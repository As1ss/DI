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
       
        private Principal principal;

        public Settings(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
            
        }


        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (opcFacil.IsSelected)
            {
                principal.modoFacil = true;
                principal.modoMedio = false;
                principal.modoDios = false;
            }
            if (opcMedio.IsSelected) {
                principal.modoFacil = false;
                principal.modoMedio = true;
                principal.modoDios = false;
            }
            if (opcModoDios.IsSelected)
            {
                principal.modoFacil = false;
                principal.modoMedio = false;
                principal.modoDios = true;
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
