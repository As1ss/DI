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
    /// Lógica de interacción para ModoMedio.xaml
    /// </summary>
    public partial class ModoMedio : Page
    {

        MainWindow window;

        //Aqui inicializamos todas las posiciones de los elementos
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

        //Aqui inicializamos todas las variables de los elementos
        List<Rectangle> rectangles;
        int currentRectangleIndex = 0;

        //Aqui inicializamos todos los timers
        DispatcherTimer opacityTimer;
        DispatcherTimer respawnTimer;

        //Aqui inicializamos todas las variables de puntuación y vidas
        static int puntuacion;
        static int vidas;

        //Aqui inicializamos todas las variables de los elementos seleccionados
        static bool imgProcSelected;
        static bool imgHDDSelected;
        static bool imgPowerSelected;
        static bool imgRamSelected;
        static bool imgGIUSelected;


        //Aqui inicializamos todas las variables de los elementos vivos
        bool boxProcisAlive;
        bool boxHDDisAlive;
        bool boxPowerisAlive;
        bool boxRamisAlive;
        bool boxGIUisAlive;

        public ModoMedio(MainWindow window)
        {
            InitializeComponent();
            InitializeRectangles(); // Inicializar la lista de rectángulos
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

            //Aqui inicializamos todas las variables de los elementos seleccionados
            vidas = 2;
            puntuacion = 0;
            labelVidas.Content = "Vidas: " + vidas.ToString();

            //Aqui inicializamos todas las variables de los elementos seleccionados
            boxHDDisAlive = true;
            boxProcisAlive = true;
            boxPowerisAlive = true;
            boxRamisAlive = true;
            boxGIUisAlive = true;

            //Aqui inicializamos todos los timers
            opacityTimer = new DispatcherTimer();
            opacityTimer.Tick += Timer_Tick;
            opacityTimer.Interval = TimeSpan.FromSeconds(1);
            opacityTimer.Start();

            respawnTimer = new DispatcherTimer();
            respawnTimer.Tick += Respawn_Tick;
            respawnTimer.Interval = TimeSpan.FromSeconds(5);
            respawnTimer.Start();
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

        private void Respawn_Tick(object? sender, EventArgs e)
        {
            //Comprobación si los rectangulos están desactivados

            if (!boxProcisAlive)
            {//Si el rectángulo está desactivado, lo activamos
                rectProc.Opacity = 1; // Aumentamos la opacidad del rectángulo
                boxProcisAlive = true; // Activar el rectángulo
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
            if (puntuacion == 8)
            {
                SoundManager.nivel2SoundTrack.Stop();//Paramos la música del nivel 2
                respawnTimer.Stop(); // Detener el timer de respawn
                opacityTimer.Stop(); // Detener el timer de opacidad
                MessageBox.Show("Has pasado de nivel!"); // Mostrar mensaje de victoria
               
                
                Nivel3TalkFrame nivel3TalkFrame= new Nivel3TalkFrame(window); // Inicializar la página de diálogo del nivel 3
                this.NavigationService.Navigate(nivel3TalkFrame); // Navegar a la página de diálogo del nivel 3

            }

            if (currentRectangleIndex < rectangles.Count) // Comprobar si el índice del rectángulo actual es menor que el número de rectángulos
            {
                Rectangle currentRect = rectangles[currentRectangleIndex]; // Obtener el rectángulo actual
                currentRect.Opacity -= 0.2; // Disminuir la opacidad del rectángulo actual

                if (currentRect.Opacity <= 0) // Comprobar si la opacidad del rectángulo actual es menor o igual a 0
                {
                    string rectName = currentRect.Name; // Obtener el nombre del rectángulo actual


                    // Comprobar el nombre del rectángulo
                    if (rectName == "rectProc")
                    {
                        // Si el nombre del rectángulo es "rectProc", desactivar el rectángulo, así con todos los demás
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
                    if (rectName == "rectGIU")
                    {
                        boxGIUisAlive = false;
                    }

                    currentRectangleIndex++; // Incrementar el índice del rectángulo actual
                    vidas--; // Disminuir las vidas
                    labelVidas.Content = "Vidas: " + vidas; // Actualizar el contenido del Label de vidas
                    if (vidas <= 0) // Comprobar si las vidas son menores o iguales a 0
                    {
                        SoundManager.nivel2SoundTrack.Stop();//Paramos la música del nivel 2
                        respawnTimer.Stop(); // Detener el timer de respawn
                        opacityTimer.Stop(); // Detener el timer de opacidad
                        MessageBox.Show("Has perdido pulsa aceptar para continuar."); // Mostrar mensaje de derrota
                        Principal princpalPage = new Principal(window); // Inicializar la página principal
                        this.NavigationService.Navigate(princpalPage); // Navegar a la página principal
                    }
                }
            }
            else
            {
                // Si todos los rectángulos han alcanzado una opacidad < 0, reinicia el proceso.
                currentRectangleIndex = 0;


            }
        }

        private bool isColliding(Rectangle rect1, Rectangle rect2) // Comprobar si dos rectángulos están colisionando
        {
            Point rect1Pos = new Point(Canvas.GetLeft(rect1), Canvas.GetTop(rect1)); // Obtener la posición del rectángulo 1
            Point rect2Pos = new Point(Canvas.GetLeft(rect2), Canvas.GetTop(rect2)); // Obtener la posición del rectángulo 2

            // Comprobar si los rectángulos están colisionando
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

      
        private void canvasMedio_Drop(object sender, DragEventArgs e)
        {
            //Aqui inicializamos todos los eventos de los elementos de drag and drop
            if (imgProcSelected)
            { // Comprobar si el procesador está seleccionado
                imgProcPosition = e.GetPosition(canvasNivel2); // Obtener la posición del procesador
                Canvas.SetTop(imgProc, imgProcPosition.Y); // Establecer la posición del procesador
                Canvas.SetLeft(imgProc, imgProcPosition.X); // Establecer la posición del procesador
                procesadorColliders(); // Comprobar las colisiones del procesador
            }
            if (imgHDDSelected)
            {
                imgHDDPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);
                hardDiskColliders();
            }
            if (imgPowerSelected)
            {
                imgPowerPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgPower, imgPowerPosition.Y);
                Canvas.SetLeft(imgPower, imgPowerPosition.X);
                powerColliders();
            }
            if (imgRamSelected)
            {
                imgRamPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgRam, imgRamPosition.Y);
                Canvas.SetLeft(imgRam, imgRamPosition.X);
                ramColliders();
            }
            if (imgGIUSelected)
            {
                imgGIUPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgGIU, imgGIUPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUPosition.X);
                GIUcolliders();
            }



        }

        private void canvasMedio_DragOver(object sender, DragEventArgs e)
        {
            //Aqui inicializamos todos los eventos de los elementos de drag and drop

            if (imgProcSelected)
            {// Comprobar si el procesador está seleccionado
                imgProcPosition = e.GetPosition(canvasNivel2); // Obtener la posición del procesador
                Canvas.SetTop(imgProc, imgProcPosition.Y); // Establecer la posición del procesador
                Canvas.SetLeft(imgProc, imgProcPosition.X); // Establecer la posición del procesador
                procesadorColliders(); // Comprobar las colisiones del procesador
            }
            if (imgHDDSelected)
            {
                imgHDDPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);
                hardDiskColliders();
            }
            if (imgPowerSelected)
            {
                imgPowerPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgPower, imgPowerPosition.Y);
                Canvas.SetLeft(imgPower, imgPowerPosition.X);
                powerColliders();
            }
            if (imgRamSelected)
            {
                imgRamPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgRam, imgRamPosition.Y);
                Canvas.SetLeft(imgRam, imgRamPosition.X);
                ramColliders();
            }
            if (imgGIUSelected)
            {
                imgGIUPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgGIU, imgGIUPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUPosition.X);
                GIUcolliders();
            }


        }

        private void imgProc_MouseMove(object sender, MouseEventArgs e) // Evento de movimiento del objeto procesador
        {
            //Comprobación de si el botón izquierdo del ratón está pulsado
            if (e.LeftButton == MouseButtonState.Pressed)
            { 
                imgProcPosition = e.GetPosition(canvasNivel2); // Obtener la posición del procesador
                Canvas.SetTop(imgProc, imgProcPosition.Y); // Establecer la posición del procesador
                Canvas.SetLeft(imgProc, imgProcPosition.X); // Establecer la posición del procesador
                imgHDDSelected = false; // Desactivar la selección del disco duro
                imgPowerSelected = false; // Desactivar la selección de la fuente de alimentación
                imgRamSelected = false; // Desactivar la selección de la memoria RAM
                imgGIUSelected = false; // Desactivar la selección de la tarjeta gráfica
                imgProcSelected = true; // Activar la selección del procesador
                DragDrop.DoDragDrop(canvasNivel2, imgProc, DragDropEffects.Move); // Iniciar el drag and drop del procesador



            }
            //Comprobación de si el botón izquierdo del ratón está soltado
            if (e.LeftButton == MouseButtonState.Released)
            {
                //Desactivar la selección del procesador
                imgProcSelected = false;

                //Comprobación de si el procesador está colisionando con el rectángulo del procesador cuando el boton se ha soltado
                if (isColliding(imgProc, rectProc) && imgProcSelected == false && boxProcisAlive)
                {
                    rectProc.Stroke = Brushes.Lime; // Cambiar el color del rectángulo del procesador a verde
                    rectProc.StrokeThickness = 5; // Cambiar el grosor del rectángulo del procesador a 5
                    puntuacion += 1; // Aumentar la puntuación
                    labelPuntuacion.Content = puntuacion + "/8"; // Actualizar el contenido del Label de puntuación
                    rectProc.Opacity = -1; // Desactivar el rectángulo del procesador
                    vidas++; // Aumentar las vidas
                   
                }


                procesadorColliders(); // Comprobar las colisiones del procesador
                Canvas.SetTop(imgProc, imgProcOriginalPosition.Y); // Establecer la posición del procesador a la posición original
                Canvas.SetLeft(imgProc, imgProcOriginalPosition.X); // Establecer la posición del procesador a la posición original
            }
        }

        private void imgHDD_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                imgHDDPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgHDD, imgHDDPosition.Y);
                Canvas.SetLeft(imgHDD, imgHDDPosition.X);
                imgProcSelected = false;
                imgPowerSelected = false;
                imgRamSelected = false;
                imgGIUSelected = false;
                imgHDDSelected = true;
                DragDrop.DoDragDrop(canvasNivel2, imgHDD, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgHDDSelected = false;
                if (isColliding(imgHDD, rectHDD) && imgHDDSelected == false && boxHDDisAlive)
                {
                    rectHDD.Stroke = Brushes.Lime;
                    rectHDD.StrokeThickness = 5;
                    puntuacion += 1;
                    labelPuntuacion.Content = puntuacion + "/8";
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

                imgPowerPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgPower, imgPowerPosition.Y);
                Canvas.SetLeft(imgPower, imgPowerPosition.X);
                imgProcSelected = false;
                imgHDDSelected = false;
                imgRamSelected = false;
                imgGIUSelected = false;
                imgPowerSelected = true;

                DragDrop.DoDragDrop(canvasNivel2, imgPower, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgPowerSelected = false;
                if (isColliding(imgPower, rectPower) && imgPowerSelected == false && boxPowerisAlive)
                {
                    rectPower.Stroke = Brushes.Lime;
                    rectPower.StrokeThickness = 5;
                    puntuacion += 1;
                    labelPuntuacion.Content = puntuacion + "/8";
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

                imgRamPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgRam, imgRamPosition.Y);
                Canvas.SetLeft(imgRam, imgRamPosition.X);
                imgProcSelected = false;
                imgHDDSelected = false;
                imgPowerSelected = false;
                imgGIUSelected = false;
                imgRamSelected = true;

                DragDrop.DoDragDrop(canvasNivel2, imgRam, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgRamSelected = false;
                if (isColliding(imgRam, rectRam) && imgRamSelected == false && boxRamisAlive)
                {
                    rectRam.Stroke = Brushes.Lime;
                    rectRam.StrokeThickness = 5;
                    puntuacion += 1;
                    labelPuntuacion.Content = puntuacion + "/8";
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

                imgGIUPosition = e.GetPosition(canvasNivel2);
                Canvas.SetTop(imgGIU, imgGIUPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUPosition.X);
                imgProcSelected = false;
                imgHDDSelected = false;
                imgPowerSelected = false;
                imgRamSelected = false;
                imgGIUSelected = true;

                DragDrop.DoDragDrop(canvasNivel2, imgGIU, DragDropEffects.Move);


            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                imgGIUSelected = false;
                if (isColliding(imgGIU, rectGIU) && imgGIUSelected == false && boxGIUisAlive)
                {
                    rectGIU.Stroke = Brushes.Lime;
                    rectGIU.StrokeThickness = 5;
                    puntuacion += 1;
                    labelPuntuacion.Content = puntuacion + "/8";
                    rectGIU.Opacity = -1f;
                    vidas++;
                   
                }

                hardDiskColliders();
                Canvas.SetTop(imgGIU, imgGIUOriginalPosition.Y);
                Canvas.SetLeft(imgGIU, imgGIUOriginalPosition.X);

            }
        }

        //Controlamos los objetos que colisionan con la fuente de alimentación
        private void powerColliders()
        {
            //Comprobación de si los objetos colisionan con la fuente de alimentación
            if (isColliding(imgPower, rectProc))
            {
                rectProc.Stroke = Brushes.Red; // Cambiar el color del rectángulo del procesador a rojo
                rectProc.StrokeThickness = 5; // Cambiar el grosor del rectángulo del procesador a 5


            }

            else //Si no esta colisionando
            {
                rectProc.Stroke = Brushes.Black; // Cambiar el color del rectángulo del procesador a negro
                rectProc.StrokeThickness = 2; // Cambiar el grosor del rectángulo del procesador a 2
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
