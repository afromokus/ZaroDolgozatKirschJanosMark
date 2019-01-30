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
        JatekAblak jAblak;
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
            jAblak = new JatekAblak();
            jAblak.ShowDialog();
        }

        private void visszaLepes(object sender, KeyEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
