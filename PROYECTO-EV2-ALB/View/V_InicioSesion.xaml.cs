﻿using PROYECTO_EV2_ALB.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROYECTO_EV2_ALB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class V_InicioSesion : Window
    {
        VM_Usuario vm_usuario;
        public V_InicioSesion()
        {
            InitializeComponent();
            vm_usuario = new VM_Usuario();

            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            vm_usuario.actualizarLista();

            if (tbUser.Text == string.Empty || tbxPassword.Password == string.Empty)
            {
                MessageBox.Show("Introduzca un usuario y una contraseña", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (vm_usuario.comprobarUsuario(tbUser.Text, tbxPassword.Password))
            {
                if(vm_usuario.comprobarAdmin(tbUser.Text, tbxPassword.Password))
                {
                    Window v_Administrador = new View.V_Administrador();
                    v_Administrador.ShowDialog();
                }
                else
                {
                    Window v_Usuario = new View.V_Usuarios();
                    v_Usuario.ShowDialog();
                }
              
            }
            else if (vm_usuario.comprobarBloqueado(tbUser.Text))
            {
                MessageBox.Show("Usuario bloqueado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
         
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
           
        }

        private void tbRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
           
            
                //Creamos una instancia de la ventana de creación de usuario
                Window v_CreacionUsuario = new View.V_CreacionUsuario();
                v_CreacionUsuario.ShowDialog();
            
          
           

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else {
                //Cerramos la aplicación
                Application.Current.Shutdown();
            }

        }

        private void EjecutarSalir(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void EjecutarAceptar(object sender, ExecutedRoutedEventArgs e)
        {
            btnLogin_Click(sender, e);
        }

        private void PuedoAceptar(object sender, CanExecuteRoutedEventArgs e)
        {
           
               e.CanExecute = true;
            
        }
    }
}