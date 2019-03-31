using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _3dLabirintus.AblakOsztalyok
{
    class AdatbazisKezelo
    {
        MySqlConnection csatlakozas;
        MySqlCommand parancs;
        MySqlDataReader tabla;

        public AdatbazisKezelo(string server = "127.0.0.1")
        {
            csatlakozas = new MySqlConnection("server=" + server + ";uid=root;" + "pwd=;"+
                "database=lab3d");
            csatlakozas.Open();
        }

        public void bejelentkezes(string felhNev, string jelszo)
        {
            parancs = new MySqlCommand("", csatlakozas);
            parancs.CommandText = "SELECT * FROM accountok";
            tabla = parancs.ExecuteReader();
        }

        public void bezaras()
        {
            csatlakozas.Close();
        }

    }
}
