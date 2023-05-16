using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<object> obiekty;

        public abstract ObservableCollection<object> PobierzObiekty();

        public static ViewModelBase CreateViewModelAPI()
        {
            return new MainViewModel();
        }

        public ObservableCollection<object> Obiekty
        {
            get => obiekty;
            set
            {
                obiekty = value;
                OnPropertyChanged();
            }
        }

        public abstract void StworzPilke();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}