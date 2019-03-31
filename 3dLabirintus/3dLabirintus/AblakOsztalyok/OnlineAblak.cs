using _3dLabirintus.VezerloEsSegedOsztalyok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3dLabirintus.AblakOsztalyok
{
    public partial class OnlineAblak : Form
    {
        Felhasznalo bejelentkezettFelhasznalo;

        public OnlineAblak(Felhasznalo bejelFelh)
        {
            InitializeComponent();
            bejelentkezettFelhasznalo = bejelFelh;
        }

        private void OnlineAblak_Load(object sender, EventArgs e)
        {
            KeyDown += new KeyEventHandler(visszaLepes);

            labelUdvozlo.Text = "Üdvözöljük " + bejelentkezettFelhasznalo.FelhNev + "!";
            labelVisszajelzo.Text = "Online-mód még nem elérhető!";
        }

        private void visszaLepes(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
