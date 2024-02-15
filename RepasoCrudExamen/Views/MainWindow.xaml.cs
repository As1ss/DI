using RepasoCrudExamen.Models;
using RepasoCrudExamen.ViewModels;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RepasoCrudExamen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VM_Persona vmPersona;
        public MainWindow()
        {
            InitializeComponent();
            vmPersona = new VM_Persona();
            cargarDataGrid();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            M_Persona persona = new M_Persona();
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.Telefono = txtTelefono.Text;
            persona.Correo = txtCorreo.Text;

            MessageBoxResult result = MessageBox.Show("¿Desea agregar a " + persona.Nombre + " " + persona.Apellido + "?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                vmPersona.insertarPersona(persona);
                limpiarCampos();
                cargarDataGrid();
            }
         
        }

       
        private void cargarDataGrid()
        {
            vmPersona = new VM_Persona();
            dtgPersonas.ItemsSource = vmPersona.Personas;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
           

            M_Persona persona = dtgPersonas.SelectedItem as M_Persona;

            MessageBoxResult result = MessageBox.Show("¿Desea modificar a " + persona.Nombre + " " + persona.Apellido + "?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question); 
            if (result == MessageBoxResult.Yes)
            {
                persona.Nombre = txtNombre.Text;
                persona.Apellido = txtApellido.Text;
                persona.Telefono = txtTelefono.Text;
                persona.Correo = txtCorreo.Text;

                vmPersona.modificarPersona(persona);
                limpiarCampos();
                cargarDataGrid();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
           
            M_Persona persona = dtgPersonas.SelectedItem as M_Persona;

            MessageBoxResult result = MessageBox.Show("¿Desea eliminar a " + persona.Nombre + " " + persona.Apellido + "?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {

               

                vmPersona.eliminarPersona(persona);
                limpiarCampos();
                cargarDataGrid();
            }
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtEdad.Text = "";
            txtCorreo.Text = "";
        }

        private void dtgPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            M_Persona persona = (M_Persona)dtgPersonas.SelectedItem;
            if (persona != null)
            {
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtTelefono.Text = persona.Telefono;
                txtCorreo.Text = persona.Correo;
            }
        }
    }
}