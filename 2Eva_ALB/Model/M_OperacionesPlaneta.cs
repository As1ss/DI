using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace _2Eva_ALB.Model
{
    public class M_OperacionesPlaneta
    {

      
        public M_OperacionesPlaneta()
        {
            
        }

        public ObservableCollection<M_Planeta> obtenerPlanetas()
        {

            ObservableCollection<M_Planeta> planetas = new ObservableCollection<M_Planeta>();
            try
            {
                // Obtener una conexión abierta a la BD
                MySqlConnection? conexionBD = Core.Conexion.obtenerConexionAbierta();
                if (conexionBD == null)
                {
                    return null;
                }
                else
                {
 
                String sql = "SELECT * FROM planetas p, tipoplaneta tp WHERE p.TipoPlaneta_idTipoPlaneta = tp.idTipoPlaneta";
                using var cmd = new MySqlCommand(sql, conexionBD);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Planeta planeta = new M_Planeta();
                    planeta.IdPlaneta = reader.GetInt32("idPlanetas");
                    planeta.CodPlaneta = reader.GetString("CodPlaneta");
                    planeta.NombrePlaneta = reader.GetString("Nombre");
                    planeta.NumSatelites = reader.GetInt32("Numero_de_satelites");
                    planeta.FactorGravitacional = reader.GetFloat("Factor_gravitacional");
                    planeta.ExisteVida = reader.GetBoolean("Existe_vida");
                 
                    M_TipoPlaneta tipoPlaneta = new M_TipoPlaneta();
                    tipoPlaneta.IdTipoPlaneta = reader.GetInt32("idTipoPlaneta");

                 
                    tipoPlaneta.NombreTipoPlaneta = reader.GetString("NombreTipo");
                    planeta.TipoPlaneta = tipoPlaneta;
                  
                    planetas.Add(planeta);

                   

                }
                reader.Close();
                    conexionBD.Close();
                }
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener personas: " + ex.Message);
                return null;
            }
            return planetas;

        }

        public M_Planeta obtenerPlaneta(String codPlaneta)


        {
            M_Planeta planeta = new M_Planeta();
            try
            {
                // Obtener una conexión abierta a la BD
                MySqlConnection? conexionBD = Core.Conexion.obtenerConexionAbierta();
                if (conexionBD == null)
                {
                    return null;
                }
                else
                {
                    String sql = "SELECT * FROM planetas p, tipoplaneta tp WHERE p.TipoPlaneta_idTipoPlaneta = tp.idTipoPlaneta AND CodPlaneta LIKE '" + codPlaneta+"'";
                    using var cmd = new MySqlCommand(sql, conexionBD);
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        planeta.IdPlaneta = reader.GetInt32("idPlanetas");
                        planeta.CodPlaneta = reader.GetString("CodPlaneta");
                        planeta.NombrePlaneta = reader.GetString("Nombre");
                        planeta.NumSatelites = reader.GetInt32("Numero_de_satelites");
                        planeta.FactorGravitacional = reader.GetFloat("Factor_gravitacional");
                        planeta.ExisteVida = reader.GetBoolean("Existe_vida");
                        M_TipoPlaneta tipoPlaneta = new M_TipoPlaneta();
                        tipoPlaneta.IdTipoPlaneta = reader.GetInt32("idTipoPlaneta");
                        tipoPlaneta.NombreTipoPlaneta = reader.GetString("NombreTipo");
                        planeta.TipoPlaneta = tipoPlaneta;
                        
                    }
                    reader.Close();
                    conexionBD.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener planeta: " + ex.Message);
                return null;
            }
            return planeta;
        }


        //Creamos un método para guardar un planeta en la BBDD
        public Boolean guardarPlaneta(M_Planeta planeta)
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
                    String sql = "INSERT INTO planetas (CodPlaneta, Nombre, Numero_de_satelites, Factor_gravitacional, Existe_vida, TipoPlaneta_idTipoPlaneta) VALUES ('" + planeta.CodPlaneta + "','" + planeta.NombrePlaneta + "'," + planeta.NumSatelites + "," + planeta.FactorGravitacional + "," + planeta.ExisteVida + "," + planeta.TipoPlaneta.IdTipoPlaneta + ")";
                    using var cmd = new MySqlCommand(sql, conexionBD);
                    cmd.ExecuteNonQuery();
                    conexionBD.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar planeta: " + ex.Message);
                return false;
            }
            return true;
        }
    }
}
