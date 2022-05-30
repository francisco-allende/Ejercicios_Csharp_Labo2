using System;
using System.IO;

namespace Biblio
{
    public class GestionarArchivos : IArchivos
    {
        static string rutaArchivo;

        static GestionarArchivos()
        {
            rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public void Escribir(string nombreFile, string contenido)
        {
            string ruta = GestionarArchivos.rutaArchivo + nombreFile;

            try
            {
                using (StreamWriter sw = new StreamWriter(ruta))
                {
                    sw.WriteLine(contenido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error para abrir el archivo ", ex);
            }
        }

        public void EscribirAContinuacion(string nombreFile, string contenido, bool append)
        {
            string ruta = GestionarArchivos.rutaArchivo + nombreFile;

            try
            {
                using (StreamWriter sw = new StreamWriter(ruta, append))
                {
                    sw.WriteLine(contenido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error para abrir el archivo ", ex);
            }
        }

        public string Leer(string ruta)
        {
            GestionarArchivos.rutaArchivo += ruta;
            string retorno = String.Empty;

            try
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    retorno = $"{sr.ReadToEnd()}\n";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error para abrir el archivo ", ex);
            }

            return retorno;
        }
    }
}
