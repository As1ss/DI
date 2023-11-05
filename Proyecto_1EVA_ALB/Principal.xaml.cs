using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Page
    {
        MainWindow window;
        public bool modoFacil;
        public bool modoMedio;
        public bool modoDios;
        static Cursor owCursor = new Cursor(Application.GetResourceStream(new Uri("pointer.cur",UriKind.Relative)).Stream);
        public Principal(MainWindow window)
        {
            
            this.window = window;   
            InitializeComponent();
            modoFacil = true;
            Mouse.OverrideCursor = owCursor;


          

        }
        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            tutorialFrame tutorial = new tutorialFrame(window);
            this.NavigationService.Navigate(tutorial);

          
        }
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // Crear e instanciar el diálogo personalizado
            var dialog = new Settings(this);

            // Mostrar el diálogo como una ventana emergente
            dialog.ShowDialog();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            window.Close();
        }

        private void btnJugar_MouseEnter(object sender, MouseEventArgs e)
        {
            Canvas.SetTop(btnJugar, 488);
           
            btnJugar.Width += 50;
            btnJugar.Height += 50;
        }

        private void btnJugar_MouseLeave(object sender, MouseEventArgs e)
        {
            Canvas.SetTop(btnJugar, 538);
            btnJugar.Width -= 50;
            btnJugar.Height -= 50;
        }

        private void btnSalir_MouseEnter(object sender, MouseEventArgs e)
        {
            Canvas.SetTop(btnSalir, 488);
            btnSalir.Width += 50;
            btnSalir.Height += 50;
        }

        private void btnSalir_MouseLeave(object sender, MouseEventArgs e)
        {
            Canvas.SetTop(btnSalir, 538);
            btnSalir.Width -= 50;
            btnSalir.Height -= 50;
           
        }
    }
}
