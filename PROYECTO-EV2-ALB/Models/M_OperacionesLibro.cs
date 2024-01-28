using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using MySqlConnector;
using PROYECTO_EV2_ALB.Core;
using WPF_MVVM_CRUD.Core;

namespace PROYECTO_EV2_ALB.Models
{
    public class M_OperacionesLibro
    {
        public ObservableCollection<M_Libro> listaLibros;

        public M_OperacionesLibro()
        {
            listaLibros = new ObservableCollection<M_Libro>();
        }

        
        public ObservableCollection<M_Libro> obtenerLibros()
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
                        String consulta = "SELECT * FROM libro";
                        using var comando = new MySqlCommand(consulta, conexionBD);
                        using MySqlDataReader reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                            M_Libro libro = new M_Libro();
                            libro.Id_libro = reader.GetInt32(0);
                            libro.Titulo = reader.GetString(1);
                            libro.Autor = reader.GetString(2);
                            libro.Stock = reader.GetInt32(3);
                            if (!reader.IsDBNull(4))
                            {
                                libro.Imagen = Utils.ConvertByteArrayToBitmapImage(reader.GetFieldValue<byte[]>(4));
                            }
                            else
                            {
                                 
                                  // Asignar imagen por defecto
                                 libro.Imagen = new BitmapImage(new Uri("../images/default.png", UriKind.Relative));


                            }




                            listaLibros.Add(libro);
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
            return listaLibros;
        }

        public void insertarLibro(M_Libro libroNuevo)
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
                        String consulta = "INSERT INTO libro (titulo, autor, stock,imagen) VALUES (@titulo, @autor, @stock,@imagen)";
                        using var comando = new MySqlCommand(consulta, conexionBD);
                        comando.Parameters.AddWithValue("@titulo", libroNuevo.Titulo);
                        comando.Parameters.AddWithValue("@autor", libroNuevo.Autor);
                        comando.Parameters.AddWithValue("@stock", libroNuevo.Stock);
                        comando.Parameters.AddWithValue("@imagen", Utils.ConvertBitmapImageToByteArray(libroNuevo.Imagen));
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

        
        public void actualizarLibro(M_Libro libroNuevo)
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
                        String consulta = "UPDATE libro SET titulo=@titulo, autor=@autor, stock=@stock, imagen=@imagen WHERE id_libro=@id_libro";
                        using var comando = new MySqlCommand(consulta, conexionBD);
                        comando.Parameters.AddWithValue("@titulo", libroNuevo.Titulo);
                        comando.Parameters.AddWithValue("@autor", libroNuevo.Autor);
                        comando.Parameters.AddWithValue("@stock", libroNuevo.Stock);
                        comando.Parameters.AddWithValue("@id_libro", libroNuevo.Id_libro);
                        comando.Parameters.AddWithValue("@imagen", Utils.ConvertBitmapImageToByteArray(libroNuevo.Imagen));
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

        public void eliminarLibro(M_Libro libroEliminar)
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
                        String consulta = "DELETE FROM libro WHERE id_libro=@id_libro";
                        using var comando = new MySqlCommand(consulta, conexionBD);
                        comando.Parameters.AddWithValue("@id_libro", libroEliminar.Id_libro);
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
