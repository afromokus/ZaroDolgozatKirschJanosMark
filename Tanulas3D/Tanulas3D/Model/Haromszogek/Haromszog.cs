using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanulas3D.Model
{
    class Haromszog
    {
        Pont3D p1;
        Pont3D p2;
        Pont3D p3;

        public Haromszog(Haromszog h)
        {
            p1 = h.p1;
            p2 = h.p2;
            p3 = h.p3;
        }

        public Haromszog()
        {
            p1 = new Pont3D();
            p2 = new Pont3D();
            p3 = new Pont3D();
        }

        public Haromszog(Pont3D v1, Pont3D v2, Pont3D v3)
        {
            this.p1 = v1;
            this.p2 = v2;
            this.p3 = v3;
        }

        public void felulIrHaromszog(Haromszog h)
        {
            p1 = h.p1;
            p2 = h.p2;
            p3 = h.p3;
        }


        public override string ToString()
        {
            return "Pont 1: (" + p1.getX() + ", " + p1.getY() + ")\n" + "Pont 2: (" + p2.getX() + ", " + p2.getY() + ")\n" + 
                "Pont 3: (" + p3.getX() + ", " + p3.getY() + ")\n";
        }

        public Pont3D getPont1()
        {
            return p1;
        }

        public Pont3D getPont2()
        {
            return p2;
        }

        public Pont3D getPont3()
        {
            return p3;
        }

        internal void eltolas(int x, int y)
        {
            p1.setX(p1.getX() + x);
            p1.setY(p1.getY() + y);
            p2.setX(p2.getX() + x);
            p2.setY(p2.getY() + y);
            p3.setX(p3.getX() + x);
            p3.setY(p3.getY() + y);
        }

        public Haromszog getHaromszog()
        {
            return this;
        }

        public void hozzaadMindenErtekhez(float szam)
        {
            p1.hozzaadMindenErtekhez(szam);
            p2.hozzaadMindenErtekhez(szam);
            p3.hozzaadMindenErtekhez(szam);
        }

        public void setPont1(Pont3D p1)
        {
            this.p1 = p1;
        }

        public void setPont2(Pont3D p2)
        {
            this.p2 = p2;
        }

        public void setPont3(Pont3D p3)
        {
            this.p3 = p3;
        }

        internal void hozzaadXY(float szam)
        {
            p1.hozzadXY(szam);
            p2.hozzadXY(szam);
            p3.hozzadXY(szam);
        }

        public void novelesKepernyore(float width, float height)
        {
            p1.setX(p1.getX() * width / 2);
            p1.setY(p1.getY() * height / 2);
            p2.setX(p2.getX() * width / 2);
            p2.setY(p2.getY() * height / 2);
            p3.setX(p3.getX() * width / 2);
            p3.setY(p3.getY() * height / 2);
        }
    }
}
