using System;
using Biblio;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace EntidadesDAO
{
    public class LocalDAO
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static LocalDAO()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=Centralita;Trusted_Connection=True;";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        public static void Guardar(Local local)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"INSERT INTO Llamadas (COSTO, DURACION, NRO_ORIGEN, NRO_DESTINO, TIPO) " +
                                        $"VALUES (@costo, @duracion, @nro_origen, @nro_destino, @tipo)";
                command.Parameters.AddWithValue("@costo", local.Costo);
                command.Parameters.AddWithValue("@duracion", local.Duracion);
                command.Parameters.AddWithValue("@nro_origen", local.NroOrigen);
                command.Parameters.AddWithValue("@nro_destino", local.NroDestino);
                command.Parameters.AddWithValue("@tipo", 0);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Local> Leer()
        {
            try
            {
                List<Local> lista = new List<Local>();

                command.Parameters.Clear();
                command.Connection.Open();
                command.CommandText = "SELECT NRO_ORIGEN, DURACION, NRO_DESTINO, COSTO FROM Llamadas " +
                    "WHERE TIPO = 0";

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add(new Local(
                            dataReader["NRO_ORIGEN"].ToString(),
                            Convert.ToInt32(dataReader["DURACION"]),
                            dataReader["NRO_DESTINO"].ToString(),
                            Convert.ToSingle(dataReader["COSTO"])
                        ));
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
