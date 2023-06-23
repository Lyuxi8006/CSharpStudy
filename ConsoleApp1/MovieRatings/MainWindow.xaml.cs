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

namespace MovieRatings
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
    public class Movie
    {
        public string Title { get; set; }
        public int Rating { get; set; }
    }

    public class Movies
    {
        public List<Movie> MovieList { get; set; } = GetMovies();
        public static List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie(){Title="Move ONE", Rating = 3},
                new Movie(){Title="Move TWO", Rating = 4},
                new Movie(){Title="Move THREE", Rating = 5}
            }.ToList();
        }
    }
}
