using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3dLabirintus.VezerloEsSegedOsztalyok
{
    public class Felhasznalo
    {
        string felhNev;
        string jelszo;
        string emailCim;
        string jog;
        int szint;
        int regioAz;

        public Felhasznalo(string felhNev, string jelszo, string emailCim, string jog, int szint, int regioAz)
        {
            this.felhNev = felhNev;
            this.jelszo = jelszo;
            this.emailCim = emailCim;
            this.jog = jog;
            this.szint = szint;
            this.regioAz = regioAz;
        }

        public string FelhNev { get => felhNev; set => felhNev = value; }
        public string Jelszo { get => jelszo; set => jelszo = value; }
        public string EmailCim { get => emailCim; set => emailCim = value; }
        public string Jog { get => jog; set => jog = value; }
        public int Szint { get => szint; set => szint = value; }
        public int RegioAz { get => regioAz; set => regioAz = value; }
    }
}
