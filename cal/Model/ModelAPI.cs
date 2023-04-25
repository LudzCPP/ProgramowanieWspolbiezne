using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logika;

namespace Model
{
    internal class ModelAPI : ModelAbstractAPI
    {
        private readonly ILogikaAPIBase logika;
        public ModelAPI()
        {
            logika = ILogikaAPIBase.CreateApi();
        }

        public override void CzyscStol()
        {
            logika.Stop();
            Balls.Clear();
        }

        public override void DodajKulki(int ballsNumber, int minX, int maxX, int minY, int maxY, int radius)
        {
            logika.DodajKulki(ballsNumber, minX, maxX, minY, maxY, radius);
            foreach (var punkt in logika.Punkty)
            {
                var ball = new BallModel(punkt.X, punkt.Y, punkt.Radius);
                punkt.BallChanged += ball.OnBallChanged;
                Balls.Add(ball);
            }
            logika.Start(radius, maxX, maxY);
        }
    }
}
