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
        public Form1()
        {
            InitializeComponent();
            serialPort1 = new SerialPort();
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;
            serialPort1.DataReceived += DataReceivedHandler;
            btnArrowUp.Text = char.ConvertFromUtf32(0x2191);
            btnArrowDown.Text = char.ConvertFromUtf32(0x2193);
            btnArrowLeft.Text = char.ConvertFromUtf32(0x2190);
            btnArrowRigth.Text = char.ConvertFromUtf32(0x2192);
        }

        private void btnLigarGuindaste_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
        }

        private void btnLigarIma_Click(object sender, EventArgs e)
        {
            serialPort1.Write(contador.ToString());
            
        }

        private void btnEnviarAltura_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviarAngulo_Click(object sender, EventArgs e)
        {

        }
        private void Text_Out(string sData)
        {
            textBoxDistancia.Text = sData;
        }
        string s;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            s = serialPort1.ReadExisting();              //le o dado disponível na serial
            this.Invoke(new EventHandler(trataDadoRecebido));   //chama outra thread para escrever o dado no text box
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort comm = (SerialPort)sender;
            s = comm.ReadExisting();              //le o dado disponível na serial
            this.Invoke(new EventHandler(trataDadoRecebido));   //chama outra thread para escrever o dado no text box
            
        }
        private void trataDadoRecebido(object sender, EventArgs e)
        {
            textBoxDistancia.Text = s;
            serialPort1.Write(contador.ToString());
            contador = contador + 1;
        }
    }
}
