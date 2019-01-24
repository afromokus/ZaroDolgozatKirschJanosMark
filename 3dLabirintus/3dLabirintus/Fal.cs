using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _3dLabirintus
{
    class Fal : PictureBox
    {

        public Fal(int szemBal, int szemtav, int latoter, int latoSzel)
        {
            BackColor = Color.Gray;
            Top = 150;

            Left = latoter / latoSzel * szemBal;
            #region magyarázat
            /*MessageBox.Show("Képernyőszélesség: " + latoter + "px\nEgyszerre látható mezők száma: " + latoSzel +
                " db\nVízszintes eltolás játékoshoz képest: " + szemBal + " egység\nTávolság játékostól: " +
                szemtav);*/
            #endregion

            Height = Convert.ToInt32(300 / Math.Pow(1.5, szemtav));
            Width = Height;

            //MessageBox.Show("Baloldal: " + Left + "\nTető: " + Top + "\nMagasság és szélesség: " + Height);

        }

        public Fal(bool oldalE)
        {
            BackColor = Color.Gray;

            Width = 80;

        }

    }
}
