namespace _3dLabirintus.AblakOsztalyok
{
    partial class bejelentkezesAblak
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFelhNev = new System.Windows.Forms.TextBox();
            this.textBoxJelszo = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButtonIP = new System.Windows.Forms.RadioButton();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Felhasználónév:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jelszó:";
            // 
            // textBoxFelhNev
            // 
            this.textBoxFelhNev.Location = new System.Drawing.Point(155, 58);
            this.textBoxFelhNev.Name = "textBoxFelhNev";
            this.textBoxFelhNev.Size = new System.Drawing.Size(166, 20);
            this.textBoxFelhNev.TabIndex = 2;
            // 
            // textBoxJelszo
            // 
            this.textBoxJelszo.Location = new System.Drawing.Point(155, 120);
            this.textBoxJelszo.Name = "textBoxJelszo";
            this.textBoxJelszo.Size = new System.Drawing.Size(166, 20);
            this.textBoxJelszo.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(196, 283);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(34, 181);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(160, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Csatlakozás helyi szerverhez";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButtonIP
            // 
            this.radioButtonIP.AutoSize = true;
            this.radioButtonIP.Location = new System.Drawing.Point(241, 181);
            this.radioButtonIP.Name = "radioButtonIP";
            this.radioButtonIP.Size = new System.Drawing.Size(108, 17);
            this.radioButtonIP.TabIndex = 6;
            this.radioButtonIP.TabStop = true;
            this.radioButtonIP.Text = "IP-cím megadása";
            this.radioButtonIP.UseVisualStyleBackColor = true;
            this.radioButtonIP.CheckedChanged += new System.EventHandler(this.radioButtonIP_CheckedChanged);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(221, 223);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(158, 20);
            this.textBoxIP.TabIndex = 7;
            this.textBoxIP.TextChanged += new System.EventHandler(this.textBoxIP_TextChanged);
            // 
            // bejelentkezesAblak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 338);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.radioButtonIP);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxJelszo);
            this.Controls.Add(this.textBoxFelhNev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "bejelentkezesAblak";
            this.Text = "bejelentkezesAblak";
            this.Load += new System.EventHandler(this.bejelentkezesAblak_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFelhNev;
        private System.Windows.Forms.TextBox textBoxJelszo;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButtonIP;
        private System.Windows.Forms.TextBox textBoxIP;
    }
}