using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        int contador = 10;
        public delegate void myDelegate(string sData);
        SerialPort serialPort1;
        int anguloReferencia = 0;
        int alturaReferencia = 0;
        int imaDesligado = 1;
        int mensagemErroTrue = 0;
        public Form1()
        {
            InitializeComponent();
            serialPort1 = new SerialPort();
            serialPort1.PortName = "COM8";
            serialPort1.BaudRate = 9600;
            serialPort1.DataReceived += DataReceivedHandler;
            btnArrowUp.Text = char.ConvertFromUtf32(0x2191);
            btnArrowDown.Text = char.ConvertFromUtf32(0x2193);
            btnArrowLeft.Text = char.ConvertFromUtf32(0x2190);
            btnArrowRigth.Text = char.ConvertFromUtf32(0x2192);
            textBoxAltura.Text = "0";
            textBoxAngulo.Text = "0";
            textBoxDistancia.Text = "0";

        }

        private void btnLigarGuindaste_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                pctBoxGuindasteImagem.Image = Properties.Resources.guindaste2;
                serialPort1.Close();
                pctBoxGuindaste.BackColor = Color.Red;
                lblBoxGuindaste.Text = "OFF";
                btnLigarGuindaste.Text = "Ligar Guindaste";
            }
            else
            {
                pctBoxGuindasteImagem.Image = Properties.Resources.guindaste1;
                serialPort1.Open();
                pctBoxGuindaste.BackColor = Color.Lime;
                lblBoxGuindaste.Text = "ON";
                btnLigarGuindaste.Text = "Desligar Guindaste";
            }
            
        }


        private void btnEnviarAltura_Click(object sender, EventArgs e)
        {
            int alturaInt = 0;
            bool alturaNegativo = false;
            try
            {
                alturaInt = Int32.Parse(textBoxAlturaIn.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Altura precisa ser numérico",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
            if (alturaInt < 0)
            {
                alturaNegativo = true;
                alturaInt = -alturaInt;
            }
            byte[] saida = new byte[2];
            if (alturaNegativo)
            {
                saida[0] = 5;
                saida[1] = (byte)alturaInt;
            }
            else
            {
                saida[0] = 1;
                saida[1] = (byte)alturaInt;
            }
            try
            {
                serialPort1.Write(saida, 0, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ligue o guindaste",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
            
        }

        private void btnEnviarAngulo_Click(object sender, EventArgs e)
        {
            int anguloInt = 0;
            bool anguloNegativo = false;
            try
            {
                anguloInt = Int32.Parse(textBoxAnguloIn.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Angulo precisa ser numérico",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
            if(anguloReferencia + anguloInt > 180 || anguloReferencia + anguloInt < -180)
            {
                MessageBox.Show("Angulo fora do limite",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);

                return;
            }
            if (anguloInt < 0)
            {
                anguloNegativo = true;
                anguloInt = -anguloInt;
            }
            byte[] saida = new byte[2];
            if (anguloNegativo)
            {
                saida[0] = 4;
                saida[1] = (byte)anguloInt;
            }
            else
            {
                saida[0] = 0;
                saida[1] = (byte)anguloInt;
            }
            try
            {
                serialPort1.Write(saida, 0, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ligue o guindaste",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
        }
   
        string s;
 
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort comm = (SerialPort)sender;
            byte[] saida = new byte[2];
            
            saida[0] = (byte)comm.ReadByte();
            saida[1] = (byte)comm.ReadByte();
            s = saida[1].ToString();
            if (saida[0] == 0)
            {
                this.Invoke(new EventHandler(atualizarTextBoxAngulo));
            }
            if (saida[0] == 1)
            {
                this.Invoke(new EventHandler(atualizarTextBoxAltura));
            }
            if (saida[0] == 2)
            {
                this.Invoke(new EventHandler(atualizarIma));
            }
            if (saida[0] == 3)
            {
                this.Invoke(new EventHandler(atualizarTextBoxDistancia));
            }
            if (saida[0] == 4)
            {
                int sNegativo = -(Int32.Parse(s));
                s = sNegativo.ToString();
                this.Invoke(new EventHandler(atualizarTextBoxAngulo));
            }
            if (saida[0] == 5)
            {
                int sNegativo = -(Int32.Parse(s));
                s = sNegativo.ToString();
                this.Invoke(new EventHandler(atualizarTextBoxAltura));
            }
            if (saida[0] == 6)
            {
                
                this.Invoke(new EventHandler(atualizarTextBoxAngulo));
            }




        }
        private void atualizarTextBoxDistancia(object sender, EventArgs e)
        {
            textBoxDistancia.Text = s;
        }
        private void atualizarTextBoxAngulo(object sender, EventArgs e)
        {
            anguloReferencia = Int32.Parse(s);
            textBoxAngulo.Text = anguloReferencia.ToString();
        }
        private void atualizarTextBoxAltura(object sender, EventArgs e)
        {
            alturaReferencia = alturaReferencia + Int32.Parse(s);
            textBoxAltura.Text = s;
        }
        private void atualizarIma(object sender, EventArgs e)
        {
            if (Int32.Parse(s) == 0)
            {
                imaDesligado = 0;
                pctBoxIma.BackColor = Color.Lime;
                lblBoxIma.Text = "ON";
                btnLigarIma.Text = "Desliga Ima";
            }
            if (Int32.Parse(s) == 1)
            {
                imaDesligado = 1;
                pctBoxIma.BackColor = Color.Red;
                lblBoxIma.Text = "OFF";
                btnLigarIma.Text = "Ligar Ima";
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnArrowUp_MouseDown(object sender, MouseEventArgs e)
        {
            byte[] saida = new byte[2];
            saida[0] = 6;
            saida[1] = 1;
            try
            {
                serialPort1.Write(saida, 0, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ligue o guindaste",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnLigarDesligarIma_Click(object sender, EventArgs e)
        {
            byte[] saida = new byte[2];
            saida[0] = 2;
            saida[1] = (byte)imaDesligado;
            if (anguloReferencia > 180 || anguloReferencia < -180)
            {
                MessageBox.Show("Angulo fora do limite",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);

                return;
            }
            try
            {
                serialPort1.Write(saida, 0, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ligue o guindaste",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnArrowUp_MouseUp(object sender, MouseEventArgs e)
        {
            byte[] saida = new byte[2];
            saida[0] = 6;
            saida[1] = 0;
            try
            {
                serialPort1.Write(saida, 0, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ligue o guindaste",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            byte[] saida = new byte[2];
            
            saida[0] = 7;
            saida[1] = 0;
            

            try
            {
                serialPort1.Write(saida, 0, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ligue o guindaste",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
        }
    }
}
