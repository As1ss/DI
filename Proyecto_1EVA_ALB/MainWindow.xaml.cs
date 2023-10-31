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

namespace Proyecto_1EVA_ALB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool modoFacil;
        public bool modoMedio;
        public bool modoDios;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
           

            MessageBox.Show("Modo facil: " + modoFacil + "\nModo medio: " + modoMedio + "\nModo Dios: " + modoDios);
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // Crear e instanciar el diálogo personalizado
            var dialog = new Settings(this);

            // Mostrar el diálogo como una ventana emergente
            dialog.ShowDialog();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

      

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Muestra un mensaje de confirmación
            MessageBoxResult result = MessageBox.Show("¿Seguro que deseas cerrar el juego?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    this.Close();
                }
                catch
                {
                    Console.WriteLine("Ha ocurrido algún tipo de error");
                }
              
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
