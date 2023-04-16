using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dane
{
    public class DataAPI : DataAPIBase
    {
        private List<Kulka> _kulki;
        private readonly Random _random;

        public DataAPI()
        {
            _kulki = new List<Kulka>();
            _random = new Random();
        }

        public override Task<List<Kulka>> PobierzKulkiAsync()
        {
            return Task.FromResult(_kulki);
        }

        public override Task<Kulka> DodajKulkeAsync()
        {
            var kulka = new Kulka
            {
                Id = Guid.NewGuid(),
                PozycjaX = _random.Next(0, 100),
                PozycjaY = _random.Next(0, 100),
                PredkoscX = _random.Next(-5, 5),
                PredkoscY = _random.Next(-5, 5)
            };

            _kulki.Add(kulka);
            return Task.FromResult(kulka);
        }
    }
}
