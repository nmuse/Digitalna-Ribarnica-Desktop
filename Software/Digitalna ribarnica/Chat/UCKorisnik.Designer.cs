namespace Chat
{
    partial class UCKorisnik
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucProfilna = new System.Windows.Forms.PictureBox();
            this.ucStatus = new System.Windows.Forms.PictureBox();
            this.ucNaziv = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucProfilna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucStatus)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ucProfilna
            // 
            this.ucProfilna.Location = new System.Drawing.Point(3, 3);
            this.ucProfilna.Name = "ucProfilna";
            this.ucProfilna.Size = new System.Drawing.Size(35, 35);
            this.ucProfilna.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ucProfilna.TabIndex = 0;
            this.ucProfilna.TabStop = false;
            // 
            // ucStatus
            // 
            this.ucStatus.Location = new System.Drawing.Point(202, 15);
            this.ucStatus.Name = "ucStatus";
            this.ucStatus.Size = new System.Drawing.Size(19, 19);
            this.ucStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ucStatus.TabIndex = 1;
            this.ucStatus.TabStop = false;
            // 
            // ucNaziv
            // 
            this.ucNaziv.AutoSize = true;
            this.ucNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ucNaziv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(136)))), ((int)(((byte)(133)))));
            this.ucNaziv.Location = new System.Drawing.Point(44, 15);
            this.ucNaziv.Name = "ucNaziv";
            this.ucNaziv.Size = new System.Drawing.Size(67, 24);
            this.ucNaziv.TabIndex = 6;
            this.ucNaziv.Text = "Naziv:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucProfilna);
            this.panel1.Controls.Add(this.ucNaziv);
            this.panel1.Controls.Add(this.ucStatus);
            this.panel1.Location = new System.Drawing.Point(6, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 46);
            this.panel1.TabIndex = 7;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // UCKorisnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCKorisnik";
            this.Size = new System.Drawing.Size(239, 60);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucProfilna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucStatus)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.PictureBox ucStatus;
        public System.Windows.Forms.PictureBox ucProfilna;
        public System.Windows.Forms.Label ucNaziv;
        private System.Windows.Forms.Panel panel1;
    }
}
