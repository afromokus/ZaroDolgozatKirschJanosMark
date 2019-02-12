using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanulas3D.Model.Vektorok
{
    class Vektor2D
    {
        private float x, y;

        public Vektor2D()
        {
        }

        public Vektor2D(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
    }
}
