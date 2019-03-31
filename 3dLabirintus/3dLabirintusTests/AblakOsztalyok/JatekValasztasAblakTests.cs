using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3dLabirintus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _3dLabirintus.Tests
{
    [TestClass()]
    public class JatekValasztasAblakTests
    {
        [TestMethod()]
        public void jatekFuttatasTestMukodo()
        {
            bool expected = true;
            try
            {
                string alkNev = "Labirintus";
                bool actual = JatekValasztasAblak.jatekFuttatas("..\\..\\..\\3dLabirintus/bin/debug/" +
                    alkNev);
                if (actual)
                {
                    Process[] folyamatok = Process.GetProcessesByName(alkNev);
                    folyamatok[0].Kill();
                }
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void jatekFuttatasTestRandom()
        {
            bool expected = false;
            try
            {
                string alkNev = "asdfas";
                bool actual = JatekValasztasAblak.jatekFuttatas("..\\..\\..\\3dLabirintus/bin/debug/" +
                    alkNev);
                if (actual)
                {
                    Process[] folyamatok = Process.GetProcessesByName(alkNev);
                    folyamatok[0].Kill();
                }
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                
            }
        }
    }
}