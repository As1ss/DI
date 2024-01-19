using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using PROYECTO_EV2_ALB.Core;

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
                        String consulta = "INSERT INTO libro (titulo, autor, stock) VALUES (@titulo, @autor, @stock)";
                        using var comando = new MySqlCommand(consulta, conexionBD);
                        comando.Parameters.AddWithValue("@titulo", libroNuevo.Titulo);
                        comando.Parameters.AddWithValue("@autor", libroNuevo.Autor);
                        comando.Parameters.AddWithValue("@stock", libroNuevo.Stock);
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
