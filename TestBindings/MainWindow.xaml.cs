using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestBindings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Persona p;
        public MainWindow()
        {
            InitializeComponent();
            p= new Persona();
            p.Nombre = "Alexis";
            p.Apellido = "López";
            p.Edad = 21;
            p.NombreCompleto = "";

            this.DataContext = p;
            
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{p.Nombre} tiene la edad de {p.Edad}");
        }
    }
}