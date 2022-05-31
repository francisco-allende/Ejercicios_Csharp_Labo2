using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml; //este es solo para el XmlTextWriter
using System.Xml.Serialization; //este es el posta q voy a usar

namespace Biblio
{
    //Es identico al modelo anterior pero cambio Alumno por Persona
    public class Serializadora
    {
        private static string rutaBase;

        //Al parecer, se usa Directory en la serializacion
        static Serializadora()
        {
            DirectoryInfo info = Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Archivos_Serializados\\");
            Serializadora.rutaBase = info.FullName;
        }

        public static void Serialziar(string nombreArchivo, Persona persona)
        {
            string ruta = Serializadora.rutaBase + nombreArchivo;

            try
            {
                using (StreamWriter sw = new StreamWriter(ruta))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Persona));
                    xml.Serialize(sw, persona);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo pasar a XML", ex);
            }
           
        }

        //No la voy a usar, sirve saberla por si entra al parcial
        public static void SerialziarConXMLTextWriter(string nombreArchivo, Persona persona)
        {
            string ruta = Serializadora.rutaBase + nombreArchivo;

            try
            {
                //esta y la del formato identado, las unicas lineas que cambian
                using (XmlTextWriter stream = new XmlTextWriter(ruta, Encoding.UTF8)) 
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Persona));
                    stream.Formatting = Formatting.Indented;
                    xml.Serialize(stream, persona);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo pasar a XML", ex);
            }

        }

        public static Persona Deserializar(string nombreArchivo, Persona persona)
        {
            string ruta = Serializadora.rutaBase + nombreArchivo;

            using(StreamReader sr = new StreamReader(ruta))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Persona));
                persona = xml.Deserialize(sr) as Persona;
                return persona;
            }
        }

        //Lo mismo, la otra forma con el XML writer
        public static Persona DeserializarConXmlTextReader(string nombreArchivo, Persona persona)
        {
            string ruta = Serializadora.rutaBase + nombreArchivo;

            using (XmlTextReader xmlReader = new XmlTextReader(ruta)) //unica linea que cambia
            {
                XmlSerializer xml = new XmlSerializer(typeof(Persona));
                persona = xml.Deserialize(xmlReader) as Persona;
                return persona;
            }
        }
    }
}
