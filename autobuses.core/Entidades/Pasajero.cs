using autobuses.core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autobuses.core.Entidades
{
    public class Pasajero{
        public int Id { get; set; }
        public Boleto Boleto { get; set; }
        public int NumeroAsiento { get; set; }

        public static List<Pasajero> GetAllPasajeros()
        {
            List<Pasajero> pasajeros = new List<Pasajero>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM pasajero;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Pasajero pasajero = new Pasajero();
                        pasajero.Id = int.Parse(dataReader["id"].ToString());
                        
                        Boleto boleto = new Boleto();
                        boleto.Id = int.Parse(dataReader["idBoleto"].ToString());
                        pasajero.Boleto = boleto;

                        pasajero.NumeroAsiento = int.Parse(dataReader["numeroAsiento"].ToString());

                        pasajeros.Add(pasajero);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pasajeros;
        }

        public static bool Guardar(int idBoleto, int numeroAsiento)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO pasajero (idBoleto, numeroAsiento) Values (@idBoleto, @numeroAsiento)";
                    cmd.Parameters.AddWithValue("@idBoleto", idBoleto);
                    cmd.Parameters.AddWithValue("@numeroAsiento", numeroAsiento);

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool Editar(int idBoleto, int numeroAsiento, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE pasajero SET idBoleto = @idBoleto, numeroAsiento = @numeroAsiento WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@idBoleto", idBoleto);
                    cmd.Parameters.AddWithValue("@numeroAsiento", numeroAsiento);
                    cmd.Parameters.AddWithValue("@id", id);

                    result = cmd.ExecuteNonQuery() == 1;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
