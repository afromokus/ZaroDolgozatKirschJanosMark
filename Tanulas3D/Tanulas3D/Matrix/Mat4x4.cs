using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanulas3D.Matrix
{
    class Mat4x4
    {
        int oszlopokSzama = 4;
        int sorokSzama = 4;

        float[,] m;

        public Mat4x4()
        {

            m = new float[oszlopokSzama, sorokSzama];

            for (int j = 0; j < oszlopokSzama; j++)
            {
                for (int i = 0; i < sorokSzama; i++)
                {
                    m[j, i] = 0;
                }
            }
        }

        public float[,] M { get => m; set => m = value; }

        public override string ToString()
        {
            string sor = "";
            string teljesSzoveg = "";

            for (int j = 0; j < sorokSzama; j++)
            {
                for (int i = 0; i < oszlopokSzama; i++)
                {
                    sor += m[j, i] + "\t";
                }

                teljesSzoveg += sor + "\n";
                sor = "";
            }

            return teljesSzoveg;
        }

    }
}
