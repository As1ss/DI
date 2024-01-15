using System;
using System.Collections.Generic;
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

namespace PROYECTO_EV2_ALB.View
{
    /// <summary>
    /// Lógica de interacción para V_Administrador.xaml
    /// </summary>
    public partial class V_Administrador : Window
    {
        public V_Administrador()
        {
            InitializeComponent();
        }

        

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bAdminUsers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Cambia a un TabItem específico por referencia
            tcAdministrador.SelectedItem = tiUsers;


        }

        private void bIncidencias_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Cambia a un TabItem específico por referencia
            tcAdministrador.SelectedItem = tiIncidence;
        }

        private void bAdminBooks_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Cambia a un TabItem específico por referencia
            tcAdministrador.SelectedItem = tiBook;
        }

        private void bLogOut_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnDetalles_Click(object sender, RoutedEventArgs e)
        {
            Window v_incidencia = new V_Incidencia();
            v_incidencia.ShowDialog();
        }
    }
}
