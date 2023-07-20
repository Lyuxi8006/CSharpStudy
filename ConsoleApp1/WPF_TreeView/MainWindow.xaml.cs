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

namespace WPF_TreeView
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
}
