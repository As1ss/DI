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

namespace Proyecto_1EVA_ALB
{
    /// <summary>
    /// Lógica de interacción para Nivel3TalkFrame.xaml
    /// </summary>
    public partial class Nivel3TalkFrame : Page
    {
        static int contadorClicks;
        MainWindow window;
        public Nivel3TalkFrame(MainWindow window)
        {
            contadorClicks = 0;
            InitializeComponent();
            this.window = window;


        }

        private void textWinston_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            contadorClicks++;
            if (contadorClicks == 1)
            {
                PrimerTexto();
            }
            if (contadorClicks == 2)
            {

                SegundoTexto();

            }
            if (contadorClicks == 3)
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
            String texto = "Supongo que no tenemos muchas opciones. Vamos a ayudar a Mercy con su solicitud, pero\n mantén un ojo en todo esto, no sabemos qué planea realmente.";
            textWinston.Content = texto;
            textWinston.Visibility = Visibility.Visible;
            bubbleChatWinston.Visibility = Visibility.Visible;
        }
    }
}
