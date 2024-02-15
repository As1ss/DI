using RepasoCrudExamen.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoCrudExamen.ViewModels
{
    internal class VM_Persona
    {
        private M_OperacionesPersona operacionesPersona;
        private ObservableCollection<M_Persona> personas;

        public VM_Persona()
        {
            operacionesPersona = new M_OperacionesPersona();
            personas = operacionesPersona.obtenerPersonas();
        }

        public void insertarPersona(M_Persona persona)
        {

            operacionesPersona.insertarPersona(persona);
        }

        public void modificarPersona(M_Persona persona)
        {
            
           operacionesPersona.modificarPersona(persona);
                
            
          
        }
        public void eliminarPersona(M_Persona persona)
        {
            operacionesPersona.eliminarPersona(persona);
        }
        public void obtenerPersonas()
        {
            operacionesPersona.obtenerPersonas();
        }

        public ObservableCollection<M_Persona> Personas { get => personas; set => personas = value; }
    }
}
