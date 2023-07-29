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

namespace WPF_ToggleButton
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

        private void btnToggle1_Checked(object sender, RoutedEventArgs e)
        {
            T1.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void btnToggle1_Unchecked(object sender, RoutedEventArgs e)
        {
            T2.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void btnToggle1_Click(object sender, RoutedEventArgs e)
        {
 
            T3.Foreground = new SolidColorBrush(Colors.Red);
            if (btnToggle1.IsChecked == true) 
            {
                T1.Background = new SolidColorBrush(Colors.Red);
            }
            else if (btnToggle1.IsChecked == null)
            {
                T2.Background = new SolidColorBrush(Colors.LightGray);
            }
            else if (btnToggle1.IsChecked == false)
            {
                T3.Background = new SolidColorBrush(Colors.Blue);
            }
        }
    }
}
