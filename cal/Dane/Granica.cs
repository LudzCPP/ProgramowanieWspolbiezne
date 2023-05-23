using System;
using System.Diagnostics;
using System.Numerics;

namespace Dane
{
    public class Granica
    {
        private Random losowosc = new Random();
        public int Szerokosc { get; set; }
        public int Wysokosc { get; set; }

        public Granica(int szerokosc, int wysokosc)
        {
            Szerokosc = szerokosc;
            Wysokosc = wysokosc;
        }

        public Ball StworzPilke()
        {
            int x = losowosc.Next(40, Szerokosc - 40);
            int y = losowosc.Next(40, Wysokosc - 40);
            Vector2 position = new Vector2((int)x, (int)y);
            int Vx = losowosc.Next(1, 3);
            int Vy = Vx != 0 ? losowosc.Next(1, 3) : losowosc.Next(1, 3);
            Vector2 velocity = new Vector2(Vx, Vy);

            int mass = 3;
            int radius = 25;

            return Ball.CreateAPI(position, velocity, radius, mass, this);
        }
    }
}
