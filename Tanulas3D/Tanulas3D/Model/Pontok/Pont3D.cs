using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Tanulas3D.Model.Pontok;

namespace Tanulas3D.Model
{
    class Pont3D
    {
        private float x, y, z;

        public Pont3D()
        {
        }

        public Pont3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Pont2D konvertalPont2Dre(float keparany, float fLatoRad)
        {
            Pont2D p2d = new Pont2D();

            //x
            p2d.X = x * keparany * fLatoRad;
            
            if (z != 0)
            {
                p2d.X /= z;
            }

            //y
            p2d.Y = y * fLatoRad;
            if (z != 0)
            {
                p2d.Y /= z;
            }

            return p2d;
        }

        public void setX(float x)
        {
            this.x = x;
        }

        public void setY(float y)
        {
            this.y = y;
        }

        public void setZ(float z)
        {
            this.z = z;
        }

        public float getX()
        {
            return x;
        }

        public float getY()
        {
            return y;
        }

        public float getZ()
        {
            return z;
        }
        public override string ToString()
        {
            return getX() + "x\t" + getY() + "y\t" + getZ() + "z";
        }

        public void hozzadXY(float szam)
        {
            x += szam;
            y += szam;
        }

        public void hozzaadMindenErtekhez(float szam)
        {
            x += szam;
            y += szam;
            z += szam;

        }

        internal void eltolZTengelyen(float szam)
        {
            z += szam;
        }
    }
}
