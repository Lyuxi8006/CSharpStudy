using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BarChartDemo
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
    public class Course
    {
        public string Name { get; set; }
        public int Grade { get; set; }
    }
    public class Courses
    {
        public List<Course> CourseList { get; set; } = GetCourses();
        public static List<Course> GetCourses() 
        {
            var courses = new List<Course>()
            {
                new Course() { Name = "Math", Grade = 75 * 3},
                new Course() { Name = "Science", Grade = 85 * 3},
                new Course() { Name = "English", Grade = 80 * 3},
                new Course() { Name = "Art", Grade = 90 * 3}
            };
            return courses.ToList();
        }
    }
}
