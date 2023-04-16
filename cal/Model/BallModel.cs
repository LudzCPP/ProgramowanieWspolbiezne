using System.Threading.Tasks;
using Dane;
using Logika;

namespace Model
{
    public class BallModel : IBallModel
    {
        private Kulka _kulka;
        private LogikaAPIBase _logikaAPI;

        public BallModel(Kulka kulka, LogikaAPIBase logikaAPI)
        {
            _kulka = kulka;
            _logikaAPI = logikaAPI;
        }

        public override Kulka Kulka => _kulka;

        public override async Task MoveAsync(double ograniczenieX, double ograniczenieY)
        {
            await _logikaAPI.AktualizujPolozenieKulkiAsync(_kulka, ograniczenieX, ograniczenieY);
        }
    }
}
