using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Eva_ALB.Model
{
    public class M_Planeta
    {
        private int idPlaneta;
        private string codPlaneta;
        private string nombrePlaneta;
        private int numSatelites;
        private float factorGravitacional;
        private Boolean existeVida;
        private M_TipoPlaneta tipoPlaneta;

        public M_Planeta()
        {
           
        }

        public int IdPlaneta { get => idPlaneta; set => idPlaneta = value; }
        public string CodPlaneta { get => codPlaneta; set => codPlaneta = value; }
        public string NombrePlaneta { get => nombrePlaneta; set => nombrePlaneta = value; }
        public int NumSatelites { get => numSatelites; set => numSatelites = value; }
        public float FactorGravitacional { get => factorGravitacional; set => factorGravitacional = value; }
        public bool ExisteVida { get => existeVida; set => existeVida = value; }
        public M_TipoPlaneta TipoPlaneta { get => tipoPlaneta; set => tipoPlaneta = value; }

    }
}
