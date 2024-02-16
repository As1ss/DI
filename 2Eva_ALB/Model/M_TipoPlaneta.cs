using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Eva_ALB.Model
{
    public class M_TipoPlaneta
    {
        private int idTipoPlaneta;
        private string nombreTipoPlaneta;

        public M_TipoPlaneta()
        {
            
        }

        public int IdTipoPlaneta { get => idTipoPlaneta; set => idTipoPlaneta = value; }
        public string NombreTipoPlaneta { get => nombreTipoPlaneta; set => nombreTipoPlaneta = value; }

    }
}
