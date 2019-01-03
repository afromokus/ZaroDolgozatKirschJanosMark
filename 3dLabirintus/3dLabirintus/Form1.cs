using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace _3dLabirintus
{
    public partial class Form1 : Form
    {

        static Panel latoter;
        static Label terkep;
        
        static int i = 0, j = 0;
        private static int szemBal;
        static char[,] palya;
        static int palyaSzelesseg = 8, palyaMagassag = 8;
        private static Pont jatekosHely;
        private static Pont fal0Hely;
        private static Pont fal1Hely;
        private static Pont fal2Hely;
        private static bool jatekMegyE = false;
        private static int latoSzel = 5;
        private static int szemtav;
        private static int latotav = 8;
        static List<Fal> falak = new List<Fal>();
        

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
                    if (jatekMegyE && jatekosHely.getX() < 7 && palya[jatekosHely.getY(), jatekosHely.getX() + 1] != '#')
                    {
                        jatekosJobbra();
                    }
                    break;

                case Keys.A:
                    if (jatekMegyE && jatekosHely.getX() > 0 && palya[jatekosHely.getY(), jatekosHely.getX() - 1] != '#')
                    {
                        jatekosBalra();
                    }
                    break;

                case Keys.T:
                    latoter.Controls.Clear();
                    break;

            }
        }

        private static void jatekosBalra()
        {
            falak = new List<Fal>();
            setMezoPalya(jatekosHely, '_');
            jatekosHely.setX(jatekosHely.getX() - 1);
            terkepVizsgalataEsRajzolas();
        }

        private static void jatekosJobbra()
        {
            falak = new List<Fal>();
            setMezoPalya(jatekosHely, '_');
            jatekosHely.setX(jatekosHely.getX() + 1);
            terkepVizsgalataEsRajzolas();
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
        }
        private static void setMezoPalya(int x, int y, char objektum)
        {
            palya[y, x] = objektum;
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

            falakKozeZaras();


            jatekosHely = new Pont(3, 3);
            fal0Hely = new Pont(3, 3);
            fal1Hely = new Pont(2, 2);
            fal2Hely = new Pont(1, 1);
            setMezoPalya(fal0Hely, '#');
            setMezoPalya(fal1Hely, '#');
            setMezoPalya(fal2Hely, '#');

            jatekosHely.setX(2);
            jatekosHely.setY(5);


            terkepVizsgalataEsRajzolas();

            //MessageBox.Show("Falak száma: " + falak.Count);

            // hatter.Paint += new PaintEventHandler(vonalRajzolasa);
        }

        private static void falakKozeZaras()
        {
            for (i = 0; i < palyaSzelesseg; i++)
            {
                setMezoPalya(0, i, '#');
            }

            for (i = 0; i < palyaSzelesseg; i++)
            {
                setMezoPalya(palyaMagassag - 1, i, '#');
            }

            for (i = 1; i < palyaMagassag; i++)
            {
                setMezoPalya(i, 0, '#');
            }

            for (i = 1; i < palyaMagassag; i++)
            {
                setMezoPalya(i, palyaMagassag - 1, '#');
            }

        }

        private static void terkepVizsgalataEsRajzolas()
        {
            latoter.Controls.Clear();
            setMezoPalya(jatekosHely, 'P');
            terkep.Text = palyaRajzolasa();

            i = jatekosHely.getX() - latoSzel / 2;
            szemBal = 0;
            j = jatekosHely.getY() - 1;
            szemtav = 1;

            try
            {
                if (palya[jatekosHely.getY(), jatekosHely.getX() - 1] == '#')
                {
                    rajzolFalBalOld();
                }

                if (palya[jatekosHely.getY(), jatekosHely.getX() + 1] == '#')
                {
                    rajzolFalJobbOld();
                }

            }
            catch
            {
            }

            do
            {
                if (i > 0)
                {
                    j = jatekosHely.getY() - 1;
                    if (j > 0)
                    {
                        szemtav = 1;
                        do
                        {
                            if (palya[j, i] == '#')
                            {
                                kirajzolFal(szemBal, szemtav);
                                //MessageBox.Show("Térkép(" + i + "," + j + ") = " + palya[j, i] + "\tBizony fal!");
                                i++;
                                szemBal++;
                                szemtav = 1;
                                j = jatekosHely.getY() - 1;
                            }
                            else
                            {
                                //MessageBox.Show("Térkép(" + i + "," + j + ") = " + palya[j, i] + "\tNem fal.");
                                szemtav++;
                                j--;
                            }

                        }
                        while (szemtav <= latotav && j >= 0 && i < palyaSzelesseg);

                        i++;
                        szemBal++;

                    }
                    else
                    {
                        osszesNagyFal();
                        break;
                    }
                }
                else
                {
                    i++;
                }

            }
            while (szemBal <= latoSzel && i < palyaSzelesseg - 1);
            
        }

        private static void rajzolFalJobbOld()
        {
            Fal oldalFal = new Fal(true);

            oldalFal.Height = latoter.Height;

            oldalFal.Left = latoter.Width - oldalFal.Width;

            latoter.Controls.Add(oldalFal);
        }

        private static void rajzolFalBalOld()
        {
            Fal oldalFal = new Fal(true);

            oldalFal.Height = latoter.Height;

            latoter.Controls.Add(oldalFal);
        }

        private static void kirajzolFal(int szemBal, int szemtav)
        {
            falak.Add(new Fal(szemBal, szemtav, latoter.Width, latoSzel));
            latoter.Controls.Add(falak[falak.Count - 1]);
        }

        private static void osszesNagyFal()
        {
            falak = new List<Fal>();
            latoter.BackColor = Color.Gray;
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
