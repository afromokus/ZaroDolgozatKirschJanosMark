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
            keparany = Height / Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vaszon.BackColor = Color.White;
            matVetulet = new Mat4x4();
            elokeszuletek();

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

        }

        Vektor3D szorozMatrixVektor(Vektor3D be, Mat4x4 mat)
        {
            Vektor3D ki = new Vektor3D(be.X*mat.M[0, 0], be.Y * mat.M[1, 1], be.Z * mat.M[2, 2]);
            float w = mat.M[2, 3];

            if (w != 0f)
            {
                ki.X /= w;
                ki.Y /= w;
                ki.Z /= w;
            }

            return ki;
        }

        private List<Haromszog> keszitKocka()
        {

            List<Haromszog> haromszogLista = new List<Haromszog>();

            //elülső rész
            haromszogLista.Add(new Haromszog(new Vektor3D(0, 0, 0), new Vektor3D(0, 1, 0), new Vektor3D(1, 1, 0)));
            haromszogLista.Add(new Haromszog(new Vektor3D(0, 0, 0), new Vektor3D(1, 1, 0), new Vektor3D(1, 0, 0)));

            //jobb oldal
            haromszogLista.Add(new Haromszog(new Vektor3D(1, 0, 0), new Vektor3D(1, 1, 0), new Vektor3D(1, 1, 1)));
            haromszogLista.Add(new Haromszog(new Vektor3D(1, 0, 0), new Vektor3D(1, 1, 1), new Vektor3D(1, 0, 1)));

            //hátsó rész
            haromszogLista.Add(new Haromszog(new Vektor3D(1, 0, 1), new Vektor3D(1, 1, 1), new Vektor3D(0, 0, 1)));
            haromszogLista.Add(new Haromszog(new Vektor3D(1, 0, 1), new Vektor3D(0, 1, 1), new Vektor3D(0, 0, 1)));

            //bal oldal
            haromszogLista.Add(new Haromszog(new Vektor3D(0, 0, 1), new Vektor3D(0, 1, 1), new Vektor3D(0, 1, 1)));
            haromszogLista.Add(new Haromszog(new Vektor3D(0, 0, 1), new Vektor3D(0, 1, 0), new Vektor3D(0, 0, 0)));

            //felső rész
            haromszogLista.Add(new Haromszog(new Vektor3D(0, 1, 0), new Vektor3D(0, 1, 1), new Vektor3D(1, 1, 1)));
            haromszogLista.Add(new Haromszog(new Vektor3D(0, 1, 0), new Vektor3D(1, 1, 1), new Vektor3D(1, 1, 0)));

            //alsó rész
            haromszogLista.Add(new Haromszog(new Vektor3D(1, 0, 1), new Vektor3D(0, 0, 1), new Vektor3D(0, 0, 0)));
            haromszogLista.Add(new Haromszog(new Vektor3D(1, 0, 1), new Vektor3D(0, 0, 0), new Vektor3D(1, 0, 0)));

            return haromszogLista;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            HaromszogRajzolo rajzolo = new HaromszogRajzolo(vaszon);

            foreach (Haromszog haromszog in kocka.HaromszogLista)
            {
                /*haromszog.felulIrHaromszog(konvertalHaromszog2D(haromszog));

                haromszog.V1.X *= Width / 5;
                haromszog.V1.Y *= Height / 5;
                haromszog.V2.X *= Width / 5;
                haromszog.V2.Y *= Height / 5;
                haromszog.V3.X *= Width / 5;
                haromszog.V3.Y *= Height / 5;
                

                rajzolo.rajzolHaromszog(haromszog);*/
            }

        }

        private void vaszon_Paint(object sender, PaintEventArgs e)
        {
        }

    }

}
