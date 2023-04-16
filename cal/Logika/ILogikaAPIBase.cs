using System.Collections.Generic;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public abstract class LogikaAPIBase
    {
        public abstract Task<List<Kulka>> PobierzKulkiAsync();
        public abstract Task<Kulka> DodajKulkeAsync();
        public abstract Task AktualizujPolozenieKulkiAsync(Kulka kulka, double ograniczenieX, double ograniczenieY);
    }
}
