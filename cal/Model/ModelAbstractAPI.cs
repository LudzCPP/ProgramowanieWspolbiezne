using Dane;
using Logika;
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
        public abstract ObservableCollection<object> PobierzObiekty();
        public abstract void StworzPilke();

        public abstract List<Ball> PobierzPilki();
        /*public abstract void DodajKulki(int ballsNumber, int minX, int maxX, int minY, int maxY, int radius);
        public abstract void CzyscStol();*/

        public static ModelAbstractAPI CreateAPI(ILogikaAPIBase logikaAPI)
        {
            return new ModelAPI(logikaAPI);
        }
    }
}
