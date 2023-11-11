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
    /// Lógica de interacción para Nivel3TalkFrame.xaml
    /// </summary>
    public partial class Nivel3TalkFrame : Page
    {
        // Inicializar variables
        static int contadorClicks;
        MainWindow window;

        // Inicializar el texto actual que se mostrará letra por letra
        static string textoActual; 
        static string textoSegundo;
        static string textoTercero;

        // Inicializar el DispatcherTimer
        DispatcherTimer timerTexto;
        static int indiceTexto;// Índice de la letra actual
        static int indiceTextoSegundo;
        static int indiceTextoTercero;

      

        public Nivel3TalkFrame(MainWindow window)
        {
            contadorClicks = 0;
            InitializeComponent();
            this.window = window;
            // Inicializar el contenido del Label
            textWinston.Content = string.Empty;
            textMercy.Content = string.Empty;
            // Inicializar el texto actual que se mostrará letra por letra
            textoActual = "Nuestro último cliente es la doctora Mercy. Hace tiempo que no tengo trato con ella, pero\n me han comentado que últimamente está algo cambiada. ¡Vaya calor que hace en este\n lugar! Uno se puede achicharrar aquí dentro.";
            textoSegundo = "¡Oh, el joven mono ha venido a visitar mi nueva morada, y trae compañía, qué sorpresa! \nComo bien sabes, las apariencias engañan, ¿verdad? No te preocupes, me aseguraré de \nque estos componentes tengan un uso... interesante.";
            textoTercero = "Supongo que no tenemos muchas opciones. Vamos a ayudar a Mercy con su solicitud, pero\n mantén un ojo en todo esto, no sabemos qué planea realmente.";
           // Inicializar el índice de la letra actual del texto actual y del texto segundo y tercero
            indiceTexto = 0;
            indiceTextoSegundo = 0;
            indiceTextoTercero = 0;

            
            timerTexto = new DispatcherTimer();
            timerTexto.Interval = TimeSpan.FromMilliseconds(30); // Controla la velocidad de la animación
            timerTexto.Tick += Texto_Tick; // Añadir el evento Tick al DispatcherTimer
            timerTexto.Start(); // Iniciar el DispatcherTimer

            SoundManager.nivel3TalkSoundTrack.Play(); // Reproducir la música de fondo

           


        }

        // Evento Tick del DispatcherTimer
        private void Texto_Tick(object? sender, EventArgs e)
        {
            if (indiceTexto < textoActual.Length)
            {
                // Agregar la siguiente letra al contenido del Label
                textWinston.Content += textoActual[indiceTexto].ToString(); // Agregar la siguiente letra al contenido del Label
                indiceTexto++; // Aumentar el índice de la letra actual
                if (indiceTexto == textoActual.Length) // Comprobar si se ha llegado al final del texto
                {
                    timerTexto.Stop(); // Detener la animación de texto actual
                }
            }

            else if (indiceTextoSegundo < textoSegundo.Length) // Comprobar si el índice de la letra actual es menor que la longitud del texto segundo
            {
                textMercy.Content += textoSegundo[indiceTextoSegundo].ToString(); // Agregar la siguiente letra al contenido del Label
                indiceTextoSegundo++; // Incrementar el índice de la letra actual
                if(indiceTextoSegundo == textoSegundo.Length) // Comprobar si se ha llegado al final del texto
                {
                    timerTexto.Stop();// Detener la animación de texto actual
                }
            }
            else if (indiceTextoTercero < textoTercero.Length) // Comprobar si el índice de la letra actual es menor que la longitud del texto tercero
            {
                textWinston.Content += textoTercero[indiceTextoTercero].ToString(); // Agregar la siguiente letra al contenido del Label
                indiceTextoTercero++; // Incrementar el índice de la letra actual
                if(indiceTextoTercero == textoTercero.Length) //    Comprobar si se ha llegado al final del texto
                {
                    timerTexto.Stop(); // Detener la animación de texto actual
                }
            }
            else 
            {
                timerTexto.Stop();// Detener la animación de texto actual
            }
        }

        private void textWinston_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Evento Click del Label
        {
            contadorClicks++; // Incrementar el contador de clicks
            if (contadorClicks == 1) // Comprobar si es el primer click
            {
                timerTexto.Stop(); // Detener la animación de texto actual
                textWinston.Content = textoActual; // Mostrar el texto completo
                indiceTexto = textoActual.Length; // Actualizar el índice de la letra actual al final del texto
            }
            else if (contadorClicks == 2) // Comprobar si es el segundo click
            {
                PrimerTexto(); // Mostrar el texto del soldado 76
                timerTexto.Start(); // Iniciar la animación de texto actual


            }
            else if (contadorClicks == 3) // Comprobar si es el tercer click
            {
                timerTexto.Stop(); // Detener la animación de texto actual
                textMercy.Content = textoSegundo; // Mostrar el texto completo
                indiceTextoSegundo = textoSegundo.Length; // Actualizar el índice de la letra actual al final del texto
                textWinston.Content = string.Empty; // Eliminar el contenido del Label


            }

            else if (contadorClicks == 4) // Comprobar si es el cuarto click
            {

                SegundoTexto(); // Mostrar el texto de mercy
                timerTexto.Start(); // Iniciar la animación de texto actual

            }
            else if (contadorClicks == 5) // Comprobar si es el quinto click
            {
                timerTexto.Stop(); // Detener la animación de texto actual
                textWinston.Content = textoTercero; // Mostrar el texto completo
            }
            else if (contadorClicks == 6) // Comprobar si es el sexto click
            {
                SoundManager.nivel3TalkSoundTrack.Stop(); // Detener la música de fondo
                ModoDios nivel3 = new ModoDios(window); // Crear una instancia de la página nivel 3
                this.NavigationService.Navigate(nivel3); //     Navegar a la página nivel 3 
            }

        }
        private void PrimerTexto() // Método para mostrar el texto de mercy
        {
            textMercy.Visibility = Visibility.Visible; // Mostrar el texto de mercy
            mercyImage.Visibility = Visibility.Visible; // Mostrar la imagen de mercy
            bubbleMercy.Visibility = Visibility.Visible; // Mostrar el bocadillo de mercy

            textWinston.Visibility = Visibility.Hidden; // Ocultar el texto de winston
            bubbleChatWinston.Visibility = Visibility.Hidden; // Ocultar el bocadillo de winston
        }
        private void SegundoTexto() // Método para mostrar el texto de winston
        {
            textMercy.Visibility = Visibility.Hidden; // Ocultar el texto de mercy
            mercyImage.Visibility = Visibility.Hidden; // Ocultar la imagen de mercy
            bubbleMercy.Visibility = Visibility.Hidden; // Ocultar el bocadillo de mercy


            textWinston.Visibility = Visibility.Visible; // Mostrar el texto de winston
            bubbleChatWinston.Visibility = Visibility.Visible; // Mostrar el bocadillo de winston
        }
    }

   

}

