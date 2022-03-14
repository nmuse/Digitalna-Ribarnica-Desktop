namespace Chat
{
    partial class UCPoruka
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucDatum = new System.Windows.Forms.Label();
            this.rtbxOpis = new System.Windows.Forms.RichTextBox();
            this.ucProfilna = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ucProfilna)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDatum
            // 
            this.ucDatum.AutoSize = true;
            this.ucDatum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(136)))), ((int)(((byte)(133)))));
            this.ucDatum.Location = new System.Drawing.Point(10, 61);
            this.ucDatum.Name = "ucDatum";
            this.ucDatum.Size = new System.Drawing.Size(37, 13);
            this.ucDatum.TabIndex = 9;
            this.ucDatum.Text = "Naziv:";
            // 
            // rtbxOpis
            // 
            this.rtbxOpis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.rtbxOpis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.rtbxOpis.Location = new System.Drawing.Point(51, 11);
            this.rtbxOpis.Name = "rtbxOpis";
            this.rtbxOpis.Size = new System.Drawing.Size(314, 47);
            this.rtbxOpis.TabIndex = 8;
            this.rtbxOpis.Text = "";
            // 
            // ucProfilna
            // 
            this.ucProfilna.Location = new System.Drawing.Point(10, 16);
            this.ucProfilna.Name = "ucProfilna";
            this.ucProfilna.Size = new System.Drawing.Size(35, 35);
            this.ucProfilna.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ucProfilna.TabIndex = 7;
            this.ucProfilna.TabStop = false;
            // 
            // UCPoruka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucDatum);
            this.Controls.Add(this.rtbxOpis);
            this.Controls.Add(this.ucProfilna);
            this.Name = "UCPoruka";
            this.Size = new System.Drawing.Size(374, 84);
            ((System.ComponentModel.ISupportInitialize)(this.ucProfilna)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label ucDatum;
        public System.Windows.Forms.RichTextBox rtbxOpis;
        public System.Windows.Forms.PictureBox ucProfilna;
    }
}
