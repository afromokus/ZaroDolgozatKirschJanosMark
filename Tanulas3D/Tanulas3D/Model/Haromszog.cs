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

        public Haromszog(Vektor3D v1, Vektor3D v2, Vektor3D v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public Vektor3D V1 { get => v1; set => v1 = value; }
        public Vektor3D V2 { get => v2; set => v2 = value; }
        public Vektor3D V3 { get => v3; set => v3 = value; }
    }
}
