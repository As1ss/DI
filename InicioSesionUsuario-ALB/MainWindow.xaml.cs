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


  

            try
            {
               MySqlConnection connector = ConexionBD.getConnection();

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
                    
                  
                   
                    connector.Close(); 
                    connector.Open();

                    using (MySqlCommand commando = new MySqlCommand("SELECT tipo_usuario FROM usuario",connector))
                    {
                        commando.ExecuteReader(); 
                        if (reader.Read())
                        {
                            MessageBox.Show($"LOGIN CORRECTO: \nNombre: {userBDD} \nTipo de usuario: {reader.GetString(0)}");
                        }
                    }

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