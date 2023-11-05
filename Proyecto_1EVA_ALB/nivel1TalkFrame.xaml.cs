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
    /// Lógica de interacción para nivel1TalkFrame.xaml
    /// </summary>
    public partial class nivel1TalkFrame : Page
    {
        static int contadorClicks;
        MainWindow window;
        public nivel1TalkFrame(MainWindow window)
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
            String texto = "Vaya, parece está aún más gruñón de lo normal. Será mejor " +
                "que nos ponganmos manos a la\nobra de inmediato para evitar su mal humor.";
            textWinston.Content = texto;
            textWinston.Visibility = Visibility.Visible;
            bubbleChatWinston.Visibility = Visibility.Visible;
        }
    }
    
}
