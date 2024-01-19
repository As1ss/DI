using PROYECTO_EV2_ALB.ViewModels;
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
    /// Lógica de interacción para V_CreacionUsuario.xaml
    /// </summary>
    public partial class V_CreacionUsuario : Window
    {
        VM_Usuario vm_usuario;

        Models.M_Usuario usuarioNuevo;

        public V_CreacionUsuario()
        {
            InitializeComponent();
            vm_usuario = new VM_Usuario();
            usuarioNuevo = new Models.M_Usuario();

            
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

           this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            if (tbUser.Text == string.Empty || tbxPassword.Password == string.Empty || tbEmail.Text == string.Empty)
            {
              
                MessageBox.Show("Introduzca un usuario, una contraseña y un email válidos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if(vm_usuario.existeUsuario(tbUser.Text))
            {
                MessageBox.Show("El usuario ya existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (!vm_usuario.comprobarEmail(tbEmail.Text))
                {
                    MessageBox.Show("Email no válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    usuarioNuevo.Nombre = tbUser.Text;
                    usuarioNuevo.Contrasena = tbxPassword.Password;
                    usuarioNuevo.Email = tbEmail.Text;
                    usuarioNuevo.Tipo_usuario = "estandar";



                    vm_usuario.insertarUsuario(usuarioNuevo);




                    MessageBox.Show("Usuario creado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                   //Cerrar ventana sin evento close
                    
                    this.Closing -= Window_Closing;
                    this.Close();
                }
             

         


               
            }
         
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea salir de la creación de usuarios?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question);

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

        private void EjecutarAceptar(object sender, ExecutedRoutedEventArgs e)
        {
            btnRegister_Click(sender, e);
           
        }

        private void PuedoAceptar(object sender, CanExecuteRoutedEventArgs e)
        {
                e.CanExecute = true;
            
        }

        private void EjecutarSalir(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
