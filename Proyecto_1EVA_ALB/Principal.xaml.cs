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
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Page
    {
        MainWindow window;
        public bool modoFacil;
        public bool modoMedio;
        public bool modoDios;
        public Principal(MainWindow window)
        {
            this.window = window;   
            InitializeComponent();
            modoFacil = true;
        }
        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            if (modoFacil)
            {
                ModoFacil modoFacilPage = new ModoFacil(window);
                this.NavigationService.Navigate(modoFacilPage);

            }
            if (modoMedio)
            {
                ModoMedio modoMedio = new ModoMedio(window);
                this.NavigationService.Navigate(modoMedio);
            }
            if (modoDios)
            {
                ModoDios modoGod = new ModoDios(window);
                this.NavigationService.Navigate(modoGod);
            }
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
            window.Close();
        }
       
    }
}
