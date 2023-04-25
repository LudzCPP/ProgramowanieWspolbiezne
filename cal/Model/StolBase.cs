using System.Threading.Tasks;


namespace Model
{
    public abstract class StolBase
    {
        public abstract int CanvasHeight { get; }
        public abstract int CanvasWidth { get; }
        public abstract int Radius { get; }

        public static StolBase CreateApi()
        {
            return new Stol();
        }
    }
}
