using _2Eva_ALB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2Eva_ALB.ViewModel
{
    public class VM_Planeta
    {
        private ObservableCollection<Model.M_Planeta> planetas;
        private M_OperacionesPlaneta operacionesPlaneta;
        private M_OperacionesTipoPlaneta operacionesTipoPlaneta;

        public VM_Planeta()
        {
            
            //Llamada al método que obtiene los planetas
            operacionesPlaneta = new M_OperacionesPlaneta();
            operacionesTipoPlaneta = new M_OperacionesTipoPlaneta();
           
            planetas = operacionesPlaneta.obtenerPlanetas();
           
        }

        public M_Planeta obtenerPlaneta(String codigo)
        {
            return operacionesPlaneta.obtenerPlaneta(codigo);
        }
        public void guardarPlaneta(M_Planeta planeta)
        {
            operacionesPlaneta.guardarPlaneta(planeta);
        }
        public void guardarTipoPlaneta(M_TipoPlaneta tipoPlaneta)
        {
            operacionesTipoPlaneta.guardarTipoPlaneta(tipoPlaneta);
        }


        public Boolean comprobarSiexistePlaneta(String codigo)
        {
            M_Planeta planeta = operacionesPlaneta.obtenerPlaneta(codigo);

           

            if(planeta.NombrePlaneta!= "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ObservableCollection<Model.M_Planeta> Planetas { get => planetas; set => planetas = value; }

    }
}
