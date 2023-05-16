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
        public LogikaAPI(DataAPI dataAPI)
        {
            _dataAPI = dataAPI;
            punkty = new List<Ball>();
            random = new Random();
        }

        /*public override void DodajKulki(int ballsNumber, int minX, int maxX, int minY, int maxY, int radius)
        {
            var randomGenerator = new Losowosc();
            for (var i = 0; i < ballsNumber; i++)
            {
                var point = new Punkt(randomGenerator.GenerateDouble(minX, maxX), randomGenerator.GenerateDouble(minY, maxY), radius);
                Punkty.Add(point);
            }


        }*/

        public override void StworzPilke()
        {
            punkty.Add(_dataAPI.Granica.StworzPilke());
            var punkt = punkty[punkty.Count - 1];
            punkt.PositionChanged += CzyKolizja;
        }

        private static readonly ReaderWriterLockSlim blokada = new ReaderWriterLockSlim();
        private bool CzyKolizjaMiedzyPilkami(Ball punkt1, Ball punkt2)
        {
            Vector2 pozycjaPunkt1 = punkt1.Position;
            Vector2 pozycjaPunkt2 = punkt2.Position;
            int pozycja = (int)Math.Sqrt(Math.Pow((pozycjaPunkt1.X + punkt1.VectorX) - (pozycjaPunkt2.X + punkt2.VectorX), 2) + Math.Pow((pozycjaPunkt1.Y + punkt1.Y) - (pozycjaPunkt2.Y + punkt2.Y), 2));
        
            if(pozycja <= punkt1.Radius/2 + punkt2.Radius / 2)
            {
                blokada.EnterWriteLock();
                try
                {
                    int x1 = punkt1.VectorX;
                    int y1 = punkt1.VectorY;
                    int x2 = punkt2.VectorX;
                    int y2 = punkt2.VectorY;

                    punkt1.VectorX = (x1 * (punkt1.Mass - punkt2.Mass) + 2 * punkt2.Mass * x2) / (punkt1.Mass + punkt2.Mass);
                    punkt1.VectorY = (y1 * (punkt1.Mass - punkt2.Mass) + 2 * punkt2.Mass * y2) / (punkt1.Mass + punkt2.Mass);
                    punkt2.VectorX = (x2 * (punkt2.Mass - punkt1.Mass) + 2 * punkt1.Mass * x1) / (punkt1.Mass + punkt2.Mass);
                    punkt2.VectorY = (y2 * (punkt2.Mass - punkt1.Mass) + 2 * punkt1.Mass * y1) / (punkt1.Mass + punkt2.Mass);
                }
                finally
                {
                    blokada.ExitWriteLock();
                }
                return false;
            }
            return true;
        }

        /*public override void Poruszanie(int radius, int maxX, int maxY)
        {
            var randomGenerator = new Losowosc();
            for (var i = 0; i < Punkty.Count; i++)
            {
                var xShift = randomGenerator.GenerateDouble(-1, 1);
                var yShift = randomGenerator.GenerateDouble(-1, 1);
                var x = Punkty[i].X + xShift;
                var y = Punkty[i].Y + yShift;


                if (x - radius < 0) x = radius;
                if (x + radius > maxX) x = maxX - radius;
                if (y - radius < 0) y = radius;
                if (y + radius > maxY) y = maxY - radius;

                Punkty[i].Move(x, y);
            }
        }*/

        /*public override void Stop()
        {
            timer.Dispose();
            Punkty.Clear();
        }*/

        private void CzyKolizja(object sender, Zdarzenia e)
        {
            Ball punkt = (Ball)sender;
            if (punkt != null)
            {
                blokada.EnterWriteLock();
                try
                {
                    Vector2 position = punkt.Position;
                    if (position.X - punkt.Radius < 0)
                    {
                        punkt.VectorX = Math.Abs(punkt.VectorX);
                        position.X = punkt.Radius;
                    }
                    else if (position.X + punkt.Radius > _dataAPI.Granica.Szerokosc)
                    {
                        punkt.VectorX = -Math.Abs(punkt.VectorX);
                        position.X = _dataAPI.Granica.Szerokosc - punkt.Radius;
                    }

                    if (position.Y - punkt.Radius < 0)
                    {
                        punkt.VectorY = Math.Abs(punkt.VectorY);
                        position.Y = punkt.Radius;
                    }
                    else if (position.Y + punkt.Radius > _dataAPI.Granica.Wysokosc)
                    {
                        punkt.VectorY = -Math.Abs(punkt.VectorY);
                        position.Y = _dataAPI.Granica.Wysokosc - punkt.Radius;
                    }
                }
                finally
                {
                    blokada.ExitWriteLock();
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

        /*public override void Start(int radius, int maxX, int maxY)
        {
            timer = new Timer((_) => Poruszanie(radius, maxX, maxY), null, TimeSpan.Zero, TimeSpan.FromMilliseconds(16));
        }*/
    }
}
