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
         //Comprobar que el libro existen en la base de datos

            //Si existe, mostrar mensaje de error
                // MessageBox.Show("El libro ya existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    
                //Si no existe, agregarlo
                MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres agregar el libro?", "Agregar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                   {
                    MessageBox.Show("Libro agregado correctamente", "Libro", MessageBoxButton.OK, MessageBoxImage.Information);
                }

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
           //Comprobar que el libro existe en la base de datos

            //Si existe, modificarlo
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres modificar el libro?", "Modificar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Libro modificado correctamente", "Libro", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            //Si no existe, mostrar mensaje de error
            // MessageBox.Show("El libro no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            //Comprobar que el libro existe en la base de datos

            //Si existe, eliminarlo
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar el libro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Libro eliminado correctamente", "Libro", MessageBoxButton.OK, MessageBoxImage.Information);
            }
          

            //Si no existe, mostrar mensaje de error
           // MessageBox.Show("El libro no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

       

       

        private void Agregar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (tiBook.IsSelected)
            {
                if (verificarCamposLibro())
                {
                    e.CanExecute = true;
                  
                }
                else
                {
                    e.CanExecute = false;
                  
                   
                }
            }
        }
           

        private void Agregar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            btnAgregar_Click(sender, e);   
        }

        private void Modificar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (tiBook.IsSelected)
            {
                if (verificarCamposLibro())
                {
                    e.CanExecute = true;
             

                }
                else
                {
                    e.CanExecute = false;
                  
                   
                }
            }

        }

        private void Modificar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            btnModificar_Click(sender, e);
        }

        private void Eliminar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (tiBook.IsSelected)
            {
                if (verificarCamposLibro())
                {
                    e.CanExecute = true;

                }
                else
                {
                    e.CanExecute = false;
                   
                   
                }
            }

        }

        private void Eliminar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            btnEliminar_Click(sender, e);
        }

        private void DetallesIncidencia_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dgIncidencias.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void ResolverIncidencia_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(dgIncidencias.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void btnUnBlock_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsuarios.SelectedItem != null) // and usuario bloqueado
            {
                MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres desbloquear al usuario?", "Desbloquear", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Usuario desbloqueado correctamente", "Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btnBlock_Click(object sender, RoutedEventArgs e)
        {
            if(dgUsuarios.SelectedItem != null) // and usuario no bloqueado
            {
                MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres bloquear al usuario?", "Bloquear", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Usuario bloqueado correctamente", "Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void DesbloquearUsuario_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dgUsuarios.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void BloquearUsuario_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dgUsuarios.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
    }
}
