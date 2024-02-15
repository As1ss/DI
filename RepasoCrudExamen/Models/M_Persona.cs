using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoCrudExamen.Models
{
  
    internal class M_Persona
    {
        private int id;
        private string nombre;
        private string apellido;
        private string telefono;
        private string correo;

        public M_Persona()
        {
           
        }

        public M_Persona(int id, string nombre, string apellido, string telefono, string correo)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.correo = correo;
        }
       
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
