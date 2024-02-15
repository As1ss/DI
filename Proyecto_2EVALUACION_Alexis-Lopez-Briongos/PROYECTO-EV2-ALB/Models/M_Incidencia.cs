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
        private int id_usuario;
        private string descripcion;
        private DateTime fecha_incidencia;
        private Boolean resuelta;

        public M_Incidencia()
        {
            fecha_incidencia = DateTime.Now;
        }

        public M_Incidencia(int id_incidencia,int id_usuario, string descripcion, DateTime fecha_incidencia, Boolean resuelta)
        {
            this.id_incidencia = id_incidencia;
            this.id_usuario = id_usuario;
            this.descripcion = descripcion;
            this.fecha_incidencia = fecha_incidencia;
            this.resuelta = resuelta;
        }
        public int Id_incidencia { get => id_incidencia; set => id_incidencia = value; }
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha_incidencia { get => fecha_incidencia; set => fecha_incidencia = value; }
       public Boolean Resuelta { get => resuelta; set => resuelta = value; }
        
    }
}
