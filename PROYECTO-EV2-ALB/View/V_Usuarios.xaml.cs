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
    }
}
