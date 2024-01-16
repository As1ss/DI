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

namespace PROYECTO_EV2_ALB.View
{
    /// <summary>
    /// Lógica de interacción para V_Usuarios.xaml
    /// </summary>
    public partial class V_Usuarios : Window
    {
        public ObservableCollection<Libro> Libros { get; set; }

        public V_Usuarios()
        {
            InitializeComponent();
            Libros = new ObservableCollection<Libro>();

            // Agrega algunos libros de ejemplo
            Libros.Add(new Libro { Titulo = "Libro 1", Autor = "RutaImagen1.jpg",Stock= 20 });
            Libros.Add(new Libro { Titulo = "Libro 2", Autor = "RutaImagen2.jpg",Stock = 50 });
            Libros.Add(new Libro { Titulo = "Libro 3", Autor = "RutaImagen2.jpg",Stock = 40 });
            Libros.Add(new Libro { Titulo = "Libro 4", Autor = "RutaImagen2.jpg",Stock = 60 });
            Libros.Add(new Libro { Titulo = "Libro 5", Autor = "RutaImagen2.jpg",Stock = 10 });

         
            // Agrega más libros según sea necesario

            listBoxBooks.ItemsSource = Libros;
        }

        private void bQueryBooks_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tcUser.SelectedItem = tiBooks;
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
                MessageBox.Show("Incidencia enviada correctamente", "Incidencia", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnPedir_Click(object sender, RoutedEventArgs e)
        {
            
               //Comprobar si el stock es mayor que 0
                if (listBoxBooks.SelectedItem != null)
            {
                    Libro libro = (Libro)listBoxBooks.SelectedItem;
                    if (libro.Stock > 0)
                {
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

        private void EnviarIncidencia_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            btnEnviar_Click(sender, e);
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

        private void PedirLibro_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //Si agregamos el comando a la lista de comandos de la ventana, podemos ejecutarlo desde aquí
          //  btnPedir_Click(sender, e);  
        }
    }
}
