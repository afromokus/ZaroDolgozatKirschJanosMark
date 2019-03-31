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
    public partial class bejelentkezesAblak : Form
    {

        KeyEventHandler visszaAFomenubeEsemenyKezelo;
        AdatbazisKezelo ak;
        OnlineAblak oa;
        Felhasznalo bejelentkezettFelh;
        ErrorProvider epFelh;
        private ErrorProvider epJelsz;
        ErrorProvider epIP;

        public bejelentkezesAblak()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bejelentkezesAblak_Load(object sender, EventArgs e)
        {
            textBoxIP.Enabled = false;
            radioButton1.Checked = true;
            Text = "Bejelentkezés";

            visszaAFomenubeEsemenyKezelo = new KeyEventHandler(visszaLepes);
            KeyDown += visszaAFomenubeEsemenyKezelo;
            textBoxFelhNev.KeyUp += new KeyEventHandler(felhNevTextBox_KeyPress);
            textBoxJelszo.KeyUp += new KeyEventHandler(jelszTextBox_KeyPress);

            textBoxFelhNev.KeyDown += visszaAFomenubeEsemenyKezelo;
            textBoxJelszo.KeyDown += visszaAFomenubeEsemenyKezelo;
            buttonOK.KeyDown += visszaAFomenubeEsemenyKezelo;

            buttonOK.Click += new EventHandler(buttonOK_Click);

            textBoxJelszo.PasswordChar = '*';

            epFelh = new ErrorProvider();
            epJelsz = new ErrorProvider();
            epIP = new ErrorProvider();            

        }

        private void jelszTextBox_KeyPress(object sender, KeyEventArgs e)
        {
            if (vizsgalHosszMegfE(textBoxJelszo.Text))
            {
                epJelsz.Clear();
            }
            else
            {
                epJelsz.SetError(textBoxJelszo, "Jelszó nem megfelelő hosszúságú!");
            }
        }

        private void felhNevTextBox_KeyPress(object sender, KeyEventArgs e)
        {
            if (vizsgalHosszMegfE(textBoxFelhNev.Text))
            {
                epFelh.Clear();
            }
            else
            {
                epFelh.SetError(textBoxFelhNev, "Felhasználónévnek legalább négy karakterből szükséges" +
                    " állnia!");
            }
        }

        public static bool vizsgalHosszMegfE(string elem)
        {
            if (elem.Length < 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (ellenorizIPCimHelyesE() || !radioButtonIP.Checked)
            {
                if (textBoxFelhNev.Text.Length >= 4 && textBoxJelszo.Text.Length >= 4)
                {
                    try
                    {
                        ak = new AdatbazisKezelo(textBoxIP.Text);
                        Felhasznalo vizsgaltFelh = ak.bejelentkezes(textBoxFelhNev.Text, textBoxJelszo.Text);
                        if (vizsgaltFelh == null)
                        {
                            MessageBox.Show("Érvénytelen felhasználónév, vagy jelszó!");
                            textBoxFelhNev.Text = "";
                            textBoxJelszo.Text = "";
                        }
                        else
                        {
                            bejelentkezettFelh = vizsgaltFelh;
                            oa = new OnlineAblak(bejelentkezettFelh);
                            Hide();
                            if (oa.ShowDialog() == DialogResult.Cancel)
                            {
                                Show();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("A szerver nem elérhető!");
                    }
                }
                else
                {
                    MessageBox.Show("Jelszó vagy felhasználónév nem megfelelő hosszúságú!");
                    textBoxFelhNev.Text = "";
                    textBoxJelszo.Text = "";
                    epFelh.Clear();
                    epJelsz.Clear();
                }
            }
            else
            {
                MessageBox.Show("Érvénytelen ip-cím!");
            }
        }

        private void visszaLepes(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void radioButtonIP_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIP.Checked)
            {
                textBoxIP.Enabled = true;
            }
            else
            {
                textBoxIP.Enabled = false;
                textBoxIP.Text = "";
            }
        }

        private void textBoxIP_TextChanged(object sender, EventArgs e)
        {
            if (!ellenorizIPCimHelyesE())
            {
                epIP.SetError(textBoxIP, "Helytelen szintaxis!");
            }
            else
            {
                epIP.Clear();
            }
        }

        bool ellenorizIPCimHelyesE()
        {
            try
            {
                if (textBoxIP.Text.Count(karakter => karakter == '.') == 3)
                {
                    Convert.ToInt32(textBoxIP.Text.Replace(".", ""));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
