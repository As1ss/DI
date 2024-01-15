using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_EV2_ALB.Models
{
    public class Usuario
    {
        private int id_usuario;
        private string nombre;
        private string contrasena;
        private string tipo_usuario;

        public Usuario()
        {

        }

        public Usuario(int id_usuario, string nombre, string contrasena, string tipo_usuario)
        {
            this.id_usuario = id_usuario;
            this.nombre = nombre;
            this.contrasena = contrasena;
            this.tipo_usuario = tipo_usuario;
        }

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Tipo_usuario { get => tipo_usuario; set => tipo_usuario = value; }

    }
}
