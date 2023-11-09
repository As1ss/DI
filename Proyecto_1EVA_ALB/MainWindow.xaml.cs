using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
      

        
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Principal(this);
           
        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
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
