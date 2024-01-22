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
       
        VM_Usuario vm_usuario;
        VM_Libro vm_libro;
        VM_Incidencia vm_incidencia;
        VM_Prestamo vm_prestamo;

        public V_Administrador()
        {

            InitializeComponent();

            cargarUsuarios();
            cargarLibros();
            cargarIncidencias();
            cargarPrestamos();


          

           
        }

        private void cargarPrestamos()
        {
            vm_prestamo = new VM_Prestamo();
            dgPrestamos.ItemsSource = vm_prestamo.ListaPrestamos;
        }

        //Metodo para completar los campos en los textbox al seleccionar una fila del datagrid
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


        public void cargarIncidencias()
        {
            vm_incidencia = new VM_Incidencia();
            dgIncidencias.ItemsSource = vm_incidencia.ListaIncidencias;
        }


        public void cargarUsuarios()
        {
            vm_usuario= new VM_Usuario(); //Invocando al objeto vm_usuario regenero la colección de usuarios
          
         
           
            dgUsuarios.ItemsSource = vm_usuario.ListaUsuarios; //Asigno la listaUsuarios al DataGrid
           
           
        }
        public void cargarLibros()
        {
            vm_libro = new VM_Libro();
            
            dgLibros.ItemsSource = vm_libro.ListaLibros;
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
                //Cerramos la ventana sin el evento close para que no salga el mensaje de confirmación
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
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void bInformes_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tcAdministrador.SelectedItem = tiInformes;
        }

        private void bPrestamos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tcAdministrador.SelectedItem = tiPrestamos;
        }


        private void btnDetalles_Click(object sender, RoutedEventArgs e)
        {
            Models.M_Incidencia incidenciaSeleccionada = dgIncidencias.SelectedItem as Models.M_Incidencia;

            Window v_incidencia = new V_Incidencia(incidenciaSeleccionada);
            v_incidencia.ShowDialog();
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
                if (!vm_usuario.comprobarBloqueado(nombreUsuario) && usuarioSeleccionado.Tipo_usuario!="administrador")
                {
                    MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres bloquear al usuario?", "Bloquear", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("Usuario bloqueado correctamente", "Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
                        vm_usuario.bloquearUsuario(nombreUsuario);
                        cargarUsuarios();
                       
                    }
                }
                else if (usuarioSeleccionado.Tipo_usuario == "administrador")
                {
                    MessageBox.Show("No se puede bloquear a un administrador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);    
                }
                else
                {
                    MessageBox.Show("El usuario ya está bloqueado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void btnResolver_Click_1(object sender, RoutedEventArgs e)
        {

          
            M_Incidencia incidencia = dgIncidencias.SelectedItem as M_Incidencia;

            if (incidencia.Resuelta == true)
            {
               
                MessageBox.Show("La incidencia ya está resuelta", "Incidencia resuelta", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("¿Desea resolver la incidencia?", "Resolver incidencia", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    vm_incidencia.resolverIncidencia(incidencia);
                    cargarIncidencias();


                }
            }
        }

        private void btnAplazar_Click(object sender, RoutedEventArgs e)
        {

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

      

        private void AplazarPrestamo_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(dgPrestamos.SelectedItem != null)
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
