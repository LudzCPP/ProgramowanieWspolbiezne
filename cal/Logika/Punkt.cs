using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Punkt
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }

        public Punkt(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public event EventHandler<BallEventArgs> BallChanged;

        public void Move(double x, double y)
        {
            X = x;
            Y = y;
            BallChanged.Invoke(this, new BallEventArgs(X, Y));
        }

    }
    public class BallEventArgs : EventArgs
    {
        public BallEventArgs(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; } 
        public double Y { get; set; }
    }
}
