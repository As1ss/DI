using MySqlConnector;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InicioSesionUsuario_ALB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const String SERVIDOR= "localhost";
        private const uint PUERTO = 3306;
        private const String BASEDATOS = "usuariologin";
        private const String USUARIO = "root";
        private const String PASSWORD = "1234";
        private String? nombreUsuario;
        private String? contrasenaUsuario;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            
             nombreUsuario = tbxUsuario.Text;
             contrasenaUsuario = bxPassword.Password;


            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = SERVIDOR,
                Port = PUERTO,
                Database = BASEDATOS,
                UserID = USUARIO,
                Password = PASSWORD
            };

            using var connector = new MySqlConnection(builder.ToString());

            try
            {
                connector.Open();

                String consulta = "SELECT nombre,contrasena FROM usuario";

                using var command = new MySqlCommand(consulta, connector);

                using var reader = command.ExecuteReader();
                
                String userBDD = "";
                String passwordBDD = "";


                  while(reader.Read()) { 

                    userBDD = reader.GetString(0);
                    passwordBDD= reader.GetString(1);

                   

                }

                if (nombreUsuario.Equals(userBDD) && contrasenaUsuario.Equals(passwordBDD))
                {
                    
                    MessageBox.Show("LOGIN CORRECTO");

                }
                else
                {
                    MessageBox.Show("LOGIN INCORRECTO");
                }




            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


            

        }
    }
}