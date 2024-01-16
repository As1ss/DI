using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROYECTO_EV2_ALB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class V_InicioSesion : Window
    {
        public V_InicioSesion()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbUser.Text == string.Empty || tbxPassword.Password == string.Empty)
            {
                MessageBox.Show("Introduzca un usuario y una contraseña", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tbUser.Text == "Usuario")
            {
                Window v_usuarios = new View.V_Usuarios();
                v_usuarios.ShowDialog();
            }
            else if (tbUser.Text == "Admin")
            {
                Window v_Administrador = new View.V_Administrador();
                v_Administrador.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
           
        }

        private void tbRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
           
            
                //Creamos una instancia de la ventana de creación de usuario
                Window v_CreacionUsuario = new View.V_CreacionUsuario();
                v_CreacionUsuario.ShowDialog();
            
          
           

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else {
                //Cerramos la aplicación
                Application.Current.Shutdown();
            }

        }

        private void EjecutarSalir(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void EjecutarAceptar(object sender, ExecutedRoutedEventArgs e)
        {
            btnLogin_Click(sender, e);
        }

        private void PuedoAceptar(object sender, CanExecuteRoutedEventArgs e)
        {
           
               e.CanExecute = true;
            
        }
    }
}