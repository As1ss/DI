using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Reflection;
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
        static Cursor owCursor = new Cursor(Application.GetResourceStream(new Uri("Cursors/pointer.cur", UriKind.Relative)).Stream); //Cursor personalizado
      

        public Principal(MainWindow window)
        {

            this.window = window; //Para poder cerrar la ventana desde el boton salir
            InitializeComponent();
            modoFacil = true;
            Mouse.OverrideCursor = owCursor;
            


        }
        private void btnJugar_Click(object sender, RoutedEventArgs e)
            //Este metodo es para pasar a la ventana de juego
        {
            tutorialFrame tutorialFrame = new tutorialFrame(window);
            this.NavigationService.Navigate(tutorialFrame);



        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        { //Este metodo es para cerrar la ventana
            window.Close();
        }

        private void btnJugar_MouseEnter(object sender, MouseEventArgs e)
        {
            //Esto es para generar la animación de aumento de tamaño sin desposicionar el boton
            Canvas.SetTop(btnJugar, 488);

            btnJugar.Width += 50;
            btnJugar.Height += 50;
        }

        private void btnJugar_MouseLeave(object sender, MouseEventArgs e)
        {
            //Esto es para generar la animación de disminución de tamaño sin desposicionar el boton
            Canvas.SetTop(btnJugar, 538);
            btnJugar.Width -= 50;
            btnJugar.Height -= 50;
        }

        private void btnSalir_MouseEnter(object sender, MouseEventArgs e)
        {
            //Esto es para generar la animación de aumento de tamaño sin desposicionar el boton
            Canvas.SetTop(btnSalir, 488);
            btnSalir.Width += 50;
            btnSalir.Height += 50;
        }

        private void btnSalir_MouseLeave(object sender, MouseEventArgs e)
        {
            //Esto es para generar la animación de disminución de tamaño sin desposicionar el boton
            Canvas.SetTop(btnSalir, 538);
            btnSalir.Width -= 50;
            btnSalir.Height -= 50;

        }
    }
}
