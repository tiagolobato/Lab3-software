using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Media;
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
        int beepDistancia = 0;
        int descendo = 0;
        int passouLimiteSensor = 0;
        int controleManualLigado = 0;
        int guindasteLigado = 0;
        int sinalControleManual = 0;
        SoundPlayer beepLento1 = new SoundPlayer(@"C:\SonsVS\guindaste\beepLento1.wav");
        SoundPlayer beepLento2 = new SoundPlayer(@"C:\SonsVS\guindaste\beepLento2.wav");
        SoundPlayer beepMedio = new SoundPlayer(@"C:\SonsVS\guindaste\beepMedio1.wav");
        SoundPlayer beepRapido1 = new SoundPlayer(@"C:\SonsVS\guindaste\beepRapido1.wav");
        SoundPlayer beepRapido2 = new SoundPlayer(@"C:\SonsVS\guindaste\beepRapido2.wav");
        SoundPlayer beepFatal = new SoundPlayer(@"C:\SonsVS\guindaste\beepFatal.wav");

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
            byte[] saida = new byte[2];
            saida[0] = 3;
            
            if (serialPort1.IsOpen)
            {
                saida[1] = 0;
                pictureBoxGuindaste.Image = Properties.Resources.guindaste_desligado;
                serialPort1.Write(saida, 0, 2);
                serialPort1.Close();
                pctBoxGuindaste.BackColor = Color.Red;
                lblBoxGuindaste.Text = "OFF";
                btnLigarGuindaste.Text = "Ligar Guindaste";

                pictureBox1.BackColor = Color.SeaShell;
                pictureBox2.BackColor = Color.SeaShell;
                pictureBox3.BackColor = Color.SeaShell;
                pictureBox4.BackColor = Color.SeaShell;
                pictureBox5.BackColor = Color.SeaShell;
                pictureBox6.BackColor = Color.SeaShell;
                guindasteLigado = 0;
                controleManualLigado = 0;
                pctBoxControle.BackColor = Color.Red;
                lblControle.Text = "OFF";
                btnControleManual.Text = "Habilitar Controle Manual";
                beepMedio.Stop();
                beepLento1.Stop();
                beepLento2.Stop();
                beepFatal.Stop();
                beepRapido1.Stop();
                beepRapido2.Stop();
                descendo = 0;
                passouLimiteSensor = 0;
            }
            else
            {
                saida[1] = 1;
                pictureBoxGuindaste.Image = Properties.Resources.guindaste_ligado;
                serialPort1.Open();
                serialPort1.Write(saida, 0, 2);
                pctBoxGuindaste.BackColor = Color.Lime;
                lblBoxGuindaste.Text = "ON";
                btnLigarGuindaste.Text = "Desligar Guindaste";
                guindasteLigado = 1;
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
            if (alturaReferencia + alturaInt > 40 || alturaReferencia + alturaInt < 0)
            {
                MessageBox.Show("Angulo fora do limite",
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
                sinalControleManual = 0;
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
                sinalControleManual = 0;
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
                this.Invoke(new EventHandler(atualizarTextBoxAnguloNegativo));
            }
            if (saida[0] == 5)
            {
                this.Invoke(new EventHandler(atualizarTextBoxAltura));
            }
            if (saida[0] == 6)
            {
                
                this.Invoke(new EventHandler(atualizarAlturaAnguloLimite));
            }
            if (saida[0] == 7)
            {

                this.Invoke(new EventHandler(atualizarTextBoxAngulo));
            }




        }
        private void atualizarTextBoxDistancia(object sender, EventArgs e)
        {
            textBoxDistancia.Text = s;
            if (descendo == 1 && passouLimiteSensor == 0)
            {
                if (Int32.Parse(s) < 4)
                {
                    if (beepDistancia == 4) return;
                    beepFatal.Play();
                    beepDistancia = 4;
                    pictureBox1.BackColor = Color.Red;
                    pictureBox2.BackColor = Color.Red;
                    pictureBox3.BackColor = Color.Gold;
                    pictureBox4.BackColor = Color.Yellow;
                    pictureBox5.BackColor = Color.LimeGreen;
                    pictureBox6.BackColor = Color.Green;
                    passouLimiteSensor = 1;
                    //pictureBoxGuindaste.Image = Properties.Resources.guindastecrash1;
                }
                else if (Int32.Parse(s) < 6)
                {
                    if (beepDistancia == 6) return;
                    beepRapido2.Play();
                    beepDistancia = 6;
                    pictureBox1.BackColor = Color.SeaShell;
                    pictureBox2.BackColor = Color.Red;
                    pictureBox3.BackColor = Color.Gold;
                    pictureBox4.BackColor = Color.Yellow;
                    pictureBox5.BackColor = Color.LimeGreen;
                    pictureBox6.BackColor = Color.Green;
                    passouLimiteSensor = 0;
                }
                else if (Int32.Parse(s) < 8)
                {
                    if (beepDistancia == 8) return;
                    beepDistancia = 8;
                    beepRapido1.Play();
                    pictureBox1.BackColor = Color.SeaShell;
                    pictureBox2.BackColor = Color.SeaShell;
                    pictureBox3.BackColor = Color.Yellow;
                    pictureBox4.BackColor = Color.Gold;
                    pictureBox5.BackColor = Color.LimeGreen;
                    pictureBox6.BackColor = Color.Green;
                    passouLimiteSensor = 0;
                }
                else if (Int32.Parse(s) < 10)
                {
                    if (beepDistancia == 10) return;
                    beepDistancia = 10;
                    beepMedio.Play();
                    pictureBox1.BackColor = Color.SeaShell;
                    pictureBox2.BackColor = Color.SeaShell;
                    pictureBox3.BackColor = Color.SeaShell;
                    pictureBox4.BackColor = Color.Gold;
                    pictureBox5.BackColor = Color.LimeGreen;
                    pictureBox6.BackColor = Color.Green;

                }
                else if (Int32.Parse(s) < 12)
                {
                    if (beepDistancia == 12) return;
                    beepDistancia = 12;
                    beepLento2.Play();
                    pictureBox1.BackColor = Color.SeaShell;
                    pictureBox2.BackColor = Color.SeaShell;
                    pictureBox3.BackColor = Color.SeaShell;
                    pictureBox4.BackColor = Color.SeaShell;
                    pictureBox5.BackColor = Color.LimeGreen;
                    pictureBox6.BackColor = Color.Green;


                }
                else
                {
                    if (beepDistancia == 11) return;
                    beepDistancia = 11;
                    pictureBox1.BackColor = Color.SeaShell;
                    pictureBox2.BackColor = Color.SeaShell;
                    pictureBox3.BackColor = Color.SeaShell;
                    pictureBox4.BackColor = Color.SeaShell;
                    pictureBox5.BackColor = Color.SeaShell;
                    pictureBox6.BackColor = Color.Green;


                }
            }
            
            
            

            
        }
        private void atualizarTextBoxAngulo(object sender, EventArgs e)
        {
            anguloReferencia = Int32.Parse(s);
            textBoxAngulo.Text = anguloReferencia.ToString();
            if(sinalControleManual == 0)
            {
                pictureBoxGuindaste.Image = Properties.Resources.guindaste_ligado;
            }
            else
            {
                pictureBoxGuindaste.Image = Properties.Resources.controle__manual;
            }
        }
        private void atualizarTextBoxAnguloNegativo(object sender, EventArgs e)
        {
            anguloReferencia = -(Int32.Parse(s));
            textBoxAngulo.Text = anguloReferencia.ToString();
            if (sinalControleManual == 0)
            {
                pictureBoxGuindaste.Image = Properties.Resources.guindaste_ligado;
            }
            else
            {
                pictureBoxGuindaste.Image = Properties.Resources.controle__manual;
            }
        }
        private void atualizarTextBoxAltura(object sender, EventArgs e)
        {
            alturaReferencia = Int32.Parse(s);
            textBoxAltura.Text = s;
            if (sinalControleManual == 0)
            {
                pictureBoxGuindaste.Image = Properties.Resources.guindaste_ligado;
            }
            else
            {
                pictureBoxGuindaste.Image = Properties.Resources.controle__manual;
            }
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
        private void atualizarAlturaAnguloLimite(object sender, EventArgs e)
        {
            if (s.Equals("1"))
            {
                MessageBox.Show("Altura fora do limite",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Angulo fora do limite",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

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

    

        private void btnResetar_Click(object sender, EventArgs e)
        {
            byte[] saida = new byte[2];
            
            saida[0] = 7;
            saida[1] = 0;
            descendo = 0;
            passouLimiteSensor = 0;
            pictureBox1.BackColor = Color.SeaShell;
            pictureBox2.BackColor = Color.SeaShell;
            pictureBox3.BackColor = Color.SeaShell;
            pictureBox4.BackColor = Color.SeaShell;
            pictureBox5.BackColor = Color.SeaShell;
            pictureBox6.BackColor = Color.SeaShell;
            beepMedio.Stop();
            beepLento1.Stop();
            beepLento2.Stop();
            beepFatal.Stop();
            beepRapido1.Stop();
            beepRapido2.Stop();

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

        private void btnAutomatico_Click(object sender, EventArgs e)
        {
            byte[] saida = new byte[2];
            saida[0] = 7;
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

        private void btnArrowUp_MouseDown(object sender, MouseEventArgs e)
        {
            if(controleManualLigado == 0)
            {
                MessageBox.Show("Ligue o controle manual",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
            byte[] saida = new byte[2];
            saida[0] = 6;
            saida[1] = 1;
            pictureBox1.BackColor = Color.SeaShell;
            pictureBox2.BackColor = Color.SeaShell;
            pictureBox3.BackColor = Color.SeaShell;
            pictureBox4.BackColor = Color.SeaShell;
            pictureBox5.BackColor = Color.SeaShell;
            pictureBox6.BackColor = Color.SeaShell;
            beepMedio.Stop();
            beepLento1.Stop();
            beepLento2.Stop();
            beepFatal.Stop();
            beepRapido1.Stop();
            beepRapido2.Stop();
            descendo = 0;
            passouLimiteSensor = 0;

            try
            {
                serialPort1.Write(saida, 0, 2);
                sinalControleManual = 1;
                pictureBoxGuindaste.Image = Properties.Resources.subindo_ima;
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
        private void btnArrowRigth_MouseDown(object sender, MouseEventArgs e)
        {
            if (controleManualLigado == 0)
            {
                MessageBox.Show("Ligue o controle manual",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
            byte[] saida = new byte[2];
            saida[0] = 6;
            saida[1] = 2;
            try
            {
                serialPort1.Write(saida, 0, 2);
                sinalControleManual = 1;
                pictureBoxGuindaste.Image = Properties.Resources.girando_horario;
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
        private void btnArrowRigth_MouseUp(object sender, MouseEventArgs e)
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

       

        private void btnArrowDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (controleManualLigado == 0)
            {
                MessageBox.Show("Ligue o controle manual",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
            byte[] saida = new byte[2];
            saida[0] = 6;
            saida[1] = 3;
            descendo = 1;
            try
            {
                serialPort1.Write(saida, 0, 2);
                sinalControleManual = 1;
                pictureBoxGuindaste.Image = Properties.Resources.descendo_ima;
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

        private void btnArrowDown_MouseUp(object sender, MouseEventArgs e)
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

        private void btnArrowLeft_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (controleManualLigado == 0)
            {
                MessageBox.Show("Ligue o controle manual",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
            byte[] saida = new byte[2];
            saida[0] = 6;
            saida[1] = 4;
            try
            {
                serialPort1.Write(saida, 0, 2);
                sinalControleManual = 1;
                pictureBoxGuindaste.Image = Properties.Resources.girando_antihorario;
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

        private void btnArrowLeft_MouseUp(object sender, MouseEventArgs e)
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

        private void btnControleManual_Click(object sender, EventArgs e)
        {
            if(guindasteLigado ==0)
            {
                MessageBox.Show("Ligue o guindaste",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
            if (controleManualLigado == 0)
            {
                pictureBoxGuindaste.Image = Properties.Resources.controle__manual;
                controleManualLigado = 1;
                pctBoxControle.BackColor = Color.Lime;
                lblControle.Text = "ON";
                btnControleManual.Text = "Desligar Controle Manual";
            }
            else if (controleManualLigado == 1)
            {
                pictureBoxGuindaste.Image = Properties.Resources.guindaste_ligado;
                controleManualLigado = 0;
                pctBoxControle.BackColor = Color.Red;
                lblControle.Text = "OFF";
                btnControleManual.Text = "Habilitar Controle Manual";
                pictureBox1.BackColor = Color.SeaShell;
                pictureBox2.BackColor = Color.SeaShell;
                pictureBox3.BackColor = Color.SeaShell;
                pictureBox4.BackColor = Color.SeaShell;
                pictureBox5.BackColor = Color.SeaShell;
                pictureBox6.BackColor = Color.SeaShell;
                beepMedio.Stop();
                beepLento1.Stop();
                beepLento2.Stop();
                beepFatal.Stop();
                beepRapido1.Stop();
                beepRapido2.Stop();
                descendo = 0;
                passouLimiteSensor = 0;
            }
        }

        private void btnMapear_Click(object sender, EventArgs e)
        {
            byte[] saida = new byte[2];
            saida[0] = 7;
            saida[1] = 2;

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

        private void pictureBoxGuindaste_Click(object sender, EventArgs e)
        {

        }
    }
}
