using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3dLabirintus.AblakOsztalyok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3dLabirintus.AblakOsztalyok.Tests
{
    [TestClass()]
    public class bejelentkezesAblakTests
    {
        [TestMethod()]
        public void vizsgalHosszMegfETestTrue()
        {
            bool expected = true;
            bool actual = AblakOsztalyok.bejelentkezesAblak.vizsgalHosszMegfE("elegHosszuFelhNev");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void vizsgalHosszMegfETestUres()
        {
            bool expected = false;
            bool actual = AblakOsztalyok.bejelentkezesAblak.vizsgalHosszMegfE("");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void vizsgalHosszMegfETestFalse()
        {
            bool expected = false;
            bool actual = AblakOsztalyok.bejelentkezesAblak.vizsgalHosszMegfE("as");
            Assert.AreEqual(expected, actual);
        }
    }
}