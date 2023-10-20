using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practica2_Alexis_Lopez_Briongos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
          

        }

      






        //Eventos de creación y borrado de los hints de los campos
        #region
        private void textNombre_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textNombre.Text = "";
            textNombre.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void textNombre_MouseLeave(object sender, MouseEventArgs e)
        {
            if (textNombre.Text.Equals(""))
            {
                textNombre.Foreground = new SolidColorBrush(Colors.Gray);
                textNombre.Text = "Ej: Roberto Joao";
            }

        }

        private void textApellido_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textApellido.Text = "";
            textApellido.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void textApellido_MouseLeave(object sender, MouseEventArgs e)
        {

            if (textApellido.Text.Equals(""))
            {
                textApellido.Foreground = new SolidColorBrush(Colors.Gray);
                textApellido.Text = "Ej: Tirón Gonsales";
            }

        }

        private void textDNI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textDNI.Text = "";
            textDNI.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void textDNI_MouseLeave(object sender, MouseEventArgs e)
        {
            if (textDNI.Text.Equals(""))
            {
                textDNI.Foreground = new SolidColorBrush(Colors.Gray);
                textDNI.Text = "Ej: 12345678N";
            }

        }

        private void textEmail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textEmail.Text = "";
            textEmail.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void textEmail_MouseLeave(object sender, MouseEventArgs e)
        {
            if (textEmail.Text.Equals(""))
            {
                textEmail.Foreground = new SolidColorBrush(Colors.Gray);
                textEmail.Text = "Ej: JohnDoe@gmail.com";
            }
        }
        #endregion





        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            textNombre.Text = "";
            textApellido.Text = "";
            textDNI.Text = "";
            textEmail.Text = "";
            datePicker.Text = "";
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            comprobarCampos();
        }

        private void comprobarCampos()
        {
            bool emailValido = comprobarEmail(textEmail.Text);
            bool nombreValido = comprobarNombre(textNombre.Text);
            bool apellidosValido = comprobarApellidos(textApellido.Text);
            bool dniValido = comprobarDNI(textDNI.Text);
            bool edadValido = comprobarEdad(datePicker.Text);
            List<Boolean> formValido = new List<Boolean>();
            formValido.Add(emailValido);
            formValido.Add(nombreValido);
            formValido.Add(apellidosValido);
            formValido.Add(dniValido);
            formValido.Add(edadValido);

            if (formValido.All(valor => valor == true))
            {
                MessageBox.Show("REGISTRO COMPLETADO");
            }

            
            if (!emailValido)
            {
                textEmail.Foreground = new SolidColorBrush(Colors.Red);
                textEmail.Text = "EL EMAIL ES ERRONEO";
            }
            if (!nombreValido)
            {
                textNombre.Foreground = new SolidColorBrush(Colors.Red);
                textNombre.Text = "EL NOMBRE ES ERRONEO";
            }
            if (!apellidosValido)
            {
                textApellido.Foreground = new SolidColorBrush(Colors.Red);
                textApellido.Text = "EL APELLIDO ES ERRONEO";
            }
            

            if (!dniValido)
            {
                textDNI.Foreground = new SolidColorBrush(Colors.Red);
                textDNI.Text = "EL DNI ES ERRONEO";
            }
         
            if (!edadValido)
            {
                MessageBox.Show("Fecha erronea");
            }
           



        }

        //Métodos de validación de los valores introducidos por el usuario en los campos
        #region
        private bool comprobarEdad(String fecha)
        {
            string patron = @"^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}$";
            return Regex.IsMatch(fecha, patron);
        }

        private bool comprobarEmail(String email)
        {
           
            // Patrón para validar correos electrónicos
            string patron = @"^[\w\.-]+@[\w\.-]+\.\w+$";

            // Comprobar si el email coincide con el patrón
            return Regex.IsMatch(email, patron);
        }

        private bool comprobarDNI(String dni)
        {
            // Patrón para validar dni
            string patron = @"^\d{8}[A-Za-z]$";

            // Comprobar si el email coincide con el patrón
            return Regex.IsMatch(dni, patron);
        }

        private bool comprobarApellidos(String apellidos)
        {
            //Patrón para validar los apellidos
            string patron = "^[^0-9\\-_:]*$";

            //Comprobar si los apellidos coinciden con el patrón
            return Regex.IsMatch(apellidos, patron);
        }

        private bool comprobarNombre(String nombre)
        {
            //Patrón para validar nombre
            string patron = "^[^0-9\\-_:]*$";

            //Comprobar si el nombre coincide con el patrón
            return Regex.IsMatch(nombre, patron);
        }

        #endregion

        private void btnSalir_Click(object sender)
        {

            if (MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

       
    }
}
