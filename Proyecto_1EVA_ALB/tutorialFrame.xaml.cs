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
using WpfAnimatedGif;

namespace Proyecto_1EVA_ALB
{
    /// <summary>
    /// Lógica de interacción para tutorialFrame.xaml
    /// </summary>
    public partial class tutorialFrame : Page
    {
        static int contadorClicks;
        DispatcherTimer timer;
        MainWindow window;
        BitmapImage image;
        static string textoActual; // Texto actual que se mostrará letra por letra
        static string textoSegundo;
         int indiceTexto;// Índice de la letra actual
         int indiceTextoSegundo;
        private DispatcherTimer timerTexto; // Temporizador para mostrar el texto letra por letra
        SoundPlayer tutorialSoundTrack;
        public tutorialFrame(MainWindow window)
        {
            this.window = window;
            image = new BitmapImage();
            InitializeComponent();


            timer = new DispatcherTimer();
            timer.Tick += Gif_Tick;
            timer.Start();
            contadorClicks = 0;

            textoActual = "Bienvenido novato, mi nombre es Winston y estoy aquí para instruirte y guiarte\n a lo largo de tu recorrido en este juego.";
            textoSegundo = "El objetivo que debemos cumplir es el empaquetado de todos los componentes hardware \npara satisfacer" +
                " las peticiones de nuestros clientes antes de que desaparezcan las cajas.";
            indiceTexto = 0; // Comenzar desde la primera letra
            textWinston.Content = string.Empty; // Inicializar el contenido del Label

            timerTexto = new DispatcherTimer();
            timerTexto.Interval = TimeSpan.FromMilliseconds(30); // Controla la velocidad de la animación
            timerTexto.Tick += Texto_Tick;
            timerTexto.Start();

            tutorialSoundTrack = new SoundPlayer("tutorialSoundTrack.wav");
            tutorialSoundTrack.PlayLooping();



        }

        private void Texto_Tick(object? sender, EventArgs e)
        {
            if (indiceTexto < textoActual.Length)
            {
                // Agregar la siguiente letra al contenido del Label
                textWinston.Content += textoActual[indiceTexto].ToString();
                indiceTexto++;
                if (indiceTexto == textoActual.Length)//Si el texto llega al final se para el timer para que no reporduzca el siguiente texto
                {
                    timerTexto.Stop();
                }
            }

            else if (indiceTextoSegundo < textoSegundo.Length)
            {
                textWinston.Content += textoSegundo[indiceTextoSegundo].ToString();
                indiceTextoSegundo++;
            }
            else
            {
                timerTexto.Stop();
                
            }



        }
        private void Gif_Tick(object? sender, EventArgs e)
        {

            image.BeginInit();
            image.UriSource = new Uri("tutorialGif.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(testGIF, image);
            timer.Stop();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            contadorClicks++;
            if (contadorClicks == 1)
            {
                timerTexto.Stop(); // Detener la animación de texto actual
                textWinston.Content = textoActual; // Mostrar el texto completo
                indiceTexto = textoActual.Length;
               
            }
            else if (contadorClicks == 2)
            {
                textWinston.Content = string.Empty;
                timerTexto.Start();


            }
            else if (contadorClicks == 3)
            {
                timerTexto.Stop();
                textWinston.Content = textoSegundo;
               

            }
           
         else if (contadorClicks==4)
            {
                
                tutorialSoundTrack.Stop();
                nivel1TalkFrame nivel1Frame = new nivel1TalkFrame(window);
                this.NavigationService.Navigate(nivel1Frame);
            }
        }

       
    }
}
