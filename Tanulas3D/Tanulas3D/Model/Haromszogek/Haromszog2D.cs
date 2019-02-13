using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanulas3D.Model.Pontok;

namespace Tanulas3D.Model
{
    class Haromszog2D
    {
        Pont2D p1;
        Pont2D p2;
        Pont2D p3;

        internal Pont2D P1 { get => p1; set => p1 = value; }
        internal Pont2D P2 { get => p2; set => p2 = value; }
        internal Pont2D P3 { get => p3; set => p3 = value; }

        public Haromszog2D(Haromszog2D h)
        {
            p1 = h.p1;
            p2 = h.p2;
            p3 = h.p3;
        }

        public Haromszog2D()
        {
            p1 = new Pont2D();
            p2 = new Pont2D();
            p3 = new Pont2D();
        }

        public Haromszog2D(Pont2D p1, Pont2D p2, Pont2D p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public void felulIrHaromszog(Haromszog2D h)
        {
            p1 = h.p1;
            p2 = h.p2;
            p3 = h.p3;
        }


        public override string ToString()
        {
            return "Pont 1: (" + p1.X + ", " + p1.Y + ")\n" + "Pont 2: (" + p2.X + ", " + p2.Y + ")\n" +
                "Pont 3: (" + p3.X + ", " + p3.Y + ")\n";
        }

        internal void eltolas(int mennyiseg)
        {
            p1.X += mennyiseg;
            p1.Y += mennyiseg;
            p2.X += mennyiseg;
            p2.Y += mennyiseg;
            p3.X += mennyiseg;
            p3.Y += mennyiseg;
        }
    }
}
