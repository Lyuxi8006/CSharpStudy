using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

namespace DataBinding
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

    public class Book
    {
       
        public int ID { get; set; }
        public string Title { get; set; }
        public Book()
        {
        }
    };
    public class Student
    {
        public int ID { get; set; } = 1;
        public string NAME { get; set; } = "Sam";

        public List<Book> BOOKS { get; set; }

        public Student()
        {
            BOOKS = new List<Book>()
            {
                new Book()
                {
                    ID = 2,
                    Title = "Databinding In WPF"
                },
                new Book()
                {
                    ID = 2,
                    Title = "DataContext In WPF"
                }

            };

        }
    }
}
