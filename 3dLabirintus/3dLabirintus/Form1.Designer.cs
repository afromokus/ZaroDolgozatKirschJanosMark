﻿namespace _3dLabirintus
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonJatekStart = new System.Windows.Forms.Button();
            this.buttonOnlineMod = new System.Windows.Forms.Button();
            this.buttonBeallitasok = new System.Windows.Forms.Button();
            this.buttonKilepes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonJatekStart
            // 
            this.buttonJatekStart.Location = new System.Drawing.Point(275, 83);
            this.buttonJatekStart.Name = "buttonJatekStart";
            this.buttonJatekStart.Size = new System.Drawing.Size(240, 23);
            this.buttonJatekStart.TabIndex = 0;
            this.buttonJatekStart.Text = "Játék indítása";
            this.buttonJatekStart.UseVisualStyleBackColor = true;
            this.buttonJatekStart.Click += new System.EventHandler(this.buttonJatekStart_Click);
            // 
            // buttonOnlineMod
            // 
            this.buttonOnlineMod.Location = new System.Drawing.Point(275, 138);
            this.buttonOnlineMod.Name = "buttonOnlineMod";
            this.buttonOnlineMod.Size = new System.Drawing.Size(240, 23);
            this.buttonOnlineMod.TabIndex = 1;
            this.buttonOnlineMod.Text = "Online - mód";
            this.buttonOnlineMod.UseVisualStyleBackColor = true;
            this.buttonOnlineMod.Click += new System.EventHandler(this.buttonOnlineMod_Click);
            // 
            // buttonBeallitasok
            // 
            this.buttonBeallitasok.Location = new System.Drawing.Point(275, 193);
            this.buttonBeallitasok.Name = "buttonBeallitasok";
            this.buttonBeallitasok.Size = new System.Drawing.Size(240, 23);
            this.buttonBeallitasok.TabIndex = 2;
            this.buttonBeallitasok.Text = "Beállítások";
            this.buttonBeallitasok.UseVisualStyleBackColor = true;
            // 
            // buttonKilepes
            // 
            this.buttonKilepes.Location = new System.Drawing.Point(275, 247);
            this.buttonKilepes.Name = "buttonKilepes";
            this.buttonKilepes.Size = new System.Drawing.Size(240, 23);
            this.buttonKilepes.TabIndex = 3;
            this.buttonKilepes.Text = "Kilépés";
            this.buttonKilepes.UseVisualStyleBackColor = true;
            this.buttonKilepes.Click += new System.EventHandler(this.buttonKilepes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonOnlineMod);
            this.Controls.Add(this.buttonKilepes);
            this.Controls.Add(this.buttonBeallitasok);
            this.Controls.Add(this.buttonJatekStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonJatekStart;
        private System.Windows.Forms.Button buttonOnlineMod;
        private System.Windows.Forms.Button buttonBeallitasok;
        private System.Windows.Forms.Button buttonKilepes;
    }
}

