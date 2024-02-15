using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM_CRUD.Core;

namespace RepasoCrudExamen.Models
{
    internal class M_OperacionesPersona
    {
        private MySqlConnector.MySqlConnection conexion;


        public M_OperacionesPersona()
        {
           
            
        }
        
          
        public ObservableCollection<M_Persona> obtenerPersonas()
        {
            

            ObservableCollection<M_Persona> personas = new ObservableCollection<M_Persona>();
            try
            {
                conexion = Conexion.obtenerConexionAbierta();
                if (conexion == null)
                {
                    return null;
                }
                String sql = "SELECT * FROM persona";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Persona persona = new M_Persona();
                    persona.Id = reader.GetInt32(0);
                    persona.Nombre = reader.GetString(1);
                    persona.Apellido = reader.GetString(2);
                    persona.Telefono = reader.GetString(3);
                    persona.Correo = reader.GetString(4);
                    personas.Add(persona);
                }
                reader.Close();
                conexion.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener personas: " + ex.Message);
                return null;
            }
            return personas;
        }
        public void insertarPersona(M_Persona persona)
        {
            try
            {
                conexion = Conexion.obtenerConexionAbierta();
                if (conexion == null)
                {
                    return;
                }
                String sql = "INSERT INTO persona (nombre, apellido, telefono, correo) VALUES (@nombre, @apellido, @telefono, @correo)";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@apellido", persona.Apellido);
                cmd.Parameters.AddWithValue("@telefono", persona.Telefono);
                cmd.Parameters.AddWithValue("@correo", persona.Correo);
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al insertar persona: " + ex.Message);
            }
        }   

        public void modificarPersona(M_Persona persona)
        {
               try
            {
                conexion = Conexion.obtenerConexionAbierta();
                if (conexion == null)
                {
                    return;
                }
                else
                {
                    String sql = "UPDATE persona SET nombre = @nombre, apellido = @apellido, telefono = @telefono, correo = @correo WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@nombre", persona.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", persona.Apellido);
                    cmd.Parameters.AddWithValue("@telefono", persona.Telefono);
                    MessageBox.Show(persona.Telefono);
                    cmd.Parameters.AddWithValue("@correo", persona.Correo);
                    cmd.Parameters.AddWithValue("@id", persona.Id);
                    cmd.ExecuteNonQuery();
                    conexion.Close();

                    MessageBox.Show("Exito al modificar a la persona");
                }
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar persona: " + ex.Message);
            }
        }

        public void eliminarPersona(M_Persona persona)
        {
            try
            {
                conexion = Conexion.obtenerConexionAbierta();
                if (conexion == null)
                {
                    return;
                }
                else
                {
                    String sql = "DELETE FROM persona WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@id", persona.Id);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar persona: " + ex.Message);
            }
        }


    }
}
