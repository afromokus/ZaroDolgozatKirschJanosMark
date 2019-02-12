using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanulas3D.Model;
using Tanulas3D.Matrix;
using Tanulas3D.Service;
using Tanulas3D.Model.Vektorok;

namespace Tanulas3D
{

    public static class MathExtensions
    {
        public static float konvertalFloat(this double ertek)
        {
            return (float)ertek;
        }
    }

    public partial class Form1 : Form
    {
        Alakzat kocka;
        Mat4x4 matVetulet;
        Mat4x4 matForgatasZ;
        Mat4x4 matForgatasX;
        float keparany;
        float fKozel;
        float fTavol;
        float fLatoter;
        float fLatoRad;
        float q;


        public Form1()
        {
            InitializeComponent();

        }

        private void frissitKeparany()
        {
            keparany = (float)Height / Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vaszon.BackColor = Color.White;
            matVetulet = new Mat4x4();
            matForgatasX = new Mat4x4();
            matForgatasZ = new Mat4x4();
            elokeszuletek();

        }

        Pont3D szorzasMatrixPonttal(Pont3D be, Mat4x4 m)
        {
            Pont3D ki = new Pont3D(0,0,0);

            ki.X = be.X * m.M[0, 0] + be.Y * m.M[1, 0] + be.Z * m.M[2, 0] + m.M[3, 0];
            ki.Y = be.Y * m.M[0, 1] + be.Y * m.M[1, 1] + be.Z * m.M[2, 1] + m.M[3, 1];
            ki.Z = be.Z * m.M[0, 2] + be.Z * m.M[1, 2] + be.Z * m.M[2, 2] + m.M[3, 2];
            float w = be.Z * m.M[0, 3] + be.Z * m.M[1, 3] + be.Z * m.M[2, 3] + m.M[3, 3];

            if (w != 0)
            {
                ki.X /= w;
                ki.Y /= w;
                ki.Z /= w;
            }

            return ki;
        }

