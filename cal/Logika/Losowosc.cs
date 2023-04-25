using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Losowosc
    {
        private readonly Random _losowosc;

        public Losowosc()
        {
            _losowosc = new Random();
        }

        public double GenerateDouble(double min, double max)
        {
            return _losowosc.NextDouble() * (max - min) + min;
        }
    }
}
