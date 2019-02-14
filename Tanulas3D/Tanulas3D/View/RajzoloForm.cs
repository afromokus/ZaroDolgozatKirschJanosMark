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
using Tanulas3D.Model.Pontok;
using Tanulas3D.Model.Haromszogek;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
        float forgatas;


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

            ki.setX(be.getX() * m.M[0, 0] + be.getY() * m.M[1, 0] + be.getZ() * m.M[2, 0] + m.M[3, 0]);
            ki.setY(be.getY() * m.M[0, 1] + be.getY() * m.M[1, 1] + be.getZ() * m.M[2, 1] + m.M[3, 1]);
            ki.setZ(be.getZ() * m.M[0, 2] + be.getZ() * m.M[1, 2] + be.getZ() * m.M[2, 2] + m.M[3, 2]);
            float w = be.getZ() * m.M[0, 3] + be.getZ() * m.M[1, 3] + be.getZ() * m.M[2, 3] + m.M[3, 3];

            if (w != 0)
            {
                ki.setX(ki.getX() / w);
                ki.setY(ki.getY() / w);
                ki.setZ(ki.getZ() / w);
            }

            return ki;
        }

        private void elokeszuletek()
        {

            kocka = new Alakzat(keszitKockaAlaphelyzet());

            fKozel = 0.1f;
            fTavol = 1000;
            fLatoter = 90;
            frissitKeparany();
            fLatoRad = 1.0f / Math.Tan(fLatoter / 2f).konvertalFloat();
            frissitKeparany();
            q = fTavol / (fKozel - fTavol);
            forgatas = 1f;

            //matVetulet
            matVetulet.M[0, 0] = keparany * fLatoRad;
            matVetulet.M[1, 1] = fLatoRad;
            matVetulet.M[2, 2] = q;
            matVetulet.M[2, 3] = 1f;
            matVetulet.M[3, 3] = 0f;

            //forgatás z
            matForgatasX.M[0, 0] = 1f;
            matForgatasX.M[1, 1] = Math.Cos(forgatas / 2).konvertalFloat();
            matForgatasX.M[1, 2] = Math.Sin(forgatas / 2).konvertalFloat();
            matForgatasX.M[2, 1] = -Math.Sin(forgatas / 2).konvertalFloat();
            matForgatasX.M[2, 2] = Math.Cos(forgatas / 2).konvertalFloat();
            matForgatasX.M[3, 3] = 1f;

            //forgatás x
            matForgatasZ.M[0, 0] = 1f;
            matForgatasZ.M[1, 1] = Math.Cos(forgatas / 2).konvertalFloat();
            matForgatasZ.M[1, 2] = Math.Sin(forgatas / 2).konvertalFloat();
            matForgatasZ.M[2, 1] = - Math.Sin(forgatas / 2).konvertalFloat();
            matForgatasZ.M[2, 2] = Math.Cos(forgatas / 2).konvertalFloat();
            matForgatasZ.M[3, 3] = 1f;


        }
        private List<Haromszog> keszitKockaAlaphelyzet()
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
            int i = 0;
            int kockakSzama = 0;
            HaromszogRajzolo rajzolo = new HaromszogRajzolo(vaszon);
            Haromszog kivetiettHaromszog;
            Haromszog eltoltHaromszog;
            Haromszog elforgatottHaromszogZ;
            Haromszog elforgatottHaromszogZX;


            

                for (i = 0; i < kocka.HaromszogLista.Count; i++)
                {

                eltoltHaromszog = new Haromszog();
                eltoltHaromszog = Clone<Haromszog>(kocka.HaromszogLista[i]);
                

                MessageBox.Show("Eredeti háromszög:\n" + kocka.HaromszogLista[i]);

                eltoltHaromszog.eltolZTengelyen(1f);

                kivetiettHaromszog = new Haromszog();
                    kivetiettHaromszog.setPont1(szorzasMatrixPonttal(eltoltHaromszog.getPont1(), matVetulet));
                    kivetiettHaromszog.setPont2(szorzasMatrixPonttal(eltoltHaromszog.getPont2(), matVetulet));
                    kivetiettHaromszog.setPont3(szorzasMatrixPonttal(eltoltHaromszog.getPont3(), matVetulet));

                kivetiettHaromszog.hozzaadXY(1f);

                kivetiettHaromszog.novelesKepernyore((float)Width, (float)Height);

                MessageBox.Show("Eredeti háromszög ismét:\n" + kocka.HaromszogLista[i] + "\nEltolt háromszög:\n" + eltoltHaromszog);

                rajzolo.rajzolHaromszog(kivetiettHaromszog);

                }

        }

        float normalOsztasHaNullaEgyel(float osztando, float oszto)
        {
            if (oszto != 0)
            {
                return osztando / oszto;
            }
            else
            {
                return osztando;
            }
        }

        private void vaszon_Paint(object sender, PaintEventArgs e)
        {
        }

        public static T Clone<T>(T masolando)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, masolando);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }

}
