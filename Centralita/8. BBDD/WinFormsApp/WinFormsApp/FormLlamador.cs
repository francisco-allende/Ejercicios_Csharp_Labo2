using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        //Este metodo q tanto me costo por la boludez del acceso al metodo guardar
        //se debe a que para acceder a los metodos de una interfaz, debo crear una nueva interfaz
        //De dicho objeto para acceder
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
