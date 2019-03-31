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
    public partial class JatekValasztasAblak : Form
    {
        #region deklarálás
        KeyEventHandler visszaAFomenubeEsemenyKezelo;
        #endregion

        #region betöltés
        public JatekValasztasAblak()
        {
            InitializeComponent();
        }

        private void JatekValasztasAblak_Load(object sender, EventArgs e)
        {
            Text = "Hamarosan indul a játék\u2026";

            visszaAFomenubeEsemenyKezelo = new KeyEventHandler(visszaLepes);

            gombokraVisszaLepesEsemeny();

            buttonVissza.Text += "  \u2190";
        }

        private void gombokraVisszaLepesEsemeny()
        {
            buttonUjJatek.KeyDown += visszaAFomenubeEsemenyKezelo;
            buttonBetoltes.KeyDown += visszaAFomenubeEsemenyKezelo;
            buttonVissza.KeyDown += visszaAFomenubeEsemenyKezelo;
        }

        #endregion

        #region gombok metódusai
        private void buttonUjJatek_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("..\\");
        }

        public static bool jatekFuttatas(string fileNev, string kiterjesztes="exe")
        {
            try
            {
                System.Diagnostics.Process.Start(fileNev + "." + kiterjesztes);
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show("Játék futtatása sikertelen:\t" + e.Message);
                return false;
            }
        }

        private void visszaLepes(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
        #endregion
    }
}
