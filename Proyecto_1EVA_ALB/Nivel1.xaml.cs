using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

        //Posiciones
        Point imgProcPosition;
        Point imgProcOriginalPosition;

        Point imgHDDPosition;
        Point imgHDDOriginalPosition;

        Point imgPowerPosition;
        Point imgPowerOriginalPosition;

        Point imgRamPosition;
        Point imgRamOriginalPosition;

        Point imgGIUPosition;
        Point imgGIUOriginalPosition;

        //Rectangles
        List<Rectangle> rectangles;
        int currentRectangleIndex = 0;

        //Timers
        DispatcherTimer opacityTimer;
        DispatcherTimer respawnTimer;


        static int puntuacion;
        static int vidas;

        //Variables para comprobar si las imagenes estan seleccionadas
        static bool imgProcSelected;
        static bool imgHDDSelected;
        static bool imgPowerSelected;
        static bool imgRamSelected;
        static bool imgGIUSelected;

        //Variables para comprobar si las cajas estan vivas
        bool boxProcisAlive;
        bool boxHDDisAlive;
        bool boxPowerisAlive;
        bool boxRamisAlive;
        bool boxGIUisAlive;


        public ModoFacil(MainWindow window)
        {
            InitializeComponent();
            InitializeRectangles();
            this.window = window;
            //Aqui inicializamos todas las posiciones originales de los elementos

            imgProcOriginalPosition = new Point(Canvas.GetLeft(imgProc), Canvas.GetTop(imgProc));
            imgProcPosition = imgProcOriginalPosition;

            imgHDDOriginalPosition = new Point(Canvas.GetLeft(imgHDD), Canvas.GetTop(imgHDD));
            imgHDDPosition = imgHDDOriginalPosition;


            imgPowerOriginalPosition = new Point(Canvas.GetLeft(imgPower), Canvas.GetTop(imgPower));
            imgPowerPosition = imgPowerOriginalPosition;

            imgRamOriginalPosition = new Point(Canvas.GetLeft(imgRam), Canvas.GetTop(imgRam));
            imgRamPosition = imgRamOriginalPosition;

            imgGIUOriginalPosition = new Point(Canvas.GetLeft(imgGIU), Canvas.GetTop(imgGIU));
            imgGIUPosition = imgGIUOriginalPosition;

            vidas = 3;
            puntuacion = 0;
            labelVidas.Content = "Vidas: " + vidas.ToString();

            //Inicializamos las variables de comprobación
            boxHDDisAlive = true;
            boxProcisAlive = true;
            boxPowerisAlive = true;
            boxRamisAlive = true;
            boxGIUisAlive = true;

            //Inicializamos los timers
            opacityTimer = new DispatcherTimer();
            opacityTimer.Tick += Timer_Tick;
            opacityTimer.Interval = TimeSpan.FromSeconds(1.5f);
            opacityTimer.Start();

            //Inicializamos el timer de respawn
            respawnTimer = new DispatcherTimer();
            respawnTimer.Tick += Respawn_Tick;
            respawnTimer.Interval = TimeSpan.FromSeconds(10);
            respawnTimer.Start();
        }

        //Inicializamos los rectangulos
        private void InitializeRectangles()
        {
            rectangles = new List<Rectangle>
        {
            rectProc,
            rectHDD,
            rectPower,
            rectGIU,
            rectRam
        };


        }

        private void Respawn_Tick(object? sender, EventArgs e)
        {

            if (!boxProcisAlive)
            {
                rectProc.Opacity = 1;
                boxProcisAlive = true;
            }

            if (!boxHDDisAlive)
            {
                rectHDD.Opacity = 1;
                boxHDDisAlive = true;
            }
            if (!boxPowerisAlive)
            {
                rectPower.Opacity = 1;
                boxPowerisAlive = true;

            }
            if (!boxRamisAlive)
            {
                rectRam.Opacity = 1;
                boxRamisAlive = true;
            }
            if (!boxGIUisAlive)
            {
                rectGIU.Opacity = 1;
                boxGIUisAlive = true;
            }


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Comprobación de la puntuación
            if (puntuacion == 5)
            {

                SoundManager.nivel1SoundTrack.Stop(); //Parar la música de fondo
                respawnTimer.Stop(); //Parar el timer de respawn
                opacityTimer.Stop(); //Parar el timer de opacidad
                MessageBox.Show("Has pasado de nivel!"); //Mostrar mensaje
                puntuacion = 0; //Reiniciar la puntuación
                Nivel2TalkFrame nivel2TalkFrame = new Nivel2TalkFrame(window); //Pasar a la siguiente página
                this.NavigationService.Navigate(nivel2TalkFrame); //Navegar a la siguiente página

            }

            //  Comprobación de la opacidad
            if (currentRectangleIndex < rectangles.Count)
            {
                Rectangle currentRect = rectangles[currentRectangleIndex]; //Obtener el rectángulo actual
                currentRect.Opacity -= 0.2; //Disminuir la opacidad del rectángulo actual

                // Comprobar si la opacidad del rectángulo actual es menor o igual a 0
                if (currentRect.Opacity <= 0)
                {
                   
                    string rectName = currentRect.Name; //Obtener el nombre del rectángulo actual


                    // Comprobar el nombre del rectángulo
                    if (rectName == "rectProc")
                    {
                        boxProcisAlive = false;

                    }
                    if (rectName == "rectHDD")
                    {
                        boxHDDisAlive = false;
                    }
                    if (rectName == "rectPower")
                    {
                        boxPowerisAlive = false;
                    }
                    if (rectName == "rectRam")
                    {
                        boxRamisAlive = false;
                    }
                    if (rectName== "rectGIU")
                    {
                        boxGIUisAlive = false;
                    }

                    currentRectangleIndex++; //Aumentar el índice del rectángulo actual
                    vidas--; //Disminuir las vidas
                    labelVidas.Content = "Vidas: " + vidas; //Mostrar las vidas

                    // Comprobar si las vidas son <= 0
                    if (vidas <= 0)
                    {
                     
                        SoundManager.nivel1SoundTrack.Stop(); //Parar la música de fondo
                        respawnTimer.Stop(); // Parar el timer de respawn
                        opacityTimer.Stop(); //Parar el timer de opacidad
                        MessageBox.Show("Has perdido pulsa aceptar para continuar."); //    Mostrar mensaje
                        Principal princpalPage = new Principal(window); //Pasar a la siguiente página
                        this.NavigationService.Navigate(princpalPage); //Navegar a la siguiente página
                    }
                }
            }
            else
            {
                // Si todos los rectángulos han alcanzado una opacidad < 0, reinicia el proceso.
                currentRectangleIndex = 0;


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

        //Métodos para soltar las imágenes
        private void canvasFacil_Drop(object sender, DragEventArgs e)
        {
            if (imgProcSelected)
            {
                imgProcPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgProc, imgProcPosition.Y);
                Canvas.SetLeft(imgProc, imgProcPosition.X);
                procesadorColliders();
            }
            if (imgHDDSelected)
            {
                imgHDDPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);
                hardDiskColliders();
            }
            if (imgPowerSelected)
            {
                imgPowerPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgPower, imgPowerPosition.Y);
                Canvas.SetLeft(imgPower, imgPowerPosition.X);
                powerColliders();
            }
            if(imgRamSelected)
            {
                imgRamPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgRam, imgRamPosition.Y);
                Canvas.SetLeft(imgRam, imgRamPosition.X);
                ramColliders();
            }
            if (imgGIUSelected)
            {
                imgGIUPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgGIU, imgGIUPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUPosition.X);
                GIUcolliders();
            }



        }
        //Métodos para arrastrar las imagenes
        private void canvasFacil_DragOver(object sender, DragEventArgs e)
        {
            //Comprobamos si las imagenes estan seleccionadas
            if (imgProcSelected)
            {

                imgProcPosition = e.GetPosition(canvasNivel1); //Obtener la posición del ratón
                Canvas.SetTop(imgProc, imgProcPosition.Y); //Asignar la posición del ratón a la imagen
                Canvas.SetLeft(imgProc, imgProcPosition.X); //Asignar la posición del ratón a la imagen
                procesadorColliders(); // Comprobar colisiones
            }
            if (imgHDDSelected)
            {
                imgHDDPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);
                hardDiskColliders();
            }
            if (imgPowerSelected)
            {
                imgPowerPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgPower, imgPowerPosition.Y);
                Canvas.SetLeft(imgPower, imgPowerPosition.X);
                powerColliders();
            }
            if (imgRamSelected)
            {
                imgRamPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgRam, imgRamPosition.Y);
                Canvas.SetLeft(imgRam, imgRamPosition.X);
                ramColliders();
            }
            if(imgGIUSelected)
            {
                imgGIUPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgGIU, imgGIUPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUPosition.X);
                GIUcolliders();
            }


        }

        //Métodos para mover las imagenes
        private void imgProc_MouseMove(object sender, MouseEventArgs e)
        {
            //Comprobamos si el boton izquierdo del ratón esta pulsado
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                
                SoundManager.grabBox.Play();
                imgProcPosition = e.GetPosition(canvasNivel1); //Obtener la posición del ratón
                Canvas.SetTop(imgProc, imgProcPosition.Y); //Asignar la posición del ratón a la imagen
                Canvas.SetLeft(imgProc, imgProcPosition.X); //Asignar la posición del ratón a la imagen
                imgHDDSelected = false;
                imgPowerSelected = false;
                imgRamSelected = false;
                imgGIUSelected = false;
                imgProcSelected = true;
                DragDrop.DoDragDrop(canvasNivel1, imgProc, DragDropEffects.Move); //Permitir arrastrar la imagen



            }
            //Comprobamos si el boton izquierdo del ratón esta soltado
            if (e.LeftButton == MouseButtonState.Released)
            {
                //  Comprobamos si la imagen esta colisionando con el rectangulo
                imgProcSelected = false;
                if (isColliding(imgProc, rectProc) && imgProcSelected == false && boxProcisAlive)
                {
                    rectProc.Stroke = Brushes.Lime; //Cambiar el color del rectangulo
                    rectProc.StrokeThickness = 5; //Cambiar el grosor del rectangulo
                    puntuacion ++; //Aumentar la puntuación
                    labelPuntuacion.Content = puntuacion + "/5"; //Mostrar la puntuación
                    rectProc.Opacity = -1; //Cambiar la opacidad del rectangulo
                    vidas++; //Aumentar las vidas

                }


                procesadorColliders(); //Comprobar colisiones
                Canvas.SetTop(imgProc, imgProcOriginalPosition.Y); //Asignar la posición original a la imagen
                Canvas.SetLeft(imgProc, imgProcOriginalPosition.X); //  Asignar la posición original a la imagen
            }
        }

        private void imgHDD_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                SoundManager.grabBox.Play();
                imgHDDPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);
                imgProcSelected = false;
                imgPowerSelected = false;
                imgRamSelected = false;
                imgGIUSelected = false;
                imgHDDSelected = true;
                DragDrop.DoDragDrop(canvasNivel1, imgHDD, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgHDDSelected = false;
                if (isColliding(imgHDD, rectHDD) && imgHDDSelected == false && boxHDDisAlive)
                {
                    rectHDD.Stroke = Brushes.Lime;
                    rectHDD.StrokeThickness = 5;
                    puntuacion++;
                    labelPuntuacion.Content = puntuacion + "/5";
                    rectHDD.Opacity = -1f;
                    vidas++;

                }

                hardDiskColliders();
                Canvas.SetTop(imgHDD, imgHDDOriginalPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDOriginalPosition.X);

            }
        }

        private void imgPower_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                SoundManager.grabBox.Play();
                imgPowerPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgPower, imgPowerPosition.Y);
                Canvas.SetLeft(imgPower, imgPowerPosition.X);
                imgProcSelected = false;
                imgHDDSelected = false;
                imgRamSelected = false;
                imgGIUSelected = false;
                imgPowerSelected = true;

                DragDrop.DoDragDrop(canvasNivel1, imgPower, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgPowerSelected = false;
                if (isColliding(imgPower, rectPower) && imgPowerSelected == false && boxPowerisAlive)
                {
                    rectPower.Stroke = Brushes.Lime;
                    rectPower.StrokeThickness = 5;
                    puntuacion++;
                    labelPuntuacion.Content = puntuacion + "/5";
                    rectPower.Opacity = -1f;
                    vidas++;

                }

                hardDiskColliders();
                Canvas.SetTop(imgPower, imgPowerOriginalPosition.Y);
                Canvas.SetLeft(imgPower, imgPowerOriginalPosition.X);

            }
        }

        private void imgRam_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                SoundManager.grabBox.Play();
                imgRamPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgRam, imgRamPosition.Y);
                Canvas.SetLeft(imgRam, imgRamPosition.X);
                imgProcSelected = false;
                imgHDDSelected = false;
                imgPowerSelected = false;
                imgGIUSelected = false;
                imgRamSelected = true;

                DragDrop.DoDragDrop(canvasNivel1, imgRam, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgRamSelected = false;
                if (isColliding(imgRam, rectRam) && imgRamSelected == false && boxRamisAlive)
                {
                    rectRam.Stroke = Brushes.Lime;
                    rectRam.StrokeThickness = 5;
                    puntuacion++;
                    labelPuntuacion.Content = puntuacion + "/5";
                    rectRam.Opacity = -1f;
                    vidas++;

                }

                hardDiskColliders();
                Canvas.SetTop(imgRam, imgRamOriginalPosition.Y);
                Canvas.SetLeft(imgRam, imgRamOriginalPosition.X);

            }
        }

        private void imgGIU_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                SoundManager.grabBox.Play();
                imgGIUPosition = e.GetPosition(canvasNivel1);
                Canvas.SetTop(imgGIU, imgGIUPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUPosition.X);
                imgProcSelected = false;
                imgHDDSelected = false;
                imgPowerSelected = false;
                imgRamSelected = false;
                imgGIUSelected = true;

                DragDrop.DoDragDrop(canvasNivel1, imgGIU, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgGIUSelected = false;
                if (isColliding(imgGIU, rectGIU) && imgGIUSelected == false && boxGIUisAlive)
                {
                    rectGIU.Stroke = Brushes.Lime;
                    rectGIU.StrokeThickness = 5;
                    puntuacion++;
                    labelPuntuacion.Content = puntuacion + "/5";
                    rectGIU.Opacity = -1f;
                    vidas++;

                }

                hardDiskColliders();
                Canvas.SetTop(imgGIU, imgGIUOriginalPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUOriginalPosition.X);

            }
        }

        private void powerColliders()
        {
            if (isColliding(imgPower, rectProc))
            {
                rectProc.Stroke = Brushes.Red;
                rectProc.StrokeThickness = 5;


            }
            else
            {
                rectProc.Stroke = Brushes.Black;
                rectProc.StrokeThickness = 2;
            }
            if (isColliding(imgPower, rectHDD))
            {
                rectHDD.Stroke = Brushes.Red;
                rectHDD.StrokeThickness = 5;
            }
            else
            {
                rectHDD.Stroke = Brushes.Black;
                rectHDD.StrokeThickness = 2;
            }
            if (isColliding(imgPower, rectPower))
            {
                rectPower.Stroke = Brushes.Lime;
                rectPower.StrokeThickness = 5;
            }
            else
            {
                rectPower.Stroke = Brushes.Black;
                rectPower.StrokeThickness = 2;
            }
            if (isColliding(imgPower, rectRam))
            {
                rectRam.Stroke = Brushes.Red;
                rectRam.StrokeThickness = 5;
            }
            else
            {
                rectRam.Stroke = Brushes.Black;
                rectRam.StrokeThickness = 2;
            }
            if (isColliding(imgPower, rectGIU))
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

        private void ramColliders()
        {
            if (isColliding(imgRam, rectProc))
            {
                rectProc.Stroke = Brushes.Red;
                rectProc.StrokeThickness = 5;
            }
            else
            {
                rectProc.Stroke = Brushes.Black;
                rectProc.StrokeThickness = 2;
            }
            if (isColliding(imgRam, rectHDD))
            {
                rectHDD.Stroke = Brushes.Red;
                rectHDD.StrokeThickness = 5;
            }
            else
            {
                rectHDD.Stroke = Brushes.Black;
                rectHDD.StrokeThickness = 2;
            }
            if (isColliding(imgRam, rectPower))
            {
                rectPower.Stroke = Brushes.Red;
                rectPower.StrokeThickness = 5;
            }
            else
            {
                rectPower.Stroke = Brushes.Black;
                rectPower.StrokeThickness = 2;
            }
            if (isColliding(imgRam, rectRam))
            {
                rectRam.Stroke = Brushes.Lime;
                rectRam.StrokeThickness = 5;
            }
            else
            {
                rectRam.Stroke = Brushes.Black;
                rectRam.StrokeThickness = 2;
            }
            if (isColliding(imgRam, rectGIU))
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

        private void GIUcolliders()
        {
            if (isColliding(imgGIU, rectProc))
            {
                rectProc.Stroke = Brushes.Red;
                rectProc.StrokeThickness = 5;
            }
            else
            {
                rectProc.Stroke = Brushes.Black;
                rectProc.StrokeThickness = 2;
            }
            if (isColliding(imgGIU, rectHDD))
            {
                rectHDD.Stroke = Brushes.Red;
                rectHDD.StrokeThickness = 5;
            }
            else
            {
                rectHDD.Stroke = Brushes.Black;
                rectHDD.StrokeThickness = 2;
            }
            if (isColliding(imgGIU, rectPower))
            {
                rectPower.Stroke = Brushes.Red;
                rectPower.StrokeThickness = 5;
            }
            else
            {
                rectPower.Stroke = Brushes.Black;
                rectPower.StrokeThickness = 2;
            }
            if (isColliding(imgGIU, rectRam))
            {
                rectRam.Stroke = Brushes.Red;
                rectRam.StrokeThickness = 5;
            }
            else
            {
                rectRam.Stroke = Brushes.Black;
                rectRam.StrokeThickness = 2;
            }
            if (isColliding(imgGIU, rectGIU))
            {
                rectGIU.Stroke = Brushes.Lime;
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

