namespace Ponude
{
    partial class OcijeniKorisnika
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOcjeni = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbxOpis = new System.Windows.Forms.RichTextBox();
            this.ucKolicina = new System.Windows.Forms.Label();
            this.cmbOcjena = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOcjeni);
            this.groupBox1.Controls.Add(this.btnOdustani);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rtbxOpis);
            this.groupBox1.Controls.Add(this.ucKolicina);
            this.groupBox1.Controls.Add(this.cmbOcjena);
            this.groupBox1.Location = new System.Drawing.Point(257, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnOcjeni
            // 
            this.btnOcjeni.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOcjeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOcjeni.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOcjeni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(153)))), ((int)(((byte)(106)))));
            this.btnOcjeni.Location = new System.Drawing.Point(92, 128);
            this.btnOcjeni.Name = "btnOcjeni";
            this.btnOcjeni.Size = new System.Drawing.Size(102, 40);
            this.btnOcjeni.TabIndex = 33;
            this.btnOcjeni.Text = "Ocijeni";
            this.btnOcjeni.UseVisualStyleBackColor = true;
            this.btnOcjeni.Click += new System.EventHandler(this.btnOcjeni_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdustani.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOdustani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(153)))), ((int)(((byte)(106)))));
            this.btnOdustani.Location = new System.Drawing.Point(200, 128);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(86, 40);
            this.btnOdustani.TabIndex = 34;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(161)))), ((int)(((byte)(141)))));
            this.label5.Location = new System.Drawing.Point(11, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Komentar";
            // 
            // rtbxOpis
            // 
            this.rtbxOpis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.rtbxOpis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.rtbxOpis.Location = new System.Drawing.Point(69, 55);
            this.rtbxOpis.Name = "rtbxOpis";
            this.rtbxOpis.Size = new System.Drawing.Size(279, 67);
            this.rtbxOpis.TabIndex = 31;
            this.rtbxOpis.Text = "";
            // 
            // ucKolicina
            // 
            this.ucKolicina.AutoSize = true;
            this.ucKolicina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(161)))), ((int)(((byte)(141)))));
            this.ucKolicina.Location = new System.Drawing.Point(71, 31);
            this.ucKolicina.Name = "ucKolicina";
            this.ucKolicina.Size = new System.Drawing.Size(41, 13);
            this.ucKolicina.TabIndex = 30;
            this.ucKolicina.Text = "Ocjena";
            // 
            // cmbOcjena
            // 
            this.cmbOcjena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.cmbOcjena.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.cmbOcjena.FormattingEnabled = true;
            this.cmbOcjena.Location = new System.Drawing.Point(131, 28);
            this.cmbOcjena.Name = "cmbOcjena";
            this.cmbOcjena.Size = new System.Drawing.Size(121, 21);
            this.cmbOcjena.TabIndex = 29;
            // 
            // OcijeniKorisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(816, 294);
            this.Controls.Add(this.groupBox1);
            this.Name = "OcijeniKorisnika";
            this.Text = "OcijeniKorisnika";
            this.Load += new System.EventHandler(this.OcijeniKorisnika_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label ucKolicina;
        public System.Windows.Forms.ComboBox cmbOcjena;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbxOpis;
        private System.Windows.Forms.Button btnOcjeni;
        private System.Windows.Forms.Button btnOdustani;
    }
}