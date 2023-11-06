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
    /// Lógica de interacción para Nivel2TalkFrame.xaml
    /// </summary>
    public partial class Nivel2TalkFrame : Page
    {
        static int contadorClicks;
        MainWindow window;
        public Nivel2TalkFrame(MainWindow window)
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
            String texto = "¿Pero qué le pasa a todo el mundo con las prisas? En fin, más vale que nos pongamos a\n ello, no le llaman justiciero por nada.";
            textWinston.Content = texto;
            textWinston.Visibility = Visibility.Visible;
            bubbleChatWinston.Visibility = Visibility.Visible;
        }
    }
}
