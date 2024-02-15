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
        private M_Usuario usuario;
        private M_Libro libro;
        private DateTime fecha_prestamo;
        private DateTime fecha_devolucion;
        
        public M_Prestamo()
        {

        }

        public M_Prestamo(int id_prestamo, M_Usuario usuario, M_Libro libro, DateTime fecha_prestamo, DateTime fecha_devolucion)
        {
            this.id_prestamo = id_prestamo;
            this.usuario = usuario;
            this.libro = libro;
            this.fecha_prestamo = fecha_prestamo;
            this.fecha_devolucion = fecha_devolucion;
        }
        public int Id_prestamo { get => id_prestamo; set => id_prestamo = value; }
        public M_Usuario Usuario { get => usuario; set => usuario = value; }
        public M_Libro Libro { get => libro; set => libro = value; }
        public DateTime Fecha_prestamo { get => fecha_prestamo; set => fecha_prestamo = value; }
        public DateTime Fecha_devolucion { get => fecha_devolucion; set => fecha_devolucion = value; }
    }
}
