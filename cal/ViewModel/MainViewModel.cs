using System.Collections.ObjectModel;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        
        private readonly ObservableCollection<BallModel> wspolrzedne;
        private readonly ModelAbstractAPI model;

        private int numerKulki;
        private int promien;
        private readonly int szerokosc;
        private readonly int wysokosc;
        

        public ICommand DodawanieKulek { get; }
        public ICommand CzyszczenieStolu { get; }

        public MainViewModel() : this(StolBase.CreateApi()) { }

        private MainViewModel(StolBase stolModel)
        {
            wspolrzedne = new ObservableCollection<BallModel>();
            promien = stolModel.Radius;
            szerokosc = stolModel.CanvasWidth;
            wysokosc = stolModel.CanvasHeight;
            model = ModelAbstractAPI.CreateAPI();

            DodawanieKulek = new RelayCommand(DodajKulki);
            CzyszczenieStolu = new RelayCommand(CzyscStol);
        }

        private void DodajKulki()
        {
            model.DodajKulki(NumerKulki, promien, szerokosc-promien, promien, wysokosc-promien, promien);
        }

        private void CzyscStol()
        {
            model.CzyscStol();
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

        public ObservableCollection<BallModel> Wspolrzedne
        {
            get => model.Balls;
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
