using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using _3dLabirintus.VezerloEsSegedOsztalyok;
using System.Windows.Media;

namespace _3dLabirintus
{
    public partial class Form3DLabirintus : Form
    {
        #region deklarálás, alapértékek, inícializálás
        
        KeyEventHandler kilepesEsemenyKezelo;

        JatekValasztasAblak valasztasAblak;

        Gomb gombJatekStart;
        Gomb gombOnlineMod;
        Gomb gombBeallitasok;
        Gomb gombKilepes;

        MediaPlayer videoLabirintus;
        

        public Form3DLabirintus()
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
            MaximizeBox = false;

            BackColor = System.Drawing.Color.White;
            kilepesEsemenyKezelo = new KeyEventHandler(kilepes_ESC);
            

            videoLabirintus = new MediaPlayer();
            videoLabirintus.Open(new Uri("Labirintus.mp4"));
            videoLabirintus.Play();

            /*
            videoLabirintus.left = (-65, -18);
            videoLabirintus.settings.setMode("loop", true);
            videoLabirintus.KeyDownEvent += new AxWMPLib._WMPOCXEvents_KeyDownEventHandler(videoLabirintus_KeyDownEvent);
            videoLabirintus.PlayStateChange += videoLabirintus_PlayStateChange;*/
           


            gombokKonfiguracioja();

            foGombokraKilepesAlapEsemny();

        }

        /*private void videoLabirintus_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 3)
            {
                Location = new Point(Screen.PrimaryScreen.Bounds.Width / 4, Screen.PrimaryScreen.Bounds.Height / 4);
                Width = videoLabirintus.currentMedia.imageSourceWidth - 30;
                Height = videoLabirintus.currentMedia.imageSourceHeight + 28;

                videoLabirintus.Height = Height + 50;
                videoLabirintus.Width = Width + 100;

            }
        }*/
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

            Controls.Add(gombJatekStart);
            Controls.Add(gombOnlineMod);
            Controls.Add(gombBeallitasok);
            Controls.Add(gombKilepes);
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

        #region fel nem használt kód
        public static double tavolsagSzamitasa(Pont elsoPont, Pont masodikPont)
        {
            return Math.Sqrt(Math.Pow((elsoPont.getX() - masodikPont.getX()), 2)
                + Math.Pow((elsoPont.getY() - masodikPont.getY()), 2));
        }

        #endregion
        /*
        #region videó beállítások

        private void videoLabirintus_KeyDownEvent(object sender, AxWMPLib._WMPOCXEvents_KeyDownEvent e)
        {
            //27 -----> ESC
            if (e.nKeyCode == 27)
            {
                MessageBox.Show(videoLabirintus.currentMedia.imageSourceWidth + "");
                Environment.Exit(0);
            }
        }


        #endregion*/

    }
}
