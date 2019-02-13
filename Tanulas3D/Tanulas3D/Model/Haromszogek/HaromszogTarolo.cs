using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanulas3D.Model.Pontok;

namespace Tanulas3D.Model.Haromszogek
{
    class HaromszogTarolo
    {

        Pont3D p1;
        Pont3D p2;
        Pont3D p3;

        public HaromszogTarolo(Pont3D p1, Pont3D p2, Pont3D p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
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

        public void adatokLekerese(Haromszog h)
        {
            setPont1(h.P1);
            setPont2(h.P2);
            setPont3(h.P3);
        }

        internal Haromszog visszaadHaromszogAdatok()
        {
            Haromszog visszaadando = new Haromszog(getPont1(), getPont2(), getPont3());


            return visszaadando;
        }

        public override string ToString()
        {
            return "pont1 : " + p1.getX() + "x\t" + p1.getY() + "y\t" + p1.getZ() + "z\n" +
               "pont2 : " + p2.getX() + "x\t" + p2.getY() + "y\t" + p2.getZ() + "z\n" +
               "pont3 : " + p3.getX() + "x\t" + p3.getY() + "y\t" + p3.getZ() + "z";
        }
    }
}
