using System.Collections;
using System.Collections.ObjectModel;

namespace Logika
{
    public abstract class ILogikaAPIBase
    {
        internal abstract void DodajKulki(ICollection<Punkt> coordinates, int ballsNumber, int minX, int maxX, int minY,
        int maxY, System.Timers.Timer timer, int radius, ObservableCollection<Punkt> coor);
        internal abstract void Poruszanie(ObservableCollection<Punkt> coordinates, int radius, int maxX, int maxY);
        internal abstract void Stop(System.Timers.Timer timer);
        internal abstract void Czyszczenie(System.Timers.Timer timer, IList coordinates);

        internal static ILogikaAPIBase CreateApi()
        {
            return new LogikaAPI();
        }
    }
}
