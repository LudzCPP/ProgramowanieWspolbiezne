using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Logika;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private double x;
        private double y;

        public double X
        {
            get => x;
            set
            {
                x = value;
                OnPropertyChanged();

            }
        }
        public double Y
        {
            get => y;
            set
            {
                y = value;
                OnPropertyChanged();
            }
        }

        public void OnBallChanged(object sender, BallEventArgs e)
        {
            X = e.X;
            Y = e.Y;
        }
        public double Radius { get; set; }

        public BallModel(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
