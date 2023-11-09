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
        static string textoSegundo;
        static string textoTercero;

        DispatcherTimer timerTexto;
        static int indiceTexto;// Índice de la letra actual
        static int indiceTextoSegundo;
        static int indiceTextoTercero;

        SoundPlayer nivel2SoundTrack;
        public Nivel2TalkFrame(MainWindow window)
        {
            contadorClicks = 0;
            InitializeComponent();
            this.window = window;
            textWinston.Content = string.Empty;
            textSoldado76.Content = string.Empty;
            textoActual = "Nuestro segundo cliente es el justiciero Soldado 76, su solicitud es de suma urgencia\n y requiere un alto nivel de discreción. Se encuentra actualmente en búsqueda y captura \na nivel mundial, lo que hace que esta transacción sea especialmente delicada.";
            textoSegundo = "¡Alto ahí! Ah, Winston, ¿eres tú? Veo que vienes acompañado. Espero que sea de fiar. Han \ninterceptado mi último convoy con los componentes necesarios para mis operaciones\n secretas. Necesito que hagas el trabajo rápido y, ya sabes... Tú no me conoces.";
            textoTercero = "¿Pero qué le pasa a todo el mundo con las prisas? En fin, más vale que nos pongamos a\n ello, no le llaman justiciero por nada.";
            indiceTexto = 0;
            indiceTextoSegundo = 0;
            indiceTextoTercero = 0;

            timerTexto = new DispatcherTimer();
            timerTexto.Interval = TimeSpan.FromMilliseconds(30); // Controla la velocidad de la animación
            timerTexto.Tick += Texto_Tick;
            timerTexto.Start();

            nivel2SoundTrack = new SoundPlayer("nivel2SoundTrack.wav");
            nivel2SoundTrack.PlayLooping();




        }

        private void Texto_Tick(object? sender, EventArgs e)
        {
            if (indiceTexto < textoActual.Length)
            {
                // Agregar la siguiente letra al contenido del Label
                textWinston.Content += textoActual[indiceTexto].ToString();
                indiceTexto++;
                if(indiceTexto == textoActual.Length)
                {
                    timerTexto.Stop();
                }
            }

            else if (indiceTextoSegundo < textoSegundo.Length)
            {
                textSoldado76.Content += textoSegundo[indiceTextoSegundo].ToString();
                indiceTextoSegundo++;
                if(indiceTextoSegundo == textoSegundo.Length)
                {
                    timerTexto.Stop();
                }
            }
            else if (indiceTextoTercero < textoTercero.Length)
            {
                textWinston.Content += textoTercero[indiceTextoTercero].ToString();
                indiceTextoTercero++;
                if (indiceTextoTercero == textoTercero.Length)
                {
                    timerTexto.Stop();
                }
            }
            else
            {
                timerTexto.Stop();
            }
        }

        private void textWinston_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                PrimerTexto();
                timerTexto.Start();


            }
            else if (contadorClicks == 3)
            {
                timerTexto.Stop();
                textSoldado76.Content = textoSegundo;
                indiceTextoSegundo = textoSegundo.Length;
                textWinston.Content = string.Empty;


            }

            else if (contadorClicks == 4)
            {

                SegundoTexto();
                timerTexto.Start();

            }
            else if (contadorClicks == 5)
            {
                timerTexto.Stop();
                textWinston.Content = textoTercero;
            }
            else if (contadorClicks == 6)
            {
                ModoMedio nivel2 = new ModoMedio(window);
                this.NavigationService.Navigate(nivel2);
            }

        }
        private void PrimerTexto()
        {
            textSoldado76.Visibility = Visibility.Visible;
            soldado76Image.Visibility = Visibility.Visible;
            bubbleChatSoldado76.Visibility = Visibility.Visible;

            textWinston.Visibility = Visibility.Hidden;
            bubbleChatWinston.Visibility = Visibility.Hidden;
        }
        private void SegundoTexto()
        {
            textSoldado76.Visibility = Visibility.Hidden;
            soldado76Image.Visibility = Visibility.Hidden;
            bubbleChatSoldado76.Visibility = Visibility.Hidden;


            textWinston.Visibility = Visibility.Visible;
            bubbleChatWinston.Visibility = Visibility.Visible;
        }
    }
    /*
     * 
     * private void SegundoTexto()
    {
        textSoldado76.Visibility = Visibility.Hidden;
        soldado76Image.Visibility = Visibility.Hidden;
        bubbleChatSoldado76.Visibility = Visibility.Hidden;
        String texto = "¿Pero qué le pasa a todo el mundo con las prisas? En fin, más vale que nos pongamos a\n ello, no le llaman justiciero por nada.";
        textWinston.Content = texto;
        textWinston.Visibility = Visibility.Visible;
        bubbleChatWinston.Visibility = Visibility.Visible;
    }
     * 
     */

}

