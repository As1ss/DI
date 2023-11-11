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
    /// Lógica de interacción para nivel1TalkFrame.xaml
    /// </summary>
    public partial class nivel1TalkFrame : Page
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
     
        public nivel1TalkFrame(MainWindow window)
        {
            contadorClicks = 0;
            InitializeComponent();
            this.window = window;
            textWinston.Content = string.Empty;
            textTobJorn.Content = string.Empty;
            textoActual = "Nuestro primer cliente es un buen amigo llamado Torbjorn. Es un poco gruñón pero\n " +
                "es buena persona y necesita nuestros componentes para mejorar sus torretas.";
            textoSegundo = "¡Hey, buenas Winston! Gracias a dios que has llegado ¿Quién es ese con el que vienes?\n¡Bah, no importa!  Lo único que quiero son esos malditos componentes para mis chicas\nhambrientas de poder.";
            textoTercero = "Vaya, parece está aún más gruñón de lo normal. Será mejor " +
                "que nos ponganmos manos a la\nobra de inmediato para evitar su mal humor.";
            indiceTexto = 0;
            indiceTextoSegundo = 0;
            indiceTextoTercero = 0;

            timerTexto = new DispatcherTimer();
            timerTexto.Interval = TimeSpan.FromMilliseconds(30); // Controla la velocidad de la animación
            timerTexto.Tick += Texto_Tick;
            timerTexto.Start();

          
            SoundManager.nivel1SoundTrack.Play();


        }

        private void Texto_Tick(object? sender, EventArgs e)
        {
            if (indiceTexto < textoActual.Length)
            {
                // Agregar la siguiente letra al contenido del Label
                textWinston.Content += textoActual[indiceTexto].ToString();
                indiceTexto++;
                if (indiceTexto == textoActual.Length)
                {
                    timerTexto.Stop();
                }
            }

            else if (indiceTextoSegundo < textoSegundo.Length)
            {
               textTobJorn.Content += textoSegundo[indiceTextoSegundo].ToString();
                indiceTextoSegundo++;
                if (indiceTextoSegundo== textoSegundo.Length)
                {
                    timerTexto.Stop();
                }
            }
            else if (indiceTextoTercero< textoTercero.Length)
            {
                textWinston.Content += textoTercero[indiceTextoTercero].ToString();
                indiceTextoTercero++;
                if(indiceTextoTercero== textoTercero.Length)
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
                textTobJorn.Content = textoSegundo;
                indiceTextoSegundo = textoSegundo.Length;
                


            }

            else if (contadorClicks == 4)
            {
               
                textWinston.Content = string.Empty;
                SegundoTexto();
                timerTexto.Start();
              
            }
            else if (contadorClicks==5)
            {
               
                timerTexto.Stop();
                textWinston.Content = textoTercero;
            }
            else if(contadorClicks==6)
            {
               
                ModoFacil nivel1 = new ModoFacil(window);
                this.NavigationService.Navigate(nivel1);
            }

        }
        private void PrimerTexto()
        {
            textTobJorn.Visibility = Visibility.Visible;
            tobjornImage.Visibility = Visibility.Visible;
            bubbleChatTobjorn.Visibility = Visibility.Visible;

            textWinston.Visibility = Visibility.Hidden;
            bubbleChatWinston.Visibility = Visibility.Hidden;
        }
        private void SegundoTexto()
        {
            textTobJorn.Visibility = Visibility.Hidden;
            tobjornImage.Visibility = Visibility.Hidden;
            bubbleChatTobjorn.Visibility = Visibility.Hidden;
           
           
            textWinston.Visibility = Visibility.Visible;
            bubbleChatWinston.Visibility = Visibility.Visible;
        }
    }

}
