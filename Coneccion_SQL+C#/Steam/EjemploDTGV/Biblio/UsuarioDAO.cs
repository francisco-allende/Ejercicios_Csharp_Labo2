using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Biblio
{
    public static class UsuarioDAO
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static UsuarioDAO()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=EJERCICIOS_UTN_STEAM;Trusted_Connection=True;";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        public static List<Usuario> Leer()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT CODIGO_USUARIO, USERNAME FROM USUARIOS";
                command.ExecuteNonQuery();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        usuarios.Add(new Usuario(
                            dataReader["USERNAME"].ToString(),
                            (int)dataReader["CODIGO_USUARIO"]
                            ));
                    }
                }

                return usuarios;
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
