using Dane;
using System.Numerics;

public delegate void PositionChangedEventHandler(object sender, Zdarzenia e);

namespace Dane
{
    public class Zdarzenia
    {
        public Vector2 Position { get; private set; }

        public Zdarzenia(Vector2 position)
        {
            Position = position;
        }
    }
}
public interface INotifyPositionChanged
{
    event PositionChangedEventHandler PositionChanged;
}