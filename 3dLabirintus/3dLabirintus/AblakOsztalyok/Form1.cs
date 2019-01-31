using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using _3dLabirintus.VezerloEsSegedOsztalyok;

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

            BackColor = Color.White;

            kilepesEsemenyKezelo = new KeyEventHandler(kilepes_ESC);

            gombokAlapKonfiguracioja();
            gombokhozEsemenyekRendeleseFormhozAdas();

            foGombokraKilepesEsemny();
        }

        private void gombokhozEsemenyekRendeleseFormhozAdas()
        {
            gombJatekStart.Click += new EventHandler(gombJatekStart_Click);
            gombKilepes.Click += new EventHandler(gombKilepes_Click);

            Controls.Add(gombJatekStart);
            Controls.Add(gombOnlineMod);
            Controls.Add(gombBeallitasok);
            Controls.Add(gombKilepes);
        }

        private void gombokAlapKonfiguracioja()
        {
            gombJatekStart = new Gomb();
            gombOnlineMod = new Gomb();
            gombBeallitasok = new Gomb();
            gombKilepes = new Gomb();

            gombJatekStart.Width = 240;
            gombOnlineMod.Width = gombJatekStart.Width;
            gombBeallitasok.Width = gombJatekStart.Width;
            gombKilepes.Width = gombJatekStart.Width;

            gombJatekStart.Location = new Point(267, 83);
            gombOnlineMod.Location = new Point(gombJatekStart.Location.X, gombJatekStart.Location.Y + 55);
            gombBeallitasok.Location = new Point(gombJatekStart.Location.X, gombJatekStart.Location.Y + 110);
            gombKilepes.Location = new Point(gombJatekStart.Location.X, gombJatekStart.Location.Y + 164);

            gombJatekStart.Text = "Játék indítása";
            gombOnlineMod.Text = "Online - mód";
            gombBeallitasok.Text = "Beállítások";
            gombKilepes.Text = "Kilépés";
        }

        private void foGombokraKilepesEsemny()
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






        #region fel nem használt kód
        public static double tavolsagSzamitasa(Pont elsoPont, Pont masodikPont)
        {
            return Math.Sqrt(Math.Pow((elsoPont.getX() - masodikPont.getX()), 2)
                + Math.Pow((elsoPont.getY() - masodikPont.getY()), 2));
        }

        #endregion

    }
}
