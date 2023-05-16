using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class DataAPI
    {
        public Granica Granica { get; set; }

        public static DataAPI CreateAPI(int szerokosc, int wysokosc)
        {
            return new DataAPIBase(szerokosc, wysokosc);
        }
    }
    internal class DataAPIBase : DataAPI
    {
        public DataAPIBase(int szerokosc, int wysokosc)
        {
            Granica = new Granica(szerokosc, wysokosc);
        }
    }
}
