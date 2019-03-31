using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using _3dLabirintus.VezerloEsSegedOsztalyok;
using _3dLabirintus.AblakOsztalyok;

namespace _3dLabirintus
{
    public partial class Form1 : Form
    {
        #region deklarálás, alapértékek, inícializálás
        
        KeyEventHandler kilepesEsemenyKezelo;

        JatekValasztasAblak valasztasAblak;

        Gomb gombJatekStart;
        Gomb gombOnlineMod;
        Gomb gombBeallitasok;
        Gomb gombKilepes;
        

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region betöltés

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "3D Labirintus";

            Width = 820;
            Height = 490;

            BackColor = Color.White;

            kilepesEsemenyKezelo = new KeyEventHandler(kilepes_ESC);

            gombokKonfiguracioja();

            foGombokraKilepesAlapEsemny();
        }
        #endregion

        #region gombok konfigurálása

        private void gombokKonfiguracioja()
        {

            gombokPeldanyositasa();

            gombokSzelessegenekMegadasa();

            gombokElhelyezkedese();

            gombokFelirata();

            gombokhozEsemenyekRendeleseFormhozAdas();
        }

        private void gombokhozEsemenyekRendeleseFormhozAdas()
        {
            gombJatekStart.Click += new EventHandler(gombJatekStart_Click);
            gombKilepes.Click += new EventHandler(gombKilepes_Click);
            gombOnlineMod.Click += new EventHandler(gombOnline_Click);

            Controls.Add(gombJatekStart);
            Controls.Add(gombOnlineMod);
            Controls.Add(gombBeallitasok);
            Controls.Add(gombKilepes);
        }

        private void gombOnline_Click(object sender, EventArgs e)
        {
            bejelentkezesAblak ba = new bejelentkezesAblak();
            Hide();
            if (ba.ShowDialog() == DialogResult.Cancel)
            {
                Show();
            }
        }

        private void gombokFelirata()
        {
            gombJatekStart.Text = "Játék indítása";
            gombOnlineMod.Text = "Online - mód";
            gombBeallitasok.Text = "Beállítások";
            gombKilepes.Text = "Kilépés";
        }

        private void gombokElhelyezkedese()
        {
            gombJatekStart.Location = new Point(Width / 3, 83);
            gombOnlineMod.Location = new Point(gombJatekStart.Location.X, gombJatekStart.Location.Y + Height / 9);
            gombBeallitasok.Location = new Point(gombJatekStart.Location.X, Convert.ToInt16(gombJatekStart.Location.Y + Height / 4.5));
            gombKilepes.Location = new Point(gombJatekStart.Location.X, gombJatekStart.Location.Y + Height / 3);
        }

        private void gombokSzelessegenekMegadasa()
        {
            gombJatekStart.Width = 240;
            gombOnlineMod.Width = gombJatekStart.Width;
            gombBeallitasok.Width = gombJatekStart.Width;
            gombKilepes.Width = gombJatekStart.Width;
        }

        private void gombokPeldanyositasa()
        {

            gombJatekStart = new Gomb();
            gombOnlineMod = new Gomb();
            gombBeallitasok = new Gomb();
            gombKilepes = new Gomb();

        }

        private void foGombokraKilepesAlapEsemny()
        {
            gombJatekStart.KeyDown += kilepesEsemenyKezelo;
            gombOnlineMod.KeyDown += kilepesEsemenyKezelo;
            gombBeallitasok.KeyDown += kilepesEsemenyKezelo;
            gombKilepes.KeyDown += kilepesEsemenyKezelo;
        }

        private void kilepes_ESC(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Environment.Exit(0);
            }
        }

        #endregion

        #region gombok metódusai

        private void buttonOnlineMod_Click(object sender, EventArgs e)
        {

        }

        private void gombKilepes_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void gombJatekStart_Click(object sender, EventArgs e)
        {
            Focus();

            valasztasAblak = new JatekValasztasAblak();
            valasztasAblak.Left = Left;
            valasztasAblak.Top = Top;
            Hide();
            if (valasztasAblak.ShowDialog() == DialogResult.Cancel)
            {
                Show();
                gombJatekStart.Focus();
            }
        }

        #endregion

    }
}
