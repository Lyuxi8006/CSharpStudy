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

namespace WPF_Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void C3_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime d = DateTime.Parse("1/1/2020");
            for (int i = 0; i < 366; ++i)
            {
                if (d.AddDays((double)i).DayOfWeek == DayOfWeek.Wednesday)
                { 
                    Calendar3.BlackoutDates.Add(new CalendarDateRange(d.AddDays((double)i)));
                }
            }
        }
    }
}
