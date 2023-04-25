using System.Collections;
using System.Collections.ObjectModel;
using Timer = System.Timers.Timer;

namespace Logika
{
    internal class LogikaAPI : ILogikaAPIBase
    {

        internal override void DodajKulki(ICollection<Punkt> coordinates, int ballsNumber, int minX, int maxX, int minY, int maxY, Timer timer, int radius, ObservableCollection<Punkt> coor)
        {
            var randomGenerator = new Losowosc();
            if (coordinates.Count != 0) return;
            for (var i = 0; i < ballsNumber; i++)
            {
                var point = new Punkt(randomGenerator.GenerateDouble(minX, maxX),
                    randomGenerator.GenerateDouble(minY, maxY));
                coordinates.Add(point);
            }
            if (ballsNumber == 0) return;

            var context = SynchronizationContext.Current;
            timer.Interval = 30;
            timer.Elapsed += (_, _) => context.Send(_ => Poruszanie(coor, radius, maxX, maxY), null);
            timer.AutoReset = true;
            timer.Enabled = true;

        }

        internal override void Poruszanie(ObservableCollection<Punkt> coordinates, int radius, int maxX, int maxY)
        {
            var randomGenerator = new Losowosc();
            var copy = coordinates;
            for (var i = 0; i < coordinates.Count; i++)
            {
                var xShift = randomGenerator.GenerateDouble(-1, 1);
                var yShift = randomGenerator.GenerateDouble(-1, 1);
                var newPt = new Punkt(copy[i].X + xShift, copy[i].Y + yShift);
                if (newPt.X - radius < 0) newPt = new Punkt(radius, newPt.Y);
                if (newPt.X + radius > maxX) newPt = new Punkt(maxX - radius, newPt.Y);
                if (newPt.Y - radius < 0) newPt = new Punkt(newPt.X, radius);
                if (newPt.Y + radius > maxY) newPt = new Punkt(newPt.X, maxY - radius);
                copy[i] = newPt;
            }
            coordinates = new ObservableCollection<Punkt>(copy);
        }

        internal override void Stop(Timer timer)
        {
            timer.Enabled = false;
        }

        internal override void Czyszczenie(Timer timer, IList coordinates)
        {
            Stop(timer);
            coordinates.Clear();
        }
    }
}
