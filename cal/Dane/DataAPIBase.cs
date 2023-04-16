using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class DataAPIBase
    {
        public abstract Task<List<Kulka>> PobierzKulkiAsync();
        public abstract Task<Kulka> DodajKulkeAsync();
    }
}
