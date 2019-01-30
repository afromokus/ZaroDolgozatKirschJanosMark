using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _3dLabirintus.VezerloEsSegedOsztalyok
{
    class Gomb : Button
    {

        Color ablakHatterSzine = Application.OpenForms.Cast<Form>().Last<Form>().BackColor;

        public Gomb()
        {
            BackColor = ablakHatterSzine;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = ablakHatterSzine;
            Font = new Font("", 18, FontStyle.Bold);
            ForeColor = Color.FromArgb(0,240,240,0);
            Height = 50;

            }
    }
}
