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
    public partial class JatekAblak : Form
    {
        #region deklarálás

        static Label terkep;
        private static int szemtav;
        private static int szemBal;
        static int palyaSzelesseg = 8, palyaMagassag = 8;
        static char[,] palya;
        static Panel latoter;
        //Milyen mesziről kezdneke el az objektumok láthatóvá válni
        private static int latotav = 10;
        private static int latoSzel = 5;
        private static Pont jatekosHely;
        private static bool jatekMegyE = false;
        static int i = 0, j = 0;
        static List<Fal> falak = new List<Fal>();
        private static Pont fal0Hely;
        private static Pont fal1Hely;
        private static Pont fal2Hely;
        public static Color alapszinLatoter = Color.FromArgb(100, 135, 206, 255);

        #endregion

        #region betöltés
        public JatekAblak()
        {
            InitializeComponent();
        }

        private void JatekAblak_Load(object sender, EventArgs e)
        {
            Text = "3D Labirintus";

            latoter = new Panel();
            latoter.Width = Width;
            latoter.Height = Height;

            terkep = new Label();

            Controls.Add(latoter);

            palya = new char[palyaMagassag, palyaSzelesseg];
            palyaUresFeltoltese(palyaMagassag, palyaSzelesseg);

            KeyDown += new KeyEventHandler(billentyuLenyomas);

            jatekInditas(palyaSzelesseg / 2, palyaMagassag / 2);

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
            switch (e.KeyCode)
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
            terkep.Height = palyaMagassag * 13;

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
    }
}
