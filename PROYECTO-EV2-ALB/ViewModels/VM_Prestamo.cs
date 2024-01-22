﻿using PROYECTO_EV2_ALB.Models;
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

        public void actualizarLista()
        {

            listaPrestamos = operacionesPrestamo.obtenerPrestamos();
           
        } 
        public void actualizarPrestamo(M_Prestamo prestamo)
        {
            operacionesPrestamo.actualizarPrestamo(prestamo);
            
        }
        
        public void insertarPrestamo(Models.M_Prestamo prestamo)
        {
            operacionesPrestamo.insertarPrestamo(prestamo);
        }

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


    }
}