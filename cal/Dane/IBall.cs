using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Dane
{
    internal class IBall : Ball
    {
        public event PositionChangedEventHandler PositionChanged;

        private Vector2 _position;
        private Vector2 _velocity;
        private int _radius;
        private int _mass;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public IBall(Vector2 position, Vector2 velocity, int radius, int mass, Granica granica)
        {
            _position = position;
            _velocity = velocity;
            _radius = radius;
            _mass = mass;
            Granica = granica;
            Task.Run(() => Move());
        }

        private TimeSpan ComputeDelay()
        {
            return TimeSpan.FromMilliseconds(2 * _velocity.Length());
        }

        public async Task Move()
        {
            while (!_cts.Token.IsCancellationRequested)
            {
                _position += _velocity;

                await Task.Delay(ComputeDelay(), _cts.Token);
                PositionChanged?.Invoke(this, new Zdarzenia(_position));
            }
        }

        public override Vector2 Position
        {
            get => _position;
        }

        public override int X => (int)_position.X;
        public override int Y => (int)_position.Y;

        public override Vector2 Velocity
        {
            get => _velocity;
            set => _velocity = value;
        }

        public override int Radius
        {
            get => _radius;
            set => _radius = value;
        }

        public override int Diameter => _radius * 2;

        public override int Mass
        {
            get => _mass;
            set => _mass = value;
        }
    }
}
