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

namespace MasterDetailDemo
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
    public class Car
    {
        public string MAKE { get; set; }
        public string MODEL { get; set; }
        public string PHOTO { get; set; }
    }
    public class Cars
    { 
        public static List<Car> GetCars()
        {
            var cars = new List<Car>()
            {
                new Car() { MAKE = "Pontiac", MODEL = "TransAM", PHOTO = "/Assets/Pontiac.png"},
                new Car() { MAKE = "Ford", MODEL = "Mustang" , PHOTO = "/Assets/Ford.png"},
                new Car() { MAKE = "Chevy", MODEL = "Camaro" , PHOTO = "/Assets/Chevy.png"}
           };
            return cars;
        }
        public List<Car> CARLIST { get; set; } = GetCars(); 
    }
}
