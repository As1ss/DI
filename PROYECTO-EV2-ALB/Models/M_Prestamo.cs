using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_EV2_ALB.Models
{
    public class M_Prestamo
    {
        private int id_prestamo;
        private int id_usuario;
        private int id_libro;
        private DateTime fecha_prestamo;
        private DateTime fecha_devolucion;
        
        public M_Prestamo()
        {

        }

        public M_Prestamo(int id_prestamo, int id_usuario, int id_libro, DateTime fecha_prestamo, DateTime fecha_devolucion)
        {
            this.id_prestamo = id_prestamo;
            this.id_usuario = id_usuario;
            this.id_libro = id_libro;
            this.fecha_prestamo = fecha_prestamo;
            this.fecha_devolucion = fecha_devolucion;
        }
        public int Id_prestamo { get => id_prestamo; set => id_prestamo = value; }
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public int Id_libro { get => id_libro; set => id_libro = value; }
        public DateTime Fecha_prestamo { get => fecha_prestamo; set => fecha_prestamo = value; }
        public DateTime Fecha_devolucion { get => fecha_devolucion; set => fecha_devolucion = value; }
    }
}
