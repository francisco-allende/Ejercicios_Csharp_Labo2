using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblio;
using EntidadesDAO;


namespace WinFormsApp
{
    public partial class FormLlamador : Form
    {
        private Centralita centralita;
        private bool isNewCall;

        public FormLlamador(Centralita centralita)
        {
            InitializeComponent();
            this.centralita = centralita;
            this.isNewCall = true;
        }

        public Centralita Centralita { get => this.centralita; }

        private void FormLlamador_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            // Carga enums al cmb
            cmbBox_Franja.Enabled = true;
            cmbBox_Franja.DataSource = Enum.GetValues(typeof(Franja));
        }

        private void btn_Num1_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("1");
        }

        private void btn_Num2_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("2");
        }

        private void btn_Num3_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("3");
        }

        private void btn_Num4_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("4");
        }

        private void btn_Num5_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("5");
        }

        private void btn_Num6_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("6");
        }

        private void btn_Num7_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("7");
        }

        private void btn_Num8_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("8");
        }

        private void btn_Num9_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("9");
        }

        private void btn_NumAsterisco_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("*");
        }

        private void btn_Num0_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("0");
        }

        private void btn_NumNumeral_Click(object sender, EventArgs e)
        {
            this.PrintCaracter("#");
        }

        private void btnLlamar_Click(object sender, EventArgs e)
        {
            try
            {
                this.GenerateCall();
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (CentralitaException ex)
            {
                string msj = $"{ex.Message} ocurrido en la clase {ex.NombreClase} en el metodo {ex.NombreMetodo}";
                MessageBox.Show(msj);
            }
            catch(FallaLogException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Leer lo que anote para este metodo automatic.
        //El evento no es asyn porque dentro de automatic llamo a metodos async
        //(por ende, generate automatic call es tambien async)
        private void btn_AutomaticCall_Click(object sender, EventArgs e)
        {
            try
            {
                this.GenerateAutomaticCall();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado");
            }
        }

        //Metodos
        private void Serialize(string tipo)
        {
            if(tipo == "Prov")
            {
                List<Provincial> listaProv = new List<Provincial>();

                foreach (Llamada item in this.centralita.Llamadas)
                {
                    if(item is Provincial)
                    {
                        listaProv.Add(item as Provincial);
                    }
                }
                if (listaProv.Count > 0)
                {
                    Provincial p = new Provincial();
                    p.Guardar(listaProv);
                }
            }
            else if(tipo == "Local")
            {
                List<Local> listaLocal = new List<Local>();

                foreach (Llamada item in this.centralita.Llamadas)
                {
                    if (item is Local)
                    {
                        listaLocal.Add(item as Local);

                    }
                }
                if(listaLocal.Count > 0)
                {
                    Local l = new Local();
                    l.Guardar(listaLocal);
                }
            }
        }

        private void PrintCaracter(string character)
        {
            if(isNewCall)
            {
                this.txtBox_NroDestino.Text = "";
                this.isNewCall = false;
                if(character == "#")
                {
                    this.cmbBox_Franja.Enabled = true;
                }
                else
                {
                    this.cmbBox_Franja.Enabled = false;
                }
            }
            
            this.txtBox_NroDestino.Text += character;
        }

        private void SaveInDDBB(Provincial prov)
        {
            ProvincialDAO.Guardar(prov);  
        }

        private void SaveInDDBB(Local local)
        {
            LocalDAO.Guardar(local);
        }

        private async Task<Provincial> GenerateAutomaticProvinceCall()
        {
            Provincial prov = await Task.Run(() =>
            {
                Random rand = new Random();
                int tiempo = rand.Next(0, 11);
                tiempo = tiempo * 1000;
                Thread.Sleep(tiempo);
                float duracion = rand.Next(1, 51);
                string nroOrigen = String.Empty;
                string nroDestino = String.Empty;
                nroDestino += "#";

                Franja franjaHoraria;
                int tipoFranja = rand.Next(1, 4);

                switch (tipoFranja)
                {
                    case 1:
                        franjaHoraria = Franja.Franja_1;
                        break;

                    case 2:
                        franjaHoraria = Franja.Franja_2;
                        break;

                    case 3:
                        franjaHoraria = Franja.Franja_3;
                        break;

                    default:
                        franjaHoraria = Franja.Franja_1;
                        break;
                }

                for (int i = 0; i <= 8; i++)
                {
                    nroDestino += rand.Next(0, 10).ToString();
                    nroOrigen += rand.Next(0, 10).ToString();
                }

                Provincial prov = new Provincial(nroOrigen, franjaHoraria, duracion, nroDestino);
          
                return prov;
            });

            return prov;
        }

        private async Task<Local> GenerateAutomaticLocalCall()
        {
            Local local = await Task.Run(() =>
            {

                Random rand = new Random();
                int tiempo = rand.Next(0, 11);
                tiempo = tiempo * 1000;
                Thread.Sleep(tiempo);
                float duracion = rand.Next(1, 51);
                string nroOrigen = String.Empty;
                string nroDestino = String.Empty;
                float costo;
                float randomFloat = (float)rand.NextDouble();
                while (randomFloat > 0.57 || randomFloat < 0.05)
                {
                    randomFloat = (float)rand.NextDouble();
                }
                costo = randomFloat * 10;

                for (int i = 0; i <= 8; i++)
                {
                    nroDestino += rand.Next(0, 10).ToString();
                    nroOrigen += rand.Next(0, 10).ToString();
                }

                Local local = new Local(nroOrigen, duracion, nroDestino, costo);
         
                return local;
            });

            return local;
        }

        /*
         *  Es async por que llama a tasks que se realizan en otro hilo, por ende, 
         *  uso async para este metodo, y await cuando los espero a las tasks. 
         *  Cada uno hace lo mismo, pero uno para local y otro prov. Creo el objeto
         *  en un hilo secundario, por eso me lo retorna "2 veces" 
         *  (uno para el obj de esa task, otro para el metodo posta que lo retorna)
         *  No conviene que retorne void. Se puede hacer. Minimo un bool o algo de q salio ok
         *  No puedo modificar controles del form en las task secundaria que abri
         *  El sleep tambien dentro, sino cuelga el form y pierde todo el sentido
         *  Esto anda barbaro. Las hace re bien, no cuelga nada, puedo llamar manual a la vez
         *  Y si me salgo no pasa una
         *  Si bien tiene mas sentido serialziar y cargar a la bbdd en la task, queria usar el obj
         *  retornado para algo. 
         */
        private async void GenerateAutomaticCall()
        {
            Random rand = new Random();
            try
            {
                if (rand.Next(0, 2) == 1)
                {
                   Provincial prov = await this.GenerateAutomaticProvinceCall();
                    this.centralita += prov;
                    this.Serialize("Prov");
                    this.SaveInDDBB(prov);
                }
                else
                {
                    Local local = await this.GenerateAutomaticLocalCall();
                    this.centralita += local;
                    this.Serialize("Local");
                    this.SaveInDDBB(local);
                }

                this.GenerateAutomaticCall();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GenerateCall()
        {
            string destino = this.txtBox_NroDestino.Text;
            Random rand = new Random();
            float duracion = rand.Next(1, 51);
            string origen = "";
            
            while(!Int32.TryParse(this.txtBoxNroOrigen.Text, out int num))
            {
                throw new FormatException("Solo se aceptan numeros");
            }

            origen = this.txtBoxNroOrigen.Text;

            try
            {
                if (destino.StartsWith("#"))
                {
                    // Lectura
                    Franja franjaHoraria;
                    Enum.TryParse<Franja>(cmbBox_Franja.SelectedValue.ToString(), out franjaHoraria);

                    Provincial llamadaProv = new Provincial(origen, franjaHoraria, duracion, destino);
                    this.centralita += llamadaProv;
                    this.Serialize("Prov");
                    this.SaveInDDBB(llamadaProv);
                    
                }
                else
                {
                    float costo;
                    float randomFloat = (float)rand.NextDouble();
                    while (randomFloat > 0.57 || randomFloat < 0.05)
                    {
                        randomFloat = (float)rand.NextDouble();
                    }
                    costo = randomFloat * 10;

                    Local llamadoLocal = new Local(origen, duracion, destino, costo);
                    this.centralita += llamadoLocal;
                    this.Serialize("Local");
                    this.SaveInDDBB(llamadoLocal);
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
            
            this.Limpiar();
        }

        private void Limpiar()
        {
            try
            {
                this.txtBoxNroOrigen.Text = String.Empty;
                this.txtBox_NroDestino.Text = String.Empty;
                if (this.cmbBox_Franja.Enabled)
                {
                    this.cmbBox_Franja.SelectedIndex = 0;
                }

                this.isNewCall = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
