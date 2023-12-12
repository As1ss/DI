using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace InicioSesionUsuario_ALB
{
    /// <summary>
    /// Lógica de interacción para AdminVentana.xaml
    /// </summary>
    public partial class AdminVentana : Window
    {
        private static MySqlConnection? connector; 
        public AdminVentana()
        {
            InitializeComponent();
            connector=ConexionBD.getConnection();
            cargarUsuarios();




        }

        private void btnCargarLista_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (dataGrid.SelectedItem != null)
                {
                    // Obtener el objeto asociado a la fila seleccionada
                    DataRowView row = (DataRowView)dataGrid.SelectedItem;

                    // Obtener el valor de la celda en la columna "Nombre"
                    string nombreValor = row["nombre"].ToString();

                    // Haz algo con el valor obtenido
                    MessageBox.Show($"El valor de la columna 'Nombre' es: {nombreValor}");
                    desbloquearUsuario(nombreValor);
                }
                else
                {
                    MessageBox.Show("Selecciona un registro para desbloquear");
                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
          


        }

        private void desbloquearUsuario(string? nombreValor)
        {
            String consultaUnlock = $"UPDATE usuario SET intentos_fallidos=0, bloqueado=0 WHERE nombre = '{nombreValor}'";
            using MySqlCommand unlockUsuario = new MySqlCommand(consultaUnlock, connector);

            unlockUsuario.Prepare();
            unlockUsuario.ExecuteNonQuery();
            cargarUsuarios();

        }

        private void cargarUsuarios()
        {
            try
            {

                String query = "SELECT * FROM usuario";
                using MySqlCommand consultarUsuarios = new MySqlCommand(query, connector);

                consultarUsuarios.Prepare();
                consultarUsuarios.ExecuteNonQuery();




                MySqlDataAdapter dataUsuarios = new MySqlDataAdapter(consultarUsuarios);

                DataTable dt = new DataTable("Usuarios info");
                dataUsuarios.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }
    }

}

