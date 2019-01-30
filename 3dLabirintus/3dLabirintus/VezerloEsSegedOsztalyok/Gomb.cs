using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3dLabirintus.VezerloEsSegedOsztalyok
{
    class Gomb : Button
    {

        System.Drawing.Color ablakHatterSzine = Application.OpenForms.Cast<Form>().Last<Form>().BackColor;

        public Gomb()
        {
            BackColor = ablakHatterSzine;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = ablakHatterSzine;

            }
    }
}
