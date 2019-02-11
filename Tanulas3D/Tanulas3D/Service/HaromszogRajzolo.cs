using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Tanulas3D.Service
{
    class HaromszogRajzolo
    {
        private Panel vaszon;

        public HaromszogRajzolo(Panel vaszon)
        {
            this.vaszon = vaszon;

            Graphics grafika = vaszon.CreateGraphics();

            Pen ceruza = new Pen(Color.Black);

            grafika.DrawLine(ceruza, 10,10,100,150);

        }
    }
}
