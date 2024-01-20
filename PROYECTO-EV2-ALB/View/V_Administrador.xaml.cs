using MySqlConnector;
using PROYECTO_EV2_ALB.Models;
using PROYECTO_EV2_ALB.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PROYECTO_EV2_ALB.View
{
    /// <summary>
    /// Lógica de interacción para V_Administrador.xaml
    /// </summary>
    public partial class V_Administrador : Window
    {
        ObservableCollection<Models.M_Usuario> listaUsuarios;
        VM_Usuario vm_usuario;
        VM_Libro vm_libro;

        public V_Administrador()
        {

            InitializeComponent();

            cargarUsuarios();
            cargarLibros();



            if (tiUsers.IsSelected)
            {
                // Asignamos el ViewModel a la ventana
                this.DataContext = new VM_Usuario();
                // Enlazamos el DataGrid directamente con la propiedad ListaUsuarios del ViewModel
                dgUsuarios.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("ListaUsuarios"));
                // Suscribirse al evento CollectionChanged de la propiedad ListaUsuarios

            }
            if (tiBook.IsSelected)
            {
                vm_libro = new VM_Libro();
                this.DataContext = new VM_Libro();
                dgLibros.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("ListaLibros"));
               
            }
        }
        private void DynamicDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Verifica si hay una fila seleccionada
            if (dgLibros.SelectedItem != null)
            {
                // Obtén el objeto seleccionado (supongamos que tu objeto tiene propiedades Autor y Stock)
                M_Libro selectedItem = (M_Libro)dgLibros.SelectedItem;

                // Asigna los valores a los TextBox
                tbxTitulo.Text = selectedItem.Titulo;
                tbxAutor.Text = selectedItem.Autor;
                tbxStock.Text = selectedItem.Stock.ToString();
            }
        }




        public void cargarUsuarios()
        {
            vm_usuario= new VM_Usuario(); //Invocando al objeto vm_usuario regenero la colección de usuarios
          
            listaUsuarios = vm_usuario.ListaUsuarios; //Asigno la colección de usuarios a la listaUsuarios
           
            dgUsuarios.ItemsSource = listaUsuarios; //Asigno la listaUsuarios al DataGrid
           
           
        }
        public void cargarLibros()
        {
            vm_libro = new VM_Libro();
            
            dgLibros.ItemsSource = vm_libro.ListaLibros;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
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
        private void limpiarCampos()
        {
            tbxTitulo.Text = "";
            tbxAutor.Text = "";
            tbxStock.Text = "";
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
        #region Navegación de pestañas

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
        #endregion

        #region Botones eventos

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
         //Comprobar que el libro existen en la base de datos
         if(vm_libro.existeLibro(tbxTitulo.Text))
            {
                //Si existe, mostrar mensaje de error
                MessageBox.Show("El libro ya existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
         else
            {
                if (!vm_libro.comprobarStock(tbxStock.Text))
                {
                    MessageBox.Show("Stock no válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

             
                Models.M_Libro libroNuevo = new Models.M_Libro(); 
              
                MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres agregar el libro?", "Agregar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    libroNuevo.Titulo = tbxTitulo.Text;
                    libroNuevo.Autor = tbxAutor.Text;
                    libroNuevo.Stock = Convert.ToInt32(tbxStock.Text);
                    vm_libro.insertarLibro(libroNuevo);
                    cargarLibros();
                    MessageBox.Show("Libro agregado correctamente", "Libro", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiarCampos();
                    //dgLibros.Items.Refresh();
                }
                }

            }
            //Si no existe, agregarlo
            //MessageBox.Show("Libro agregado correctamente", "Libro", MessageBoxButton.OK, MessageBoxImage.Information

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
           //Comprobar que el libro existe en la base de datos por id

            //Obtenemos el objeto seleccionado del datagrid
             Models.M_Libro libroSeleccionado = dgLibros.SelectedItem as Models.M_Libro;
            //Comprobar que el libro existen en la base de datos

            int id = libroSeleccionado.Id_libro;

           if(vm_libro.comprobarIdLibro(id))
            {
                if (!vm_libro.comprobarStock(tbxStock.Text))
                {
                    MessageBox.Show("Stock no válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Models.M_Libro libroNuevo = new Models.M_Libro();
                    MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres modificar el libro?", "Modificar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {

                        libroNuevo.Id_libro = id;
                        libroNuevo.Titulo = tbxTitulo.Text;
                        libroNuevo.Autor = tbxAutor.Text;
                        libroNuevo.Stock = Convert.ToInt32(tbxStock.Text);
                        vm_libro.actualizarLibro(libroNuevo);
                        cargarLibros();
                        MessageBox.Show("Libro modificado correctamente", "Libro", MessageBoxButton.OK, MessageBoxImage.Information);
                        limpiarCampos();
                        //dgLibros.Items.Refresh();
                    }
                }
            }
           else
            {
                //Si no existe, mostrar mensaje de error
                MessageBox.Show("El libro no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Si existe, modificarlo
            //MessageBox.Show("Libro modificado correctamente", "Libro", MessageBoxButton.OK, MessageBoxImage.Information
        }
    

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            //Comprobar que el libro existe en la base de datos
            //Obtenemos el objeto seleccionado del datagrid
            Models.M_Libro libroSeleccionado = dgLibros.SelectedItem as Models.M_Libro;
            //Comprobar que el libro existen en la base de datos
            if (vm_libro.comprobarIdLibro(libroSeleccionado.Id_libro))
            {
                MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar el libro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Libro eliminado correctamente", "Libro", MessageBoxButton.OK, MessageBoxImage.Information);
                    vm_libro.eliminarLibro(libroSeleccionado);
                    cargarLibros();
                    //dgLibros.Items.Refresh();
                    limpiarCampos();
                }
               
            }
            else
            {
                MessageBox.Show("El libro no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnUnBlock_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el usuario seleccionado del datagridUsuarios
            Models.M_Usuario usuarioSeleccionado = dgUsuarios.SelectedItem as Models.M_Usuario;

            if (usuarioSeleccionado != null)
            {
                string nombreUsuario = usuarioSeleccionado.Nombre;

                if(vm_usuario.comprobarBloqueado(nombreUsuario))
                {
                    MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres desbloquear al usuario?", "Desbloquear", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("Usuario desbloqueado correctamente", "Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                        vm_usuario.desbloquearUsuario(nombreUsuario);
                        cargarUsuarios ();
                        //dgUsuarios.Items.Refresh();

                    }
                }
                else
                {
                    MessageBox.Show("El usuario no está bloqueado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }


        }

        private void btnBlock_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el usuario seleccionado del datagridUsuarios
            Models.M_Usuario usuarioSeleccionado = dgUsuarios.SelectedItem as Models.M_Usuario;
            if(usuarioSeleccionado != null)
            {
                string nombreUsuario = usuarioSeleccionado.Nombre;
                if (!vm_usuario.comprobarBloqueado(nombreUsuario))
                {
                    MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres bloquear al usuario?", "Bloquear", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("Usuario bloqueado correctamente", "Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                        vm_usuario.bloquearUsuario(nombreUsuario);
                        cargarUsuarios();
                        //dgUsuarios.Items.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("El usuario ya está bloqueado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion

        #region Comandos

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
    #endregion
}
