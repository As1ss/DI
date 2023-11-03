
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Media;


namespace TestDrag_Drop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool isRedSelected;
        static bool isBlueSelected;
        static Point rPosition;
        static Point bPosition;
        public MainWindow()
        {
            InitializeComponent();
            rPosition = new Point(Canvas.GetLeft(redRectangle), Canvas.GetTop(redRectangle));
            bPosition = new Point(Canvas.GetLeft(blueRectangle),Canvas.GetTop(blueRectangle));
        }

        private void isColliding()
        {
            if (rPosition.X < bPosition.X + blueRectangle.Width &&
                rPosition.X + redRectangle.Width > bPosition.X &&
                rPosition.Y < bPosition.Y + blueRectangle.Height &&
                rPosition.Y + redRectangle.Height > bPosition.Y && isBlueSelected)
            {
                redRectangle.Stroke = Brushes.Lime;
                redRectangle.StrokeThickness = 5;
            }
            else
            {
                redRectangle.Stroke = Brushes.Transparent;

            }
            if (rPosition.X < bPosition.X + blueRectangle.Width &&
               rPosition.X + redRectangle.Width > bPosition.X &&
               rPosition.Y < bPosition.Y + blueRectangle.Height &&
               rPosition.Y + redRectangle.Height > bPosition.Y && isRedSelected)
            {
                blueRectangle.Stroke = Brushes.Lime;
                blueRectangle.StrokeThickness = 5;
            }
            else
            {
                blueRectangle.Stroke = Brushes.Transparent;
            }
        }

        private void RedRectangle_MouseMove(object sender, MouseEventArgs e)
        {
            
            if(e.LeftButton== MouseButtonState.Pressed)
            {
               
                rPosition = e.GetPosition(canvas);
                Canvas.SetTop(redRectangle, rPosition.Y);
                Canvas.SetLeft(redRectangle, rPosition.X);
                isBlueSelected = false;
                isRedSelected = true;
                DragDrop.DoDragDrop(redRectangle,redRectangle, DragDropEffects.Move);
                isColliding();
            }

            if (e.LeftButton== MouseButtonState.Released)
            {
                redRectangle.Stroke = Brushes.Transparent;

            }
            
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            if (isRedSelected)
            {
                rPosition = e.GetPosition(canvas);
                Canvas.SetTop(redRectangle, rPosition.Y);
                Canvas.SetLeft(redRectangle, rPosition.X);
                
            }
            if (isBlueSelected)
            {
                bPosition = e.GetPosition(canvas);
                Canvas.SetTop(blueRectangle, bPosition.Y);
                Canvas.SetLeft(blueRectangle, bPosition.X);

            }
        }

        private void canvas_DragOver(object sender, DragEventArgs e)
        {
            if (isRedSelected)
            {
                rPosition = e.GetPosition(canvas);
                Canvas.SetTop(redRectangle, rPosition.Y);
                Canvas.SetLeft(redRectangle, rPosition.X);
                isColliding();
            }
            if (isBlueSelected)
            {
                bPosition = e.GetPosition(canvas);
                Canvas.SetTop(blueRectangle, bPosition.Y);
                Canvas.SetLeft(blueRectangle, bPosition.X);
                isColliding();
            }
        }

        private void blueRectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                bPosition = e.GetPosition(canvas);
                Canvas.SetTop(blueRectangle, bPosition.Y);
                Canvas.SetLeft(blueRectangle, bPosition.X);
                isRedSelected = false;
                isBlueSelected = true;
                DragDrop.DoDragDrop(blueRectangle, blueRectangle, DragDropEffects.Move);
                isColliding();
            }
        }

     
    }
}
