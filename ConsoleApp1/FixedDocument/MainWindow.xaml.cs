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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FixedDocument
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CteatePage();
        }
        void CteatePage()
        {
            ListBox lbx = new ListBox();
            for (int i = 0; i < 50; i++)
            {
                lbx.Items.Add("Book " + i);
            }
            PageContent pc = new PageContent();
            FixedPage fp = new FixedPage();
            fp.Children.Add(lbx);
            ((IAddChild)pc).AddChild(fp);
            FxDoc.Pages.Add(pc);
        }
    }
}
