using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Biblio
{
    //realiza todas las operaciones en la tabla juegos
    public static class JuegoDAO 
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static JuegoDAO()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=EJERCICIOS_UTN_STEAM;Trusted_Connection=True;";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        public static void Guardar(Juego juego)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"INSERT INTO JUEGOS (CODIGO_USUARIO, NOMBRE, PRECIO, GENERO) " +
                                        $"VALUES (@codigo_usuario, @nombre, @precio, @genero)";
                command.Parameters.AddWithValue("@codigo_usuario", juego.CodigoUsuario);
                command.Parameters.AddWithValue("@nombre", juego.Nombre);
                command.Parameters.AddWithValue("@precio", juego.Precio);
                command.Parameters.AddWithValue("@genero", juego.Genero);
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

        public static List<Biblioteca> Leer()
        {
            List<Biblioteca> biblioteca = new List<Biblioteca>();

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT JUEGOS.NOMBRE AS juego, JUEGOS.GENERO as genero, " +
                    " JUEGOS.CODIGO_JUEGO as codigoJuego, USUARIOS.USERNAME as usuario " +
                    " FROM JUEGOS JOIN USUARIOS ON JUEGOS.CODIGO_USUARIO = USUARIOS.CODIGO_USUARIO";

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        //Lo añado a las columnas de la tabla nueva que hice con el join.
                        //Clave el as para tener los nombres de columnas
                            biblioteca.Add(new Biblioteca(
                                dataReader["usuario"].ToString(),
                                dataReader["genero"].ToString(),
                                dataReader["juego"].ToString(),
                                (int)dataReader["codigoJuego"]
                        ));
                     }
                }

                return biblioteca;
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

        public static Juego LeerPorId(int id)
        {
            Juego juego = null; 

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM JUEGOS WHERE CODIGO_JUEGO = @Id";
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        juego = new Juego
                        (
                            dataReader["NOMBRE"].ToString(),
                            (double)dataReader["PRECIO"],
                            dataReader["GENERO"].ToString(),
                            (int)dataReader["CODIGO_JUEGO"],
                            (int)dataReader["CODIGO_USUARIO"]
                        );
                    }
                }

                return juego;
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

        public static void Modificar(Juego juego)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "UPDATE JUEGOS SET NOMBRE = @nombre, GENERO = @genero," + 
                                       "PRECIO = @precio WHERE CODIGO_JUEGO = @Id";
                command.Parameters.AddWithValue("@nombre", juego.Nombre);
                command.Parameters.AddWithValue("@genero", juego.Genero);
                command.Parameters.AddWithValue("@precio", juego.Precio);
                command.Parameters.AddWithValue("@Id", juego.CodigoJuego);
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
                command.CommandText = "DELETE FROM JUEGOS WHERE CODIGO_JUEGO = @Id";
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
