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
                    string query = "SELECT * FROM autobus;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
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
            catch (Exception ex)
            {
                throw ex;
            }
            return autobuses;
        }
    }
}
