using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnArrowUp.Text = char.ConvertFromUtf32(0x2191);
            btnArrowDown.Text = char.ConvertFromUtf32(0x2193);
            btnArrowLeft.Text = char.ConvertFromUtf32(0x2190);
            btnArrowRigth.Text = char.ConvertFromUtf32(0x2192);
        }
    }
}
