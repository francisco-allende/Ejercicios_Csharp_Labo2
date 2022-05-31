using System;
using System.IO;
using System.Text.Json;

namespace Biblio
{
    public class Serializador
    {
        static string rutaArchivo;

        static Serializador()
        {
            //Puede ser directory o no, me es mas comodo directory
            DirectoryInfo info = Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Archivos_Serializados_Json\\");
            Serializador.rutaArchivo = info.FullName;
        }

        public static void SerializadorJson(string nombreFile, Persona persona)
        {
            string ruta = Serializador.rutaArchivo + nombreFile;
            
            //seteo el identado
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true; 

            //Puede ser streamwriter o file
            using (StreamWriter sw = new StreamWriter(ruta))
            {
                try
                {
                    string miJson = JsonSerializer.Serialize(persona, opciones); //paso obj e identacion
                    sw.WriteLine(miJson); //con una linea es suficiente, se identa con la opcion. Es tdoo "una gran linea identada"
                }
                catch (Exception ex)
                {

                    throw new Exception("no se pudo pasar a json", ex);
                }
            }
        }

        //La otra forma. Es lo mismo, es para saber como es nomas
        public static void SerializarJsonConFile(string nombreFile, Persona persona)
        {
            string ruta = Serializador.rutaArchivo + nombreFile;

            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;

            try
            {
                string miJson = JsonSerializer.Serialize(persona, opciones);
                File.WriteAllText(ruta, miJson);
            }
            catch (Exception ex)
            {
                throw new Exception("no se pudo pasar a json", ex);
            }
        }

        public static Persona DeserealizarJson(string nombreFile, Persona persona)
        {
            string ruta = Serializador.rutaArchivo + nombreFile;

            try
            {
                using(StreamReader sr = new StreamReader(ruta))
                {
                    string miJson = sr.ReadToEnd();
                    return JsonSerializer.Deserialize<Persona>(miJson);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("no se pudo pasar a json", ex);
            }
        }

        //Lo mismo, es igual pero con file
        public static Persona DeserealizarJsonConFile(string nombreFile, Persona persona)
        {
            string ruta = Serializador.rutaArchivo + nombreFile;

            try
            {
                string miJson = File.ReadAllText(ruta);
                return JsonSerializer.Deserialize<Persona>(miJson);
            }
            catch (Exception ex)
            {
                throw new Exception("no se pudo pasar a json", ex);
            }
        }
    }
}
