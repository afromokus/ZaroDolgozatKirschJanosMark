using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace _3dLabirintus
{
    public partial class Form1 : Form
    {
        #region deklarálás, alapértékek, inícializálás
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
        //Milyen mesziről kezdneke el az objektumok láthatóvá válni
        private static int latotav = 10;
        static List<Fal> falak = new List<Fal>();
        KeyEventHandler kilepesEsemenyKezelo;

        JatekValasztasAblak valasztasAblak;

        #region fel nem használt deklaráció
        public static Color alapszinLatoter = Color.FromArgb(100, 135, 206, 255);
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region betöltés

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "3D Labirintus";

            palya = new char[palyaMagassag, palyaSzelesseg];
            palyaUresFeltoltese(palyaMagassag, palyaSzelesseg);

            latoter = new Panel();
            latoter.Width = Width;
            latoter.Height = Height;

            terkep = new Label();

            Controls.Add(latoter);

            kilepesEsemenyKezelo = new KeyEventHandler(kilepes);

            foGombokraKilepesEsemny();

            KeyDown += new KeyEventHandler(billentyuLenyomas);
            

        }

        private void foGombokraKilepesEsemny()
        {
            buttonJatekStart.KeyDown += kilepesEsemenyKezelo;
            buttonOnlineMod.KeyDown += kilepesEsemenyKezelo;
            buttonBeallitasok.KeyDown += kilepesEsemenyKezelo;
            buttonKilepes.KeyDown += kilepesEsemenyKezelo;
        }

        private void kilepes(object sender, KeyEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        #region gombok metódusai

        private void buttonOnlineMod_Click(object sender, EventArgs e)
        {

        }

        private void buttonKilepes_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonJatekStart_Click(object sender, EventArgs e)
        {
            Focus();

            valasztasAblak = new JatekValasztasAblak();
            valasztasAblak.Left = Left;
            valasztasAblak.Top = Top;
            Hide();
            if (valasztasAblak.ShowDialog() == DialogResult.Cancel)
            {
                Show();
            }
        }

        #endregion

        #region térképfrissítés metódusa

        private static string terkepAtRajzolasa()
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

        #endregion

        #region pályamanipuláció

        private static void osszesSzelsoMezoFallaAlakitasa()
        {
            /*
             #____________
             #____________
             #____________
             #____________
             #____________
             */
            for (i = 0; i < palyaMagassag; i++)
            {
                setMezoPalya(0, i, '#');
            }
            /*
             ____________#
             ____________#
             ____________#
             ____________#
             ____________#
             ____________#
             ____________#
             */

            for (i = 0; i < palyaMagassag; i++)
            {
                setMezoPalya(palyaSzelesseg - 1, i, '#');
            }

            //_########################_
            for (i = 1; i < palyaSzelesseg - 1; i++)
            {
                setMezoPalya(i, 0, '#');
            }

            /*
             * __________________________
             * __________________________
             * __________________________
             * __________________________
             * __________________________
             * _########################_
             * _*/
            for (i = 1; i < palyaSzelesseg - 1; i++)
            {
                setMezoPalya(i, palyaMagassag - 1, '#');
            }


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

        private static void setMezoPalya(Pont hely, char objektum)
        {
            palya[hely.getY(), hely.getX()] = objektum;
        }
        private static void setMezoPalya(int x, int y, char objektum)
        {
            palya[y, x] = objektum;
        }

        #endregion

        #region falRajzolas

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

        #endregion

        #region irányítás
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
                    if (jatekMegyE && jatekosHely.getX() < palyaSzelesseg - 1 && palya[jatekosHely.getY(), jatekosHely.getX() + 1] != '#')
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

                case Keys.W:
                    if (jatekMegyE && jatekosHely.getY() > 0 && palya[jatekosHely.getY() - 1, jatekosHely.getX()] != '#')
                    {
                        jatekosElore();
                    }
                    break;

                case Keys.S:
                    if (jatekMegyE && jatekosHely.getY() < palyaMagassag - 1 && palya[jatekosHely.getY() + 1, jatekosHely.getX()] != '#')
                    {
                        jatekosHatra();
                    }
                    break;

                case Keys.T:
                    latoter.Controls.Clear();
                    latoter.Controls.Add(terkep);
                    break;

                case Keys.Escape:
                    MessageBox.Show("Kilépés ablak");
                    Environment.Exit(0);
                    break;

            }
        }
        #endregion

        #region játékos mozgása

        private void jatekosHatra()
        {
            latvanyEsJatekosElozoPozicioNullazasa();
            jatekosHely.setY(jatekosHely.getY() + 1);
            terkepVizsgalataEsRajzolas();
        }

        private void jatekosElore()
        {
            latvanyEsJatekosElozoPozicioNullazasa();
            jatekosHely.setY(jatekosHely.getY() - 1);
            terkepVizsgalataEsRajzolas();
        }

        private static void jatekosBalra()
        {
            latvanyEsJatekosElozoPozicioNullazasa();
            jatekosHely.setX(jatekosHely.getX() - 1);
            terkepVizsgalataEsRajzolas();
        }

        private static void jatekosJobbra()
        {
            latvanyEsJatekosElozoPozicioNullazasa();
            jatekosHely.setX(jatekosHely.getX() + 1);
            terkepVizsgalataEsRajzolas();
        }

        private static void latvanyEsJatekosElozoPozicioNullazasa()
        {
            falak = new List<Fal>();
            setMezoPalya(jatekosHely, '_');
        }

        private static void terkepVizsgalataEsRajzolas()
        {
            latoter.Controls.Clear();
            latoter.Controls.Add(terkep);
            setMezoPalya(jatekosHely, 'P');
            terkep.Text = terkepAtRajzolasa();

            i = jatekosHely.getX() - latoSzel / 2;
            szemBal = 0;
            j = jatekosHely.getY() - 1;
            szemtav = 1;

            if (palya[jatekosHely.getY() - 1, jatekosHely.getX()] != '#')
            {
                latoter.BackColor = alapszinLatoter;
            }

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

        #endregion


        public static void jatekInditas(int jatekosKezdoHelyX, int jatekosKezdoHelyY)
        {

            jatekMegyE = true;

            latoter.BackColor = alapszinLatoter;
            latoter.Dock = DockStyle.Fill;

            terkep.Width = palyaSzelesseg * 10;
            terkep.Height = palyaMagassag*13;

            osszesSzelsoMezoFallaAlakitasa();


            jatekosHely = new Pont(3, 3);
            fal0Hely = new Pont(3, 3);
            fal1Hely = new Pont(5, 1);
            fal2Hely = new Pont(1, 1);
            setMezoPalya(fal0Hely, '#');
            setMezoPalya(fal1Hely, '#');

            jatekosHely.setX(jatekosKezdoHelyX);
            jatekosHely.setY(jatekosKezdoHelyY);

            if (palya[jatekosKezdoHelyY, jatekosKezdoHelyX] == '#')
            {
                throw new Exception("Játékos nem kezdhet falban!");
            }


            terkepVizsgalataEsRajzolas();
        }






        #region fel nem használt kód
        public static double tavolsagSzamitasa(Pont elsoPont, Pont masodikPont)
        {
            return Math.Sqrt(Math.Pow((elsoPont.getX() - masodikPont.getX()), 2)
                + Math.Pow((elsoPont.getY() - masodikPont.getY()), 2));
        }

        #endregion

    }
}
