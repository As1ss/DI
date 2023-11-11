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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Proyecto_1EVA_ALB
{
    /// <summary>
    /// Lógica de interacción para ModoDios.xaml
    /// </summary>
    public partial class ModoDios : Page
    {
        MainWindow window;

        // Inicializar variables de posición de los elementos
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

        // Inicializar variables de los rectángulos
        List<Rectangle> rectangles;

        // Inicializar variable del índice del rectángulo actual
        int currentRectangleIndex = 0;

        // Inicializar el DispatcherTimer
        DispatcherTimer opacityTimer;
        DispatcherTimer respawnTimer;

        // Inicializar variables de puntuación y vidas
        static int puntuacion;
        static int vidas;

        // Inicializar variables de selección de imagen
        static bool imgProcSelected;
        static bool imgHDDSelected;
        static bool imgPowerSelected;
        static bool imgRamSelected;
        static bool imgGIUSelected;


        // Inicializar de si estan vivos los rectángulos
        bool boxProcisAlive;
        bool boxHDDisAlive;
        bool boxPowerisAlive;
        bool boxRamisAlive;
        bool boxGIUisAlive;

        SoundPlayer nivel3SoundTrack;

        public ModoDios(MainWindow window)
        {
            InitializeComponent();
            InitializeRectangles(); // Añadir los rectángulos a la lista de rectángulos
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

            // Inicializar variables de puntuación y vidas
            vidas = 1;
            puntuacion = 0;

            labelVidas.Content = "Vidas: " + vidas.ToString(); // Añadir el contenido al Label de las vidas

            // Inicializar variables de selección de imagen
            boxHDDisAlive = true;
            boxProcisAlive = true;
            boxPowerisAlive = true;
            boxRamisAlive = true;
            boxGIUisAlive = true;

          
            opacityTimer = new DispatcherTimer();
            opacityTimer.Tick += Timer_Tick; // Añadir el evento Tick al DispatcherTimer
            opacityTimer.Interval = TimeSpan.FromSeconds(0.5f); // Controla la velocidad del intervalo de opacidad
            opacityTimer.Start(); // Iniciar el DispatcherTimer

            respawnTimer = new DispatcherTimer();
            respawnTimer.Tick += Respawn_Tick; // Añadir el evento Tick al DispatcherTimer
            respawnTimer.Interval = TimeSpan.FromSeconds(2.5f); // Controla la velocidad del intervalo de respawn
            respawnTimer.Start(); // Iniciar el DispatcherTimer

            SoundManager.nivel3SoundTrack.Play(); // Reproducir la música de fondo del nivel 3

           
        }


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
        // Evento Tick del DispatcherTimer respawnTimer
        private void Respawn_Tick(object? sender, EventArgs e) 
        {
            // Comprobar si los rectángulos están vivos
            if (!boxProcisAlive)
            {
                rectProc.Opacity = 1; // Establecer la opacidad del rectángulo a 1
                boxProcisAlive = true; // Establecer la variable de si está vivo a true
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
            if (puntuacion == 12) // Comprobar si la puntuación es igual a 12
            {
             
                SoundManager.nivel3SoundTrack.Stop(); // Detener la música de fondo del nivel 3
                respawnTimer.Stop(); // Detener el DispatcherTimer respawnTimer
                opacityTimer.Stop(); // Detener el DispatcherTimer opacityTimer
                MessageBox.Show("Has pasado de nivel!"); // Mostrar un mensaje de que has pasado de nivel


                FinalTalkFrame finalTalk = new FinalTalkFrame(window); // Crear una instancia de la clase FinalTalkFrame
                this.NavigationService.Navigate(finalTalk); // Navegar a la página FinalTalkFrame

            }

            if (currentRectangleIndex < rectangles.Count) // Comprobar si el índice del rectángulo actual es menor que la cantidad de rectángulos
            {
                Rectangle currentRect = rectangles[currentRectangleIndex]; // Obtener el rectángulo actual
                currentRect.Opacity -= 0.2; // Disminuir la opacidad del rectángulo actual en 0.2

                if (currentRect.Opacity <= 0) // Comprobar si la opacidad del rectángulo actual es menor o igual a 0
                {
                    string rectName = currentRect.Name; // Obtener el nombre del rectángulo actual
                     

                    // Comprobar el nombre del rectángulo
                    if (rectName == "rectProc")
                    {
                        boxProcisAlive = false;// Establecer la variable de si está vivo a false

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
                    if (rectName == "rectGIU")
                    {
                        boxGIUisAlive = false;
                    }

                    currentRectangleIndex++;
                    vidas--;
                    labelVidas.Content = "Vidas: " + vidas;
                    if (vidas <= 0)
                    {
                       
                        SoundManager.nivel3SoundTrack.Stop();
                        respawnTimer.Stop();
                        opacityTimer.Stop();
                        MessageBox.Show("Has perdido pulsa aceptar para continuar.");
                        Principal princpalPage = new Principal(window);
                        this.NavigationService.Navigate(princpalPage);
                    }
                }
            }
            else
            {
                // Si todos los rectángulos han alcanzado una opacidad < 0, reinicia el proceso.
                currentRectangleIndex = 0;


            }
        }

        // Método para comprobar si dos rectángulos están colisionando
        private bool isColliding(Rectangle rect1, Rectangle rect2)
        {
            Point rect1Pos = new Point(Canvas.GetLeft(rect1), Canvas.GetTop(rect1)); // Obtener la posición del rectángulo 1
            Point rect2Pos = new Point(Canvas.GetLeft(rect2), Canvas.GetTop(rect2)); // Obtener la posición del rectángulo 2

            // Comprobar si el rectángulo 1 está colisionando con el rectángulo 2
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

        // Evento Drop del Canvas
        private void canvasFacil_Drop(object sender, DragEventArgs e) 
        {
            if (imgProcSelected) // Comprobar si la imagen del procesador está seleccionada
            {
                imgProcPosition = e.GetPosition(canvasNivel3); // Obtener la posición de la imagen del procesador
                Canvas.SetTop(imgProc, imgProcPosition.Y); // Establecer la posición de la imagen del procesador en el Canvas
                Canvas.SetLeft(imgProc, imgProcPosition.X); // Establecer la posición de la imagen del procesador en el Canvas
                procesadorColliders(); // Comprobar si la imagen del procesador está colisionando con algún rectángulo
            }
            
            
            if (imgHDDSelected)
            {
                imgHDDPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);
                hardDiskColliders();
            }
            if (imgPowerSelected)
            {
                imgPowerPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgPower, imgPowerPosition.Y);
                Canvas.SetLeft(imgPower, imgPowerPosition.X);
                powerColliders();
            }
            if (imgRamSelected)
            {
                imgRamPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgRam, imgRamPosition.Y);
                Canvas.SetLeft(imgRam, imgRamPosition.X);
                ramColliders();
            }
            if (imgGIUSelected)
            {
                imgGIUPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgGIU, imgGIUPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUPosition.X);
                GIUcolliders();
            }



        }

        // Evento DragOver del Canvas
        private void canvasFacil_DragOver(object sender, DragEventArgs e) 
        {

            if (imgProcSelected) //     Comprobar si la imagen del procesador está seleccionada
            {
                imgProcPosition = e.GetPosition(canvasNivel3); // Obtener la posición de la imagen del procesador
                Canvas.SetTop(imgProc, imgProcPosition.Y); // Establecer la posición de la imagen del procesador en el Canvas
                Canvas.SetLeft(imgProc, imgProcPosition.X); // Establecer la posición de la imagen del procesador en el Canvas
                procesadorColliders(); // Comprobar si la imagen del procesador está colisionando con algún rectángulo
            }
           
            if (imgHDDSelected)
            {
                imgHDDPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);
                hardDiskColliders();
            }
            if (imgPowerSelected)
            {
                imgPowerPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgPower, imgPowerPosition.Y);
                Canvas.SetLeft(imgPower, imgPowerPosition.X);
                powerColliders();
            }
            if (imgRamSelected)
            {
                imgRamPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgRam, imgRamPosition.Y);
                Canvas.SetLeft(imgRam, imgRamPosition.X);
                ramColliders();
            }
            if (imgGIUSelected)
            {
                imgGIUPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgGIU, imgGIUPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUPosition.X);
                GIUcolliders();
            }


        }

        private void imgProc_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                imgProcPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgProc, imgProcPosition.Y);
                Canvas.SetLeft(imgProc, imgProcPosition.X);
                imgHDDSelected = false;
                imgPowerSelected = false;
                imgRamSelected = false;
                imgGIUSelected = false;
                imgProcSelected = true;
                DragDrop.DoDragDrop(canvasNivel3, imgProc, DragDropEffects.Move);



            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgProcSelected = false;
                if (isColliding(imgProc, rectProc) && imgProcSelected == false && boxProcisAlive)
                {
                    rectProc.Stroke = Brushes.Lime;
                    rectProc.StrokeThickness = 5;
                    puntuacion += 1;
                    labelPuntuacion.Content = puntuacion + "/12";
                    rectProc.Opacity = -1;
                    vidas++;

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

                imgHDDPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);
                imgProcSelected = false;
                imgPowerSelected = false;
                imgRamSelected = false;
                imgGIUSelected = false;
                imgHDDSelected = true;
                DragDrop.DoDragDrop(canvasNivel3, imgHDD, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgHDDSelected = false;
                if (isColliding(imgHDD, rectHDD) && imgHDDSelected == false && boxHDDisAlive)
                {
                    rectHDD.Stroke = Brushes.Lime;
                    rectHDD.StrokeThickness = 5;
                    puntuacion += 1;
                    labelPuntuacion.Content = puntuacion + "/12";
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

                imgPowerPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgPower, imgPowerPosition.Y);
                Canvas.SetLeft(imgPower, imgPowerPosition.X);
                imgProcSelected = false;
                imgHDDSelected = false;
                imgRamSelected = false;
                imgGIUSelected = false;
                imgPowerSelected = true;

                DragDrop.DoDragDrop(canvasNivel3, imgPower, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgPowerSelected = false;
                if (isColliding(imgPower, rectPower) && imgPowerSelected == false && boxPowerisAlive)
                {
                    rectPower.Stroke = Brushes.Lime;
                    rectPower.StrokeThickness = 5;
                    puntuacion += 1;
                    labelPuntuacion.Content = puntuacion + "/12";
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

                imgRamPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgRam, imgRamPosition.Y);
                Canvas.SetLeft(imgRam, imgRamPosition.X);
                imgProcSelected = false;
                imgHDDSelected = false;
                imgPowerSelected = false;
                imgGIUSelected = false;
                imgRamSelected = true;

                DragDrop.DoDragDrop(canvasNivel3, imgRam, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgRamSelected = false;
                if (isColliding(imgRam, rectRam) && imgRamSelected == false && boxRamisAlive)
                {
                    rectRam.Stroke = Brushes.Lime;
                    rectRam.StrokeThickness = 5;
                    puntuacion += 1;
                    labelPuntuacion.Content = puntuacion + "/12";
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

                imgGIUPosition = e.GetPosition(canvasNivel3);
                Canvas.SetTop(imgGIU, imgGIUPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUPosition.X);
                imgProcSelected = false;
                imgHDDSelected = false;
                imgPowerSelected = false;
                imgRamSelected = false;
                imgGIUSelected = true;

                DragDrop.DoDragDrop(canvasNivel3, imgGIU, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgGIUSelected = false;
                if (isColliding(imgGIU, rectGIU) && imgGIUSelected == false && boxGIUisAlive)
                {
                    rectGIU.Stroke = Brushes.Lime;
                    rectGIU.StrokeThickness = 5;
                    puntuacion += 1;
                    labelPuntuacion.Content = puntuacion + "/12";
                    rectGIU.Opacity = -1f;
                    vidas++;

                }

                hardDiskColliders();
                Canvas.SetTop(imgGIU, imgGIUOriginalPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUOriginalPosition.X);

            }
        }
        // Método para comprobar si la imagen de la fuente de alimentación está colisionando con algún rectángulo
        private void powerColliders() 
        {
            if (isColliding(imgPower, rectProc)) //   Comprobar si la imagen de la fuente de alimentación está colisionando con el rectángulo del procesador
            {
                rectProc.Stroke = Brushes.Red; // Establecer el color del borde del rectángulo del procesador a rojo
                rectProc.StrokeThickness = 5; // Establecer el grosor del borde del rectángulo del procesador a 5


            }
            else
            {
                rectProc.Stroke = Brushes.Black; // Establecer el color del borde del rectángulo del procesador a negro
                rectProc.StrokeThickness = 2; //Establecer el grosor del borde del rectángulo del procesador a 2
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
