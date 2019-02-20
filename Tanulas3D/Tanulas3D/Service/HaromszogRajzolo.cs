using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Tanulas3D.Model;
using Tanulas3D.Model.Pontok;

namespace Tanulas3D.Service
{
    class HaromszogRajzolo
    {
        Graphics grafika;
        Pen ceruza;

        private Panel vaszon;

        public HaromszogRajzolo(Panel vaszon)
        {
            this.vaszon = vaszon;

            grafika = vaszon.CreateGraphics();

            ceruza = new Pen(Color.Black);
        }

        public void rajzolHaromszog(Haromszog h3D)
        {
            try
            {
                grafika.DrawLine(ceruza, h3D.getPont1().getX(), h3D.getPont1().getY(), h3D.getPont2().getX(), h3D.getPont2().getY());
                grafika.DrawLine(ceruza, h3D.getPont2().getX(), h3D.getPont2().getY(), h3D.getPont3().getX(), h3D.getPont3().getY());
                grafika.DrawLine(ceruza, h3D.getPont3().getX(), h3D.getPont3().getY(), h3D.getPont1().getX(), h3D.getPont1().getY());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void rajzolHaromszog(Haromszog2D h2D)
        {
            grafika.DrawLine(ceruza, h2D.P1.X, h2D.P1.Y, h2D.P2.X, h2D.P2.Y);
            grafika.DrawLine(ceruza, h2D.P2.X, h2D.P2.Y, h2D.P3.X, h2D.P3.Y);
            grafika.DrawLine(ceruza, h2D.P3.X, h2D.P3.Y, h2D.P1.X, h2D.P1.Y);
        }

        public void rajzolHaromszog(Pont2D p1, Pont2D p2, Pont2D p3)
        {

            grafika.DrawLine(ceruza, p1.X, p1.Y, p2.X, p2.Y);
            grafika.DrawLine(ceruza, p2.X, p2.Y, p3.X, p3.Y);
            grafika.DrawLine(ceruza, p3.X, p3.Y, p1.X, p1.Y);

        }

        public void rajzolHaromszog(Pont3D p1, Pont3D p2, Pont3D p3)
        {


            grafika.DrawLine(ceruza, p1.getX(), p1.getY(), p2.getX(), p2.getY());
            grafika.DrawLine(ceruza, p2.getX(), p2.getY(), p3.getX(), p3.getY());
            grafika.DrawLine(ceruza, p3.getX(), p3.getY(), p1.getX(), p1.getY());

        }

        public void tisztitas()
        {
            grafika.Clear(Color.White);
        }

    }
}
