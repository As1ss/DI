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
using System.Windows.Threading;

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

        Point imgHDDPosition;
        Point imgHDDOriginalPosition;

        Point rectProcPosition;
        Point rectHDDPosition;
        Point rectRamPosition;
        Point rectPowerPosition;
        Point rectGIUPosition;

        bool imgProcSelected;
        bool imgHDDSelected;
        DispatcherTimer timer;
        DispatcherTimer respawn;
        static int posX, posY;
        bool boxProcisAlive;

        public ModoFacil(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            //Aqui inicializamos todas las posiciones originales de los elementos

            imgProcOriginalPosition = new Point(Canvas.GetLeft(imgProc), Canvas.GetTop(imgProc));
            imgHDDOriginalPosition = new Point(Canvas.GetLeft(imgHDD), Canvas.GetTop(imgHDD));
            /*
             *   rectProcPosition = new Point(Canvas.GetTop(rectProc), Canvas.GetLeft(rectProc));
            rectHDDPosition  = new Point(Canvas.GetLeft(rectHDD),Canvas.GetTop(rectHDD));
            rectPowerPosition = new Point(Canvas.GetLeft(rectPower), Canvas.GetTop(rectPower));
            rectRamPosition = new Point(Canvas.GetLeft(rectRam), Canvas.GetTop(rectRam));
            rectGIUPosition = new Point(Canvas.GetLeft(rectGIU), Canvas.GetTop(rectGIU));
             */



            boxProcisAlive = true;
            timer = new DispatcherTimer();
            respawn = new DispatcherTimer();
            respawn.Tick += Respawn_Tick;
            respawn.Interval = TimeSpan.FromSeconds(10);


            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(2);

            timer.Start();

        }

        private void Respawn_Tick(object? sender, EventArgs e)
        {
            if (!boxProcisAlive)
            {
                rectProc.Opacity = 1;
                boxProcisAlive = true;
                canvasFacil.Children.Add(rectProc);
                respawn.Stop();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            rectProc.Opacity -= 0.2f;

            if (rectProc.Opacity < 0.0f && boxProcisAlive)
            {
                boxProcisAlive = false;

                canvasFacil.Children.Remove(rectProc);


                respawn.Start();
            }



        }




        private void imgProc_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                DragDrop.DoDragDrop(canvasFacil, imgProc, DragDropEffects.Move);
                imgProcSelected = true;
                imgHDDSelected = false;

            }
            if (e.LeftButton == MouseButtonState.Released)
            {


                if (isColliding(imgProc, rectProc))
                {
                    Canvas.SetTop(imgProc, imgProcOriginalPosition.Y);
                    Canvas.SetLeft(imgProc, imgProcOriginalPosition.X);
                }
                else
                {
                    rectProc.Stroke = Brushes.Black;
                    rectProc.StrokeThickness = 2;

                    rectHDD.Stroke = Brushes.Black;
                    rectHDD.StrokeThickness = 2;

                    rectPower.Stroke = Brushes.Black;
                    rectPower.StrokeThickness = 2;

                    rectRam.Stroke = Brushes.Black;
                    rectRam.StrokeThickness = 2;

                    rectGIU.Stroke = Brushes.Black;
                    rectGIU.StrokeThickness = 2;


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

            imgProcPosition = e.GetPosition(canvasFacil);
            Canvas.SetTop(imgProc, imgProcPosition.Y);
            Canvas.SetLeft(imgProc, imgProcPosition.X);
            procesadorColliders();












        }

        private void canvasFacil_DragOver(object sender, DragEventArgs e)
        {

            imgProcPosition = e.GetPosition(canvasFacil);
            Canvas.SetTop(imgProc, imgProcPosition.Y);
            Canvas.SetLeft(imgProc, imgProcPosition.X);
            procesadorColliders();



        }

        private void imgHDD_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                DragDrop.DoDragDrop(canvasFacil, imgHDD, DragDropEffects.Move);
                imgHDDSelected = true;
                imgProcSelected = false;

            }
            if (e.LeftButton == MouseButtonState.Released)
            {

                if (isColliding(imgHDD, rectHDD))
                {
                    Canvas.SetTop(imgHDD, imgHDDOriginalPosition.Y);
                    Canvas.SetLeft(imgHDD, imgHDDOriginalPosition.X);
                }
                else
                {
                    rectProc.Stroke = Brushes.Black;
                    rectProc.StrokeThickness = 2;

                    rectHDD.Stroke = Brushes.Black;
                    rectHDD.StrokeThickness = 2;

                    rectPower.Stroke = Brushes.Black;
                    rectPower.StrokeThickness = 2;

                    rectRam.Stroke = Brushes.Black;
                    rectRam.StrokeThickness = 2;

                    rectGIU.Stroke = Brushes.Black;
                    rectGIU.StrokeThickness = 2;


                    Canvas.SetTop(imgHDD, imgHDDOriginalPosition.Y);
                    Canvas.SetLeft(imgHDD, imgHDDOriginalPosition.X);
                }


            }
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
            if (isColliding(imgProc, rectRam))
            {
                rectRam.Stroke = Brushes.Red;
                rectRam.StrokeThickness = 5;
            }
            else if (imgProcSelected == false)
            {
                rectRam.Stroke = Brushes.Black;
                rectRam.StrokeThickness = 2;
            }
            if (isColliding(imgProc, rectGIU))
            {
                rectGIU.Stroke = Brushes.Red;
                rectGIU.StrokeThickness = 5;
            }
            else if (imgProcSelected == false)
            {
                rectGIU.Stroke = Brushes.Black;
                rectGIU.StrokeThickness = 2;
            }

        }
        private void hardDiskColliders()
        {
            if (isColliding(imgHDD, rectProc))
            {
                rectProc.Stroke = Brushes.Red;
                rectProc.StrokeThickness = 5;
            }
            else
            {
                rectProc.Stroke = Brushes.Black;
                rectProc.StrokeThickness = 2;
            }
            if (isColliding(imgHDD, rectHDD))
            {
                rectHDD.Stroke = Brushes.Lime;
                rectHDD.StrokeThickness = 5;
            }
            else if (imgHDDSelected == false)
            {
                rectHDD.Stroke = Brushes.Black;
                rectHDD.StrokeThickness = 2;
            }
            if (isColliding(imgHDD, rectPower))
            {
                rectPower.Stroke = Brushes.Red;
                rectPower.StrokeThickness = 5;
            }
            else if (imgHDDSelected == false)
            {
                rectPower.Stroke = Brushes.Black;
                rectPower.StrokeThickness = 2;
            }
            if (isColliding(imgHDD, rectRam))
            {
                rectRam.Stroke = Brushes.Red;
                rectRam.StrokeThickness = 5;
            }
            else if (imgHDDSelected == false)
            {
                rectRam.Stroke = Brushes.Black;
                rectRam.StrokeThickness = 2;
            }
            if (isColliding(imgHDD, rectGIU))
            {
                rectGIU.Stroke = Brushes.Red;
                rectGIU.StrokeThickness = 5;
            }
            else if (imgHDDSelected == false)
            {
                rectGIU.Stroke = Brushes.Black;
                rectGIU.StrokeThickness = 2;
            }

        }
    }
}
