namespace _3dLabirintus.AblakOsztalyok
{
    partial class OnlineAblak
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
            this.labelUdvozlo = new System.Windows.Forms.Label();
            this.labelVisszajelzo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUdvozlo
            // 
            this.labelUdvozlo.AutoSize = true;
            this.labelUdvozlo.Location = new System.Drawing.Point(22, 23);
            this.labelUdvozlo.Name = "labelUdvozlo";
            this.labelUdvozlo.Size = new System.Drawing.Size(66, 13);
            this.labelUdvozlo.TabIndex = 0;
            this.labelUdvozlo.Text = "Üdvözöljük !";
            // 
            // labelVisszajelzo
            // 
            this.labelVisszajelzo.AutoSize = true;
            this.labelVisszajelzo.Location = new System.Drawing.Point(22, 78);
            this.labelVisszajelzo.Name = "labelVisszajelzo";
            this.labelVisszajelzo.Size = new System.Drawing.Size(63, 13);
            this.labelVisszajelzo.TabIndex = 1;
            this.labelVisszajelzo.Text = "Visszajelzés";
            // 
            // OnlineAblak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.labelVisszajelzo);
            this.Controls.Add(this.labelUdvozlo);
            this.Name = "OnlineAblak";
            this.Text = "OnlineAblak";
            this.Load += new System.EventHandler(this.OnlineAblak_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUdvozlo;
        private System.Windows.Forms.Label labelVisszajelzo;
    }
}