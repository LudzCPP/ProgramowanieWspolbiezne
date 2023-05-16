using System.Collections;
using System.Collections.ObjectModel;
using Dane;

namespace Logika
{
    public abstract class ILogikaAPIBase
    {
        public List<Ball> punkty;
        public Random random;

        /*public abstract void DodajKulki(int ballsNumber, int minX, int maxX, int minY,
        int maxY, int radius);
        public abstract void Poruszanie(int radius, int maxX, int maxY);
        public abstract void Stop();
        public abstract void Start(int radius, int maxX, int maxY);*/
        


        public static ILogikaAPIBase CreateApi(DataAPI dataAPI)
        {
                return new LogikaAPI(DataAPI.CreateAPI(300, 150));
        }

        public abstract void StworzPilke();
    }
}
