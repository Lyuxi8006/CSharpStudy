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

namespace Wpf_ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = this;
        }

        public List<TodoItem> ITEMLIST { get; set; } = TodoItems.GetTodoItems();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBX1.Text != "")
            {
                LBX1.Items.Add(TBX1.Text);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (LBX1.SelectedItem != null)
            {

                LBX1.Items.Remove(LBX1.SelectedItem);
            }
        }
    }

    public class TodoItems
    {
        public List<TodoItem> MYLIST { get; set; } = GetTodoItems();
        public static List<TodoItem> GetTodoItems()
        {
            var list = new List<TodoItem>(); 
            list.Add(new TodoItem() {NAME = "Whole Milk", IMG="/Assets/cow.png"});
            list.Add(new TodoItem() { NAME = "Whole Wheat", IMG = "/Assets/bread.png" });
            list.Add(new TodoItem() { NAME = "Oringe Juice", IMG = "/Assets/juice.png" });
            return list;
        }
    }

    public class TodoItem
    {
        public string NAME { get; set; }
        public string IMG { get; set; }

        public override string ToString()
        {
            return this.NAME;
        }
    }
}