        private void elokeszuletek()
        {

            kocka = new Alakzat(keszitKocka());

            fKozel = 0.1f;
            fTavol = 1000;
            fLatoter = 90;
            frissitKeparany();
            fLatoRad = 1.0f / Math.Tan(fLatoter / 2f).konvertalFloat();
            frissitKeparany();
            q = fTavol / (fKozel - fTavol);

            //matVetulet
            matVetulet.M[0, 0] = keparany * fLatoRad;
            matVetulet.M[1, 1] = fLatoRad;
            matVetulet.M[2, 2] = q;
            matVetulet.M[2, 3] = 1f;
            matVetulet.M[3, 3] = 0f;

            //forgatás z
            matForgatasX.M[0, 0] = 1f;
            matForgatasX.M[1, 1] = Math.Cos(fLatoter / 2).konvertalFloat();
            matForgatasX.M[1, 2] = Math.Sin(fLatoter / 2).konvertalFloat();
            matForgatasX.M[2, 1] = -Math.Sin(fLatoter / 2).konvertalFloat();
            matForgatasX.M[2, 2] = Math.Cos(fLatoter / 2).konvertalFloat();
            matForgatasX.M[3, 3] = 1f;

            //forgatás x
            matForgatasZ.M[0, 0] = 1f;
            matForgatasZ.M[1, 1] = 1f;
            matForgatasZ.M[1, 2] = 1f;
            matForgatasZ.M[2, 1] = 1f;
            matForgatasZ.M[2, 2] = 1f;
            matForgatasZ.M[3, 3] = 1f;

        }
        private List<Haromszog> keszitKocka()
        {

            List<Haromszog> haromszogLista = new List<Haromszog>();

            //elülső rész
            haromszogLista.Add(new Haromszog(new Pont3D(0, 0, 0), new Pont3D(0, 1, 0), new Pont3D(1, 1, 0)));
            haromszogLista.Add(new Haromszog(new Pont3D(0, 0, 0), new Pont3D(1, 1, 0), new Pont3D(1, 0, 0)));

            //jobb oldal
            haromszogLista.Add(new Haromszog(new Pont3D(1, 0, 0), new Pont3D(1, 1, 0), new Pont3D(1, 1, 1)));
            haromszogLista.Add(new Haromszog(new Pont3D(1, 0, 0), new Pont3D(1, 1, 1), new Pont3D(1, 0, 1)));

            //hátsó rész
            haromszogLista.Add(new Haromszog(new Pont3D(1, 0, 1), new Pont3D(1, 1, 1), new Pont3D(0, 0, 1)));
            haromszogLista.Add(new Haromszog(new Pont3D(1, 0, 1), new Pont3D(0, 1, 1), new Pont3D(0, 0, 1)));

            //bal oldal
            haromszogLista.Add(new Haromszog(new Pont3D(0, 0, 1), new Pont3D(0, 1, 1), new Pont3D(0, 1, 1)));
            haromszogLista.Add(new Haromszog(new Pont3D(0, 0, 1), new Pont3D(0, 1, 0), new Pont3D(0, 0, 0)));

            //felső rész
            haromszogLista.Add(new Haromszog(new Pont3D(0, 1, 0), new Pont3D(0, 1, 1), new Pont3D(1, 1, 1)));
            haromszogLista.Add(new Haromszog(new Pont3D(0, 1, 0), new Pont3D(1, 1, 1), new Pont3D(1, 1, 0)));

            //alsó rész
            haromszogLista.Add(new Haromszog(new Pont3D(1, 0, 1), new Pont3D(0, 0, 1), new Pont3D(0, 0, 0)));
            haromszogLista.Add(new Haromszog(new Pont3D(1, 0, 1), new Pont3D(0, 0, 0), new Pont3D(1, 0, 0)));

            return haromszogLista;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            while (true)
            {
                HaromszogRajzolo rajzolo = new HaromszogRajzolo(vaszon);

                foreach (Haromszog haromszog in kocka.HaromszogLista)
                {
                    Haromszog elforgatottHaromszogZ = new Haromszog(haromszog);

                    elforgatottHaromszogZ.P1 = szorzasMatrixPonttal(haromszog.P1, matForgatasZ);
                    elforgatottHaromszogZ.P2 = szorzasMatrixPonttal(haromszog.P2, matForgatasZ);
                    elforgatottHaromszogZ.P3 = szorzasMatrixPonttal(haromszog.P3, matForgatasZ);

                    Haromszog elforgatottHaromszogZX = new Haromszog(elforgatottHaromszogZ);

                    elforgatottHaromszogZX.P1 = szorzasMatrixPonttal(elforgatottHaromszogZ.P1, matForgatasX);
                    elforgatottHaromszogZX.P2 = szorzasMatrixPonttal(elforgatottHaromszogZ.P2, matForgatasX);
                    elforgatottHaromszogZX.P3 = szorzasMatrixPonttal(elforgatottHaromszogZ.P3, matForgatasX);

                    //másolat készítése eltolás elott, melyet eltolunk
                    Haromszog eltoltHaromszog = new Haromszog(elforgatottHaromszogZX);

                    eltoltHaromszog.P1.Z += 3f;
                    eltoltHaromszog.P2.Z += 3f;
                    eltoltHaromszog.P3.Z += 3f;

                    Haromszog kivetiettHaromszog = new Haromszog();

                    kivetiettHaromszog.P1 = szorzasMatrixPonttal(eltoltHaromszog.P1, matVetulet);
                    kivetiettHaromszog.P2 = szorzasMatrixPonttal(eltoltHaromszog.P2, matVetulet);
                    kivetiettHaromszog.P3 = szorzasMatrixPonttal(eltoltHaromszog.P3, matVetulet);


                    kivetiettHaromszog.P1.X *= Width / 2;
                    kivetiettHaromszog.P1.Y *= Height / 2;
                    kivetiettHaromszog.P2.X *= Width / 2;
                    kivetiettHaromszog.P2.Y *= Height / 2;
                    kivetiettHaromszog.P3.X *= Width / 2;
                    kivetiettHaromszog.P3.Y *= Height / 2;

                    kivetiettHaromszog.eltolas(300);


                    rajzolo.rajzolHaromszog(kivetiettHaromszog.P1, kivetiettHaromszog.P2, kivetiettHaromszog.P3);
                    
                }
                System.Threading.Thread.Sleep(100);
            }

        }

        private void vaszon_Paint(object sender, PaintEventArgs e)
        {
        }

    }

}
