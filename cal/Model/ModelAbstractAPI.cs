using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public ObservableCollection<BallModel> Balls = new ObservableCollection<BallModel>();
        public abstract void DodajKulki(int ballsNumber, int minX, int maxX, int minY, int maxY, int radius);
        public abstract void CzyscStol();

        public static ModelAbstractAPI CreateAPI()
        {
            return new ModelAPI();
        }
    }
}
