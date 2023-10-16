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
        }
        private void textNombre_MouseLeave(object sender, MouseEventArgs e)
        {
            textNombre.Text = "Ej: Roberto Joao";
        }

        private void textApellido_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textApellido.Text = "";
        }

        private void textApellido_MouseLeave(object sender, MouseEventArgs e)
        {
            textApellido.Text = "Ej: Tirón Gonsales";
        }

        private void textDNI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textDNI.Text = "";
        }

        private void textDNI_MouseLeave(object sender, MouseEventArgs e)
        {
            textDNI.Text = "Ej: 12345678N";
        }

        private void textEmail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textEmail.Text = "";
        }

        private void textEmail_MouseLeave(object sender, MouseEventArgs e)
        {
            textEmail.Text = "Ej: JohnDoe@gmail.com";


        }
    }
}
