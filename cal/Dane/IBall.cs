using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    internal class IBall : Ball
    {
        public event PositionChangedEventHandler PositionChanged;

        private Vector2 _position;
        private int _VectorX;
        private int _VectorY;
        private int _radius;
        private int _mass;

        public IBall(Vector2 position, int _VectorX, int _VectorY, int _radius, int _mass, Granica granica)
        {
            this._position = position;
            this._VectorX = VectorX;
            this._VectorY = VectorY;
            this._radius = _radius;
            this._mass = _mass;
        }

        public async Task Move()
        {
            while (true)
            {
                int newX = (int)_position.X + _VectorX;
                int newY = (int)_position.Y + _VectorY;
                Vector2 newPosition = new Vector2(newX, newY);
                setPosition(newPosition);

                double velocity = Math.Sqrt(_VectorX * _VectorX + _VectorY * _VectorY);
                await Task.Delay(TimeSpan.FromMilliseconds(2 * velocity));
            }
        }

        public override Vector2 Position
        {
            get { return _position; }
        }

        private void setPosition(Vector2 newPosition)
        {
            _position.X = newPosition.X;
            _position.Y = newPosition.Y;
            PositionChanged?.Invoke(this, new Zdarzenia(newPosition));
        }

        public override int X { get { return (int)_position.X; } }
        public override int Y { get { return (int)_position.Y; } }
        public override int VectorX
        {
            get { return _VectorX; }
            set { _VectorX = value; }
        }

        public override int VectorY
        {
            get { return _VectorY; }
            set { _VectorY = value; }
        }

        public override int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override int Diameter
        {
            get { return Radius * 2; }
        }

        public override int Mass
        {
            get { return _mass; }
            set { _mass = value; }
        }
    }
}
