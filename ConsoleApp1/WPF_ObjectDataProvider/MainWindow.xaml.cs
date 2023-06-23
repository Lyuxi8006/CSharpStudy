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

namespace WPF_ObjectDataProvider
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
    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Fall
    }
    public enum Genre
    {
        History,
        Technology,
        Novel
    }

    public class Book
    {
        public string Title { get; set; }
        public Genre Genre { get; set;}
    }

    public class Books
    {
        public static List<Book> GetBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Title = "XMLDataProvider",
                    Genre = Genre.History
                },
                new Book()
                {
                    Title = "Object Data Provider",
                    Genre = Genre.Novel
                },
                new Book()
                {
                    Title = "Binding to Enums",
                    Genre = Genre.Technology
                }
            }.ToList();
            return books;
        }
        public static List<Book> GetBooks2(string bookType)
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Title = "XMLDataProvider",
                    Genre = Genre.History
                },
                new Book()
                {
                    Title = "Object Data Provider",
                    Genre = Genre.Novel
                },
                new Book()
                {
                    Title = "Binding to Enums",
                    Genre = Genre.Technology
                }
            }.Where(book=>book.Genre.ToString() == bookType).ToList();
            return books;
        }
    }
}
