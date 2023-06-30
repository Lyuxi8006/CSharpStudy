using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WPF_ToolBar
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
            string[] files = {
            "/Assets/arrow.png",
            "/Assets/applogoexample.png",
            "/Assets/apps.png",
            "/Assets/bell.png",
            "/Assets/bell_16.png",
            "/Assets/bell_64.png",
            "/Assets/calendarcolor.png",
            "/Assets/calendarwhite.png",
            "/Assets/cartcolor.png",
            "/Assets/cartwhite.png",
            "/Assets/chatcolor.png",
            "/Assets/chatwhite.png",
            "/Assets/closecolor.png",
            "/Assets/closewhite.png",
            "/Assets/cloud.png",
            "/Assets/contacts.png",
            "/Assets/desk.jpg",
            "/Assets/desk2.jpg",
            "/Assets/document.png",
            "/Assets/downloadsfolder.png",
            "/Assets/dropbox.png",
            "/Assets/folder.png",
            "/Assets/googledrive.png",
            "/Assets/image.png",
            "/Assets/image1.jpg",
            "/Assets/image2.jpg",
            "/Assets/image3.jpg",
            "/Assets/image4.jpg",
            "/Assets/image5.jpg",
            "/Assets/image6.jpg",
            "/Assets/image6.png",
            "/Assets/image7.jpg",
            "/Assets/image8.jpg",
            "/Assets/image9.jpg",
            "/Assets/left.png",
            "/Assets/Logo.png",
            "/Assets/logoutwhite.png",
            "/Assets/mailcolor.png",
            "/Assets/mailwhite.png",
            "/Assets/mmc.png",
            "/Assets/music.png",
            "/Assets/newdocument.png",
            "/Assets/noimage.png",
            "/Assets/notifcolor.png",
            "/Assets/notifwhite.png",
            "/Assets/onedrive.png",
            "/Assets/play.png",
            "/Assets/plus.png",
            "/Assets/profilewhite.png",
            "/Assets/profolder.png",
            "/Assets/recent.png",
            "/Assets/right.png",
            "/Assets/right2.png",
            "/Assets/search.png",
            "/Assets/searchcolor.png",
            "/Assets/searchwhite.png",
            "/Assets/settings.png",
            "/Assets/share.png",
            "/Assets/sms.png",
            "/Assets/star.png",
            "/Assets/testprofile.jpg",
            "/Assets/todobw.png",
            "/Assets/todocolor.png",
            "/Assets/trash.png",
            "/Assets/video.png",
            "/Assets/zip.png" };

            for (int i = 0; i < 100; i++)
            {
                
                int n = i % files.Length;
                var path = files[n].Split('\\');
                var fn = path[path.Length - 1];
                PB1.Value++;
                IMG.Source = new BitmapImage(new Uri(files[n], UriKind.RelativeOrAbsolute));
                await Task.Delay(200);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowDialog();

        }
    }
}
