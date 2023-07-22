using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPF_GeometryGroup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Path path = null;
        private double minLength = 10;
        private double pointLength = 1;
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void canDraw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 右键按下转实线
            if (e.RightButton == MouseButtonState.Pressed)
            {
                if (path != null)
                {
                    if (path.Data is GeometryGroup)
                    {
                        GeometryGroup geometryGroup = path.Data as GeometryGroup;
                        if (geometryGroup.Children.Count > 3)
                        {

                            Polygon new_polygon = new Polygon();
                            new_polygon.Stroke = Brushes.Blue;
                            new_polygon.StrokeThickness = 2;
                            for (int i = 0; i < geometryGroup.Children.Count; ++i)
                            {
                                if (geometryGroup.Children[i] is EllipseGeometry ellipse)
                                {
                                    new_polygon.Points.Add(ellipse.Center);
                                }

                            }
                            canDraw.Children.Add(new_polygon);
                        }
                    }
                    canDraw.Children.Remove(path);
                    path = null;
                }
                return;
            }

            // 虚线点,用GeometryGroup包含每个点
            if (path == null)
            {
                canDraw.Children.Clear();
                path = new Path()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = Brushes.Blue
                };
                GeometryGroup geometryGroup = new GeometryGroup();
                geometryGroup.Children.Add(new EllipseGeometry() { Center = e.GetPosition(canDraw), RadiusX = pointLength, RadiusY = pointLength });
                path.Data = geometryGroup;
                canDraw.Children.Add(path);
            }    
        }

        private void canDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (path == null) 
                return;
            if (path.Data is GeometryGroup)
            {
                var geometryGroup = path.Data as GeometryGroup;
                if (geometryGroup.Children.Count > 0 && geometryGroup.Children[geometryGroup.Children.Count-1]  is EllipseGeometry) 
                {
                    EllipseGeometry ellipse = geometryGroup.Children[geometryGroup.Children.Count - 1] as EllipseGeometry;
                    var point = e.GetPosition(canDraw);
                    double dist = (ellipse.Center - point).Length;
                    if (dist > minLength) 
                    {
                        double deltaX = (point.X - ellipse.Center.X) / dist;
                        double deltaY = (point.Y - ellipse.Center.Y) / dist;
                        for (; dist > minLength;)
                        {
                            double destX = ellipse.Center.X + deltaX * minLength;
                            double destY = ellipse.Center.Y + deltaY * minLength;
                            Point finalPoint = new Point() { X = destX, Y = destY };
                            geometryGroup.Children.Add(new EllipseGeometry() { Center = finalPoint, RadiusX = pointLength, RadiusY = pointLength });
                            dist -= minLength;
                        }
                    }
                    if (geometryGroup.Children.Count > 10)
                    {
                        EllipseGeometry firstEllipse = geometryGroup.Children[0] as EllipseGeometry;
                        if (firstEllipse != null)
                        {
                        
                            double toFirstPointDist = (firstEllipse.Center - point).Length;
                            if (toFirstPointDist < minLength)
                            {
                                if (path != null)
                                {
                                    if (path.Data is GeometryGroup)
                                    {
                                        Polygon new_polygon = new Polygon();
                                        new_polygon.Stroke = Brushes.Blue;
                                        new_polygon.StrokeThickness = 2;
                                        for (int i = 0; i < geometryGroup.Children.Count; ++i)
                                        {
                                            if (geometryGroup.Children[i] is EllipseGeometry t)
                                            {
                                                new_polygon.Points.Add(t.Center);
                                            }

                                        }
                                        canDraw.Children.Add(new_polygon);
                                    }
                                    canDraw.Children.Remove(path);
                                    path = null;
                                }
                                return;
                            }
                        }

                    }
                }
            }
        }
    }
}
