using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanulas3D.Model
{
    class Alakzat
    {
        List<Haromszog> haromszogLista;

        public Alakzat(List<Haromszog> haromszogLista)
        {
            this.haromszogLista = haromszogLista;
        }

        internal List<Haromszog> HaromszogLista { get => haromszogLista; set => haromszogLista = value; }
    }
}
