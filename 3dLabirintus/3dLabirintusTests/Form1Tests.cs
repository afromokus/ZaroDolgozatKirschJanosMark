using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3dLabirintus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3dLabirintus.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void tavolsagSzamitasaTest()
        {
            Pont elsoPont = new Pont(-1, 3);
            Pont masodikPont = new Pont(-3, 1);

            double tavolsag = Math.Round(Form1.tavolsagSzamitasa(elsoPont, masodikPont),13);

            Assert.AreEqual(tavolsag, 2.8284271247462);
            
            

        }
    }
}