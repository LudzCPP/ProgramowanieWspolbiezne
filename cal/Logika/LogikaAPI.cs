using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public class LogikaAPI : LogikaAPIBase
    {
        private readonly DataAPIBase _dataAPI;

        public LogikaAPI(DataAPIBase dataAPI)
        {
            _dataAPI = dataAPI;
        }

        public override Task<List<Kulka>> PobierzKulkiAsync()
        {
            return _dataAPI.PobierzKulkiAsync();
        }

        public override Task<Kulka> DodajKulkeAsync()
        {
            return _dataAPI.DodajKulkeAsync();
        }

        public override async Task AktualizujPolozenieKulkiAsync(Kulka kulka, double ograniczenieX, double ograniczenieY)
        {
            double nowaPozycjaX = kulka.PozycjaX + kulka.PredkoscX;
            double nowaPozycjaY = kulka.PozycjaY + kulka.PredkoscY;

            if (nowaPozycjaX < 0 || nowaPozycjaX > ograniczenieX)
            {
                kulka.PredkoscX = -kulka.PredkoscX;
            }

            if (nowaPozycjaY < 0 || nowaPozycjaY > ograniczenieY)
            {
                kulka.PredkoscY = -kulka.PredkoscY;
            }

            kulka.PozycjaX += kulka.PredkoscX;
            kulka.PozycjaY += kulka.PredkoscY;

            await Task.CompletedTask;
        }
    }
}
