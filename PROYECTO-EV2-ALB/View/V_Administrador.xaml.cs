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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Deseas cerrar sesión?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                //Cerramos la ventana sin el evento close
                this.Closing -= Window_Closing;

            }
        }

      
        private Boolean verificarCamposLibro()
        {
            if (tbxTitulo.Text == "" || tbxAutor.Text == "" || tbxStock.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if(verificarCamposLibro())
            {
                MessageBox.Show("Libro agregado correctamente", "Libro", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Debes rellenar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }   
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if(verificarCamposLibro())
            {
                MessageBox.Show("Libro modificado correctamente", "Libro", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Debes rellenar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if(verificarCamposLibro())
            {
                MessageBox.Show("Libro eliminado correctamente", "Libro", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Debes rellenar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
