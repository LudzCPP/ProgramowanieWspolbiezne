using System;
using System.Numerics;

namespace Dane
{
    public abstract class Ball : INotifyPositionChanged
    {
        public abstract Vector2 Position { get; }
        public abstract int Mass { get; set; }
        public abstract int Radius { get; set; }
        public abstract int Diameter { get; }
        public abstract Vector2 Velocity { get; set; }
        public abstract int X { get; }
        public abstract int Y { get; }

        public static Ball CreateAPI(Vector2 position, Vector2 velocity, int radius, int mass, Granica granica)
        {
            return new IBall(position, velocity, radius, mass, granica);
        }

        public Granica Granica { get; set; }
        public event PositionChangedEventHandler PositionChanged;
    }
}
