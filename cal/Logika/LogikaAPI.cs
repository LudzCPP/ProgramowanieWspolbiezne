using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Timer = System.Threading.Timer;

namespace Logika
{
    internal class LogikaAPI : ILogikaAPIBase
    {
        private Timer timer;

        public LogikaAPI()
        {
            Punkty = new List<Punkt>();
        }

        public override void DodajKulki(int ballsNumber, int minX, int maxX, int minY, int maxY, int radius)
        {
            var randomGenerator = new Losowosc();
            for (var i = 0; i < ballsNumber; i++)
            {
                var point = new Punkt(randomGenerator.GenerateDouble(minX, maxX), randomGenerator.GenerateDouble(minY, maxY), radius);
                Punkty.Add(point);
            }


        }

        public override void Poruszanie(int radius, int maxX, int maxY)
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
        }

        public override void Stop()
        {
            timer.Dispose();
            Punkty.Clear();
        }


        public override void Start(int radius, int maxX, int maxY)
        {
            timer = new Timer((_) => Poruszanie(radius, maxX, maxY), null, TimeSpan.Zero, TimeSpan.FromMilliseconds(16));
        }
    }
}
