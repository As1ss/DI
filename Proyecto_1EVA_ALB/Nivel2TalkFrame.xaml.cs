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
    /// Lógica de interacción para Nivel2TalkFrame.xaml
    /// </summary>
    public partial class Nivel2TalkFrame : Page
    {
        static int contadorClicks;
        MainWindow window;
        static string textoActual; // Texto actual que se mostrará letra por letra
        static string textoSegundo; // Texto segundo que se mostrará letra por letra
        static string textoTercero; // Texto tercero que se mostrará letra por letra

        DispatcherTimer timerTexto;
        static int indiceTexto;// Índice de la letra actual
        static int indiceTextoSegundo; // Índice de la letra actual del texto segundo
        static int indiceTextoTercero; // Índice de la letra actual del texto tercero

        SoundPlayer nivel2SoundTrack;
        public Nivel2TalkFrame(MainWindow window)
        {
            contadorClicks = 0; // Inicializar el contador de clicks
            InitializeComponent();
            this.window = window;
            textWinston.Content = string.Empty; // Inicializar el contenido del Label
            textSoldado76.Content = string.Empty; // Inicializar el contenido del Label
            textoActual = "Nuestro segundo cliente es el justiciero Soldado 76, su solicitud es de suma urgencia\n y requiere un alto nivel de discreción. Se encuentra actualmente en búsqueda y captura \na nivel mundial, lo que hace que esta transacción sea especialmente delicada.";
            textoSegundo = "¡Alto ahí! Ah, Winston, ¿eres tú? Veo que vienes acompañado. Espero que sea de fiar. Han \ninterceptado mi último convoy con los componentes necesarios para mis operaciones\n secretas. Necesito que hagas el trabajo rápido y, ya sabes... Tú no me conoces.";
            textoTercero = "¿Pero qué le pasa a todo el mundo con las prisas? En fin, más vale que nos pongamos a\n ello, no le llaman justiciero por nada.";
            indiceTexto = 0; // Inicializar el índice de la letra actual del texto actual
            indiceTextoSegundo = 0; // Inicializar el índice de la letra actual del texto segundo
            indiceTextoTercero = 0; // Inicializar el índice de la letra actual del texto tercero

            timerTexto = new DispatcherTimer(); // Inicializar el DispatcherTimer
            timerTexto.Interval = TimeSpan.FromMilliseconds(30); // Controla la velocidad de la animación
            timerTexto.Tick += Texto_Tick; // Añadir el evento Tick al DispatcherTimer
            timerTexto.Start(); // Iniciar el DispatcherTimer

            SoundManager.nivel2SoundTrack.Play(); // Reproducir la música de fondo




        }

        private void Texto_Tick(object? sender, EventArgs e)
        {
            // Comprobar si el índice de la letra actual es menor que la longitud del texto actual
            if (indiceTexto < textoActual.Length)
            {
                // Agregar la siguiente letra al contenido del Label
                textWinston.Content += textoActual[indiceTexto].ToString();
                indiceTexto++;
                if(indiceTexto == textoActual.Length) // Comprobar si se ha llegado al final del texto
                {
                    timerTexto.Stop(); // Detener la animación de texto actual
                }
            }

            else if (indiceTextoSegundo < textoSegundo.Length) // Comprobar si el índice de la letra actual es menor que la longitud del texto segundo
            {
                textSoldado76.Content += textoSegundo[indiceTextoSegundo].ToString(); // Agregar la siguiente letra al contenido del Label
                indiceTextoSegundo++; // Incrementar el índice de la letra actual
                if(indiceTextoSegundo == textoSegundo.Length) // Comprobar si se ha llegado al final del texto
                {
                    timerTexto.Stop(); // Detener la animación de texto actual
                }
            }
            else if (indiceTextoTercero < textoTercero.Length) // Comprobar si el índice de la letra actual es menor que la longitud del texto tercero
            {
                textWinston.Content += textoTercero[indiceTextoTercero].ToString(); // Agregar la siguiente letra al contenido del Label
                indiceTextoTercero++; // Incrementar el índice de la letra actual
                if (indiceTextoTercero == textoTercero.Length) // Comprobar si se ha llegado al final del texto
                {
                    timerTexto.Stop(); // Detener la animación de texto actual
                }
            }
            else
            {
                timerTexto.Stop(); //   Detener la animación de texto actual
            }
        }

        private void textWinston_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            contadorClicks++; // Incrementar el contador de clicks
            if (contadorClicks == 1) // Comprobar si es el primer click
            {
                timerTexto.Stop(); // Detener la animación de texto actual
                textWinston.Content = textoActual; // Mostrar el texto completo
                indiceTexto = textoActual.Length; // Igualar el índice de la letra actual a la longitud del texto actual
            }
            else if (contadorClicks == 2) // Comprobar si es el segundo click
            {
                PrimerTexto(); // Mostrar el texto del soldado 76
                timerTexto.Start(); // Iniciar la animación de texto actual


            }
            else if (contadorClicks == 3) // Comprobar si es el tercer click
            {
                timerTexto.Stop(); // Detener la animación de texto actual
                textSoldado76.Content = textoSegundo; // Mostrar el texto completo
                indiceTextoSegundo = textoSegundo.Length; // Igualar el índice de la letra actual a la longitud del texto segundo
                textWinston.Content = string.Empty; // Eliminar el contenido del Label


            }

            else if (contadorClicks == 4) // Comprobar si es el cuarto click
            {

                SegundoTexto(); // Mostrar el texto del soldado 76
                timerTexto.Start(); // Iniciar la animación de texto actual

            }
            else if (contadorClicks == 5) // Comprobar si es el quinto click
            {
                timerTexto.Stop(); // Detener la animación de texto actual
                textWinston.Content = textoTercero; // Mostrar el texto completo
            }
            else if (contadorClicks == 6) // Comprobar si es el sexto click
            {
                ModoMedio nivel2 = new ModoMedio(window); // Crear una instancia de la página nivel 2
                this.NavigationService.Navigate(nivel2); // Navegar a la página nivel 2
            }

        }
        private void PrimerTexto() // Método que muestra el texto del soldado 76
        {
            textSoldado76.Visibility = Visibility.Visible; // Mostrar el texto del soldado 76
            soldado76Image.Visibility = Visibility.Visible; // Mostrar la imagen del soldado 76
            bubbleChatSoldado76.Visibility = Visibility.Visible; // Mostrar el bocadillo de texto del soldado 76

            textWinston.Visibility = Visibility.Hidden; // Ocultar el texto de Winston
            bubbleChatWinston.Visibility = Visibility.Hidden; // Ocultar el bocadillo de texto de Winston
        }
        private void SegundoTexto() // Método que muestra el texto de Winston
        {
            textSoldado76.Visibility = Visibility.Hidden; // Ocultar el texto del soldado 76
            soldado76Image.Visibility = Visibility.Hidden; // Ocultar la imagen del soldado 76
            bubbleChatSoldado76.Visibility = Visibility.Hidden; // Ocultar el bocadillo de texto del soldado 76


            textWinston.Visibility = Visibility.Visible; // Mostrar el texto de Winston
            bubbleChatWinston.Visibility = Visibility.Visible; // Mostrar el bocadillo de texto de Winston
        }
    }
   

}

