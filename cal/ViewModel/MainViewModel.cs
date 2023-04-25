using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;
using Logika;
using Timer = System.Timers.Timer;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        
        private readonly ObservableCollection<Punkt> wspolrzedne;
        private readonly Timer timer;
        private readonly ILogikaAPIBase logika;

        private int numerKulki;
        private int promien;
        private readonly int szerokosc;
        private readonly int wysokosc;
        

        public ICommand DodawanieKulek { get; }
        public ICommand CzyszczenieStolu { get; }

        public MainViewModel() : this(StolBase.CreateApi()) { }

        private MainViewModel(StolBase model)
        {
            logika = new LogikaAPI();
            wspolrzedne = new ObservableCollection<Punkt>();
            promien = model.Radius;
            szerokosc = model.CanvasWidth;
            wysokosc = model.CanvasHeight;
            timer = new Timer();

            DodawanieKulek = new RelayCommand(DodajKulki);
            CzyszczenieStolu = new RelayCommand(CzyscStol);
        }

        private void DodajKulki()
        {
            logika.DodajKulki(Wspolrzedne, numerKulki, promien, szerokosc - promien, promien, wysokosc - promien, timer, promien, Coor);
        }

        private void CzyscStol()
        {
            logika.Czyszczenie(timer, Wspolrzedne);
        }

        public int NumerKulki
        {
            get => numerKulki;
            set
            {
                if (value == numerKulki) return;
                numerKulki = value;
                RaisePropertyChanged();
            }
        }

        public int Promien
        {
            get => promien;
            set
            {
                if (value == promien) return;
                promien = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Punkt> Wspolrzedne
        {
            get => wspolrzedne;
            set
            {
                if (Equals(value, wspolrzedne)) return;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Punkt> Coor
        {
            get => wspolrzedne;
            set
            {
                if (Equals(value, wspolrzedne)) return;
                RaisePropertyChanged();
            }
        }

        public int Szerokosc
        {
            get => szerokosc;
            set
            {
                if (value.Equals(szerokosc)) return;
                RaisePropertyChanged();
            }
        }

        public int Wysokosc
        {
            get => wysokosc;
            set
            {
                if (value.Equals(wysokosc)) return;
                RaisePropertyChanged();
            }
        }
    }
}
