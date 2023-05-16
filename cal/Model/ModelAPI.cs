using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;
using Logika;
using System.Collections.ObjectModel;

namespace Model
{
    internal class ModelAPI : ModelAbstractAPI
    {
        private readonly ILogikaAPIBase logika;
        public ModelAPI(ILogikaAPIBase logikaApi)
        {
            logika = ILogikaAPIBase.CreateApi(null);
        }

        /*public override void CzyscStol()
        {
            logika.Stop();
            Ball.Clear();
        }*/

        public override List<Ball> PobierzPilki()
        {
            return logika.punkty;
        }

        /*public override void DodajKulki(int ballsNumber, int minX, int maxX, int minY, int maxY, int radius)
        {
            logika.DodajKulki(ballsNumber, minX, maxX, minY, maxY, radius);
            foreach (var punkt in logika.Punkty)
            {
                var ball = new BallModel(punkt.X, punkt.Y, punkt.Radius);
                punkt.BallChanged += ball.OnBallChanged;
                Balls.Add(ball);
            }
            logika.Start(radius, maxX, maxY);
        }*/

        public override void StworzPilke()
        {
            logika.StworzPilke();
        }

        public override ObservableCollection<object> PobierzObiekty()
        {
            ObservableCollection<object> obiekty = new ObservableCollection<object>();
            foreach(var ball in logika.punkty)
            {
                obiekty.Add(ball);
            }
            return obiekty;
        }
    }
}
