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
    public class Provincial : Llamada, IGuardar<Provincial>
    {
        private Franja franjaHoraria;

        public Franja FranjaHoraria { get => franjaHoraria; set => franjaHoraria = value; }
        public override float CostoLlamada { get => this.CalcularCosto(); }
        public string RutaDeArchivo { get => Environment.GetFolderPath(Environment.SpecialFolder.Desktop); }

        private float CalcularCosto()
        {
            if (this.franjaHoraria == Franja.Franja_1)
            {
                return this.duracion * 0.99f;
            }

            if (this.franjaHoraria == Franja.Franja_2)
            {
                return this.duracion * 1.25f;
            }

            if (this.franjaHoraria == Franja.Franja_3)
            {
                return this.duracion * 0.66f;
            }

            return 0;
        }

        public Provincial() : base()
        {

        }

        public Provincial(Franja franjaHoraria, Llamada llamada)
            : this(llamada.NroOrigen, franjaHoraria, llamada.Duracion, llamada.NroDestino)
        {

        }

        public Provincial(string origen, Franja franjaHoraria, float duracion, string destino)
            : base(duracion, destino, origen)
        {
            this.franjaHoraria = franjaHoraria;
        }

        protected new string Mostrar()
        {
            return $"{base.Mostrar()} - {this.CostoLlamada} - {this.franjaHoraria}";
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public override bool Equals(object obj)
        {
            return obj is Provincial;
        }

        public Provincial Leer()
        {
            Provincial llamada = new Provincial();

            try
            {
                string ruta = Path.Combine(this.RutaDeArchivo + @"\Bitacora_Llamadas_Provinciales.xml");

                using (StreamReader sr = new StreamReader(ruta))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Provincial));
                    llamada =  xml.Deserialize(sr) as Provincial;
                }
            }
            catch(InvalidCastException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return llamada;
        }

        public bool Guardar(List<Provincial> contenido)
        {
            bool retorno = false;

            try
            {
                string ruta = Path.Combine(this.RutaDeArchivo+@"\Bitacora_Llamadas_Provinciales.xml");

                using(StreamWriter sw = new StreamWriter(ruta))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Provincial>));
                    xml.Serialize(sw, contenido);
                }
                retorno = true;
            }
            catch(InvalidCastException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }

            return retorno;
        }
    }
}
