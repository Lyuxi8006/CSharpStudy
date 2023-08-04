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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowDocument
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if(pd.ShowDialog() == true ) 
            {
                IDocumentPaginatorSource ipd = FlowDoc;
                pd.PrintDocument(ipd.DocumentPaginator, "Flow Document");
            }
        }


        private void SaveTXT_Click(object sender, RoutedEventArgs e)
        {
            TextRange range;
            FileStream stream;
            range = new TextRange(RichTBX.Document.ContentStart, RichTBX.Document.ContentEnd);
            stream = new FileStream("myRTBcontent.txt", FileMode.Create);
            range.Save(stream, DataFormats.Text);
        }

        private void SaveXAML_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("myRTBcontent.xaml"))
            {
                TextRange range;
                FileStream stream;
                range = new TextRange(RichTBX.Document.ContentStart, RichTBX.Document.ContentEnd);
                stream = new FileStream("myRTBcontent.xaml", FileMode.Create);
                range.Save(stream, DataFormats.XamlPackage);
            }
        }

        private void SaveRTF_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("myRTBcontent.rtf"))
            {
                TextRange range;
                FileStream stream;
                range = new TextRange(RichTBX.Document.ContentStart, RichTBX.Document.ContentEnd);
                stream = new FileStream("myRTBcontent.rtf", FileMode.Create);
                range.Save(stream, DataFormats.Rtf);
            }
            else
            {
                MessageBox.Show("file already exists");
            }
        }
    }
}
