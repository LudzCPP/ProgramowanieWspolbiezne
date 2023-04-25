using System.Collections;
using System.Collections.ObjectModel;

namespace Logika
{
    public abstract class ILogikaAPIBase
    {
        public List<Punkt> Punkty { get; set; }
        public abstract void DodajKulki(int ballsNumber, int minX, int maxX, int minY,
        int maxY, int radius);
        public abstract void Poruszanie(int radius, int maxX, int maxY);
        public abstract void Stop();
        public abstract void Start(int radius, int maxX, int maxY);

        public static ILogikaAPIBase CreateApi()
        {
            return new LogikaAPI();
        }

    }
}
