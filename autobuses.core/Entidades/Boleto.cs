using autobuses.core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autobuses.core.Entidades
{
    public class Boleto
    {

        public int Id { get; set; }
        public int NumeroBoleto { get; set; }

        public static List<Boleto> GetAllBoletos()
        {
            List<Boleto> boletos = new List<Boleto>();
            try{
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()){
                    string query = "SELECT * FROM boleto;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read()){
                        Boleto boleto = new Boleto();
                        boleto.Id = int.Parse(dataReader["id"].ToString());
                        boleto.NumeroBoleto = int.Parse(dataReader["numeroBoleto"].ToString());

                        boletos.Add(boleto);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex){
                throw ex;
            }
            return boletos;
        }
    }
}
