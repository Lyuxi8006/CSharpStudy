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

namespace WPF_CheckBox
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

        private void CHX1_Checked(object sender, RoutedEventArgs e)
        {
            CHX2.IsChecked = true;
            CHX2.IsEnabled = true;
            CHX3.IsChecked = true;
            CHX3.IsEnabled = true;
            CHX4.IsChecked = true;
            CHX4.IsEnabled = true;

        }

        private void CHX1_Unchecked(object sender, RoutedEventArgs e)
        {
            CHX2.IsChecked = false;
            CHX2.IsEnabled = false;
            CHX3.IsChecked = false;
            CHX3.IsEnabled = false;
            CHX4.IsChecked = false;
            CHX4.IsEnabled = false;

        }

        private void CHX1_Indeterminate(object sender, RoutedEventArgs e)
        {
            CHX2.IsChecked = true;
            CHX2.IsEnabled = true;
            CHX3.IsChecked = true;
            CHX3.IsEnabled = true;
            CHX4.IsChecked = false;
            CHX4.IsEnabled = false;
        }
    }
}
