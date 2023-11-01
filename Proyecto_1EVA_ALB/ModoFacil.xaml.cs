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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_1EVA_ALB
{
    /// <summary>
    /// Lógica de interacción para ModoFacil.xaml
    /// </summary>
    public partial class ModoFacil : Page
    {
        MainWindow window;
        Point imgProcPosition;
        Point imgProcOriginalPosition;
        Point rectProcPosition;
        Point rectHDDPosition;
        Point rectRam1Position;
        Point rectRam2Position;
        Point rectPowerPosition;
        bool imgProcSelected;
        public ModoFacil(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            //Aqui inicializamos todas las posiciones originales de los elementos
            rectProcPosition = new Point(Canvas.GetTop(rectProc), Canvas.GetLeft(rectProc));
            imgProcOriginalPosition = new Point(Canvas.GetLeft(imgProc), Canvas.GetTop(imgProc));
            rectHDDPosition  = new Point(Canvas.GetLeft(rectHDD),Canvas.GetTop(rectHDD));
            rectPowerPosition = new Point(Canvas.GetLeft(rectPower), Canvas.GetTop(rectPower));
            rectRam1Position = new Point(Canvas.GetLeft(rectRam1), Canvas.GetTop(rectRam1));
            rectRam2Position = new Point(Canvas.GetLeft(rectRam2), Canvas.GetTop(rectRam2));

        }





        private void imgProc_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(canvasFacil, imgProc, DragDropEffects.Move);
                imgProcSelected = true;

            }
            if (e.LeftButton == MouseButtonState.Released && imgProcSelected)
            {
                if (isColliding(imgProc, rectProc))
                {
                    Canvas.SetTop(imgProc, Canvas.GetTop(rectProc)+75);
                    Canvas.SetLeft(imgProc,Canvas.GetLeft(rectProc)+90);
                }
                else
                {
                    rectProc.Stroke = Brushes.Black;
                    rectProc.StrokeThickness = 2;

                    rectHDD.Stroke = Brushes.Black;
                    rectHDD.StrokeThickness = 2;

                    rectPower.Stroke = Brushes.Black;
                    rectPower.StrokeThickness = 2;

                    rectRam1.Stroke = Brushes.Black;
                    rectRam1.StrokeThickness = 2;

                    rectRam2.Stroke = Brushes.Black;
                    rectRam2.StrokeThickness = 2;

                    imgProcSelected = false;
                    Canvas.SetTop(imgProc, imgProcOriginalPosition.Y);
                    Canvas.SetLeft(imgProc, imgProcOriginalPosition.X);
                }


            }
        }

        private bool isColliding(Rectangle rect1, Rectangle rect2)
        {
            Point rect1Pos = new Point(Canvas.GetLeft(rect1), Canvas.GetTop(rect1));
            Point rect2Pos = new Point(Canvas.GetLeft(rect2), Canvas.GetTop(rect2));

            if (rect1Pos.X < rect2Pos.X + rect2.Width &&
                rect1Pos.X + rect1.Width > rect2Pos.X &&
                rect1Pos.Y < rect2Pos.Y + rect2.Height &&
                rect1Pos.Y + rect1.Height > rect2Pos.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void canvasFacil_Drop(object sender, DragEventArgs e)
        {
            Point position = e.GetPosition(canvasFacil);
            Canvas.SetTop(imgProc, position.Y);
            Canvas.SetLeft(imgProc, position.X);

            if (isColliding(imgProc, rectProc))
            {
                rectProc.Stroke = Brushes.Lime;
                rectProc.StrokeThickness = 5;
            }
            else 
            {
                rectProc.Stroke = Brushes.Black;
                rectProc.StrokeThickness = 2;
            }
          

        }

        private void canvasFacil_DragOver(object sender, DragEventArgs e)
        {
            Point position = e.GetPosition(canvasFacil);
            Canvas.SetTop(imgProc, position.Y);
            Canvas.SetLeft(imgProc, position.X);

            procesadorColliders();

            

        }

        private void procesadorColliders()
        {
            if (isColliding(imgProc, rectProc))
            {
                rectProc.Stroke = Brushes.Lime;
                rectProc.StrokeThickness = 5;
            }
            else
            {
                rectProc.Stroke = Brushes.Black;
                rectProc.StrokeThickness = 2;
            }
            if (isColliding(imgProc, rectHDD))
            {
                rectHDD.Stroke = Brushes.Red;
                rectHDD.StrokeThickness = 5;
            }
            else if (imgProcSelected == false)
            {
                rectHDD.Stroke = Brushes.Black;
                rectHDD.StrokeThickness = 2;
            }
            if (isColliding(imgProc, rectPower))
            {
                rectPower.Stroke = Brushes.Red;
                rectPower.StrokeThickness = 5;
            }
            else if (imgProcSelected == false)
            {
                rectPower.Stroke = Brushes.Black;
                rectPower.StrokeThickness = 2;
            }
            if (isColliding(imgProc, rectRam1))
            {
                rectRam1.Stroke = Brushes.Red;
                rectRam1.StrokeThickness = 5;
            }
            else if (imgProcSelected == false)
            {
                rectRam1.Stroke = Brushes.Black;
                rectRam1.StrokeThickness = 2;
            }
            if (isColliding(imgProc, rectRam2))
            {
                rectRam2.Stroke = Brushes.Red;
                rectRam2.StrokeThickness = 5;
            }
            else if (imgProcSelected == false)
            {
                rectRam2.Stroke = Brushes.Black;
                rectRam2.StrokeThickness = 2;
            }
        }
    }
}
