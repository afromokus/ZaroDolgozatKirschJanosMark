using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3dLabirintus
{
    public class Pont
    {
        double x = 0;
        double y = 0;

        public Pont(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void setX(double x)
        {
            this.x = x;
        }

        public double getX()
        {
            return x;
        }

        public void setY(double y)
        {
            this.y = y;
        }

        public double getY()
        {
            return y;
        }

    }
}
