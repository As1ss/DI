using PROYECTO_EV2_ALB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_EV2_ALB.ViewModels
{
    public class VM_Usuario
    {
        private Models.M_OperacionesUsuario operacionesUsuario = new M_OperacionesUsuario();
        ObservableCollection<Models.M_Usuario> listaUsuarios;

        public VM_Usuario()
        {
            // Puedes acceder directamente a la propiedad ListaUsuarios de M_OperacionesUsuario
           listaUsuarios= operacionesUsuario.obtenerUsuarios();
        }
        public Boolean comprobarUsuario(string nombre, string contrasena)
        {
            Boolean encontrado = false;
            foreach (M_Usuario usuario in listaUsuarios)
            {
                if (usuario.Nombre == nombre && usuario.Contrasena == contrasena)
                {
                    encontrado = true;
                }
            }
            return encontrado;
        }
        public Boolean existeUsuario(string nombre)
        {
            Boolean encontrado = false;
            foreach (M_Usuario usuario in listaUsuarios)
            {
                if (usuario.Nombre == nombre)
                {
                    encontrado = true;
                }
            }
            return encontrado;
        }
        public Boolean comprobarAdmin(string nombre, string contrasena)
        {
            Boolean encontrado = false;
            foreach (M_Usuario usuario in listaUsuarios)
            {
                if (usuario.Nombre == nombre && usuario.Contrasena == contrasena && usuario.Tipo_usuario == "administrador")
                {
                    encontrado = true;
                }
            }
            return encontrado;
        }
        public void insertarUsuario(M_Usuario usuarioNuevo)
        {
            operacionesUsuario.insertarUsuario(usuarioNuevo);
        }
        public ObservableCollection<Models.M_Usuario> ListaUsuarios
        {
            get
            {
                return listaUsuarios;
            }
        }
       
    }

}
