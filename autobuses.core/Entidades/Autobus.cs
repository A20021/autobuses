using autobuses.core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autobuses.core.Entidades
{
    public class Autobus{
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public string Placa { get; set; }
        public int Matricula { get; set; }
        public Ruta Ruta { get; set; }

        public static List<Autobus> GetAllAutobuses()
        {
            List<Autobus> autobuses = new List<Autobus>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM autobusesdb.autobus;";
                    MySqlCommand command = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Autobus autobus = new Autobus();
                        autobus.Id = int.Parse(dataReader["id"].ToString());
                        autobus.Marca = dataReader["marca"].ToString();
                        autobus.Color = dataReader["color"].ToString();
                        autobus.Placa = dataReader["placa"].ToString();
                        autobus.Matricula = int.Parse(dataReader["matricula"].ToString());

                        Ruta ruta = new Ruta();
                        ruta.Id = int.Parse(dataReader["idRuta"].ToString());
                        autobus.Ruta = ruta;

                        autobuses.Add(autobus);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex) {
                
            }
            return autobuses;
        }

        public static bool Guardar(String marca, String color, String placa, int matricula, int idRuta){
            bool result = false;
            try{
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()){
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO `autobus` (`marca`, `color`, `placa`, `matricula`, `idRuta`) Values (@marca, @color, @placa, @matricula, @idRuta)";
                    cmd.Parameters.AddWithValue("@marca", marca);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.Parameters.AddWithValue("@placa", placa);
                    cmd.Parameters.AddWithValue("@matricula", matricula);
                    cmd.Parameters.AddWithValue("@idRuta", idRuta);

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }catch(Exception ex){
                
            }
            return result;
        }

        public bool Editar(String marca, String color, String placa, int matricula, int idRuta, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE autobus SET marca = @marca, color = @color, placa = @placa, matricula = @matricula, idRuta = @idRuta WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@marca", marca);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.Parameters.AddWithValue("@placa", placa);
                    cmd.Parameters.AddWithValue("@matricula", matricula);
                    cmd.Parameters.AddWithValue("@idRuta", idRuta);
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
