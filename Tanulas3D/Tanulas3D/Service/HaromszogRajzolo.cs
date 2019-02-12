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
        Graphics grafika;
        Pen ceruza;

        private Panel vaszon;

        public HaromszogRajzolo(Panel vaszon)
        {
            this.vaszon = vaszon;

            grafika = vaszon.CreateGraphics();

            ceruza = new Pen(Color.Black);
        }

        public void rajzolHaromszog(int x01, int y01, int x02, int y02, int x11, int y11)
        {

            grafika.DrawLine(ceruza, x01, y01, x02, y02);
            grafika.DrawLine(ceruza, x02, y02, x11, y11);
            grafika.DrawLine(ceruza, x11, y11, x01, y01);

        }

    }
}
