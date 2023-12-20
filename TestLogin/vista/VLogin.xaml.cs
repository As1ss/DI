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

namespace TestLogin.vista
{
    /// <summary>
    /// Lógica de interacción para VLogin.xaml
    /// </summary>
    public partial class VLogin : Window
    {
        public VLogin()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMinimizar_MouseEnter(object sender, MouseEventArgs e)
        {
            borderButtonMin.Background = new SolidColorBrush(Colors.Yellow);
        }

        private void btnMinimizar_MouseLeave(object sender, MouseEventArgs e)
        {
            borderButtonMin.Background = new SolidColorBrush(Colors.Aquamarine);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnClose_MouseEnter(object sender, MouseEventArgs e)
        {
            borderButtonClose.Background = new SolidColorBrush(Colors.Yellow);
        }

        private void btnClose_MouseLeave(object sender, MouseEventArgs e)
        {
            borderButtonClose.Background = new SolidColorBrush(Colors.Aquamarine);
        }
    }
}
