using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WPF_TreeView02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateTreeView();
        }
        private void CreateTreeView()
        {
            var cat = new Category() { CategoryName = "Produce", SubCategories = new List<SubCategory>() };
            var sub = new SubCategory() { SubCategoryName = "Vegatables", Items = new List<Item>() };
            var item = new Item() { ItemName = "Tomatoes" };
            cat.SubCategories.Add(sub);
            sub.Items.Add(item);
            TreeView t = new TreeView();
            TreeViewItem tv1 = new TreeViewItem();
            tv1.Header = cat.CategoryName;
            TreeViewItem tv2 = new TreeViewItem();
            tv2.Header = sub.SubCategoryName;
            TreeViewItem tv3 = new TreeViewItem();
            tv3.Header = item.ItemName;
            tv1.Items.Add(tv2);
            tv2.Items.Add(tv3);
            t.Items.Add(tv1);
            MyDock.Children.Add(t);
        }
    }

    public class Category
    {
        public string CategoryName { set; get; }
        public List<SubCategory> SubCategories { set; get; }    
    }
    public class SubCategory 
    {
        public string SubCategoryName { set; get;}
        public List<Item> Items { set; get; }
    }
    public class Item
    {
        public string ItemName { set; get; }
    }

    public class Songs
    {
        public static List<Song> SongList { get; set; } = GetSongs();
        public static List<Song> GetSongs()
        {
            var file = @"D:\Lyuxi\WPF\CSharpStudy\ConsoleApp1\WPF_TreeView02\Assets\songs.CSV";
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
