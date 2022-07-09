using System;
using System.Collections.Generic;
using System.Text;

namespace Biblio
{
    public class Centralita : IGuardar<string>
    {
        private List<Llamada> listaDeLlamadas;
        protected string razonSocial;

        public float GananciasPorLocal { get => this.CalcularGanancia(TipoLlamada.Local); }
        public float GananciasPorProvincial { get => this.CalcularGanancia(TipoLlamada.Provincial); }
        public float GananciasPorTotal { get => this.CalcularGanancia(TipoLlamada.Todas); }
        public List<Llamada> Llamadas { get => this.listaDeLlamadas; }
        
        public string RutaDeArchivo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float ganancia = 0;

            foreach (Llamada item in this.Llamadas)
            {
                if (tipo is TipoLlamada.Provincial && item is Provincial)
                {
                    ganancia += ((Provincial)item).CostoLlamada;
                }
                else if (tipo is TipoLlamada.Local && item is Local)
                {
                    ganancia += ((Local)item).CostoLlamada;
                }
                else if (tipo is TipoLlamada.Todas)
                {
                    switch (item)
                    {
                        case Local:
                            ganancia += ((Local)item).CostoLlamada;
                            break;

                        case Provincial:
                            ganancia += ((Provincial)item).CostoLlamada;
                            break;
                    }
                }
            }

            return ganancia;
        }

        public Centralita()
        {
            this.listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa)
            : this()
        {
            this.razonSocial = nombreEmpresa;
        }

        public void OrdenarLlamadas()
        {
            this.Llamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Razon social: {this.razonSocial}\n");
            sb.Append($"Total Ganancias Local: {this.GananciasPorLocal}\n");
            sb.Append($"Total Ganancias Provincial: {this.GananciasPorProvincial}\n");
            sb.Append($"Total Ganancia: {this.GananciasPorTotal}\n");

            sb.Append("\n******     Detalle llamados    ******\n\n");
            foreach (Llamada item in this.Llamadas)
            {
                sb.Append($"{item.ToString()}\n");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            this.listaDeLlamadas.Add(nuevaLlamada);
        }

        public bool Guardar()
        {
            bool retorno = false;
            double costo;
            double duracion;
            string origen;
            string destino;

            foreach (Llamada item in this.Llamadas)
            {
                costo = item.CostoLlamada;
                duracion = item.Duracion;
                destino = item.NroDestino;
                origen = item.NroOrigen;
        
                if(costo > 0 && duracion > 0 && destino != String.Empty && origen != String.Empty)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }

            return retorno;
        }

        public string Leer()
        {
            throw new NotImplementedException();
        }

        //Sobrecargas
        public static Centralita operator +(Centralita c1, Llamada l1)
        {
            if (c1 != l1)
            {
                c1.AgregarLlamada(l1);
            }
            else
            {
                throw new CentralitaException(
                    "Error, ya se encuentra la llamada en la centralita",
                    "Centralita",
                    "Sobrecarga del operador +"
                    );
            }

            return c1;
        }

        public static bool operator ==(Centralita c1, Llamada l1)
        {
            foreach (Llamada item in c1.listaDeLlamadas)
            {
                if (l1 == item)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Centralita c1, Llamada l1)
        {
            return !(c1 == l1);
        }
    }
}
