using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Biblio
{
    public class ConexionBBDD
    {
        static string connectionString; //string que va como parametro a la conexion
        static SqlCommand command; //tiramos comandos
        static SqlConnection connection; //abrimos y cerramos el acceso a la BBDD

        //Instancio mis objetos
        static ConexionBBDD()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=Ejercicio_Cerizza_UTN;Trusted_Connection=True;";

            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text; //seteo para que los comandos sean de tipo texto, string
            command.Connection = connection;
        }

        //Leo de forma segura antiinyecciones con addwithvalue
        public static List<Persona> Leer(int id)
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                command.Parameters.Clear(); 
                connection.Open();
                command.CommandText =$"SELECT * FROM Personas WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id",id);

                using (SqlDataReader dataReader = command.ExecuteReader()) 
                {
                    while (dataReader.Read()) 
                    {
                        personas.Add(new Persona(dataReader["Nombre"].ToString(), (int)dataReader["Id"])); //lo instancio como objeto con sus parametros segun valor de 
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

        public static List<Persona> LeerTodo()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM Personas";

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        personas.Add(new Persona(dataReader["Nombre"].ToString(), (int)dataReader["Id"])); //lo instancio como objeto con sus parametros segun valor de 
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

        //ultimo el execute non query. 
        public static void Insertar(string name)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"INSERT INTO personas (Nombre) VALUES (@name)";
                command.Parameters.AddWithValue("@name", name);
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

        public static void Eliminar(int id)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "DELETE FROM personas WHERE @Id = 3";
                command.Parameters.AddWithValue("@Id", id);
                int rows = command.ExecuteNonQuery(); 
                Console.WriteLine(rows + " filas afectadas\n");
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

        public static void Editar(string nombre, int id)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "UPDATE personas SET Nombre = @nombre WHERE Id = @Id";
                command.Parameters.AddWithValue("@nombre", nombre);
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
