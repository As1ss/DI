using PROYECTO_EV2_ALB.Models;
using PROYECTO_EV2_ALB.ViewModels;
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

namespace PROYECTO_EV2_ALB.View
{
    /// <summary>
    /// Lógica de interacción para V_Incidencia.xaml
    /// </summary>
    public partial class V_Incidencia : Window
    {
        M_Incidencia incidencia;
        VM_Usuario vm_usuario;
        VM_Incidencia vm_incidencia;
        public V_Incidencia(M_Incidencia incidencia)
        {
            InitializeComponent();
            this.incidencia = incidencia;
            vm_usuario = new VM_Usuario(); 
            vm_incidencia = new VM_Incidencia();
         
            cargarCampos();

           
        }


        private void cargarCampos()
        {
          
            M_Usuario usuario = vm_usuario.obtenerUsuarioId(incidencia.Id_usuario);
           
            tbUsuario.Text = usuario.Nombre;
            tbIncidencia.Text = Convert.ToString(incidencia.Id_incidencia);
            tbIncidenciaUser.Text = incidencia.Descripcion;
        }

       

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
