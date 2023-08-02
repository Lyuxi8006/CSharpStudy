using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// MyAddress.xaml 的交互逻辑
    /// </summary>
    public partial class MyAddress : UserControl
    {
        public MyAddress()
        {
            InitializeComponent();
        }
        //  public string AddressType { get; set; }

        public string AddressType
        {
            get { return (string)GetValue(AddressTypeProperty); }
            set { SetValue(AddressTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddressType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddressTypeProperty =
            DependencyProperty.Register("AddressType", typeof(string), typeof(MyAddress), new PropertyMetadata(""));

        private void BtnAddress_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }
        public event RoutedEventHandler Click
        {
            add { BtnAddress.AddHandler(ButtonBase.ClickEvent, value); }
            remove { BtnAddress.AddHandler(ButtonBase.ClickEvent, value); }
        }
    }
}
