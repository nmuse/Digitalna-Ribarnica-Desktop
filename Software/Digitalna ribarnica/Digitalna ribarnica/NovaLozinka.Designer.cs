namespace Digitalna_ribarnica
{
    partial class NovaLozinka
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NovaLozinka));
            this.txtPonoviLozinku = new System.Windows.Forms.TextBox();
            this.txtLozinka = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNovaLozinka = new System.Windows.Forms.Label();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.buttonPotvrdi = new System.Windows.Forms.Button();
            this.notifyPromijeni = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPonoviLozinku
            // 
            this.txtPonoviLozinku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(145)))), ((int)(((byte)(112)))));
            this.txtPonoviLozinku.ForeColor = System.Drawing.SystemColors.Window;
            this.txtPonoviLozinku.Location = new System.Drawing.Point(157, 56);
            this.txtPonoviLozinku.Name = "txtPonoviLozinku";
            this.txtPonoviLozinku.Size = new System.Drawing.Size(119, 20);
            this.txtPonoviLozinku.TabIndex = 21;
            // 
            // txtLozinka
            // 
            this.txtLozinka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(132)))), ((int)(((byte)(121)))));
            this.txtLozinka.ForeColor = System.Drawing.SystemColors.Window;
            this.txtLozinka.Location = new System.Drawing.Point(157, 23);
            this.txtLozinka.Name = "txtLozinka";
            this.txtLozinka.Size = new System.Drawing.Size(119, 20);
            this.txtLozinka.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(145)))), ((int)(((byte)(112)))));
            this.label4.Location = new System.Drawing.Point(18, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Ponovi lozinku";
            // 
            // labelNovaLozinka
            // 
            this.labelNovaLozinka.AutoSize = true;
            this.labelNovaLozinka.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNovaLozinka.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(132)))), ((int)(((byte)(121)))));
            this.labelNovaLozinka.Location = new System.Drawing.Point(30, 21);
            this.labelNovaLozinka.Name = "labelNovaLozinka";
            this.labelNovaLozinka.Size = new System.Drawing.Size(103, 20);
            this.labelNovaLozinka.TabIndex = 22;
            this.labelNovaLozinka.Text = "Nova lozinka";
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOdustani.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOdustani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(153)))), ((int)(((byte)(106)))));
            this.buttonOdustani.Location = new System.Drawing.Point(191, 95);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(86, 40);
            this.buttonOdustani.TabIndex = 25;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            this.buttonOdustani.Click += new System.EventHandler(this.buttonOdustani_Click);
            // 
            // buttonPotvrdi
            // 
            this.buttonPotvrdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPotvrdi.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPotvrdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(153)))), ((int)(((byte)(106)))));
            this.buttonPotvrdi.Location = new System.Drawing.Point(98, 95);
            this.buttonPotvrdi.Name = "buttonPotvrdi";
            this.buttonPotvrdi.Size = new System.Drawing.Size(86, 40);
            this.buttonPotvrdi.TabIndex = 24;
            this.buttonPotvrdi.Text = "Potvrdi";
            this.buttonPotvrdi.UseVisualStyleBackColor = true;
            this.buttonPotvrdi.Click += new System.EventHandler(this.buttonPotvrdi_Click);
            // 
            // notifyPromijeni
            // 
            this.notifyPromijeni.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyPromijeni.Icon")));
            this.notifyPromijeni.Text = "notifyIcon1";
            this.notifyPromijeni.Visible = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonPotvrdi);
            this.groupBox1.Controls.Add(this.buttonOdustani);
            this.groupBox1.Controls.Add(this.labelNovaLozinka);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPonoviLozinku);
            this.groupBox1.Controls.Add(this.txtLozinka);
            this.groupBox1.Location = new System.Drawing.Point(145, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 163);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // NovaLozinka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(569, 290);
            this.Controls.Add(this.groupBox1);
            this.Name = "NovaLozinka";
            this.Text = "NovaLozinka";
            this.Load += new System.EventHandler(this.NovaLozinka_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPonoviLozinku;
        private System.Windows.Forms.TextBox txtLozinka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNovaLozinka;
        private System.Windows.Forms.Button buttonOdustani;
        private System.Windows.Forms.Button buttonPotvrdi;
        private System.Windows.Forms.NotifyIcon notifyPromijeni;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}