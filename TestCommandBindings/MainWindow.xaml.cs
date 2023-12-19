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
using Microsoft.Toolkit.Uwp.Notifications;
using System.IO;
using System.Net;



namespace TestCommandBindings
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

        private void PuedoNuevo(object sender, CanExecuteRoutedEventArgs e)
        {
            if (IsMouseOver)
            {

                e.CanExecute = true;
            }
        }

        private void EjecutarNuevo(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Hello World!");
        }

        private void PuedoCortar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (tbxTexto != null) && (tbxTexto.SelectionLength > 0);
        }

        private void EjecutarCortar(object sender, ExecutedRoutedEventArgs e)
        {
            tbxTexto.Cut();
        }

        private void PuedoPegar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void EjecutarPegar(object sender, ExecutedRoutedEventArgs e)
        {
            tbxTexto.Paste();
        }

        private void PuedoSalir(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void EjecutarSalir(object sender, ExecutedRoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

       

        private void PuedoNotificacion(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute=true;
        }

        private void EjecutarNotificacion(object sender, ExecutedRoutedEventArgs e)
        {
            // Creamos dos variables para las imágenes para utilizarlas en el toast
            string imagen1Url = "https://www.iberdrola.com/wcorp/gc/prod/es_ES/comunicacion/multimedia/imagenes/iberdrola-logo-estandar.jpg";
            string imagen2Url = "https://www.iberdrola.com/wcorp/gc/prod/es_ES/comunicacion/multimedia/imagenes/iberdrola-logo-estandar.jpg";

            // Descargamos las imágenes y las convertimos en un arreglo de bytes
            byte[] imagen1Bytes = DownloadImage(imagen1Url);
            byte[] imagen2Bytes = DownloadImage(imagen2Url);

            // Creamos el toast
            var toast = new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Iberdrola")
                .AddText("Notificación")
                .AddText("Esto es una notificación de prueba")
                .AddInlineImage(imagen1Bytes, "Imagen1")
                .AddInlineImage(imagen2Bytes, "Imagen2")
                .GetToastContent();

            // Mostramos el toast
            var notificacion = new ToastNotification(toast.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(notificacion);
        }

        private byte[] DownloadImage(string imageUrl)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadData(imageUrl);
            }
        }
    }
}