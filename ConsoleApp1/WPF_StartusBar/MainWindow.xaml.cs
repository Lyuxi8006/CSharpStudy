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

namespace WPF_StartusBar
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

        private async void btnPB_Click(object sender, RoutedEventArgs e)
        {

            string[] files = { "/Assets/male_icon.png", "/Assets/Pontiac.png","/Assets/star_gold.png",
                "/Assets/arrow.png","/Assets/book_img.png","/Assets/Chevy.png","/Assets/Ford.png" };
            for (int i = 0; i < 100; i++)
            {
      

                int n = i % files.Length;
                var path = files[n].Split('\\');
                var fn = path[path.Length - 1];
                TextFN.Text = fn;
                PB1.Value++;
                IMG.Source = new BitmapImage(new Uri(files[n], UriKind.RelativeOrAbsolute));
                await Task.Delay(200);
            }
        }
    }
}
