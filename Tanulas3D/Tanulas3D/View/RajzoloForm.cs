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

            float fKozel = 0.1f;
            float fTavol = 1000;
            float fLatoter = 90;
            frissitKeparany();
            float fLatoRad = 1.0f / Math.Tan(fLatoter / 2f).konvertalFloat();
            double kiírszám = 1 / Math.Tan(fLatoter / 2f);

            matVetulet.M[0, 0] = keparany * fLatoRad;
            matVetulet.M[1, 1] = fLatoRad;
            matVetulet.M[2, 2] = fTavol / (fTavol - fKozel);
            matVetulet.M[3, 2] = (-fTavol/fKozel)/(fTavol/fKozel);
            matVetulet.M[2, 3] = 1.0f;
            matVetulet.M[3, 3] = 0.0f;

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
            Graphics grafika = vaszon.CreateGraphics();

            Pen ceruza = new Pen(Color.Black);

            grafika.DrawLine(ceruza, 10, 10, 200, 150);

            grafika.Clear(Color.White);
            vaszon.Invalidate();

            foreach (Haromszog haromszog in kocka.HaromszogLista)
            {
                Haromszog kivetitettHaromszog = new Haromszog(szorozMatrixVektor(haromszog.V1, matVetulet),
                    szorozMatrixVektor(haromszog.V2, matVetulet), szorozMatrixVektor(haromszog.V3, matVetulet));
            }

        }

        private void vaszon_Paint(object sender, PaintEventArgs e)
        {
        }

    }

}
