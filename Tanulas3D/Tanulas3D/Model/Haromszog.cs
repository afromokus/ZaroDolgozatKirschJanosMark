using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanulas3D.Model
{
    class Haromszog
    {
        Pont3D p1;
        Pont3D p2;
        Pont3D p3;

        public Haromszog()
        {
        }

        public Haromszog(Pont3D v1, Pont3D v2, Pont3D v3)
        {
            this.p1 = v1;
            this.p2 = v2;
            this.p3 = v3;
        }

        public Pont3D P1 { get => p1; set => p1 = value; }
        public Pont3D P2 { get => p2; set => p2 = value; }
        public Pont3D P3 { get => p3; set => p3 = value; }

        public void felulIrHaromszog(Haromszog h)
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
