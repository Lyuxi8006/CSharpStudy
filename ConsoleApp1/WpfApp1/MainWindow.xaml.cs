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

namespace WpfApp1
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        public void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    public class MainViewModel : ViewModelBase
    {
        private int curValue = 1;
        private int maxValue = 32;

        public int CurValue
        {
            get { return curValue; }
            set { curValue = value; NotifyPropertyChanged("CurValue"); }
        }
        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; NotifyPropertyChanged("MaxValue"); }
        }
        public MainViewModel()
        {

        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (this.DataContext is MainViewModel model)
            {
                if (model.CurValue < model.MaxValue)
                {
                    model.CurValue += 1;
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is MainViewModel model)
            {
                if (model.CurValue > 1)
                {
                    model.CurValue -= 1;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is MainViewModel model)
            {
                if (model.MaxValue > 1)
                {
                    model.MaxValue += 1;
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is MainViewModel model)
            {
                if (model.MaxValue > 1 && model.MaxValue > model.CurValue)
                {
                    model.MaxValue -= 1;
                }
            }
        }
    }
}
