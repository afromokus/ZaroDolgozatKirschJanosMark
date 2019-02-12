using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Tanulas3D.Model.Vektorok;

namespace Tanulas3D.Model
{
    class Vektor3D
    {
        private float x, y, z;

        public Vektor3D()
        {
        }

        public Vektor3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        Vektor2D konvertalVektor2Dre(float keparany, float fLatoRad)
        {
            Vektor2D v2d = new Vektor2D();

            //x
            v2d.X = X * keparany * fLatoRad;
            if (Z != 0)
            {
                v2d.X /= Z;
            }

            //y
            v2d.Y = Y * fLatoRad;
            if (Z != 0)
            {
                v2d.Y /= Z;
            }

            return v2d;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }
    }
}
