using autobuses.core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autobuses.core.Entidades
{
    public class Ruta{
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }
        public Pasajero Pasajero { get; set; }
        public Destino Destino { get; set; }
        public Partida Partida { get; set; }

        public static List<Ruta> GetAllRutas()
        {
            List<Ruta> rutas = new List<Ruta>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM ruta;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Ruta ruta = new Ruta();
                        ruta.Id = int.Parse(dataReader["id"].ToString());
                        ruta.Descripcion = dataReader["descripcion"].ToString();

                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["idEstado"].ToString());
                        ruta.Estado = estado;

                        Pasajero pasajero = new Pasajero();
                        pasajero.Id = int.Parse(dataReader["idPasajero"].ToString());
                        ruta.Pasajero = pasajero;

                        Destino destino = new Destino();
                        destino.Id = int.Parse(dataReader["idDestino"].ToString());
                        ruta.Destino = destino;

                        Partida partida = new Partida();
                        partida.Id = int.Parse(dataReader["idPartida"].ToString());
                        ruta.Partida = partida;

                        rutas.Add(ruta);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rutas;
        }
    }
}
