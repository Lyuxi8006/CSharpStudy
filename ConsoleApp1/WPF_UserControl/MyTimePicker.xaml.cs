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

namespace WPF_UserControl
{
    /// <summary>
    /// MyTimePicker.xaml 的交互逻辑
    /// </summary>
    public partial class MyTimePicker : UserControl
    {
        public MyTimePicker()
        {
            InitializeComponent();
            tbxTimePicker.Text = $"{hour:00} : {min:00}";
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
    }
}
