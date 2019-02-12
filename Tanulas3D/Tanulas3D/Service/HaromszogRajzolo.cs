using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Tanulas3D.Model;

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

        public void rajzolHaromszog(Haromszog h)
        {

            grafika.DrawLine(ceruza, h.V1.X, h.V1.Y, h.V2.X, h.V2.Y);
            grafika.DrawLine(ceruza, h.V2.X, h.V2.Y, h.V3.X, h.V3.Y);
            grafika.DrawLine(ceruza, h.V3.X, h.V3.Y, h.V1.X, h.V1.Y);

        }

    }
}
