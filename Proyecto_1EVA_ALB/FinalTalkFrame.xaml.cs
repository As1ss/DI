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
        static int contadorClicks;
        MainWindow window;
        static string textoActual; // Texto actual que se mostrará letra por letra
        static string textoSegundo;
        static string textoTercero;

        DispatcherTimer timerTexto;
        static int indiceTexto;// Índice de la letra actual
        static int indiceTextoSegundo;
        static int indiceTextoTercero;
        public FinalTalkFrame(MainWindow window)
        {
            contadorClicks = 0;
            InitializeComponent();
            this.window = window;
            textWinston.Content = string.Empty;
            textAndrew.Content = string.Empty;
            textContinuara.Text = string.Empty;
            textoActual = "¡Vaya día tan ajetreado! Será mejor que regresemos a casa para descansar. Espera \nun momento... ¿Qué es ese ruido?";
            textoSegundo = "Hey, vosotros dos, brokies. Como ya sabréis soy la persona mas influyente de internet\n y más perseguido por la matrix. Necesito de vuestros servicios ya que se acerca el Bull\n Market y hay que estar preparado, pues estos superdeportivos no se pagan solos.\n ¿Qué me decís? ¿Quéreis ser una milesima parte como yo o seguir siendo unos brokies?";
            textoTercero = "CONTINUARÁ...";
            indiceTexto = 0;
            indiceTextoSegundo = 0;
            indiceTextoTercero = 0;

            timerTexto = new DispatcherTimer();
            timerTexto.Interval = TimeSpan.FromMilliseconds(30); // Controla la velocidad de la animación
            timerTexto.Tick += Texto_Tick;
            timerTexto.Start();




        }

        private void Texto_Tick(object? sender, EventArgs e)
        {
            if (indiceTexto < textoActual.Length)
            {
                // Agregar la siguiente letra al contenido del Label
                textWinston.Content += textoActual[indiceTexto].ToString();
                indiceTexto++;
            }

            else if (indiceTextoSegundo < textoSegundo.Length)
            {
                textAndrew.Content += textoSegundo[indiceTextoSegundo].ToString();
                indiceTextoSegundo++;
            }
            else if (indiceTextoTercero < textoTercero.Length)
            {
                textContinuara.Text += textoTercero[indiceTextoTercero].ToString();
                indiceTextoTercero++;
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
                textAndrew.Content = textoSegundo;
                indiceTextoSegundo = textoSegundo.Length;
                textWinston.Content = string.Empty;


            }

            else if (contadorClicks == 4)
            {

               
                timerTexto.Start();

         

            }
            else if (contadorClicks == 5)
            {
                ModoDios nivel3 = new ModoDios(window);
                this.NavigationService.Navigate(nivel3);
            }
           

        }
        private void PrimerTexto()
        {
            textAndrew.Visibility = Visibility.Visible;
            andrewImage.Visibility = Visibility.Visible;
            bubbleAndrew.Visibility = Visibility.Visible;

            textWinston.Visibility = Visibility.Hidden;
            bubbleChatWinston.Visibility = Visibility.Hidden;
        }
        private void SegundoTexto()
        {
            textAndrew.Visibility = Visibility.Hidden;
            andrewImage.Visibility = Visibility.Hidden;
            bubbleAndrew.Visibility = Visibility.Hidden;


            textWinston.Visibility = Visibility.Visible;
            bubbleChatWinston.Visibility = Visibility.Visible;
        }
    }

}
