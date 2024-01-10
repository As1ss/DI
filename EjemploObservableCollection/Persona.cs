using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EjemploObservableCollection
{

    public class Persona
    {
        private String nombre;
        private DateTime fecha = DateTime.Now;
        private int edad;

        public Persona(string nombre, string apellido, int edad)
        {
            this.nombre = nombre;
         
            this.edad = edad;
        }
       

        public String getNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String getApellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public int getEdad
        {
            get { return edad; }
            set { edad = value; }
        }


    }
}
