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
    /// Lógica de interacción para Nivel3TalkFrame.xaml
    /// </summary>
    public partial class Nivel3TalkFrame : Page
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
        public Nivel3TalkFrame(MainWindow window)
        {
            contadorClicks = 0;
            InitializeComponent();
            this.window = window;
            textWinston.Content = string.Empty;
            textMercy.Content = string.Empty;
            textoActual = "Nuestro último cliente es la doctora Mercy. Hace tiempo que no tengo trato con ella, pero\n me han comentado que últimamente está algo cambiada. ¡Vaya calor que hace en este\n lugar! Uno se puede achicharrar aquí dentro.";
            textoSegundo = "¡Oh, el joven mono ha venido a visitar mi nueva morada, y trae compañía, qué sorpresa! \nComo bien sabes, las apariencias engañan, ¿verdad? No te preocupes, me aseguraré de \nque estos componentes tengan un uso... interesante.";
            textoTercero = "Supongo que no tenemos muchas opciones. Vamos a ayudar a Mercy con su solicitud, pero\n mantén un ojo en todo esto, no sabemos qué planea realmente.";
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
                textMercy.Content += textoSegundo[indiceTextoSegundo].ToString();
                indiceTextoSegundo++;
            }
            else if (indiceTextoTercero < textoTercero.Length)
            {
                textWinston.Content += textoTercero[indiceTextoTercero].ToString();
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
                textMercy.Content = textoSegundo;
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
                ModoDios nivel3 = new ModoDios(window);
                this.NavigationService.Navigate(nivel3);
            }

        }
        private void PrimerTexto()
        {
            textMercy.Visibility = Visibility.Visible;
            mercyImage.Visibility = Visibility.Visible;
            bubbleMercy.Visibility = Visibility.Visible;

            textWinston.Visibility = Visibility.Hidden;
            bubbleChatWinston.Visibility = Visibility.Hidden;
        }
        private void SegundoTexto()
        {
            textMercy.Visibility = Visibility.Hidden;
            mercyImage.Visibility = Visibility.Hidden;
            bubbleMercy.Visibility = Visibility.Hidden;


            textWinston.Visibility = Visibility.Visible;
            bubbleChatWinston.Visibility = Visibility.Visible;
        }
    }

    /*
     * 
     *  private void SegundoTexto()
    {
        textMercy.Visibility = Visibility.Hidden;
        mercyImage.Visibility = Visibility.Hidden;
        bubbleMercy.Visibility = Visibility.Hidden;
        String texto = "Supongo que no tenemos muchas opciones. Vamos a ayudar a Mercy con su solicitud, pero\n mantén un ojo en todo esto, no sabemos qué planea realmente.";
        textWinston.Content = texto;
        textWinston.Visibility = Visibility.Visible;
        bubbleChatWinston.Visibility = Visibility.Visible;
    }
     * */

}

