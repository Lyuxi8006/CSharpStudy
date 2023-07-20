using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WPF_TreeView3
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
        public string SubCategoryName { set; get; }
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
            var file = @"D:\Lyuxi\WPF\CSharpStudy\ConsoleApp1\WPF_TreeView3\Assets\songs.CSV";
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
    public class Book
    {
        public string BoolTitle { get; set; }
        public List<Chapter> Chapters { get; set; }
    }

    public class Chapter
    {
        public int PageNum { get; set; }
        public string ChapterTitle { set; get; }
        public List<Article> Articles { get; set; }
    }

    public class Article
    {
        public int PageNum { get; set; }
        public string ArticleTitle { get; set; }
    }
    public class Books
    {
        public List<Book> BookList { get; set; } = GetBooks();
        public static List<Book> GetBooks()
        {
            var books = new List<Book>();
            books.Add(
                new Book()
                {
                    BoolTitle = "Book One",
                    Chapters = new List<Chapter>()
                    {
                        new Chapter()
                        {
                            PageNum = 10,
                            ChapterTitle = "Introduction"
                        },
                        new Chapter()
                        {
                            PageNum = 11,
                            ChapterTitle = "Chapter One",
                            Articles = new List<Article>()
                            {
                                new Article()
                                {

                                    PageNum = 12,
                                    ArticleTitle = "Article One"
                                }

                            }
                        }
                    }
                }
                );
            books.Add(
                new Book()
                {
                    BoolTitle = "Book Two",
                    Chapters = new List<Chapter>()
                    {
                        new Chapter()
                        {
                            PageNum = 10,
                            ChapterTitle = "Introduction"
                        },
                        new Chapter()
                        {
                            PageNum = 11,
                            ChapterTitle = "Chapter One",
                            Articles = new List<Article>()
                            {
                                new Article()
                                {

                                    PageNum = 12,
                                    ArticleTitle = "Article One"
                                },
                                new Article()
                                {

                                    PageNum = 22,
                                    ArticleTitle = "Article Two"
                                }

                            }
                        }
                    }
                }
                );
            return books;
        }
    }


    public class DIR
    {
        public DirectoryInfo DIRINFO { get; set; }
        public List<FILE> FILELIST { get; set; }
    }
    public class FILE
    {
        public FileInfo FILEINFO { get; set; }
    }
    public class Dirs
    {
        public List<DIR> DIRLIST { get; set; } = GetDrv();

        private static List<DIR> GetDrv()
        {
            var di = new DirectoryInfo(@"D:\Lyuxi\image\");
            var dirlist = new List<DirectoryInfo>(di.GetDirectories());
            var dirs = new List<DIR>();
            foreach (var dirinfo in dirlist)
            {
                var d = new DIR();
                d.DIRINFO = dirinfo;
                var x = new List<FILE>();
                foreach (var f in dirinfo.GetFiles())
                {
                    var fi = new FILE() { FILEINFO = f };
                    x.Add(fi);
                }
                d.FILELIST = x;
                dirs.Add(d);
            }
            return dirs;
        }
    }


}