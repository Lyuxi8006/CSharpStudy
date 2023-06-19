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

namespace CustomStringFormatting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CustomFormatter();
        }

        private void CustomFormatter()
        {
            // 0, #, period, %,
            int NUMBER = 123;
            double TEMPERATURE = 23.5;
            decimal perMile = 0.25m;
            long PHONE = 1234567890;

            //tblk1.Text = $"{NUMBER} Any St\nSomeCity 12345";
            //tblk1.Text = $"Your number in que is {NUMBER:#}";
            //tblk2.Text = $"Your number in que is {NUMBER:0}";
            //tblk1.Text = $"The ride costs{perMile:#:##} cents";
            //tblk2.Text = $"The ride costs{perMile:0:00} cents";
            //tblk1.Text = $"Ticket#: {NUMBER:######}";
            //tblk2.Text = $"Ticket#: {NUMBER:000000}";
            //tblk1.Text = $"The percentage : {perMile:#.##%}";
            //tblk2.Text = $"The percentage : {perMile:0.00%}";
            //tblk1.Text = $"The Current Temperature : {TEMPERATURE:#.##%}";
            //tblk2.Text = $"The Current Temperature : {TEMPERATURE:0.00%}";
            //tblk1.Text = $"The phone number is : {PHONE:###-###-####}";
            //tblk2.Text = $"The phone number is : {PHONE:(000)-000-0000}";
            tblk1.Text = $"Your balance is : {123456.78 /2:#,###.###}";
            tblk2.Text = $"Your total is : {123456789.29:0, 000.000}";

        }
    }

}
