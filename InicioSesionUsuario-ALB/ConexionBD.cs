using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InicioSesionUsuario_ALB
{
    internal class ConexionBD
    {
        private static MySqlConnectionStringBuilder? builder = null;
        private static MySqlConnection? connection = null;
        private const String SERVIDOR = "localhost";
        private const uint PUERTO = 3306;
        private const String BASEDATOS = "usuariologin";
        private const String USUARIO = "root";
        private const String PASSWORD = "1234";

        private static MySqlConnectionStringBuilder getBuilder()
        {
            if (builder == null)
            {
                try
                {
                    builder = new MySqlConnectionStringBuilder();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return builder;
        }

        public static MySqlConnection getConnection()
        {
            if (connection == null)
            {
                if (getBuilder() == null)
                {
                    return null;
                }


                builder.Server = SERVIDOR;
                builder.Port = PUERTO;
                builder.Database = BASEDATOS;
                builder.UserID = USUARIO;
                builder.Password = PASSWORD;


                try
                {
                    connection = new MySqlConnection(builder.ToString());
                    connection.Open();
                  
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else if (connection.State == ConnectionState.Open)
            {
                Console.Write("Conexión a la BD establecida\n");
            }
            return connection;
        }
        public static void CerrarConexion()
        {
            if (connection != null){
                try
                {
                    connection.Close();
                    connection.Dispose();

                    if(connection.State == ConnectionState.Closed)
                    {
                        Console.Write("BD desconectada\n");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                

                   
                
            }

        }

    }
}
