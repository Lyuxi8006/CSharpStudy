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

namespace DataContext
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public string MyProperty { get; set; } = "John";
        //public int MyInt { get; set; } = 1;
        public MainWindow()
        {
            InitializeComponent();
            //var emp = new Employee();
            //DataContext = emp;
        }
    }

    public class Student
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "John";
        public Student()
        {

        }
    }
}
