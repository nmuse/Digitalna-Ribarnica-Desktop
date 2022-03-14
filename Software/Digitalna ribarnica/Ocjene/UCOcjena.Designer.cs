namespace Ocjene
{
    partial class UCOcjena
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
            this.rtbxOpis = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucNaziv = new System.Windows.Forms.Label();
            this.ucOcjenaSlike = new System.Windows.Forms.PictureBox();
            this.ucProfilna = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucOcjenaSlike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucProfilna)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbxOpis
            // 
            this.rtbxOpis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.rtbxOpis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.rtbxOpis.Location = new System.Drawing.Point(82, 47);
            this.rtbxOpis.Name = "rtbxOpis";
            this.rtbxOpis.ReadOnly = true;
            this.rtbxOpis.Size = new System.Drawing.Size(412, 39);
            this.rtbxOpis.TabIndex = 4;
            this.rtbxOpis.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ucNaziv);
            this.groupBox1.Controls.Add(this.ucOcjenaSlike);
            this.groupBox1.Controls.Add(this.ucProfilna);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 89);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // ucID
            // 
            this.ucID.AutoSize = true;
            this.ucID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(136)))), ((int)(((byte)(133)))));
            this.ucID.Location = new System.Drawing.Point(456, 9);
            this.ucID.Name = "ucID";
            this.ucID.Size = new System.Drawing.Size(35, 13);
            this.ucID.TabIndex = 3;
            this.ucID.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(136)))), ((int)(((byte)(133)))));
            this.label2.Location = new System.Drawing.Point(307, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(136)))), ((int)(((byte)(133)))));
            this.label1.Location = new System.Drawing.Point(285, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "/";
            // 
            // ucNaziv
            // 
            this.ucNaziv.AutoSize = true;
            this.ucNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ucNaziv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(136)))), ((int)(((byte)(133)))));
            this.ucNaziv.Location = new System.Drawing.Point(241, 14);
            this.ucNaziv.Name = "ucNaziv";
            this.ucNaziv.Size = new System.Drawing.Size(38, 24);
            this.ucNaziv.TabIndex = 2;
            this.ucNaziv.Text = "5.5";
            // 
            // ucOcjenaSlike
            // 
            this.ucOcjenaSlike.Location = new System.Drawing.Point(80, 11);
            this.ucOcjenaSlike.Name = "ucOcjenaSlike";
            this.ucOcjenaSlike.Size = new System.Drawing.Size(155, 27);
            this.ucOcjenaSlike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ucOcjenaSlike.TabIndex = 1;
            this.ucOcjenaSlike.TabStop = false;
            // 
            // ucProfilna
            // 
            this.ucProfilna.Location = new System.Drawing.Point(6, 9);
            this.ucProfilna.Name = "ucProfilna";
            this.ucProfilna.Size = new System.Drawing.Size(67, 74);
            this.ucProfilna.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ucProfilna.TabIndex = 0;
            this.ucProfilna.TabStop = false;
            // 
            // UCOcjena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbxOpis);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCOcjena";
            this.Size = new System.Drawing.Size(504, 94);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucOcjenaSlike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucProfilna)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox rtbxOpis;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label ucID;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label ucNaziv;
        public System.Windows.Forms.PictureBox ucOcjenaSlike;
        public System.Windows.Forms.PictureBox ucProfilna;
    }
}
