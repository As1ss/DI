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

namespace Practica2_Alexis_Lopez_Briongos
{
    /// <summary>
    /// Lógica de interacción para VentanaResultado.xaml
    /// </summary>
    public partial class VentanaResultado : Window
    {
        public VentanaResultado()
        {
            InitializeComponent();
            MessageBox.Show("REGISTRO COMPLETADO, GUARDADO EN Practica2_Alexis-Lopez-Briongos\\bin\\Debug\\net7.0-windows\\Form.txt");
        }

        private void buttonContinue_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
