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
            if (tbUser.Text == "Usuario")
            {
                Window v_usuarios = new View.V_Usuarios();
                v_usuarios.ShowDialog();
            }
            else
            {
                Window v_Administrador = new View.V_Administrador();
                v_Administrador.ShowDialog();
            }
           
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            //Cerramos la aplicación
            Application.Current.Shutdown();
           
        }

        private void tbRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
           
            
                //Creamos una instancia de la ventana de creación de usuario
                Window v_CreacionUsuario = new View.V_CreacionUsuario();
                v_CreacionUsuario.ShowDialog();
            
          
           

        }
    }
}