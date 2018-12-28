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
        static Label terkep;

        static int i = 0, j = 0;

        static char[,] palya;
        static int palyaSzelesseg = 8, palyaMagassag = 8;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "3D Labirintus";

            palya = new char[palyaMagassag, palyaSzelesseg];
            palyaFeltoltese(palyaMagassag, palyaSzelesseg);

            hatter = new Panel();
            terkep = new Label();

            jatekInditas();
            Controls.Add(hatter);
            hatter.Controls.Add(terkep);

            KeyDown += new KeyEventHandler(billentyuLenyomas);

        }

        private void billentyuLenyomas(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.M)
            {
                if (terkep.Visible)
                {
                    terkep.Visible = false;
                }
                else
                {
                    terkep.Visible = true;
                }
            }
        }

        private void palyaFeltoltese(int palyaMagassag, int palyaSzelesseg)
        {
            palyaUresFeltoltese(palyaMagassag, palyaSzelesseg);
            palyaRajzolasa(palyaMagassag, palyaSzelesseg);
        }

        private static string palyaRajzolasa(int palyaMagassag, int palyaSzelesseg)
        {
            string szoveg = "";

            for (i = 0; i < palyaMagassag; i++)
            {
                for (j = 0; j < palyaSzelesseg; j++)
                {
                    szoveg += palya[i, j];
                }
                szoveg += '\n';
            }

            return szoveg;

        }

        private static string palyaRajzolasa()
        {
            string szoveg = "";

            for (i = 0; i < palyaMagassag; i++)
            {
                for (j = 0; j < palyaSzelesseg; j++)
                {
                    szoveg += palya[i, j];
                }
                szoveg += '\n';
            }

            return szoveg;

        }

        private void palyaUresFeltoltese(int palyaMagassag, int palyaSzelesseg)
        {
            for (i = 0; i < palyaMagassag; i++)
            {
                for (j = 0; j < palyaSzelesseg; j++)
                {
                    palya[i, j] = '-';
                }
            }

        }

        private static void jatekInditas()
        {
            hatter.BackColor = Color.FromArgb(100, 135, 206, 255);
            hatter.Dock = DockStyle.Fill;

            terkep.Width = 100;
            terkep.Height = 100;
            terkep.Text = palyaRajzolasa();

           // hatter.Paint += new PaintEventHandler(vonalRajzolasa);
        }

        /*private static void vonalRajzolasa(object sender, PaintEventArgs e)
        {
            Pen blackpen = new Pen(Color.Black, 1);

            Graphics g = e.Graphics;

            g.DrawLine(blackpen, 0, 0, 200, 300);
        }*/

        public static double tavolsagSzamitasa(Pont elsoPont, Pont masodikPont)
        {
            return Math.Sqrt(Math.Pow((elsoPont.getX() - masodikPont.getX()), 2) 
                + Math.Pow((elsoPont.getY() - masodikPont.getY()), 2));
        }

    }
}
