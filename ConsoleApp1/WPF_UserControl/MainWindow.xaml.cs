using System.Collections.Generic;
using System.Windows;

namespace WPF_UserControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateUC();
        }

        private void CreateUC()
        {
            var uc = new MyAddress();
            uc.AddressType = "Mailing Address";
            MyContentControl.Content = uc;
        }
        private void MyAddress_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test from MainWindow for Billing");

        }

        private void MyAddress_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test from MainWindow for Shipping");
        }
    }
    public class Shipping
    {
        public string Street { get; set; }
        public string City { get; set; }
    }
    public class Billing
    {
        public string Street { get; set; }
        public string City { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public Billing BillAddress { get; set; }
        public Shipping ShipAddress { get; set; }
    }
    public class Customers
    {
        public List<Customer> MyCustomers { get; set; } = GetCustomers();
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            var c1 = new Customer()
            {
                Name = "John Doe",
                BillAddress = new Billing()
                {
                    Street = "1 Bill Street",
                    City = "Any City"
                },
                ShipAddress = new Shipping()
                {
                    Street = "2 Ship Street",
                    City = "Any City"
                },
            };
            var c2 = new Customer()
            {
                Name = "Jane Doe",
                BillAddress = new Billing()
                {
                    Street = "100 Bill Street",
                    City = "Some City"
                },
                ShipAddress = new Shipping()
                {
                    Street = "200 Ship Street",
                    City = "Some City"
                },
            };
            customers.Add(c1);
            customers.Add(c2);
            return customers;
        }
    }


}
