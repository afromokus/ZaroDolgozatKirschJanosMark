using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanulas3D.Model.Vektorok;

namespace Tanulas3D.Model
{
    class HaromszogVetulet
    {
        Pont2D p1;
        Pont2D p2;
        Pont2D p3;

        public HaromszogVetulet(Pont2D p1, Pont2D p2, Pont2D p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        internal Pont2D P1 { get => p1; set => p1 = value; }
        internal Pont2D P2 { get => p2; set => p2 = value; }
        internal Pont2D P3 { get => p3; set => p3 = value; }

        public override string ToString()
        {
            return "Pont 1: (" + p1.X + ", " + p1.Y + ")\n" + "Pont 2: (" + p2.X + ", " + p2.Y + ")\n" +
                "Pont 3: (" + p3.X + ", " + p3.Y + ")\n";
        }
    }
}
