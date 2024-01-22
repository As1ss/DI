using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_EV2_ALB.Models
{
    public class M_Usuario 

    {
     

        private int id_usuario;
        private string nombre;
        private string contrasena;
        private string email;
        private string tipo_usuario;
        private Boolean bloqueado;
        private Boolean prestamo_activo;

        public M_Usuario()
        {

        }

        public M_Usuario(int id_usuario, string nombre, string contrasena, string tipo_usuario, string email, bool bloqueado,bool prestamo_activo)
        {
            this.id_usuario = id_usuario;
            this.nombre = nombre;
            this.contrasena = contrasena;
            this.tipo_usuario = tipo_usuario;
            this.email = email;
            this.bloqueado = bloqueado;
            this.prestamo_activo = prestamo_activo;
        }
       

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Email { get => email; set => email = value; }
        public string Tipo_usuario { get => tipo_usuario; set => tipo_usuario = value; }
        public bool Bloqueado { get => bloqueado; set => bloqueado = value;}
        public bool Prestamo_activo { get => prestamo_activo; set => prestamo_activo = value; }

      
    }
}
