using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class Ball:INotifyPositionChanged
    {
        public abstract Vector2 Position { get; }
        public abstract int Mass { get; set; }
        public abstract int X { get; }
        public abstract int Y { get; }
        public abstract int VectorX { get; set; }
        public abstract int VectorY { get; set; }
        public abstract int Radius { get; set; }
        public abstract int Diameter { get; }

        public static Ball CreateAPI(Vector2 pozycja, int VectorX, int VectorY, int radius, int mass, Granica granica)
        {
            return new IBall(pozycja, VectorX, VectorY, radius, mass, granica);
        }

        public Granica Granica { get; set; }
        public event PositionChangedEventHandler PositionChanged;

        
    }

}

