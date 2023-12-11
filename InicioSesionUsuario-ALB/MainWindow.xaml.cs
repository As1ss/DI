using MySqlConnector;
using System.Reflection.PortableExecutable;
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

                String consulta = $"SELECT nombre,contrasena FROM usuario WHERE nombre = '{nombreUsuario}'";

                using var command = new MySqlCommand(consulta, connector);

                using var reader = command.ExecuteReader();

                String userBDD = "";
                String passwordBDD = "";
                int numFallos= 0;
                bool usuarioBloqueado= false;


                while (reader.Read())
                {

                    userBDD = reader.GetString(0);
                    passwordBDD = reader.GetString(1);



                }
           

                reader.Close();

                usuarioBloqueado = getBlockedUsuario(userBDD, reader, connector);

                if (nombreUsuario.Equals(userBDD) && contrasenaUsuario.Equals(passwordBDD) && !usuarioBloqueado)
                {

                    using (MySqlCommand commando = new MySqlCommand($"SELECT * FROM usuario WHERE usuario.nombre = '{userBDD}'", connector))
                    {
                        commando.ExecuteReader();
                        if (reader.Read())
                        {
                            MessageBox.Show($"LOGIN CORRECTO: \nID: {reader.GetInt16(0)}\nNombre: {reader.GetString(1)}\nContraseña: {reader.GetString(2)}\nTipo de usuario: {reader.GetString(3)}\nIntentos fallidos: {reader.GetInt16(4)}\nBloqueado: {reader.GetBoolean(5)}");

                            tbMensaje.Text = "Credenciales correctas";
                        }
                    }
                    reader.Close() ;
                }
                else if(nombreUsuario.Equals(userBDD) && !contrasenaUsuario.Equals(passwordBDD) && !usuarioBloqueado)
                {
                    setFallos(userBDD, reader,connector);
                    numFallos = getFallos(userBDD, reader, connector);
                    tbMensaje.Text=$"Tienes {numFallos}/3 intentos";
                    setBlockUsuario(userBDD,numFallos,reader,connector);

                }else if(nombreUsuario.Equals(userBDD) && usuarioBloqueado)
                {
                    tbMensaje.Text = "El usuario esta bloqueado";
                }
                else
                {
                    MessageBox.Show("LOGIN INCORRECTO");
                    tbMensaje.Text = "El usuario no se encuentra en nuestra base de datos";
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        
        private void setFallos(String usuarioNombre,MySqlDataReader reader,MySqlConnection connector)
        {
            tbMensaje.Text = "Contraseña incorrecta.";
            using (MySqlCommand aumentoFallos = new MySqlCommand($"UPDATE usuario SET intentos_fallidos=intentos_fallidos+1 WHERE nombre = '{usuarioNombre}'", connector))
            {
                aumentoFallos.ExecuteReader();
            }
            reader.Close();
        }
        private int getFallos(String usuarioNombre,MySqlDataReader reader, MySqlConnection connector)
        {
            int numFallos=0;

            using(MySqlCommand obtenerFallos = new MySqlCommand($"SELECT intentos_fallidos FROM usuario WHERE nombre = '{usuarioNombre}'", connector))
            {
                obtenerFallos.ExecuteReader();
                if(reader.Read())
                {
                    numFallos = reader.GetInt16(0);
                }
               
            }
            reader.Close();
           return numFallos;
        }
        private void setBlockUsuario(String usuarioNombre,int numFallos,MySqlDataReader reader, MySqlConnection connector)
        {
            using (MySqlCommand bloquearUsu = new MySqlCommand($"UPDATE usuario SET bloqueado=1 WHERE nombre = '{usuarioNombre}' AND intentos_fallidos>=3",connector))
            {
                bloquearUsu.ExecuteReader();
               
            }
            reader.Close();
        }
        private bool getBlockedUsuario(String usuarioNombre,MySqlDataReader reader,MySqlConnection connector)
        {
           bool usuarioBloqueado = false;

            using (MySqlCommand obtenerBlockUsu = new MySqlCommand($"SELECT bloqueado FROM usuario WHERE nombre ='{usuarioNombre}'", connector))
            {
                obtenerBlockUsu.ExecuteReader();

                if(reader.Read())
                {
                    usuarioBloqueado=reader.GetBoolean(0);
                }
            }
            reader.Close();

            return usuarioBloqueado;

        }
    }
}