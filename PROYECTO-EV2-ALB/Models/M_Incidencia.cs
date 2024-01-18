using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_EV2_ALB.Models
{
    public class M_Incidencia
    {
        private int id_incidencia;
        private string descripcion;
        private DateTime fecha_incidencia;
        private string resuelta;

        public M_Incidencia()
        {

        }

        public M_Incidencia(int id_incidencia, string descripcion, DateTime fecha_incidencia, string resuelta)
        {
            this.id_incidencia = id_incidencia;
            this.descripcion = descripcion;
            this.fecha_incidencia = fecha_incidencia;
            this.resuelta = resuelta;
        }
        public int Id_incidencia { get => id_incidencia; set => id_incidencia = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha_incidencia { get => fecha_incidencia; set => fecha_incidencia = value; }
        public string Resuelta { get => resuelta; set => resuelta = value; }
        
    }
}
