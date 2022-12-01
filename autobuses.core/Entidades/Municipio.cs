using autobuses.core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autobuses.core.Entidades
{
    public class Municipio{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Estado Estado { get; set; }

        public static List<Municipio> GetAllMunicipios()
        {
            List<Municipio> municipios = new List<Municipio>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM municipio;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Municipio municipio = new Municipio();
                        municipio.Id = int.Parse(dataReader["id"].ToString());
                        municipio.Nombre = dataReader["nombre"].ToString();

                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["idEstado"].ToString());
                        municipio.Estado = estado;

                        municipios.Add(municipio);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {

            }
            return municipios;
        }

        public static bool Guardar(String nombre, int idEstado)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO municipio (nombre, idEstado) Values (@nombre, @idEstado)";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@idEstado", idEstado);

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static bool Editar(String nombre,int idEstado, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE municipio SET nombre = @nombre, idEstado = @idEstado WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@idEstado", idEstado);
                    cmd.Parameters.AddWithValue("@id", id);

                    result = cmd.ExecuteNonQuery() == 1;


                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static bool Eliminar(int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "DELETE from municipio WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);

                    result = cmd.ExecuteNonQuery() == 1;

                    cmd.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
