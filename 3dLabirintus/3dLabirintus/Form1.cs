using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3dLabirintus
{
    public partial class Form1 : Form
    {

        static Panel hatter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "3D Labirintus";

            jatekInditas();
            Controls.Add(hatter);

        }

        private static void jatekInditas()
        {
            hatter = new Panel();
            hatter.BackColor = Color.FromArgb(100, 135, 206, 255);
            hatter.Dock = DockStyle.Fill;

            /*Pen ceruza = new Pen(Color.Black, 20);
            Graphics grafika = hatter.CreateGraphics();

            grafika.DrawLine(ceruza, 25, 52, 32, 42);*/
        }

        public static double tavolsagSzamitasa(Pont elsoPont, Pont masodikPont)
        {
            return Math.Sqrt(Math.Pow((elsoPont.getX() - masodikPont.getX()), 2) 
                + Math.Pow((elsoPont.getY() - masodikPont.getY()), 2));
        }

    }
}
