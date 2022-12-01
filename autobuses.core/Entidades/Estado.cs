using autobuses.core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autobuses.core.Entidades
{
    public class Estado{
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<Estado> GetAllEstados(){
            List<Estado> estados = new List<Estado>();
            try{
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()){
                    string query = "SELECT * FROM estado;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read()) {
                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["id"].ToString());
                        estado.Nombre = dataReader["nombre"].ToString();

                        estados.Add(estado);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }catch(Exception ex)
            {

            }
            return estados;
        }

        public static bool Guardar(String nombre){
            bool result = false;
            try{
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()){
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO estado (nombre) Values (@nombre)";
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }catch(Exception ex){

            }
            return result;
        }

        public static bool Editar(String nombre, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE estado SET nombre = @nombre WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
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
                    cmd.CommandText = "DELETE from estado WHERE id = @id;";
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
