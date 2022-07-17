using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Biblio;

namespace EntidadesDAO
{
    public class ProvincialDAO
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static ProvincialDAO()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=Centralita;Trusted_Connection=True;";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        public static void Guardar(Provincial prov)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "INSERT INTO Llamadas (DURACION, NRO_ORIGEN, NRO_DESTINO, COSTO, TIPO) " +
                    "VALUES (@duracion, @nro_origen, @nro_destino, @costo, @tipo)";

                command.Parameters.AddWithValue("@duracion", prov.Duracion);
                command.Parameters.AddWithValue("@nro_origen", prov.NroOrigen);
                command.Parameters.AddWithValue("nro_destino", prov.NroDestino);
                command.Parameters.AddWithValue("@costo", prov.CostoLlamada);
                command.Parameters.AddWithValue("@tipo", 1);
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

        public static List<Provincial> Leer()
        {
            try
            {
                List<Provincial> lista = new List<Provincial>();

                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "SELECT NRO_ORIGEN, DURACION, NRO_DESTINO FROM Llamadas " +
                    "WHERE TIPO = 1";

                using(SqlDataReader dataReader = command.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        lista.Add(new Provincial(
                            dataReader["NRO_ORIGEN"].ToString(),
                            Franja.Franja_1,
                            Convert.ToInt32(dataReader["DURACION"]),
                            dataReader["NRO_DESTINO"].ToString()
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
