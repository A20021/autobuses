﻿using autobuses.core.Database;
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
                
            }
            return boletos;
        }

        public static bool Guardar(int numeroBoleto)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO boleto (numeroBoleto) Values (@numeroBoleto)";
                    cmd.Parameters.AddWithValue("@numeroBoleto", numeroBoleto);

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }

        public static bool Editar(int numeroBoleto, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE boleto SET numeroBoleto = @numeroBoleto WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@numeroBoleto", numeroBoleto);
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
                    cmd.CommandText = "DELETE from boleto WHERE id = @id;";
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
