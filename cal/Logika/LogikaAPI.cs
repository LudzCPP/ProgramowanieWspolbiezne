using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Timer = System.Threading.Timer;
using Dane;
using System.Numerics;
using System.Threading;

namespace Logika
{
    internal class LogikaAPI : ILogikaAPIBase
    {
        private DataAPI _dataAPI;
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public LogikaAPI(DataAPI dataAPI)
        {
            _dataAPI = dataAPI;
            punkty = new List<Ball>();
            random = new Random();
        }

        public override void StworzPilke()
        {
            punkty.Add(_dataAPI.Granica.StworzPilke());
            var punkt = punkty[punkty.Count - 1];
            punkt.PositionChanged += CzyKolizja;
        }

        private bool CzyKolizjaMiedzyPilkami(Ball punkt1, Ball punkt2)
        {
            Vector2 pozycjaPunkt1 = punkt1.Position;
            Vector2 pozycjaPunkt2 = punkt2.Position;
            int pozycja = (int)Math.Sqrt(Math.Pow((pozycjaPunkt1.X + punkt1.Velocity.X) - (pozycjaPunkt2.X + punkt2.Velocity.X), 2) + Math.Pow((pozycjaPunkt1.Y + punkt1.Velocity.Y) - (pozycjaPunkt2.Y + punkt2.Velocity.Y), 2));

            if (pozycja <= punkt1.Radius / 2 + punkt2.Radius / 2)
            {
                _semaphore.Wait();
                try
                {
                    Vector2 v1 = punkt1.Velocity;
                    Vector2 v2 = punkt2.Velocity;

                    punkt1.Velocity = new Vector2(
                        (v1.X * (punkt1.Mass - punkt2.Mass) + 2 * punkt2.Mass * v2.X) / (punkt1.Mass + punkt2.Mass),
                        (v1.Y * (punkt1.Mass - punkt2.Mass) + 2 * punkt2.Mass * v2.Y) / (punkt1.Mass + punkt2.Mass));

                    punkt2.Velocity = new Vector2(
                        (v2.X * (punkt2.Mass - punkt1.Mass) + 2 * punkt1.Mass * v1.X) / (punkt1.Mass + punkt2.Mass),
                        (v2.Y * (punkt2.Mass - punkt1.Mass) + 2 * punkt1.Mass * v1.Y) / (punkt1.Mass + punkt2.Mass));
                }
                finally
                {
                    _semaphore.Release();
                }

                return false;
            }
            return true;
        }

        private void CzyKolizja(object sender, Zdarzenia e)
        {
            Ball punkt = (Ball)sender;
            if (punkt != null)
            {
                _semaphore.Wait();
                try
                {
                    Vector2 position = punkt.Position;
                    if (position.X - punkt.Radius < 0)
                    {
                        punkt.Velocity = new Vector2(Math.Abs(punkt.Velocity.X), punkt.Velocity.Y);
                        position.X = punkt.Radius;
                    }
                    else if (position.X + punkt.Radius > _dataAPI.Granica.Szerokosc)
                    {
                        punkt.Velocity = new Vector2(-Math.Abs(punkt.Velocity.X), punkt.Velocity.Y);
                        position.X = _dataAPI.Granica.Szerokosc - punkt.Radius;
                    }

                    if (position.Y - punkt.Radius < 0)
                    {
                        punkt.Velocity = new Vector2(punkt.Velocity.X, Math.Abs(punkt.Velocity.Y));
                        position.Y = punkt.Radius;
                    }
                    else if (position.Y + punkt.Radius > _dataAPI.Granica.Wysokosc)
                    {
                        punkt.Velocity = new Vector2(punkt.Velocity.X, -Math.Abs(punkt.Velocity.Y));
                        position.Y = _dataAPI.Granica.Wysokosc - punkt.Radius;
                    }
                }
                finally
                {
                    _semaphore.Release();
                }
                foreach (var punktt in punkty)
                {
                    if (!punktt.Equals(punkt))
                    {
                        CzyKolizjaMiedzyPilkami(punkt, punktt);
                    }
                }
            }
        }
    }
}
