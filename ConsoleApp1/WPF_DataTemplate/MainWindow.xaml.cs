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

namespace WPF_DataTemplate
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

    public class Products
    {
        public List<Product> MyProducts { get; set; } = GetProducts();
        public static List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product() { Id =1, ProdName="Milk", Dep=Dep.Dairy},
                new Product() { Id =2, ProdName="Juice", Dep=Dep.Dairy},
                new Product() { Id =3, ProdName="Water", Dep=Dep.Candy},
                new Product() { Id =1, ProdName="Candy Bar", Dep=Dep.Candy},
                new Product() { Id =2, ProdName="Chips", Dep=Dep.Snack},
                new Product() { Id =3, ProdName="Gingerale", Dep=Dep.Soda}
            };
        }
        public Product Product { set; get; } = new Product()
        {
            Id = 20,
            ProdName = "Ice Cream"
        };
    }
    public class Product
    {
        public int Id { get; set; }
        public string ProdName { get; set; }
        public Dep Dep { get; set; }
    }
    public enum Dep
    {
        Dairy,Snack,Candy,Soda
    }
}
