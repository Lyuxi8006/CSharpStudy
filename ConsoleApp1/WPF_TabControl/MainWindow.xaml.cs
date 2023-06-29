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

namespace WPF_TabControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TabControl tc = new TabControl();
            TabItem ti = new TabItem();
            ti.Header = "tab one";
            TextBlock txt = new TextBlock();
            txt.Text = "l'm a textblock";
            tc.Items.Add(ti);

            GRD.Children.Add(tc);
        }
    }
}
