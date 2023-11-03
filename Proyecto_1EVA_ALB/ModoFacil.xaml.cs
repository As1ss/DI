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



        static int puntuacion;

        static bool imgProcSelected;
        static bool imgHDDSelected;
        DispatcherTimer timer;
        DispatcherTimer respawnProcBox;
        DispatcherTimer respawnHDDBox;
        static int posX, posY;
        bool boxProcisAlive;
        bool boxHDDisAlive;

        public ModoFacil(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            //Aqui inicializamos todas las posiciones originales de los elementos

            imgProcOriginalPosition = new Point(Canvas.GetLeft(imgProc), Canvas.GetTop(imgProc));
            imgProcPosition = imgProcOriginalPosition;
            imgHDDOriginalPosition = new Point(Canvas.GetLeft(imgHDD), Canvas.GetTop(imgHDD));
            imgHDDPosition = imgHDDOriginalPosition;

            puntuacion = 0;
            labelPuntuacion.Content = "Puntuacion: " + puntuacion.ToString();
            boxHDDisAlive = true;
            boxProcisAlive = true;

            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(2);

            respawnProcBox = new DispatcherTimer();
            respawnProcBox.Tick += Respawn_Tick;
            respawnProcBox.Interval = TimeSpan.FromSeconds(10);

            respawnHDDBox = new DispatcherTimer();
            respawnHDDBox.Tick += Respawn_Tick;
            respawnProcBox.Interval = TimeSpan.FromSeconds(10);


           

            timer.Start();

        }

        private void Respawn_Tick(object? sender, EventArgs e)
        {
            if (!boxProcisAlive)
            {
                rectProc.Opacity = 1;
                boxProcisAlive = true;
                canvasFacil.Children.Add(rectProc);
                respawnProcBox.Stop();
            }
            if (!boxHDDisAlive)
            {
                rectHDD.Opacity = 1;
                boxHDDisAlive = true;
                canvasFacil.Children.Add(rectHDD);
                respawnProcBox.Stop();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            rectProc.Opacity -= 0.2f;

            if (rectProc.Opacity < 0.0f && boxProcisAlive)
            {
                boxProcisAlive = false;

                canvasFacil.Children.Remove(rectProc);


                respawnProcBox.Start();
            }

            rectHDD.Opacity -= 0.2f;

            if (rectHDD.Opacity < 0.0f && boxHDDisAlive)
            {
                boxHDDisAlive = false;

                canvasFacil.Children.Remove(rectHDD);


                respawnProcBox.Start();
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
            if (imgProcSelected)
            {
                imgProcPosition = e.GetPosition(canvasFacil);
                Canvas.SetTop(imgProc, imgProcPosition.Y);
                Canvas.SetLeft(imgProc, imgProcPosition.X);
                procesadorColliders();
            }
            if (imgHDDSelected)
            {
                imgHDDPosition = e.GetPosition(canvasFacil);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);

                hardDiskColliders();
            }
          
          
        }

        private void canvasFacil_DragOver(object sender, DragEventArgs e)
        {
          
            if (imgProcSelected)
            {
                imgProcPosition = e.GetPosition(canvasFacil);
                Canvas.SetTop(imgProc, imgProcPosition.Y);
                Canvas.SetLeft(imgProc, imgProcPosition.X);
                procesadorColliders();
            }
            if (imgHDDSelected)
            {
                imgHDDPosition = e.GetPosition(canvasFacil);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);
                hardDiskColliders();
            }
          
          
        }

        private void imgProc_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                imgProcPosition = e.GetPosition(canvasFacil);
                Canvas.SetTop(imgProc, imgProcPosition.Y);
                Canvas.SetLeft(imgProc, imgProcPosition.X);
                imgHDDSelected = false;
                imgProcSelected = true;
                DragDrop.DoDragDrop(canvasFacil, imgProc, DragDropEffects.Move);
            


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgProcSelected = false;
                if (isColliding(imgProc, rectProc) && imgProcSelected == false && boxProcisAlive)
                {
                    rectProc.Stroke = Brushes.Lime;
                    rectProc.StrokeThickness = 5;
                    puntuacion += 10;
                    labelPuntuacion.Content = "Puntuacion: " + puntuacion.ToString();
                    rectProc.Opacity = -1;
                   
                }
                
                procesadorColliders();
                Canvas.SetTop(imgProc, imgProcOriginalPosition.Y);
                Canvas.SetLeft(imgProc, imgProcOriginalPosition.X);
            }
        }

        private void imgHDD_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
               
                imgHDDPosition = e.GetPosition(canvasFacil);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);
                imgProcSelected = false;
                imgHDDSelected = true;
                DragDrop.DoDragDrop(canvasFacil, imgHDD, DragDropEffects.Move);
               

            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgHDDSelected = false;
                if (isColliding(imgHDD, rectHDD) && imgHDDSelected == false && boxHDDisAlive)
                {
                    rectHDD.Stroke = Brushes.Lime;
                    rectHDD.StrokeThickness = 5;
                    puntuacion += 10;
                    labelPuntuacion.Content = "Puntuacion: " + puntuacion.ToString();
                    rectHDD.Opacity =-1f;

                }
                
                hardDiskColliders();
                Canvas.SetTop(imgHDD, imgHDDOriginalPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDOriginalPosition.X);

            }
        }

        private void procesadorColliders()
        {
            if (isColliding(imgProc, rectProc) )
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
            else 
            {
                rectHDD.Stroke = Brushes.Black;
                rectHDD.StrokeThickness = 2;
            }
            if (isColliding(imgProc, rectPower))
            {
                rectPower.Stroke = Brushes.Red;
                rectPower.StrokeThickness = 5;
            }
            else
            {
                rectPower.Stroke = Brushes.Black;
                rectPower.StrokeThickness = 2;
            }
            if (isColliding(imgProc, rectRam))
            {
                rectRam.Stroke = Brushes.Red;
                rectRam.StrokeThickness = 5;
            }
            else 
            {
                rectRam.Stroke = Brushes.Black;
                rectRam.StrokeThickness = 2;
            }
            if (isColliding(imgProc, rectGIU))
            {
                rectGIU.Stroke = Brushes.Red;
                rectGIU.StrokeThickness = 5;
            }
            else 
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
            else
            {
                rectHDD.Stroke = Brushes.Black;
                rectHDD.StrokeThickness = 2;
            }
            if (isColliding(imgHDD, rectPower))
            {
                rectPower.Stroke = Brushes.Red;
                rectPower.StrokeThickness = 5;
            }
            else 
            {
                rectPower.Stroke = Brushes.Black;
                rectPower.StrokeThickness = 2;
            }
            if (isColliding(imgHDD, rectRam))
            {
                rectRam.Stroke = Brushes.Red;
                rectRam.StrokeThickness = 5;
            }
            else
            {
                rectRam.Stroke = Brushes.Black;
                rectRam.StrokeThickness = 2;
            }
            if (isColliding(imgHDD, rectGIU))
            {
                rectGIU.Stroke = Brushes.Red;
                rectGIU.StrokeThickness = 5;
            }
            else
            {
                rectGIU.Stroke = Brushes.Black;
                rectGIU.StrokeThickness = 2;
            }

        }
    }
}
