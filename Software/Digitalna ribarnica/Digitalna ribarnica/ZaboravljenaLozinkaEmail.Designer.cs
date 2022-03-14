namespace Digitalna_ribarnica
{
    partial class ZaboravljenaLozinkaEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZaboravljenaLozinkaEmail));
            this.textEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.buttonPotvrdi = new System.Windows.Forms.Button();
            this.notifyZaboravljenaLozinka = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEmail
            // 
            this.textEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(50)))), ((int)(((byte)(48)))));
            this.textEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(240)))), ((int)(((byte)(201)))));
            this.textEmail.Location = new System.Drawing.Point(138, 26);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(179, 20);
            this.textEmail.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(145)))), ((int)(((byte)(112)))));
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Unesite email";
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOdustani.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOdustani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(145)))), ((int)(((byte)(112)))));
            this.buttonOdustani.Location = new System.Drawing.Point(231, 62);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(86, 40);
            this.buttonOdustani.TabIndex = 21;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            this.buttonOdustani.Click += new System.EventHandler(this.buttonOdustani_Click);
            // 
            // buttonPotvrdi
            // 
            this.buttonPotvrdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPotvrdi.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPotvrdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(145)))), ((int)(((byte)(112)))));
            this.buttonPotvrdi.Location = new System.Drawing.Point(138, 62);
            this.buttonPotvrdi.Name = "buttonPotvrdi";
            this.buttonPotvrdi.Size = new System.Drawing.Size(86, 40);
            this.buttonPotvrdi.TabIndex = 20;
            this.buttonPotvrdi.Text = "Potvrdi";
            this.buttonPotvrdi.UseVisualStyleBackColor = true;
            this.buttonPotvrdi.Click += new System.EventHandler(this.buttonPotvrdi_Click);
            // 
            // notifyZaboravljenaLozinka
            // 
            this.notifyZaboravljenaLozinka.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyZaboravljenaLozinka.Icon")));
            this.notifyZaboravljenaLozinka.Text = "notifyIcon1";
            this.notifyZaboravljenaLozinka.Visible = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonPotvrdi);
            this.groupBox1.Controls.Add(this.buttonOdustani);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textEmail);
            this.groupBox1.Location = new System.Drawing.Point(216, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 125);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // ZaboravljenaLozinkaEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "ZaboravljenaLozinkaEmail";
            this.Text = "ZaboravljenaLozinkaEmail";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOdustani;
        private System.Windows.Forms.Button buttonPotvrdi;
        private System.Windows.Forms.NotifyIcon notifyZaboravljenaLozinka;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}