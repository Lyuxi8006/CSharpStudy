using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_ProgressBar
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
            //ProgressBar pb = new ProgressBar();

            //pb.Height = 10;
            //Duration duration = new Duration(TimeSpan.FromSeconds(3));
            //DoubleAnimation db = new DoubleAnimation(100, duration);
            //pb.BeginAnimation(ProgressBar.ValueProperty, db);
            //SP.Children.Add(pb);

            string[] files = { "/Assets/male_icon.png", "/Assets/Pontiac.png","/Assets/star_gold.png",
                "/Assets/arrow.png","/Assets/book_img.png","/Assets/Chevy.png","/Assets/Ford.png" };
            for (int i = 0; i < 100; i++) 
            {
                await Task.Delay(200);
                LBX1.Items.Add("item " + i+1);
                PB1.Value ++ ;
                int n = i % files.Length;
                IMG.Source = new BitmapImage(new Uri(files[n], UriKind.RelativeOrAbsolute));
            }

        }
    }
}
