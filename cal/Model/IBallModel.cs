using System.Threading.Tasks;
using Dane;

namespace Model
{
    public abstract class IBallModel
    {
        public abstract Kulka Kulka { get; }
        public abstract Task MoveAsync(double ograniczenieX, double ograniczenieY);
    }
}
