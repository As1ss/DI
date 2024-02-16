using _2Eva_ALB.Model;
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

namespace _2Eva_ALB
{
    /// <summary>
    /// Lógica de interacción para Planetas.xaml
    /// </summary>
    public partial class Planetas : Window
    {
        private ViewModel.VM_Planeta vmPlaneta;

        public Planetas()
        {
            InitializeComponent();
            cargarDatos();
        }


        public void cargarDatos()
        {
            vmPlaneta = new ViewModel.VM_Planeta();
            dtgPlanetas.ItemsSource = vmPlaneta.Planetas;
        }
        private void dtgPlanetas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Obtenemos el planeta seleccionado
            M_Planeta planeta = (M_Planeta)dtgPlanetas.SelectedItem;
            if (planeta != null)
            {
                txtCodigo.Text = planeta.CodPlaneta;
                txtNombre.Text = planeta.NombrePlaneta;
                cbTipo.Text = planeta.TipoPlaneta.NombreTipoPlaneta;
                if (planeta.ExisteVida)
                {
                    rbSi.IsChecked = true;
                }
                else
                {
                    rbNo.IsChecked = true;
                }
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            buscarPlaneta();
        }
        private void buscarPlaneta()
        {
            M_Planeta planeta = vmPlaneta.obtenerPlaneta(txtCodigo.Text);



            if (planeta != null && planeta.TipoPlaneta != null)
            {
                txtNombre.Text = planeta.NombrePlaneta;
                cbTipo.Text = planeta.TipoPlaneta.NombreTipoPlaneta;




                if (planeta.ExisteVida)
                {
                    rbSi.IsChecked = true;
                }
                else
                {
                    rbNo.IsChecked = true;
                }
            }
            else
            {
                MessageBox.Show("No se ha encontrado el planeta con el código " + txtCodigo.Text);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
                guardarPlaneta();
            
        }
        private void guardarPlaneta()
        {
            //Guardamos primero en la base de datos el tipo de planeta para evitar confiltos
            M_TipoPlaneta tipoPlaneta = new M_TipoPlaneta();
            tipoPlaneta.NombreTipoPlaneta = cbTipo.Text;
            if (tipoPlaneta.NombreTipoPlaneta == "Rocoso")
            {
                tipoPlaneta.IdTipoPlaneta = 1;
            }
            else
            {
                tipoPlaneta.IdTipoPlaneta = 2;
            }

            vmPlaneta.guardarTipoPlaneta(tipoPlaneta);

            //Guardamos el planeta


            M_Planeta planeta = new M_Planeta();
            planeta.CodPlaneta = txtCodigo.Text;
            planeta.NombrePlaneta = txtNombre.Text;
            planeta.TipoPlaneta = tipoPlaneta;
            if (rbSi.IsChecked == true)
            {
                planeta.ExisteVida = true;
            }
            else
            {
                planeta.ExisteVida = false;
            }
            vmPlaneta.guardarPlaneta(planeta);
            MessageBox.Show("Planeta guardado correctamente");
            cargarDatos();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            cbTipo.Text = "";
            rbSi.IsChecked = false;
            rbNo.IsChecked = false;
        }

        private void Guardar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtCodigo.Text!="")
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void Buscar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(txtCodigo.Text != "")
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void Limpiar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtCodigo.Text != "" || txtNombre.Text != "" || cbTipo.Text != "" || rbSi.IsChecked == true || rbNo.IsChecked == true)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void Guardar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            guardarPlaneta();
        }

        private void Buscar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            buscarPlaneta();
        }

        private void Limpiar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            limpiar();
        }
    }
}
