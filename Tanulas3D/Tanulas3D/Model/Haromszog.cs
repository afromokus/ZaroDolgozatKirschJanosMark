using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanulas3D.Model
{
    class Haromszog
    {
        Vektor3D v1;
        Vektor3D v2;
        Vektor3D v3;

        public Haromszog()
        {
        }

        public Haromszog(Vektor3D v1, Vektor3D v2, Vektor3D v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public Vektor3D V1 { get => v1; set => v1 = value; }
        public Vektor3D V2 { get => v2; set => v2 = value; }
        public Vektor3D V3 { get => v3; set => v3 = value; }

        public void felulIrHaromszog(Haromszog h)
        {
            v1 = h.v1;
            v2 = h.v2;
            v3 = h.v3;
        }


        public override string ToString()
        {
            return "Vektor 1: (" + v1.X + ", " + v1.Y + ")\n" + "Vektor 2: (" + v2.X + ", " + v2.Y + ")\n" + 
                "Vektor 3: (" + v3.X + ", " + v3.Y + ")\n";
        }

    }
}
