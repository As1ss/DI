using PROYECTO_EV2_ALB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PROYECTO_EV2_ALB.ViewModels
{
    public class VM_Prestamo
    {
        private ObservableCollection<Models.M_Prestamo> listaPrestamos;
       
        private Models.M_OperacionesPrestamo operacionesPrestamo;

        public VM_Prestamo()
        {
          
            operacionesPrestamo = new Models.M_OperacionesPrestamo();
            actualizarLista();


            
        }


        //Metodo para ctualizar la lista de prestamos
        public void actualizarLista()
        {

            listaPrestamos = operacionesPrestamo.obtenerPrestamos();
           
        } 

       

        //Metodo get y set de la lista de prestamos
        public ObservableCollection<Models.M_Prestamo> ListaPrestamos
        {
            set
            {
                listaPrestamos = value;
            }
            get
            {
                return listaPrestamos;
            }
        }


        #region Metodos CRUD
        public void actualizarPrestamo(M_Prestamo prestamo)
        {
            operacionesPrestamo.actualizarPrestamo(prestamo);

        }

        public void aplazarPrestamo(M_Prestamo prestamo)
        {
            operacionesPrestamo.aplazarPrestamo(prestamo);
        }

        public void insertarPrestamo(Models.M_Prestamo prestamo)
        {
            operacionesPrestamo.insertarPrestamo(prestamo);
        }

        public void eliminarPrestamo(Models.M_Prestamo prestamo)
        {
            operacionesPrestamo.eliminarPrestamo(prestamo);
        }

        #endregion
    }
}
