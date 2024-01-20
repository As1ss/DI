using PROYECTO_EV2_ALB.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows;

namespace PROYECTO_EV2_ALB.Models
{
    public class M_OperacionesIncidencia
    {
        private ObservableCollection<M_Incidencia> listaIncidencias;

        public M_OperacionesIncidencia()
        {
            listaIncidencias = new ObservableCollection<M_Incidencia>();
        }

        public ObservableCollection<M_Incidencia> obtenerIncidencias()
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
                        String consulta = "SELECT * FROM incidencia";
                        using var comando = new MySqlCommand(consulta, conexionBD);
                        using MySqlDataReader reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                          M_Incidencia incidencia = new M_Incidencia();
                            incidencia.Id_incidencia = reader.GetInt32(0);
                            incidencia.Id_usuario = reader.GetInt32(1);
                            incidencia.Descripcion = reader.GetString(2);
                            incidencia.Fecha_incidencia = reader.GetDateTime(3);
                            incidencia.Resuelta = reader.GetBoolean(4);
                            listaIncidencias.Add(incidencia);
                        }
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
            return listaIncidencias;
        }
        public void insertarIncidencia(M_Incidencia incidenciaNueva)
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
                        String consulta = "INSERT INTO incidencia (usuario, descripcion, fecha_incidencia, resuelta) VALUES (@id_usuario, @descripcion, @fecha_incidencia, 0)";
                        using var comando = new MySqlCommand(consulta, conexionBD);
                        comando.Parameters.AddWithValue("@id_usuario", incidenciaNueva.Id_usuario);
                        comando.Parameters.AddWithValue("@descripcion", incidenciaNueva.Descripcion);
                        comando.Parameters.AddWithValue("@fecha_incidencia", incidenciaNueva.Fecha_incidencia);
                        comando.Parameters.AddWithValue("@resuelta", incidenciaNueva.Resuelta);
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
    }



     
}
