using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ACK_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        private double _PureValue;

        public double PureValue
        {
            get { return _PureValue; }
            set
            {
                if (_PureValue != value)
                {
                    _PureValue = value;
                    Tax = PureValue * 0.24;
                    TotalPrice = PureValue + Tax;
                    OnPropertyChanged(nameof(PureValue));
                }
            }
        }


        private Double _Tax;

        public Double Tax
        {
            get { return _Tax; }
            set
            {
                if (_Tax != value)
                {
                    _Tax = value;
                    OnPropertyChanged(nameof(Tax));
                }
            }
        }


        private Double _TotalPrice;

        public Double TotalPrice
        {
            get { return _TotalPrice; }
            set
            {
                if (_TotalPrice != value)
                {
                    _TotalPrice = value;
                    PureValue = TotalPrice / 1.24;
                    Tax= PureValue * 0.24;
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }



        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Members

    }
}
