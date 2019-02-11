using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanulas3D.Model;

namespace Tanulas3D
{
    public partial class Form1 : Form
    {
        Alakzat kocka;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vaszon.BackColor = Color.White;

            elokeszuletek();

        }

        private void elokeszuletek()
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vaszon_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
