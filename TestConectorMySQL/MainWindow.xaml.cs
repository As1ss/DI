using System;
using System.Collections.Generic;
using System.Linq;
using MySqlConnector;
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

namespace TestConectorMySQL
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

        private void btnConectar_Click(object sender, RoutedEventArgs e)
        {
            String servidor = tbServidor.Text;
            uint puerto = Convert.ToUInt32(tbPuerto.Text);
            String bd = tbBDD.Text;
            String usuario = tbUsuario.Text;
            String password = tbContrasena.Password;

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = servidor,
                Port = puerto,
                Database = bd,
                UserID = usuario,
                Password = password
               
            };

            MySqlConnection conexionBD = new MySqlConnection(builder.ToString());

            conexionBD.Open();

            String consulta = "SHOW DATABASES";

            MySqlCommand comando = new MySqlCommand(consulta, conexionBD);

            MySqlDataReader reader = comando.ExecuteReader();

           String resultado = "";

            while (reader.Read())
            {
                resultado += reader.GetString(0) + "\n";
            }

            MessageBox.Show(resultado);

            conexionBD.Close();

       


        }
    }
}
