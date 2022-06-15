using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Biblio
{
    public class PersonaADO
    {
        static string connectionString; 
        static SqlCommand command; 
        static SqlConnection connection;

        static PersonaADO()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=Ejercicio_mi_primer_CRUD;Trusted_Connection=True;";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text; 
            command.Connection = connection;
        }

        public static void Guardar(string nombre, string apellido)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"INSERT INTO Persona (Nombre, Apellido) VALUES (@nombre, @apellido)";
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
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

        public static List<Persona> Leer()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM Persona";

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        personas.Add(new Persona(
                            (int)dataReader["Id"],
                            dataReader["Nombre"].ToString(),
                            dataReader["Apellido"].ToString()
                        ));
                    }
                }

                return personas;
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

        public static Persona LeerPorId(int id)
        {
            Persona p = new Persona();

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM Persona WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        p.Id = (int)dataReader["Id"];
                        p.Nombre = dataReader["Nombre"].ToString();
                        p.Apellido = dataReader["Apellido"].ToString();
                    }
                }

                return p;
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

        //Actualizo varios valores al usar un ";" despues del primer quey de update y hacer otro. Es si o si uno a uno
        public static void Modificar(string nombre, string apellido, int id)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "UPDATE Persona SET Nombre = @nombre WHERE Id = @Id; UPDATE Persona SET Apellido = @apellido WHERE Id = @Id";
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@Id", id);
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

        public static void Borrar(int id)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "DELETE FROM Persona WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);
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
    }
}
