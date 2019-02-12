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
    class Pont3D
    {
        private float x, y, z;

        public Pont3D()
        {
        }

        public Pont3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Pont2D konvertalPont2Dre(float keparany, float fLatoRad)
        {
            Pont2D p2d = new Pont2D();

            //x
            p2d.X = X * keparany * fLatoRad;
            
            if (Z != 0)
            {
                p2d.X /= Z;
            }
            MessageBox.Show("Kétdimenziós pont: " + p2d.X + " (x)\t" + p2d.Y + " (y)\n" +
                "Képarány:\t" + keparany + "\nLátoszög radiánban: " + fLatoRad);

            //y
            p2d.Y = Y * fLatoRad;
            if (Z != 0)
            {
                p2d.Y /= Z;
            }
            MessageBox.Show(p2d.Y + "");

            return p2d;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }
    }
}
