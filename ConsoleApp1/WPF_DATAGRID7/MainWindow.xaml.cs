using System;
using System.CodeDom;
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

namespace WPF_DATAGRID7
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

        const string file = @"D:\Lyuxi\WPF\CSharpStudy\ConsoleApp1\WPF_DATAGRID7\Assets\songs.CSV";
        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

            var numofSongsInFile = File.ReadAllLines(file).Length;
            if (numofSongsInFile < Songs.SongList.Count)
            {
                Song newsong = e.Row.DataContext as Song;
                AddNewSong(newsong);
            }
            else

            {
                UpdateSong();
            }
            
        }
        private void GRD_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var source = e.OriginalSource.GetType().Name;
            if (e.Key == Key.Delete && source == "DataGridCell")
            {
                var result = MessageBox.Show("Are You Sure?", "Delete Song", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    var song = GRD.SelectedItem as Song;
                    DeleteSong(song);
                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tbx = sender as TextBox;
            if (tbx.Text != "") 
            {
                var filteredList = Songs.SongList.Where(x=>x.Title.ToLower().Contains(tbx.Text.ToLower()));
                GRD.ItemsSource = null;
                GRD.ItemsSource = filteredList;
            }
            else
            {
                GRD.ItemsSource = Songs.SongList;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dg = new DataGrid();
            dg.ItemsSource = Songs.SongList;
            STKPN.Children.Add(dg);
        }


        void UpdateSong() 
        {
            string lines = "";
            foreach(var s in Songs.SongList)
            {
                lines += $"{s.Id},{s.Title},{s.Genre},{s.Artist},{s.MovieTitle},{s.ResealeYear.Year},{s.URL}\n"; 
            }
            File.WriteAllText(file, lines);
        }
        void AddNewSong(Song song) 
        {
            File.AppendAllText(file, $"{song.Id},{song.Title},{song.Genre},{song.Artist},{song.MovieTitle},{song.ResealeYear.Year},{song.URL}\n");
        }
        void DeleteSong(Song song)
        {
            string lines = "";
            foreach (var s in Songs.SongList)
            {
                if (song.Id != s.Id)
                {
                    lines += $"{s.Id},{s.Title},{s.Genre},{s.Artist},{s.MovieTitle},{s.ResealeYear.Year},{s.URL}\n";
                }
            }
            File.WriteAllText(file, lines);
        }
    }
    public class Songs
    {
        public static List<Song> SongList { get; set; } = GetSongs();
        public static List<Song> GetSongs()
        {
            var file = @"D:\Lyuxi\WPF\CSharpStudy\ConsoleApp1\WPF_DATAGRID7\Assets\songs.CSV";
            var lines = File.ReadAllLines(file);
            var list = new List<Song>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split(',');
                var g = line[2].Split(' ', '&', '-');
                var gr = g.Length > 1 ? g[0] + g[1] : g[0];
                var artists = new List<Artist>();
                if (line.Length > 6)
                {
                    for (int j = 6; j < line.Length; ++j)
                    {
                        var artist = new Artist() { Name = line[j] };
                        artists.Add(artist);
                    }
                }
                var song = new Song()
                {
                    Id = int.Parse(line[0]),
                    Title = line[1],
                    Artist = line[3],
                    IsSoundtrack = line[4] == "Unknown" ? false : true,
                    MovieTitle = line[4],
                    Genre = (Genre)Enum.Parse(typeof(Genre), gr),
                    ResealeYear = DateTime.Parse(line[5] + ",1,1"),
                    URL = new Uri($"www.{line[3]}.com", UriKind.Relative),
                    Artists = artists

                };
                list.Add(song);
            }
            return list;
        }


    }
    public class Artist
    {
        public string Name { get; set; }
    }
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public bool IsSoundtrack { get; set; }
        public string MovieTitle { get; set; }
        public Genre Genre { get; set; }
        public DateTime ResealeYear { get; set; }
        public Uri URL { get; set; }
        public List<Artist> Artists { get; set; }
    }
    public enum Genre
    {
        HeavyMetal, HardRock, SoftRock, ClassicRock, Rock, Pop, PopSoul, Soul, Blues, Jazz, RB, Country, Folk, Funk, Classical, ChristmasCarol
    }
}
