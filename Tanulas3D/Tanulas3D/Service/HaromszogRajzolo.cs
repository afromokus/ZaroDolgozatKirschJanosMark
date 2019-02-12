using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Tanulas3D.Model;
using Tanulas3D.Model.Vektorok;

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

        public void rajzolHaromszog(Pont2D p1, Pont2D p2, Pont2D p3)
        {

            grafika.DrawLine(ceruza, p1.X, p1.Y, p2.X, p2.Y);
            grafika.DrawLine(ceruza, p2.X, p2.Y, p3.X, p3.Y);
            grafika.DrawLine(ceruza, p3.X, p3.Y, p1.X, p1.Y);

        }

        public void rajzolHaromszog(Pont3D p1, Pont3D p2, Pont3D p3)
        {


            grafika.DrawLine(ceruza, p1.X, p1.Y, p2.X, p2.Y);
            grafika.DrawLine(ceruza, p2.X, p2.Y, p3.X, p3.Y);
            grafika.DrawLine(ceruza, p3.X, p3.Y, p1.X, p1.Y);

        }

    }
}
