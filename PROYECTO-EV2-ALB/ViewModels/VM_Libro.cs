using PROYECTO_EV2_ALB.Models;
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


        //Método para actualizar la lista de libros
        public void actualizarLista()
        {
            listaLibros = operacionesLibro.obtenerLibros();
        }

        //Métodos get y set
        public ObservableCollection<M_Libro> ListaLibros { get => listaLibros; set => listaLibros = value; }




        //Métodos para obtener un libro, eliminarlo, actualizarlo e insertarlo
        #region Metodos CRUD
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
        public void eliminarLibro(M_Libro libro)
        {
            operacionesLibro.eliminarLibro(libro);
        }
        public void actualizarLibro(M_Libro libro)
        {
            operacionesLibro.actualizarLibro(libro);

        }
        public void insertarLibro(M_Libro libroNuevo)
        {
            operacionesLibro.insertarLibro(libroNuevo);
        }
        #endregion




        //Métodos para comprobar los datos introducidos
        #region Comprobaciones
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
        #endregion



       
       
    }
}
