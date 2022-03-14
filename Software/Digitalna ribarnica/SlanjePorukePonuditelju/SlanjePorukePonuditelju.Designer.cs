namespace SlanjePorukePonuditelju
{
    partial class SlanjePorukePonuditelju
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlanjePorukePonuditelju));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalji = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSadrzajPoruke = new System.Windows.Forms.RichTextBox();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSalji);
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Controls.Add(this.lblSadrzajPoruke);
            this.groupBox1.Controls.Add(this.lblNaziv);
            this.groupBox1.Location = new System.Drawing.Point(205, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 548);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnSalji
            // 
            this.btnSalji.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalji.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSalji.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(153)))), ((int)(((byte)(106)))));
            this.btnSalji.Location = new System.Drawing.Point(450, 448);
            this.btnSalji.Name = "btnSalji";
            this.btnSalji.Size = new System.Drawing.Size(80, 69);
            this.btnSalji.TabIndex = 14;
            this.btnSalji.Text = "Pošalji";
            this.btnSalji.UseVisualStyleBackColor = true;
            this.btnSalji.Click += new System.EventHandler(this.btnSalji_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(130, 42);
            this.flowLayoutPanel2.MaximumSize = new System.Drawing.Size(400, 400);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(400, 400);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // lblSadrzajPoruke
            // 
            this.lblSadrzajPoruke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.lblSadrzajPoruke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.lblSadrzajPoruke.Location = new System.Drawing.Point(130, 448);
            this.lblSadrzajPoruke.Name = "lblSadrzajPoruke";
            this.lblSadrzajPoruke.Size = new System.Drawing.Size(314, 69);
            this.lblSadrzajPoruke.TabIndex = 13;
            this.lblSadrzajPoruke.Text = "";
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNaziv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(132)))), ((int)(((byte)(121)))));
            this.lblNaziv.Location = new System.Drawing.Point(135, 15);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(0, 24);
            this.lblNaziv.TabIndex = 12;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // SlanjePorukePonuditelju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1048, 581);
            this.Controls.Add(this.groupBox1);
            this.Name = "SlanjePorukePonuditelju";
            this.Text = "SlanjePorukePonuditelju";
            this.Load += new System.EventHandler(this.SlanjePorukePonuditelju_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnSalji;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public System.Windows.Forms.RichTextBox lblSadrzajPoruke;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}