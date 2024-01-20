using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PROYECTO_EV2_ALB.ViewModels
{
    public class VM_Incidencia
    {
        private ObservableCollection<Models.M_Incidencia> listaIncidencias;
        private Models.M_OperacionesIncidencia operacionesIncidencia;

        public VM_Incidencia()
        {
            operacionesIncidencia = new Models.M_OperacionesIncidencia();
           actualizarLista();
        }

        public void insertarIncidencia(Models.M_Incidencia incidencia)
        {
            operacionesIncidencia.insertarIncidencia(incidencia);

        
        }

        public void resolverIncidencia(Models.M_Incidencia incidencia)
        {
            
               operacionesIncidencia.resolverIncidencia(incidencia);
             
             
           
        }  

        public void actualizarLista()
        {
            listaIncidencias = operacionesIncidencia.obtenerIncidencias();
            
        }
        public ObservableCollection<Models.M_Incidencia> ListaIncidencias
        {
            set
            {
                listaIncidencias = value;
            }
            get
            {
                return listaIncidencias;
            }
        }

    }
}
