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

namespace WPF_MoveShapeWithMouse
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
        Point DragStartPoint, DragEndPoint, ObjectStartLocation;
        object ClickedObject;
        double ClickedLineLength;
        private void DrawingCanvas_OnPreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ContextMenu cm = new ContextMenu();
            cm.Placement = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
            MenuItem RectangleButton = new MenuItem() { Header = "RECTANGLE" };
            MenuItem CircleButton = new MenuItem() { Header = "CIRCLE" };
            MenuItem LineButtton = new MenuItem() { Header = "LINE" };

            RectangleButton.Click += RectangleButton_Click;
            CircleButton.Click += CircleButton_Click;
            LineButtton.Click += LineButtton_Click;

            cm.Items.Add(RectangleButton);
            cm.Items.Add(CircleButton);
            cm.Items.Add(LineButtton);
            cm.IsOpen = true;
        }



        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            Rectangle ARectangle = new Rectangle() { Height = 150, Width = 150, Stroke = Brushes.Black, StrokeThickness = 5, Fill = Brushes.Red };
            Canvas.SetLeft(ARectangle, (DrawingCanvas.ActualWidth / 2) - (ARectangle.Width / 2));
            Canvas.SetTop(ARectangle, (DrawingCanvas.ActualHeight / 2) - (ARectangle.Height / 2));
            ARectangle.Tag = "R" + (DrawingCanvas.Children.Count).ToString();
            ARectangle.PreviewMouseLeftButtonDown += ARectangleOnPreviewMouseLeftButtonDown;
            DrawingCanvas.Children.Add(ARectangle);
        }


        private void ARectangleOnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = sender as Rectangle;
            DragStartPoint.X = e.GetPosition(this).X;
            DragStartPoint.Y = e.GetPosition(this).Y;
            ObjectStartLocation.X = Canvas.GetLeft(r);
            ObjectStartLocation.Y = Canvas.GetTop(r); ;
            ClickedObject = r; 

        }

        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            Ellipse ACircle = new Ellipse() { Height = 150, Width = 150, Stroke = Brushes.Black, StrokeThickness = 5, Fill = Brushes.Blue };
            Canvas.SetLeft(ACircle, (DrawingCanvas.ActualWidth / 2) - (ACircle.Width / 2));
            Canvas.SetTop(ACircle, (DrawingCanvas.ActualHeight / 2) - (ACircle.Height / 2));
            ACircle.Tag = "C" + (DrawingCanvas.Children.Count).ToString();
            ACircle.PreviewMouseLeftButtonDown += ACircleOnPreviewMouseLeftButtonDown;
            DrawingCanvas.Children.Add(ACircle);
        }

        private void ACircleOnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse c = sender as Ellipse;
            DragStartPoint.X = e.GetPosition(this).X;
            DragStartPoint.Y = e.GetPosition(this).Y;
            ObjectStartLocation.X = Canvas.GetLeft(c);
            ObjectStartLocation.Y = Canvas.GetTop(c); ;
            ClickedObject = c;
        }

        private void LineButtton_Click(object sender, RoutedEventArgs e)
        {
            double LineWidth = 150;
            Line Aline = new Line() { Stroke = Brushes.Black, StrokeThickness = 5, Fill = Brushes.Red };

            Aline.X1 = (DrawingCanvas.ActualWidth / 2) - (LineWidth / 2);
            Aline.Y1 = (DrawingCanvas.ActualHeight / 2);
            Aline.X2 = Aline.X1 + LineWidth;
            Aline.Y2 = (DrawingCanvas.ActualHeight / 2);
            Aline.Tag = "L" + (DrawingCanvas.Children.Count).ToString();
            Aline.PreviewMouseLeftButtonDown += AlineOnPreviewMouseLeftButtonDown;
            DrawingCanvas.Children.Add(Aline);
        }


        private void AlineOnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Line l = sender as Line;
            ClickedLineLength = Math.Abs(l.X1 - l.X2);
            DragStartPoint.X = e.GetPosition(this).X;
            DragStartPoint.Y = e.GetPosition(this).Y;
            ObjectStartLocation.X = l.X1;
            ObjectStartLocation.Y = l.Y1;
            ClickedObject = l;
        }


        private void DrawingCanvas_OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (ClickedObject == null)
            {
                return;
            }

            DragEndPoint.X = e.GetPosition(this).X;
            DragEndPoint.Y = e.GetPosition(this).Y;
            double deltaX = DragEndPoint.X - DragStartPoint.X;
            double deltaY = DragEndPoint.Y - DragStartPoint.Y;
            if (ClickedObject is Rectangle)
            {
                Rectangle r = ClickedObject as Rectangle;
                Canvas.SetLeft(r, ObjectStartLocation.X + deltaX);
                Canvas.SetTop(r, ObjectStartLocation.Y + deltaY);
            }
            else if (ClickedObject is Ellipse)
            {
                Ellipse c = ClickedObject as Ellipse;
                Canvas.SetLeft(c, ObjectStartLocation.X + deltaX);
                Canvas.SetTop(c, ObjectStartLocation.Y + deltaY);
            }
            else if (ClickedObject is Line)
            {

                Line l = ClickedObject as Line;

                l.X1 = ObjectStartLocation.X + deltaX;
                l.Y1 = ObjectStartLocation.Y + deltaY;
                l.X2 = l.X1 + ClickedLineLength;
                l.Y2 = ObjectStartLocation.Y + deltaY;
            }
            else
            {
                return;
            }

        }

        private void DrawingCanvas_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClickedObject = null;
        }
    }

}
