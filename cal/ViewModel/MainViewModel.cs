using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Logika;
using Model;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly LogikaAPIBase _logikaAPI;
        private List<IBallModel> _kulki;
        private ICommand _dodajKulkeCommand;
        private ICommand _aktualizujPolozenieKulkiCommand;

        public MainViewModel(LogikaAPIBase logikaAPI)
        {
            _logikaAPI = logikaAPI;
            _kulki = new List<IBallModel>();
            LoadBalls();
        }

        public List<IBallModel> Kulki
        {
            get { return _kulki; }
            set
            {
                _kulki = value;
                OnPropertyChanged();
            }
        }

        public ICommand DodajKulkeCommand
        {
            get
            {
                return _dodajKulkeCommand ??= new RelayCommand(async () => await DodajKulkeAsync());
            }
        }

        public ICommand AktualizujPolozenieKulkiCommand
        {
            get
            {
                return _aktualizujPolozenieKulkiCommand ??= new RelayCommand<double[]>(async param => await AktualizujPolozenieKulkiAsync(param[0], param[1]));
            }
        }

        private async Task LoadBalls()
        {
            var kulkiDane = await _logikaAPI.PobierzKulkiAsync();
            foreach (var kulka in kulkiDane)
            {
                _kulki.Add(new BallModel(kulka, _logikaAPI));
            }
            OnPropertyChanged(nameof(Kulki));
        }

        private async Task DodajKulkeAsync()
        {
            var kulka = await _logikaAPI.DodajKulkeAsync();
            _kulki.Add(new BallModel(kulka, _logikaAPI));
            OnPropertyChanged(nameof(Kulki));
        }

        private async Task AktualizujPolozenieKulkiAsync(double ograniczenieX, double ograniczenieY)
        {
            foreach (var kulka in _kulki)
            {
                await kulka.MoveAsync(ograniczenieX, ograniczenieY);
            }
            OnPropertyChanged(nameof(Kulki));
        }
    }
}
