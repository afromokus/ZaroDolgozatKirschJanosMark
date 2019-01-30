namespace _3dLabirintus
{
    partial class JatekValasztasAblak
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
            this.buttonUjJatek = new System.Windows.Forms.Button();
            this.buttonBetoltes = new System.Windows.Forms.Button();
            this.buttonVissza = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonUjJatek
            // 
            this.buttonUjJatek.Location = new System.Drawing.Point(45, 44);
            this.buttonUjJatek.Name = "buttonUjJatek";
            this.buttonUjJatek.Size = new System.Drawing.Size(125, 23);
            this.buttonUjJatek.TabIndex = 0;
            this.buttonUjJatek.Text = "Új játék";
            this.buttonUjJatek.UseVisualStyleBackColor = true;
            this.buttonUjJatek.Click += new System.EventHandler(this.buttonUjJatek_Click);
            // 
            // buttonBetoltes
            // 
            this.buttonBetoltes.Location = new System.Drawing.Point(45, 84);
            this.buttonBetoltes.Name = "buttonBetoltes";
            this.buttonBetoltes.Size = new System.Drawing.Size(125, 23);
            this.buttonBetoltes.TabIndex = 1;
            this.buttonBetoltes.Text = "Betöltés";
            this.buttonBetoltes.UseVisualStyleBackColor = true;
            // 
            // buttonVissza
            // 
            this.buttonVissza.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonVissza.Location = new System.Drawing.Point(45, 237);
            this.buttonVissza.Name = "buttonVissza";
            this.buttonVissza.Size = new System.Drawing.Size(125, 23);
            this.buttonVissza.TabIndex = 2;
            this.buttonVissza.Text = "Vissza";
            this.buttonVissza.UseVisualStyleBackColor = true;
            // 
            // JatekValasztasAblak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 346);
            this.Controls.Add(this.buttonVissza);
            this.Controls.Add(this.buttonBetoltes);
            this.Controls.Add(this.buttonUjJatek);
            this.Name = "JatekValasztasAblak";
            this.Text = "JatekValasztasAblak";
            this.Load += new System.EventHandler(this.JatekValasztasAblak_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonUjJatek;
        private System.Windows.Forms.Button buttonBetoltes;
        private System.Windows.Forms.Button buttonVissza;
    }
}