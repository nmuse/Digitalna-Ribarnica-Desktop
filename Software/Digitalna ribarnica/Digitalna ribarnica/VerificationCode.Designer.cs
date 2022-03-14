namespace Digitalna_ribarnica
{
    partial class VerificationCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerificationCode));
            this.textBoxCode2 = new System.Windows.Forms.TextBox();
            this.textBoxCode3 = new System.Windows.Forms.TextBox();
            this.textBoxCode5 = new System.Windows.Forms.TextBox();
            this.textBoxCode1 = new System.Windows.Forms.TextBox();
            this.textBoxCode4 = new System.Windows.Forms.TextBox();
            this.lblIme = new System.Windows.Forms.Label();
            this.buttonPotvrdi = new System.Windows.Forms.Button();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.buttonSaljiPonovno = new System.Windows.Forms.Button();
            this.notifyVerification = new System.Windows.Forms.NotifyIcon(this.components);
            this.labelObavijest = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCode2
            // 
            this.textBoxCode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(136)))), ((int)(((byte)(119)))));
            this.textBoxCode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(249)))), ((int)(((byte)(233)))));
            this.textBoxCode2.Location = new System.Drawing.Point(216, 18);
            this.textBoxCode2.MaxLength = 1;
            this.textBoxCode2.Name = "textBoxCode2";
            this.textBoxCode2.Size = new System.Drawing.Size(25, 20);
            this.textBoxCode2.TabIndex = 1;
            this.textBoxCode2.TextChanged += new System.EventHandler(this.textBoxCode2_TextChanged);
            // 
            // textBoxCode3
            // 
            this.textBoxCode3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(145)))), ((int)(((byte)(112)))));
            this.textBoxCode3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(249)))), ((int)(((byte)(233)))));
            this.textBoxCode3.Location = new System.Drawing.Point(247, 18);
            this.textBoxCode3.MaxLength = 1;
            this.textBoxCode3.Name = "textBoxCode3";
            this.textBoxCode3.Size = new System.Drawing.Size(25, 20);
            this.textBoxCode3.TabIndex = 2;
            this.textBoxCode3.TextChanged += new System.EventHandler(this.textBoxCode3_TextChanged);
            // 
            // textBoxCode5
            // 
            this.textBoxCode5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(203)))), ((int)(((byte)(132)))));
            this.textBoxCode5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(249)))), ((int)(((byte)(233)))));
            this.textBoxCode5.Location = new System.Drawing.Point(309, 18);
            this.textBoxCode5.MaxLength = 1;
            this.textBoxCode5.Name = "textBoxCode5";
            this.textBoxCode5.Size = new System.Drawing.Size(25, 20);
            this.textBoxCode5.TabIndex = 4;
            this.textBoxCode5.TextChanged += new System.EventHandler(this.textBoxCode5_TextChanged);
            // 
            // textBoxCode1
            // 
            this.textBoxCode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(129)))), ((int)(((byte)(124)))));
            this.textBoxCode1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(249)))), ((int)(((byte)(233)))));
            this.textBoxCode1.Location = new System.Drawing.Point(185, 18);
            this.textBoxCode1.MaxLength = 1;
            this.textBoxCode1.Name = "textBoxCode1";
            this.textBoxCode1.Size = new System.Drawing.Size(25, 20);
            this.textBoxCode1.TabIndex = 0;
            this.textBoxCode1.TextChanged += new System.EventHandler(this.textBoxCode1_TextChanged);
            // 
            // textBoxCode4
            // 
            this.textBoxCode4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(153)))), ((int)(((byte)(106)))));
            this.textBoxCode4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(249)))), ((int)(((byte)(233)))));
            this.textBoxCode4.Location = new System.Drawing.Point(278, 18);
            this.textBoxCode4.MaxLength = 1;
            this.textBoxCode4.Name = "textBoxCode4";
            this.textBoxCode4.Size = new System.Drawing.Size(25, 20);
            this.textBoxCode4.TabIndex = 3;
            this.textBoxCode4.TextChanged += new System.EventHandler(this.textBoxCode4_TextChanged);
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblIme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(145)))), ((int)(((byte)(112)))));
            this.lblIme.Location = new System.Drawing.Point(49, 16);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(130, 20);
            this.lblIme.TabIndex = 8;
            this.lblIme.Text = "Verification code";
            // 
            // buttonPotvrdi
            // 
            this.buttonPotvrdi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPotvrdi.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPotvrdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(145)))), ((int)(((byte)(112)))));
            this.buttonPotvrdi.Location = new System.Drawing.Point(185, 61);
            this.buttonPotvrdi.Name = "buttonPotvrdi";
            this.buttonPotvrdi.Size = new System.Drawing.Size(86, 40);
            this.buttonPotvrdi.TabIndex = 5;
            this.buttonPotvrdi.Text = "Potvrdi";
            this.buttonPotvrdi.UseVisualStyleBackColor = true;
            this.buttonPotvrdi.Click += new System.EventHandler(this.buttonPotvrdi_Click);
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOdustani.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOdustani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(145)))), ((int)(((byte)(112)))));
            this.buttonOdustani.Location = new System.Drawing.Point(278, 61);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(86, 40);
            this.buttonOdustani.TabIndex = 6;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            this.buttonOdustani.Click += new System.EventHandler(this.buttonOdustani_Click);
            // 
            // buttonSaljiPonovno
            // 
            this.buttonSaljiPonovno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaljiPonovno.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSaljiPonovno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(203)))), ((int)(((byte)(132)))));
            this.buttonSaljiPonovno.Location = new System.Drawing.Point(24, 121);
            this.buttonSaljiPonovno.Name = "buttonSaljiPonovno";
            this.buttonSaljiPonovno.Size = new System.Drawing.Size(135, 40);
            this.buttonSaljiPonovno.TabIndex = 7;
            this.buttonSaljiPonovno.Text = "Pošalji ponovno";
            this.buttonSaljiPonovno.UseVisualStyleBackColor = true;
            this.buttonSaljiPonovno.Click += new System.EventHandler(this.buttonSaljiPonovno_Click);
            // 
            // notifyVerification
            // 
            this.notifyVerification.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyVerification.Icon")));
            this.notifyVerification.Text = "notifyIcon1";
            this.notifyVerification.Visible = true;
            // 
            // labelObavijest
            // 
            this.labelObavijest.AutoSize = true;
            this.labelObavijest.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelObavijest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(203)))), ((int)(((byte)(132)))));
            this.labelObavijest.Location = new System.Drawing.Point(165, 131);
            this.labelObavijest.Name = "labelObavijest";
            this.labelObavijest.Size = new System.Drawing.Size(177, 20);
            this.labelObavijest.TabIndex = 12;
            this.labelObavijest.Text = "Mail je ponovno poslan";
            this.labelObavijest.Visible = false;
            // 
            // timerLabel
            // 
            this.timerLabel.Interval = 1000;
            this.timerLabel.Tick += new System.EventHandler(this.timerLabel_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblIme);
            this.groupBox1.Controls.Add(this.labelObavijest);
            this.groupBox1.Controls.Add(this.textBoxCode2);
            this.groupBox1.Controls.Add(this.buttonOdustani);
            this.groupBox1.Controls.Add(this.textBoxCode3);
            this.groupBox1.Controls.Add(this.buttonSaljiPonovno);
            this.groupBox1.Controls.Add(this.textBoxCode1);
            this.groupBox1.Controls.Add(this.buttonPotvrdi);
            this.groupBox1.Controls.Add(this.textBoxCode5);
            this.groupBox1.Controls.Add(this.textBoxCode4);
            this.groupBox1.Location = new System.Drawing.Point(164, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 176);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // VerificationCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(762, 476);
            this.Controls.Add(this.groupBox1);
            this.Name = "VerificationCode";
            this.Text = "VerificationCode";
            this.Load += new System.EventHandler(this.VerificationCode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCode2;
        private System.Windows.Forms.TextBox textBoxCode3;
        private System.Windows.Forms.TextBox textBoxCode5;
        private System.Windows.Forms.TextBox textBoxCode1;
        private System.Windows.Forms.TextBox textBoxCode4;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Button buttonPotvrdi;
        private System.Windows.Forms.Button buttonOdustani;
        private System.Windows.Forms.Button buttonSaljiPonovno;
        private System.Windows.Forms.NotifyIcon notifyVerification;
        private System.Windows.Forms.Label labelObavijest;
        private System.Windows.Forms.Timer timerLabel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}