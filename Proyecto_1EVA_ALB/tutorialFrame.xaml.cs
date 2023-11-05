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
using WpfAnimatedGif;

namespace Proyecto_1EVA_ALB
{
    /// <summary>
    /// Lógica de interacción para tutorialFrame.xaml
    /// </summary>
    public partial class tutorialFrame : Page
    {
        static int contadorClicks;
        DispatcherTimer timer;
        MainWindow window;
        BitmapImage image;
        public tutorialFrame(MainWindow window)
        {
            this.window = window;
            image = new BitmapImage();
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += Texto_Tick;
            timer.Start();
            contadorClicks = 0;




        }

        private void Texto_Tick(object? sender, EventArgs e)
        {
            
            image.BeginInit();
            image.UriSource = new Uri("tutorialGif.gif", UriKind.Relative);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(testGIF, image);
            timer.Stop();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            contadorClicks++;
            if (contadorClicks == 1)
            {
                PrimerTexto();

            }
            if (contadorClicks == 2)
            {
                nivel1TalkFrame nivel1Frame = new nivel1TalkFrame(window);
                this.NavigationService.Navigate(nivel1Frame);

            }
        }

        private void PrimerTexto()
        {
            textWinston.Content = "El objetivo que debemos cumplir es el empaquetado de todos los componentes hardware \npara satisfacer" +
                " las peticiones de nuestros clientes antes de que desaparezcan las cajas.";

        }
    }
}
