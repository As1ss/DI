
using System.Data;
using MySqlConnector;
using System;


namespace _2Eva_ALB.Core
{
   public sealed class Conexion
    {
        /* Define variables que se van a utilizar dentro de la clase */
        private static MySqlConnectionStringBuilder? builder = null;
        private static MySqlConnection? conn = null;
        private static readonly String SERVIDOR = "localhost";
        private static uint PUERTO = 3306;
        private static String BD = "exam2eva_xyz";
        private static String USUARIO = "root";
        private static String PASSWORD = "1234";

        private static MySqlConnectionStringBuilder? getBuilder()
        {
            if (builder == null)
            {
                try
                {
                    builder = new MySqlConnectionStringBuilder();
                }
                catch (Exception)
                {
                    builder = null;
                }
            }
            return builder;
        }

        public static MySqlConnection? obtenerConexionAbierta()
        {
            if (conn == null)
            {
                if (getBuilder() == null)
                {
                    return null;
                }
                else
                {
                    builder.Server = SERVIDOR;
                    builder.Port = PUERTO;
                    builder.UserID = USUARIO;
                    builder.Password = PASSWORD;
                     builder.Database = BD;
                }
                try
                {
                    conn = new MySqlConnection(builder.ToString());
                    conn.Open();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            else if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Close();
                    conn.Open();
                }
                catch
                {
                    return null;
                }
            }

            if (conn.State == ConnectionState.Open)
            {
                Console.Write("Conexión a la BD establecida\n");
            }
            return conn;
        }

        public static void cerrarConexion()
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();

                    if (conn.State == ConnectionState.Closed)
                    {
                        Console.Write("BD desconectada\n");
                    }
                }
                catch (Exception)
                {
                    Console.Write("Error al desconectar la BD\n");
                }
            }
        }
    }
}

