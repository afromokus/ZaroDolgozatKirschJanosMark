﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace _3dLabirintus
{
    public partial class Form1 : Form
    {
        #region deklarálás, alapértékek, inícializálás
        
        KeyEventHandler kilepesEsemenyKezelo;

        JatekValasztasAblak valasztasAblak;
        

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region betöltés

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "3D Labirintus";

            kilepesEsemenyKezelo = new KeyEventHandler(kilepes);

            buttonJatekStart.BackColor = BackColor;
            buttonJatekStart.FlatStyle = FlatStyle.Flat;
            buttonJatekStart.FlatAppearance.BorderSize = 0;

            foGombokraKilepesEsemny();
            

        }

        private void foGombokraKilepesEsemny()
        {
            buttonJatekStart.KeyDown += kilepesEsemenyKezelo;
            buttonOnlineMod.KeyDown += kilepesEsemenyKezelo;
            buttonBeallitasok.KeyDown += kilepesEsemenyKezelo;
            buttonKilepes.KeyDown += kilepesEsemenyKezelo;
        }

        private void kilepes(object sender, KeyEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        #region gombok metódusai

        private void buttonOnlineMod_Click(object sender, EventArgs e)
        {

        }

        private void buttonKilepes_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonJatekStart_Click(object sender, EventArgs e)
        {
            Focus();

            valasztasAblak = new JatekValasztasAblak();
            valasztasAblak.Left = Left;
            valasztasAblak.Top = Top;
            Hide();
            if (valasztasAblak.ShowDialog() == DialogResult.Cancel)
            {
                Show();
            }
        }

        #endregion






        #region fel nem használt kód
        public static double tavolsagSzamitasa(Pont elsoPont, Pont masodikPont)
        {
            return Math.Sqrt(Math.Pow((elsoPont.getX() - masodikPont.getX()), 2)
                + Math.Pow((elsoPont.getY() - masodikPont.getY()), 2));
        }

        #endregion

    }
}
