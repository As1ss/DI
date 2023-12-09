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

namespace TestConexionBDD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String servidor = tbxServidor.Text;
            uint puerto = uint.Parse(tbxPuerto.Text);
            String bDD = tbxBDD.Text;
            String usuario = tbxUsuario.Text;
            String password = bxPassword.Password;



            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = servidor,
                Port=puerto,
                Database = bDD,
                UserID = usuario,
                Password = password

            };

            using var connectBDD = new MySqlConnection(builder.ToString());

            try
            {
                connectBDD.Open();
                String consultaBDD = "SHOW DATABASES;";
                using var comando = new MySqlCommand(consultaBDD,connectBDD);
                using var reader = comando.ExecuteReader();
                String data = "";

                while(reader.Read())
                {
                    data +=$"\n{reader.GetString(0)}";
                }

                MessageBox.Show($"Bases de datos: {data}");



            }catch(MySqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connectBDD.Close();
            }



        }

    }
}