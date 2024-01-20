using PROYECTO_EV2_ALB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PROYECTO_EV2_ALB.ViewModels
{
    public class VM_Usuario: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

       private Models.M_OperacionesUsuario operacionesUsuario ;
       private ObservableCollection<Models.M_Usuario> listaUsuarios;

        public VM_Usuario()
        {
            operacionesUsuario = new M_OperacionesUsuario();
            // Puedes acceder directamente a la propiedad ListaUsuarios de M_OperacionesUsuario
           actualizarLista();
        }


        public Boolean comprobarEmail(string email)
        {
           
          return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        
        }
        public M_Usuario obtenerUsuario(string nombre)
        {
            M_Usuario usuario = new M_Usuario();
            foreach (M_Usuario usuario1 in listaUsuarios)
            {
                if (usuario1.Nombre == nombre)
                {
                    usuario = usuario1;
                }
            }
            return usuario;
        }

        public void actualizarLista()
        {
            listaUsuarios = operacionesUsuario.obtenerUsuarios();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListaUsuarios"));
        }
        public Boolean comprobarUsuario(string nombre, string contrasena)
        {
            Boolean encontrado = false;
            foreach (M_Usuario usuario in listaUsuarios)
            {
                if (usuario.Nombre == nombre && usuario.Contrasena == contrasena && !usuario.Bloqueado)
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
        public Boolean comprobarBloqueado(string nombre)
        {
            Boolean encontrado = false;
            foreach (M_Usuario usuario in listaUsuarios)
            {
                if (usuario.Nombre == nombre && usuario.Bloqueado)
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

        public void desbloquearUsuario(string nombre)
        {
            operacionesUsuario.desbloquearUsuario(nombre);
        }
        public void bloquearUsuario(string nombre)
        {
            operacionesUsuario.bloquearUsuario(nombre);
          
        }

        public ObservableCollection<M_Usuario> ListaUsuarios
        {
            get => listaUsuarios;
            set
            {
                listaUsuarios = value;
                OnPropertyChanged("ListaUsuarios");
            }
        }
    }

}

