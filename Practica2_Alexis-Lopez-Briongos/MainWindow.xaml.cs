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

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            textNombre.Text = "";
            textApellido.Text = "";
            textDNI.Text = "";
            textEmail.Text = "";
        }
    }
}
