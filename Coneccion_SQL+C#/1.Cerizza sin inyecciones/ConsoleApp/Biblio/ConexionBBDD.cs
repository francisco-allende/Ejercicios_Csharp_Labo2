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

        //Este metodo es para el select ya que es de lectura
        public static List<Persona> Leer(string query)
        {
            List<Persona> personas = new List<Persona>();
            //Siempre try catch cuando abramos y cerremos conexion
            try
            {
                connection.Open(); //abro la conexion
                command.CommandText = query; //query SELECT enviada por parametro

                //esta bueno cerrar el data reader
                using (SqlDataReader dataReader = command.ExecuteReader()) //comando para queries de lectura que retornan datos
                {
                    while (dataReader.Read()) //Retorna true si hay registros e itera
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
                connection.Close(); //si o si siempre cierro la coneccion
            }
        }


        public static void Insertar(string query)
        {
            try
            {
                connection.Open();
                command.CommandText = query;
                command.ExecuteNonQuery(); //para insert, update y delete ya que no retorna nada, no hay lectura
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

        public static void Eliminar(string query)
        {
            try
            {
                connection.Open();
                command.CommandText = query;
                int rows = command.ExecuteNonQuery(); //retorna un int con las filas afectadas
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

        public static void Editar(string query)
        {
            try
            {
                connection.Open();
                command.CommandText = query;
                int rows = command.ExecuteNonQuery(); //para insert, update y delete ya que no retorna nada, no hay lectura
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
    }
}
