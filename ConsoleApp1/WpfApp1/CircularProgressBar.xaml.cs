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

namespace WpfApp1
{
    /// <summary>
    /// CircularProgressBar.xaml 的交互逻辑
    /// </summary>
    public partial class CircularProgressBar : UserControl
    {
        public static readonly DependencyProperty CurValueProperty =
             DependencyProperty.Register("CurValue", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(1.0, OnValueChanged));

        public static readonly DependencyProperty MaxValueProperty =
              DependencyProperty.Register("MaxValue", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(32.0, OnValueChanged));

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(int), typeof(CircularProgressBar), new PropertyMetadata(5, OnPropertyChanged));

        public static readonly DependencyProperty SegmentColorProperty =
            DependencyProperty.Register("SegmentColor", typeof(Brush), typeof(CircularProgressBar), new PropertyMetadata(new SolidColorBrush(Colors.Aquamarine)));

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(int), typeof(CircularProgressBar), new PropertyMetadata(25, OnPropertyChanged));

        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(120d, OnPropertyChanged));

        public CircularProgressBar()
        {
            InitializeComponent();

            if (Content is FrameworkElement frameworkElement)
            {
                frameworkElement.DataContext = this;
            }

            double Percentage = CurValue / MaxValue;
            Angle = (Percentage * 360);
            RenderArc();
        }



        public double CurValue
        {
            get { return (double)GetValue(CurValueProperty); }
            set { SetValue(CurValueProperty, value); }
        }

        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public int Radius
        {
            get { return (int)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public Brush SegmentColor
        {
            get { return (Brush)GetValue(SegmentColorProperty); }
            set { SetValue(SegmentColorProperty, value); }
        }

        public int StrokeThickness
        {
            get { return (int)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }


        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {

            if (sender is CircularProgressBar circle)
            {
                double Percentage = circle.CurValue / circle.MaxValue;
                circle.Angle = (Percentage * 360);
            }


        }

        private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            if (sender is CircularProgressBar circle)
            {
                circle.RenderArc();
            }
        }

        public void RenderArc()
        {
            var startPoint = new Point(Radius, 0);
            var endPoint = ComputeCartesianCoordinate(Angle, Radius);
            endPoint.X += Radius;
            endPoint.Y += Radius;

            PathRoot.Width = Radius * 2 + StrokeThickness;
            PathRoot.Height = Radius * 2 + StrokeThickness;
            PathRoot.Margin = new Thickness(StrokeThickness, StrokeThickness, 0, 0);

            var largeArc = Angle > 180.0;

            var outerArcSize = new Size(Radius, Radius);

            PathFigure.StartPoint = startPoint;

            if (startPoint.X == Math.Round(endPoint.X) && startPoint.Y == Math.Round(endPoint.Y))
                endPoint.X -= 0.01;

            ArcSegment.Point = endPoint;
            ArcSegment.Size = outerArcSize;
            ArcSegment.IsLargeArc = largeArc;
        }

        private Point ComputeCartesianCoordinate(double angle, double radius)
        {
            // convert to radians
            var angleRad = (Math.PI / 180.0) * (angle - 90);
            var x = radius * Math.Cos(angleRad);
            var y = radius * Math.Sin(angleRad);
            return new Point(x, y);
        }
    }
}
