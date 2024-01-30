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
using System.IO;

namespace PROYECTO_EV2_ALB.View
{
    /// <summary>
    /// Lógica de interacción para V_Informes.xaml
    /// </summary>
    public partial class V_Informes : Window
    {
        public V_Informes()
        {
            InitializeComponent();
            reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Reportes","Report2.rdl");
            reportViewer.RefreshReport();
        }
    }
}
