using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanulas3D.Matrix
{
    class Mat4x4
    {
        float[,] m = new float[4,  4];

        public Mat4x4()
        {

        }

        public float[,] M { get => m; set => m = value; }
    }
}
