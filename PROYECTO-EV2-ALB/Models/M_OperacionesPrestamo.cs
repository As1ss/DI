using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;
namespace PROYECTO_EV2_ALB.Models
{
    public class M_OperacionesPrestamo
    {
      

        public M_OperacionesPrestamo()
        {
           
        }

        public ObservableCollection<M_Prestamo> obtenerPrestamos()
        {
            ObservableCollection<M_Prestamo> listaPrestamos = new ObservableCollection<M_Prestamo>();
            try
            {
                // Obtener una conexión abierta a la BD
                MySqlConnection? conexionBD = Core.Conexion.obtenerConexionAbierta();

                if (conexionBD == null)
                {
                    Console.WriteLine("Error en Conexion a BD");
                }
                else
                {
                    try
                    {
                        // comando a ejecutar en la BD
                        String consulta = "SELECT libro.*,usuario.*,prestamo.* from libro, prestamo, usuario where libro.id_libro = prestamo.libro AND usuario.id_usuario = prestamo.usuario";
                        using var comando = new MySqlCommand(consulta, conexionBD);
                        using MySqlDataReader reader = comando.ExecuteReader();
                      
                        while (reader.Read())
                        {
                            M_Prestamo prestamo = new M_Prestamo();
                            prestamo.Libro = new M_Libro(); // Asegúrate de que Libro esté inicializado
                            prestamo.Usuario = new M_Usuario(); // Asegúrate de que Usuario esté inicializado

                            prestamo.Libro.Id_libro = reader.GetInt32(0);
                            prestamo.Libro.Titulo = reader.GetString(1);
                            prestamo.Libro.Autor = reader.GetString(2);
                            prestamo.Libro.Stock = reader.GetInt32(3);
                            prestamo.Usuario.Id_usuario = reader.GetInt32(4);
                            prestamo.Usuario.Nombre = reader.GetString(5);
                            prestamo.Usuario.Contrasena = reader.GetString(6);
                            prestamo.Usuario.Email = reader.GetString(7);
                            prestamo.Usuario.Tipo_usuario = reader.GetString(8);
                            prestamo.Usuario.Bloqueado = reader.GetBoolean(9);
                            prestamo.Id_prestamo = reader.GetInt32(10);
                            prestamo.Fecha_prestamo = reader.GetDateTime(13);
                            prestamo.Fecha_devolucion = reader.GetDateTime(14);
                            listaPrestamos.Add(prestamo);
                        }

                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return listaPrestamos;
        }
        public void insertarPrestamo(M_Prestamo prestamo)
        {
            try
            {
                // Obtener una conexión abierta a la BD
                MySqlConnection? conexionBD = Core.Conexion.obtenerConexionAbierta();

                if (conexionBD == null)
                {
                    Console.WriteLine("Error en Conexion a BD");
                }
                else
                {
                    try
                    {
                        // comando a ejecutar en la BD
                        String consulta = "INSERT INTO prestamo (libro, usuario, fecha_prestamo, fecha_devolucion) VALUES (@libro, @usuario, @fecha_prestamo, @fecha_devolucion)";
                        using var comando = new MySqlCommand(consulta, conexionBD);
                        comando.Parameters.AddWithValue("@libro", prestamo.Libro.Id_libro);
                        comando.Parameters.AddWithValue("@usuario", prestamo.Usuario.Id_usuario);
                        comando.Parameters.AddWithValue("@fecha_prestamo", prestamo.Fecha_prestamo);
                        comando.Parameters.AddWithValue("@fecha_devolucion", prestamo.Fecha_devolucion);
                        comando.ExecuteNonQuery();
                      
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

      

    }
}
