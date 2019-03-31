using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using _3dLabirintus.VezerloEsSegedOsztalyok;

namespace _3dLabirintus.AblakOsztalyok
{
    class AdatbazisKezelo
    {
        MySqlConnection csatlakozas;
        MySqlCommand parancs;
        MySqlDataReader tabla;

        public AdatbazisKezelo(string server = "127.0.0.1")
        {
            string felhNev = "root";
            string jelszo = "";

            if (server == "")
            {
                server = "127.0.0.1";
            }

            csatlakozas = new MySqlConnection("server=" + server + ";uid=" + felhNev +";" + 
                "pwd="+ jelszo +";"+ "database=lab3d");
            try
            {
                csatlakozas.Open();
            }
            catch
            {
            }
        }

        public Felhasznalo bejelentkezes(string felhNev, string jelszo)
        {
            Felhasznalo bejelFelh;
            if (csatlakozas.State.ToString() == "Open")
            {
                parancs = new MySqlCommand("", csatlakozas);
                parancs.CommandText = "SELECT * FROM accountok";
                tabla = parancs.ExecuteReader();

                while (tabla.Read())
                {
                    if (felhNev == tabla.GetString("felhNev") && jelszo == tabla.GetString("jelszo"))
                    {
                        bejelFelh = new Felhasznalo(tabla.GetString("felhNev"), tabla.GetString("jelszo"),
                            tabla.GetString("email_cim"), tabla.GetString("jog"),tabla.GetInt32("szint"),
                            tabla.GetInt32("regio_az"));
                        tabla.Close();
                        return bejelFelh;
                    }
                }

                tabla.Close();
                return null;
            }
            else
            {
                throw new Exception("Sikertelen adatbázis megnyitás miatt a bejelentkezés nem " +
                    "ellenőrizhető!");
            }

        }

        public void bezaras()
        {
            if (csatlakozas.State.ToString() == "Open")
            {
                csatlakozas.Close();
            }
        }

    }
}
