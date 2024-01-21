using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using PROYECTO_EV2_ALB.Models;
using PROYECTO_EV2_ALB.ViewModels;

namespace PROYECTO_EV2_ALB.View
{
    /// <summary>
    /// Lógica de interacción para V_Usuarios.xaml
    /// </summary>
    public partial class V_Usuarios : Window
    {
      
        private VM_Libro vm_libro;
        private VM_Prestamo vm_prestamo;
        private VM_Incidencia vm_incidencia;
        private ObservableCollection<M_Prestamo> listaPrestamos;
        private M_Usuario usuarioSesion;


        public V_Usuarios(M_Usuario usuarioSesion)
        {
            InitializeComponent();
            vm_libro = new VM_Libro();
            vm_incidencia = new VM_Incidencia();
            vm_prestamo = new VM_Prestamo();
            listaPrestamos = new ObservableCollection<M_Prestamo>();
          
            this.usuarioSesion = usuarioSesion;

          
            actualizarListas();


           

           
        }

        public void actualizarListas()
        {
            actualizarLibros();

            actualizarPrestamos();
        }
        public void actualizarLibros()
        {
           vm_libro.ListaLibros.Clear();
           vm_libro.actualizarLista();
            listBoxBooks.ItemsSource = vm_libro.ListaLibros;
        }

        public void actualizarPrestamos()
        {
            listaPrestamos.Clear();
            vm_prestamo.actualizarLista();
            foreach (var prestamo in vm_prestamo.ListaPrestamos)
            {
                if (prestamo.Usuario.Id_usuario == usuarioSesion.Id_usuario)
                {
                    listaPrestamos.Add(prestamo);
                }
            }
            listPrestamos.ItemsSource = listaPrestamos;
        }
        private void bQueryBooks_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tcUser.SelectedItem = tiBooks;
        }

        private void limpiarCampos()
        {
           tbxIncidencia.Text = ""; 
        }


        private void bIncidencias_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tcUser.SelectedItem = tiIncidence;
        }

        private void bPrestamos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tcUser.SelectedItem = tiPrestamos;
        }

        private void bCerrarSesion_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EjecutarAceptar(object sender, ExecutedRoutedEventArgs e)
        {
            if (tcUser.SelectedItem == tiIncidence)
            {

                
                btnEnviar_Click(sender, e);
            }
            else if(tcUser.SelectedItem == tiPrestamos)
            {
                btnPedir_Click(sender, e);
            }
        }

        private void PuedoAceptar(object sender, CanExecuteRoutedEventArgs e)
        {
            
                e.CanExecute = true;
          
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

        private void btnDevolver_Click(object sender, RoutedEventArgs e)
        {
            if (listPrestamos.SelectedItem == null)
            {
                MessageBox.Show("No has seleccionado ningún libro", "Préstamo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Devolución realizada correctamente", "Préstamo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxIncidencia.Text == "")
            {
                MessageBox.Show("No has escrito ninguna incidencia", "Incidencia", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            else
            {
                M_Incidencia incidencia = new M_Incidencia();
                incidencia.Id_usuario = usuarioSesion.Id_usuario;
                incidencia.Descripcion = tbxIncidencia.Text;
                incidencia.Fecha_incidencia = DateTime.Now;
                incidencia.Resuelta = false;

                vm_incidencia.insertarIncidencia(incidencia);
                MessageBox.Show("Incidencia enviada correctamente", "Incidencia", MessageBoxButton.OK, MessageBoxImage.Information);

                limpiarCampos();
               
            }
        }

        private void btnPedir_Click(object sender, RoutedEventArgs e)
        {
            
               //Comprobar si el stock es mayor que 0
                if (listBoxBooks.SelectedItem != null)
            {
                M_Libro libro = (M_Libro)listBoxBooks.SelectedItem;

                M_Prestamo prestamo = new M_Prestamo();

                    if (libro.Stock > 0)
                {
                    libro.Stock--;
                    vm_libro.actualizarLibro(libro);

                    prestamo.Usuario= usuarioSesion;
                    prestamo.Libro = libro;
                    prestamo.Fecha_prestamo = DateTime.Now;
                    prestamo.Fecha_devolucion = DateTime.Now.AddDays(30);
                    vm_prestamo.insertarPrestamo(prestamo);
                    actualizarListas();
                   

                        MessageBox.Show("Préstamo realizado correctamente", "Préstamo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                {
                        MessageBox.Show("No hay stock disponible", "Préstamo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
            {
                    MessageBox.Show("No has seleccionado ningún libro", "Préstamo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
              
            
        }

      

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if(tbxBuscar.Text == "")
            {
                MessageBox.Show("No has escrito nada en el buscador", "Buscar", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Libro encontrado", "Buscar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EnviarIncidencia_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(tcUser.SelectedItem == tiIncidence)
            {
                if (tbxIncidencia.Text == "")
                {
                    e.CanExecute = false;
                }
                else
                {
                    e.CanExecute = true;
                }
            }
           
        }

       

        private void PedirLibro_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(tcUser.SelectedItem == tiBooks)
            {
                if (listBoxBooks.SelectedItem == null)
                {
                    e.CanExecute = false;
                }
                else
                {
                    e.CanExecute = true;
                }
            }
        }

       

        private void DevolverLibro_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (tcUser.SelectedItem == tiPrestamos)
            {
                if (listPrestamos.SelectedItem==null)
                {
                    e.CanExecute = false;
                }
                else
                {
                    e.CanExecute = true;
                }
            }
        }

        private void DevolverLibro_Executed(object sender, ExecutedRoutedEventArgs e)
        {
           // btnDevolver_Click(sender, e);
        }

       
    }
}
