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
    public class Serializadora
    {
        private static string rutaBase;

        //Al parecer, se usa Directory en la serializacion
        static Serializadora()
        {
            DirectoryInfo info = Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Archivos_Serializados\\");
            Serializadora.rutaBase = info.FullName;
        }

        public static void Serialziar(string nombreArchivo, Alumno alumno)
        {
            string ruta = Serializadora.rutaBase + nombreArchivo;

            try
            {
                using (StreamWriter sw = new StreamWriter(ruta))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Alumno));
                    xml.Serialize(sw, alumno);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo pasar a XML", ex);
            }
           
        }

        //No la voy a usar, sirve saberla por si entra al parcial
        public static void SerialziarConXMLTextWriter(string nombreArchivo, Alumno alumno)
        {
            string ruta = Serializadora.rutaBase + nombreArchivo;

            try
            {
                //esta y la del formato identado, las unicas lineas que cambian
                using (XmlTextWriter stream = new XmlTextWriter(ruta, Encoding.UTF8)) 
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Alumno));
                    stream.Formatting = Formatting.Indented;
                    xml.Serialize(stream, alumno);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo pasar a XML", ex);
            }

        }

        public static Alumno Deserializar(string nombreArchivo, Alumno alumno)
        {
            string ruta = Serializadora.rutaBase + nombreArchivo;

            using(StreamReader sr = new StreamReader(ruta))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Alumno));
                alumno = xml.Deserialize(sr) as Alumno;
                return alumno;
            }
        }

        //Lo mismo, la otra forma con el XML writer
        public static Alumno DeserializarConXmlTextReader(string nombreArchivo, Alumno alumno)
        {
            string ruta = Serializadora.rutaBase + nombreArchivo;

            using (XmlTextReader xmlReader = new XmlTextReader(ruta)) //unica linea que cambia
            {
                XmlSerializer xml = new XmlSerializer(typeof(Alumno));
                alumno = xml.Deserialize(xmlReader) as Alumno;
                return alumno;
            }
        }
    }
}
