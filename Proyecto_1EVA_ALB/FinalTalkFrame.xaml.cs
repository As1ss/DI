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
    /// Lógica de interacción para FinalTalkFrame.xaml
    /// </summary>
    public partial class FinalTalkFrame : Page
    {
        // Inicializar variables
        static int contadorClicks; // Contador de clicks
        MainWindow window;
        static string textoActual; // Texto actual que se mostrará letra por letra
        static string textoSegundo; // Texto segundo que se mostrará letra por letra del segundo personaje
        static string textoTercero; // Texto tercero que se mostrará letra por letra del tercer personaje

        DispatcherTimer timerTexto;
        static int indiceTexto;// Índice de la letra actual
        static int indiceTextoSegundo; // Índice de la letra actual del texto segundo
        static int indiceTextoTercero; // Índice de la letra actual del texto tercero

       
        public FinalTalkFrame(MainWindow window)
        {
            contadorClicks = 0; // Inicializar el contador de clicks
            InitializeComponent();
            this.window = window;

            // Inicializar el contenido del Label en blanco
            textWinston.Content = string.Empty;
            textAndrew.Content = string.Empty;
            textContinuara.Text = string.Empty;

            // Inicializar el texto actual que se mostrará letra por letra
            textoActual = "¡Vaya día tan ajetreado! Será mejor que regresemos a casa para descansar. Espera \nun momento... ¿Qué es ese ruido?";
            textoSegundo = "Hey, vosotros dos, brokies. Como ya sabréis soy la persona mas influyente de internet\n y más perseguido por la matrix. Necesito de vuestros servicios ya que se acerca el Bull\n Market y hay que estar preparado, pues estos superdeportivos no se pagan solos.\n ¿Qué me decís? ¿Quéreis ser una milesima parte como yo o seguir siendo unos brokies?";
            textoTercero = "CONTINUARÁ...";

            // Inicializar el índice de la letra actual del texto actual y del texto segundo y tercero
            indiceTexto = 0;
            indiceTextoSegundo = 0;
            indiceTextoTercero = 0;


            timerTexto = new DispatcherTimer();
            timerTexto.Interval = TimeSpan.FromMilliseconds(30); // Controla la velocidad de la animación
            timerTexto.Tick += Texto_Tick; // Añadir el evento Tick al DispatcherTimer
            timerTexto.Start(); // Iniciar el DispatcherTimer

            SoundManager.tutorialSoundTrack.Play(); // Reproducir la música de fondo




        }

        // Método que se ejecuta cada vez que el DispatcherTimer alcanza el intervalo establecido
        private void Texto_Tick(object? sender, EventArgs e)
        {
            if (indiceTexto < textoActual.Length) // Si el índice de la letra actual es menor que la longitud del texto actual
            {
                // Agregar la siguiente letra al contenido del Label
                textWinston.Content += textoActual[indiceTexto].ToString(); // Agregar la siguiente letra al contenido del Label
                indiceTexto++; // Aumentar el índice de la letra actual
                if (indiceTexto == textoActual.Length) // Comprobar si se ha llegado al final del texto
                {
                    SoundManager.tutorialSoundTrack.Stop(); // Detener la música de fondo
                    SoundManager.topGSoundTrack.Play(); // Reproducir la música de fondo
                    timerTexto.Stop(); // Detener la animación de texto actual
                }
            }

            else if (indiceTextoSegundo < textoSegundo.Length) // Comprobar si el índice de la letra actual es menor que la longitud del texto segundo
            {
                textAndrew.Content += textoSegundo[indiceTextoSegundo].ToString(); // Agregar la siguiente letra al contenido del Label
                indiceTextoSegundo++; // Incrementar el índice de la letra actual
                if (indiceTextoSegundo == textoSegundo.Length) // Comprobar si se ha llegado al final del texto para detener la animación
                {
                    timerTexto.Stop(); // Detener la animación de texto actual
                }
              
            }
            else if (indiceTextoTercero < textoTercero.Length) // Comprobar si el índice de la letra actual es menor que la longitud del texto tercero
            {
                textContinuara.Text += textoTercero[indiceTextoTercero].ToString(); // Agregar la siguiente letra al contenido del Label
                indiceTextoTercero++;
                if (indiceTextoTercero == textoTercero.Length) // Comprobar si se ha llegado al final del texto para detener la animación
                {
                    timerTexto.Stop(); // Detener la animación de texto actual
                }
            }
            else
            {
                timerTexto.Stop(); //   Detener la animación de texto actual
            }
        }

        private void textWinston_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Evento Click del Label
        {
            // Incrementar el contador de clicks
            contadorClicks++;
            if (contadorClicks == 1) // Comprobar si es el primer click
            {
                timerTexto.Stop(); // Detener la animación de texto actual
                textWinston.Content = textoActual; // Mostrar el texto completo
                indiceTexto = textoActual.Length; // Actualizar el índice de la letra actual al final del texto
            }
            else if (contadorClicks == 2) // Comprobar si es el segundo click
            {
                SoundManager.tutorialSoundTrack.Stop(); // Detener la música de fondo
                SoundManager.topGSoundTrack.Play(); // Reproducir la música de fondo de la siguiente escena
                PrimerTexto(); // Mostrar el texto de top G
                timerTexto.Start(); // Iniciar la animación de texto actual


            }
            else if (contadorClicks == 3) // Comprobar si es el tercer click
            {
                timerTexto.Stop(); // Detener la animación de texto actual
                textAndrew.Content = textoSegundo; // Mostrar el texto completo
                indiceTextoSegundo = textoSegundo.Length; // Actualizar el índice de la letra actual al final del texto
                textWinston.Content = string.Empty; // Eliminar el contenido del Label


            }

            else if (contadorClicks == 4) // Comprobar si es el cuarto click
            {

               
                timerTexto.Start();// Iniciar la animación de texto actual

         

            }
            else if (contadorClicks == 5) // Comprobar si es el quinto click
            {
               SoundManager.topGSoundTrack.Stop(); // Detener la música de fondo
                Principal menuPrincipal = new Principal(window); // Crear una instancia de la ventana principal
                this.NavigationService.Navigate(menuPrincipal); // Navegar a la ventana principal
            }
           

        }
        private void PrimerTexto() // Método que muestra el texto de top G
        {
            textAndrew.Visibility = Visibility.Visible; // Mostrar el texto de top G
            andrewImage.Visibility = Visibility.Visible; // Mostrar la imagen de top G
            bubbleAndrew.Visibility = Visibility.Visible; // Mostrar el bocadillo de top G

            textWinston.Visibility = Visibility.Hidden; // Ocultar el texto de winston
            bubbleChatWinston.Visibility = Visibility.Hidden; // Ocultar el bocadillo de winston
        }
       
    }

}
