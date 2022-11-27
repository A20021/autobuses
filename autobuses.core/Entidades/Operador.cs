using autobuses.core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autobuses.core.Entidades
{
    public class Operador{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public static List<Operador> GetAllOperadores()
        {
            List<Operador> operadores = new List<Operador>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM operador;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Operador operador = new Operador();
                        operador.Id = int.Parse(dataReader["id"].ToString());
                        operador.Nombre = dataReader["nombre"].ToString();
                        operador.Edad = int.Parse(dataReader["edad"].ToString());

                        operadores.Add(operador);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return operadores;
        }
    }
}
