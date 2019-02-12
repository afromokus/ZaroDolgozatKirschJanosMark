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
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    m[j, i] = 0;
                }
            }
        }

        public float[,] M { get => m; set => m = value; }
    }
}
