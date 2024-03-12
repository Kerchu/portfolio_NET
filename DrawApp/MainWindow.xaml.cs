using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawApp
{
    public partial class MainWindow : Window
    {
        private bool drawing=false;
        private Point lastPoint;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void canva_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = lastPoint.X;
                line.Y1 = lastPoint.Y;
                line.X2 = e.GetPosition(canva).X;
                line.Y2 = e.GetPosition(canva).Y;
                canva.Children.Add(line);
                lastPoint = e.GetPosition(canva);
            }
        }
        private void canva_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
        {
            drawing = true;
            lastPoint = e.GetPosition(canva);
        }
        private void canva_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            drawing = false;
        }
    }
}
