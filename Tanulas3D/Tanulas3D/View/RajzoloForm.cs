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

namespace Tanulas3D
{
    public partial class Form1 : Form
    {
        Alakzat kocka;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vaszon.BackColor = Color.White;

            elokeszuletek();

        }

        private void elokeszuletek()
        {

            kocka = new Alakzat(keszitKocka());

            vaszon.Invalidate();
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

            grafika.Clear();

        }

        private void vaszon_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
