using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Biblio
{
    public class Local : Llamada, IGuardar<Local>
    {
        private float costo;

        public override float CostoLlamada { get => this.CalcularCosto(); }
        public string RutaDeArchivo { get => Environment.GetFolderPath(Environment.SpecialFolder.Desktop); }
        public float Costo { get => costo; set => costo = value; }

        public Local() : base()
        {

        }

        private float CalcularCosto()
        {
            return this.duracion * costo;
        }

        public Local(Llamada llamada, float costo)
            : this(llamada.NroOrigen, llamada.Duracion, llamada.NroDestino, costo)
        {

        }

        public Local(string origen, float duracion, string destino, float costo)
            : base(duracion, origen, destino)
        {
            this.costo = costo;
        }

        public override bool Equals(object obj)
        {
            return obj is Local;
        }

        protected new string Mostrar()
        {
            return $"{base.Mostrar()} - {this.CostoLlamada}";
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public bool Guardar(List<Local> contenido)
        {
            bool retorno = false;

            try
            {
                string ruta = Path.Combine(this.RutaDeArchivo + @"\Lista_Llamadas_Locales.xml");

                using (StreamWriter sr = new StreamWriter(ruta))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Local>));

                    xml.Serialize(sr, contenido);
                }

                retorno = true;
            }
            catch (InvalidCastException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return retorno;
        }

        public Local Leer()
        {
            throw new NotImplementedException();
        }
    }
}
