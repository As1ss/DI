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

        //Metodo para actualizar la lista de incidencias
        public void actualizarLista()
        {
            listaIncidencias = operacionesIncidencia.obtenerIncidencias();

        }

        //Metodos get y set
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


        //Metodos para insertar y resolver incidencias
        #region Métodos CRUD
        public void insertarIncidencia(Models.M_Incidencia incidencia)
        {
            operacionesIncidencia.insertarIncidencia(incidencia);

        
        }

        public void resolverIncidencia(Models.M_Incidencia incidencia)
        {
            
               operacionesIncidencia.resolverIncidencia(incidencia);
             
             
           
        }
        #endregion


      

    }
}
