using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2Eva_ALB.Model
{
    internal class M_OperacionesTipoPlaneta
    {
        
        public M_OperacionesTipoPlaneta()
        {


        }

        //Creamos un método para guardar un tipo de planeta en la BBDD

        public Boolean guardarTipoPlaneta(M_TipoPlaneta tipoPlaneta)
        {
            try
            {
                // Obtener una conexión abierta a la BD
                MySqlConnection? conexionBD = Core.Conexion.obtenerConexionAbierta();
                if (conexionBD == null)
                {
                    return false;
                }
                else
                {
                    String sql = "INSERT INTO tipoplaneta (NombreTipo) VALUES ('" + tipoPlaneta.NombreTipoPlaneta + "')";
                    using var cmd = new MySqlCommand(sql, conexionBD);
                    cmd.ExecuteNonQuery();
                    conexionBD.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar tipo de planeta: " + ex.Message);
                return false;
            }
            return true;
        }   
       
    }
}
