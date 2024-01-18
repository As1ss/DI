using MySqlConnector;
using PROYECTO_EV2_ALB.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PROYECTO_EV2_ALB.Models
{
    public class M_OperacionesUsuario
    {
        public ObservableCollection<M_Usuario> listaUsuarios;

        public M_OperacionesUsuario()
        {
            listaUsuarios = new ObservableCollection<M_Usuario>();
        }

        public void insertarUsuario(M_Usuario usuarioNuevo)
        {
           
            try
            {
                // Obtener una conexión abierta a la BD
                MySqlConnection? conexionBD = Conexion.obtenerConexionAbierta();

                if (conexionBD == null)
                {
                    Console.WriteLine("Error en Conexion a BD");
                }
                else
                {
                    try
                    {
                        // comando a ejecutar en la BD
                        String consulta = "INSERT INTO usuario (nombre, password, email, tipo_usuario) VALUES (@nombre, @contrasena, @email,@tipo_usuario)";
                        using var comando = new MySqlCommand(consulta, conexionBD);
                        comando.Parameters.AddWithValue("@nombre", usuarioNuevo.Nombre);
                        comando.Parameters.AddWithValue("@contrasena", usuarioNuevo.Contrasena);
                        comando.Parameters.AddWithValue("@email",usuarioNuevo.Email);
                        comando.Parameters.AddWithValue("@tipo_usuario", usuarioNuevo.Tipo_usuario);
                        comando.ExecuteNonQuery();
                       
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // siempre se cierra la conexion
                Conexion.cerrarConexion();
            }
            
        }

        public ObservableCollection<M_Usuario> obtenerUsuarios()
        {
            try
            {
                // Obtener una conexión abierta a la BD
                MySqlConnection? conexionBD = Conexion.obtenerConexionAbierta();

                if (conexionBD == null)
                {
                    Console.WriteLine("Error en Conexion a BD");
                }
                else
                {
                    try
                    {
                        // Variable para tratar cada linea del cursor devuelto en la consulta
                        String data = null;

                        // comando a ejecutar en la BD
                        String consulta = "SELECT * FROM usuario";
                        using var comando = new MySqlCommand(consulta, conexionBD);

                        // Ejecución del comando
                        using var reader = comando.ExecuteReader();

                        // Obtención del cursor con el resultado de una consulta
                        while (reader.Read())
                        {
                            M_Usuario usuario = new M_Usuario();
                            usuario.Id_usuario = reader.GetInt32(0);
                            usuario.Nombre = reader.GetString(1);
                            usuario.Contrasena = reader.GetString(2);
                            usuario.Email =reader.GetString(3);
                            usuario.Tipo_usuario = reader.GetString(4);
                            
                            listaUsuarios.Add(usuario);

                        }
                        Console.WriteLine("Usuarios cargados");

                        return listaUsuarios;
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // siempre se cierra la conexion
                Conexion.cerrarConexion();
            }
            return null;
        }
        
          
        
    }
}
    

