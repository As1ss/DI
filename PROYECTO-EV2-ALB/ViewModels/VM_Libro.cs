﻿using PROYECTO_EV2_ALB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PROYECTO_EV2_ALB.ViewModels
{
    public class VM_Libro
    {
        private Models.M_OperacionesLibro operacionesLibro;
        private ObservableCollection<M_Libro> listaLibros;

        public VM_Libro()
        {
                operacionesLibro = new M_OperacionesLibro();
             actualizarLista();

        }

      

        public Boolean existeLibro(string titulo)
        {
            Boolean encontrado = false;
            foreach (M_Libro libro in listaLibros)
            {
                if (libro.Titulo == titulo)
                {
                    encontrado = true;
                }
            }
            return encontrado;
        }

        public M_Libro obtenerLibroId(int id)
        {
            M_Libro libro = new M_Libro();
            foreach (M_Libro libro1 in listaLibros)
            {
                if (libro1.Id_libro == id)
                {
                    libro = libro1;
                }
            }
            return libro;
        }



        public Boolean comprobarIdLibro(int id)
        {
            Boolean encontrado = false;
            foreach (M_Libro libro in listaLibros)
            {
                if (libro.Id_libro == id)
                {
                    encontrado = true;
                }
            }
            return encontrado;
            
        }

        public void insertarLibro(M_Libro libroNuevo)
        {
            operacionesLibro.insertarLibro(libroNuevo);
        }

        public Boolean comprobarStock(String stock)
        {


            Boolean correcto = false;

            //Comprobamos que la variable stock no sea string
            if (int.TryParse(stock, out int stockInt))
            {
                if (stockInt > 0)
                {
                    correcto = true;
                }
                else
                {
                    correcto = false;
                }
            }
            else
            {
                correcto = false;
            }
            
          
            return correcto;
        }
        
        public void eliminarLibro(M_Libro libro)
        {
            operacionesLibro.eliminarLibro(libro);
        }
        public void actualizarLibro(M_Libro libro)
        {
            operacionesLibro.actualizarLibro(libro);
         
        }

        public void actualizarLista()
        {
            
            listaLibros = operacionesLibro.obtenerLibros();

           

           
          
        }

        //Devolver lista de libros con InotiFyCollectionChanged
        
        public ObservableCollection<M_Libro> ListaLibros { get => listaLibros; set => listaLibros = value; }
       
    }
}
