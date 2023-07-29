using System;
using System.Collections.Generic;
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

namespace WPF_RepeatButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbxTimePicker.Text = $"{hour:00} : {min:00}";
        }

        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            var num = int.Parse(TBX.Text);
            num += 1;
            TBX.Text = num.ToString();
        }

        int hour = DateTime.Now.Hour;
        int min = DateTime.Now.Minute;
        private void btnIncreaseHour_Click(object sender, RoutedEventArgs e)
        {

            hour++;
            if (hour == 23)
            {
                hour = 0;
            }
            tbxTimePicker.Text = $"{hour:00} : {min:00}";
        }

        private void btnDecreaseHour_Click(object sender, RoutedEventArgs e)
        {
            hour++;
            if (hour == -1)
            {
                hour = 23;
            }
            tbxTimePicker.Text = $"{hour:00} : {min:00}";
        }

        private void btnIncreaseMins_Click(object sender, RoutedEventArgs e)
        {
            min++;
            if (min == 60)
            {
                min = 0;
            }
            tbxTimePicker.Text = $"{hour:00} : {min:00}";
        }

        private void btnDecreaseMins_Click(object sender, RoutedEventArgs e)
        {
            min--;
            if (min == -1)
            {
                min = 59;
            }
            tbxTimePicker.Text = $"{hour:00} : {min:00}";
        }

        private void btnExpand_Click(object sender, RoutedEventArgs e)
        {
            MyLine.X2 += 2;
        }
    }

}
