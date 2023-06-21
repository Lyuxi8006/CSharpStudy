using System;
using System.CodeDom;
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
using System.Xml;
using System.Xml.Linq;

namespace WPF_MultiLingual_AppDemo
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
    }

    public class Lang
    {
        public string LblText { set; get; }
        public string BtnText { get; set; }
        public string Flag { get; set; }
        public string LangName { get; set; }
    }

    public class Languages
    {
        public List<Lang> MyLangs { get; set; } = GetLanguagesFromXML();
        public static List<Lang> GetLangs()
        {
            var langs = new List<Lang>()
            {
                new Lang() { LblText = "Please Entry Your Name", BtnText = "Click", Flag = "/Assets/English.jpg", LangName = "Englist" },
            new Lang() { LblText = "输入你的名字", BtnText = "点击", Flag = "/Assets/Chinese.jpg", LangName = "中文" },
            new Lang() { LblText = "お名前を入力してください", BtnText = "クリック", Flag = "/Assets/Japanese.jpg", LangName = "日本語" }
            };
            return langs;
        }

        const string filename = @"D:\Lyuxi\WPF\CSharpStudy\ConsoleApp1\WPF_MultiLingual_AppDemo\MyConfig.xml";
        public static List<Lang> GetLanguagesFromXML() 
        {
            var xdoc = XDocument.Load(filename);
            var langList = xdoc.Root.Descendants("Languages").Descendants("Language").Select(x=>new Lang()
            {
                LblText = x.Element("LblText").Value,
                BtnText = x.Element("BtnText").Value,
                Flag = x.Element("Flag").Value,
                LangName = x.Element("LangName").Value
            }).ToList();
            return langList;
        }

        private int _selectedIndex = GetTheActiveLanguageFromXML();

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; SetActiveLanguage(); }
        }

        public void SetActiveLanguage()
        {
            var xdoc = XDocument.Load(filename);
            xdoc.Root.Descendants("Languages").FirstOrDefault().Attribute("activeLangId").Value = SelectedIndex.ToString();
            xdoc.Save(filename);
        }
        public static int GetTheActiveLanguageFromXML()
        {
            var xdoc = XDocument.Load(filename);
            var id = int.Parse(xdoc.Root.Descendants("Languages").FirstOrDefault().Attribute("activeLangId").Value);
            return id;
        }

        public string BackgroundColor { set; get; } = GetBackgroundColorFromXML();
        public static string GetBackgroundColorFromXML()
        {
            var xdoc = XDocument.Load(filename);
            return xdoc.Root.Descendants("Colors").FirstOrDefault().Value;
        }
    }

}
