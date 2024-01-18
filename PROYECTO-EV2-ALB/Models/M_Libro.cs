using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_EV2_ALB.Models
{
    public class M_Libro
    {
        private int id_libro;
        private string titulo;
        private string autor;
        private int stock;

        public M_Libro()
        {

        }

        public M_Libro(string titulo, string autor, int stock)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.stock = stock;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Id_libro { get => id_libro; set => id_libro = value; }
    }
}
