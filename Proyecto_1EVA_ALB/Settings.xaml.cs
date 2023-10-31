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

namespace Proyecto_1EVA_ALB
{
    /// <summary>
    /// Lógica de interacción para Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private MainWindow mainWindow;
      
        public Settings(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

       

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (opcFacil.IsSelected)
            {
                mainWindow.modoFacil = true;
                mainWindow.modoMedio = false;
                mainWindow.modoDios = false;
            }
            if (opcMedio.IsSelected) {
                mainWindow.modoFacil = false;
                mainWindow.modoMedio = true;
                mainWindow.modoDios = false;
            }
            if (opcModoDios.IsSelected)
            {
                mainWindow.modoFacil = false;
                mainWindow.modoMedio = false;
                mainWindow.modoDios = true;
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
