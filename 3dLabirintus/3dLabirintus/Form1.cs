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

        static Panel latoter;
        static Label terkep;

        static int i = 0, j = 0;

        static char[,] palya;
        static int palyaSzelesseg = 8, palyaMagassag = 8;
        private static int jatekosLatoMezo = 5;
        private static Pont jatekosHely;
        private static Pont fal0Hely;
        static Panel fal0;
        private static bool jatekMegyE = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "3D Labirintus";

            palya = new char[palyaMagassag, palyaSzelesseg];
            palyaFeltoltese(palyaMagassag, palyaSzelesseg);

            latoter = new Panel();
            latoter.Width = Width;
            latoter.Height = Height;

            terkep = new Label();

            Controls.Add(latoter);
            latoter.Controls.Add(terkep);

            jatekInditas();

            KeyDown += new KeyEventHandler(billentyuLenyomas);

        }

        private void billentyuLenyomas(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.M:
                if (terkep.Visible)
                {
                    terkep.Visible = false;
                }
                else
                {
                    terkep.Visible = true;
                }
                    break;

                case Keys.D:
                    if (jatekMegyE && jatekosHely.getX() < 7)
                    {
                        jatekosJobbra();
                    }
                    break;

                case Keys.A:
                    if (jatekMegyE && jatekosHely.getX() > 0)
                    {
                        jatekosBalra();
                    }
                    break;

            }
        }

        private static void jatekosBalra()
        {
            setMezoPalya(jatekosHely, '_');
            jatekosHely.setX(jatekosHely.getX() - 1);
            abrazolas();
        }

        private static void jatekosJobbra()
        {
            setMezoPalya(jatekosHely, '_');
            jatekosHely.setX(jatekosHely.getX() + 1);
            abrazolas();
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

        private static void setMezoPalya(Pont hely, char objektum)
        {
            palya[hely.getY(), hely.getX()] = objektum;
            //terkep.Text = palyaRajzolasa(palyaMagassag, palyaSzelesseg);
        }

        private void palyaUresFeltoltese(int palyaMagassag, int palyaSzelesseg)
        {
            for (i = 0; i < palyaMagassag; i++)
            {
                for (j = 0; j < palyaSzelesseg; j++)
                {
                    palya[i, j] = '_';
                }
            }

        }

        private static void jatekInditas()
        {
            jatekMegyE = true;

            latoter.BackColor = Color.FromArgb(100, 135, 206, 255);
            latoter.Dock = DockStyle.Fill;

            terkep.Width = 80;
            terkep.Height = 120;


            jatekosHely = new Pont(3, 3);
            fal0Hely = new Pont(2, 1);
            fal0 = new Panel();
            latoter.Controls.Add(fal0);
            fal0.BackColor = Color.Gray;
            abrazolas();


            // hatter.Paint += new PaintEventHandler(vonalRajzolasa);
        }

        private static void abrazolas()
        {
            setMezoPalya(jatekosHely, 'P');
            setMezoPalya(fal0Hely, '#');

            terkep.Text = palyaRajzolasa();

            fal0.Width = latoter.Width / jatekosLatoMezo;
            fal0.Left = latoter.Width / 2 - fal0.Width / 2 + latoter.Width / jatekosLatoMezo *
                (fal0Hely.getX() - jatekosHely.getX());
            fal0.Top = latoter.Height - fal0.Height;
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
