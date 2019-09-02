using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
namespace WebApplication1
{
    public partial class _Default : Page
    {
        SerialPort ardo;
        protected void Page_Load(object sender, EventArgs e)
        {
            ardo = new SerialPort();
            ardo.PortName = "COM4";
            ardo.BaudRate = 9600;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string blue = "1";
            ardo.Open();
            ardo.Write(blue);
            ardo.Close();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ardo.Open();

            ardo.Close();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            ardo.Open();

            ardo.Close();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            ardo.Open();
            ardo.Write("2");
            ardo.Close();
        }
        protected void teste2(object sender, EventArgs e)
        {
            ardo.Open();
            ardo.Write("2");
            ardo.Close();
        }
        protected void teste(object sender, EventArgs e)
        {
            ardo.Open();
            ardo.Write("2");
            ardo.Close();
        }
      


        private void Button1_MouseUp(object sender, MouseEventArgs e)
        {
            string blue = "2";
            ardo.Open();
            ardo.Write(blue);
            ardo.Close();
        }

        private void Button1_MouseDown(object sender, MouseEventArgs e)
        {
            string blue = "1";
            ardo.Open();
            ardo.Write(blue);
            ardo.Close();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {

        }
    }
}