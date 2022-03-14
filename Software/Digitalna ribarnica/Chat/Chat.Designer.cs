namespace Chat
{
    partial class Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelOdjava = new System.Windows.Forms.Label();
            this.txtFiltriraj = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalji = new System.Windows.Forms.Button();
            this.lblSadrzajPoruke = new System.Windows.Forms.RichTextBox();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelOdjava);
            this.groupBox1.Controls.Add(this.txtFiltriraj);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSalji);
            this.groupBox1.Controls.Add(this.lblSadrzajPoruke);
            this.groupBox1.Controls.Add(this.lblNaziv);
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 554);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // labelOdjava
            // 
            this.labelOdjava.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOdjava.AutoSize = true;
            this.labelOdjava.Font = new System.Drawing.Font("Open Sans Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelOdjava.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(132)))), ((int)(((byte)(121)))));
            this.labelOdjava.Location = new System.Drawing.Point(87, 16);
            this.labelOdjava.Name = "labelOdjava";
            this.labelOdjava.Size = new System.Drawing.Size(164, 47);
            this.labelOdjava.TabIndex = 13;
            this.labelOdjava.Text = "Korisnici";
            this.labelOdjava.Visible = false;
            // 
            // txtFiltriraj
            // 
            this.txtFiltriraj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(50)))), ((int)(((byte)(48)))));
            this.txtFiltriraj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.txtFiltriraj.Location = new System.Drawing.Point(95, 69);
            this.txtFiltriraj.Name = "txtFiltriraj";
            this.txtFiltriraj.Size = new System.Drawing.Size(184, 20);
            this.txtFiltriraj.TabIndex = 12;
            this.txtFiltriraj.TextChanged += new System.EventHandler(this.txtFiltriraj_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(141)))), ((int)(((byte)(134)))));
            this.label2.Location = new System.Drawing.Point(46, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Traži";
            // 
            // btnSalji
            // 
            this.btnSalji.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalji.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSalji.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(153)))), ((int)(((byte)(106)))));
            this.btnSalji.Location = new System.Drawing.Point(804, 475);
            this.btnSalji.Name = "btnSalji";
            this.btnSalji.Size = new System.Drawing.Size(80, 69);
            this.btnSalji.TabIndex = 10;
            this.btnSalji.Text = "Pošalji";
            this.btnSalji.UseVisualStyleBackColor = true;
            this.btnSalji.Click += new System.EventHandler(this.btnSalji_Click);
            // 
            // lblSadrzajPoruke
            // 
            this.lblSadrzajPoruke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.lblSadrzajPoruke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.lblSadrzajPoruke.Location = new System.Drawing.Point(484, 475);
            this.lblSadrzajPoruke.Name = "lblSadrzajPoruke";
            this.lblSadrzajPoruke.Size = new System.Drawing.Size(314, 69);
            this.lblSadrzajPoruke.TabIndex = 9;
            this.lblSadrzajPoruke.Text = "";
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNaziv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(132)))), ((int)(((byte)(121)))));
            this.lblNaziv.Location = new System.Drawing.Point(489, 16);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(0, 24);
            this.lblNaziv.TabIndex = 6;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(484, 69);
            this.flowLayoutPanel2.MaximumSize = new System.Drawing.Size(400, 400);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(400, 400);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(38, 95);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(300, 450);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(300, 450);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(992, 618);
            this.Controls.Add(this.groupBox1);
            this.Name = "Chat";
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblNaziv;
        public System.Windows.Forms.RichTextBox lblSadrzajPoruke;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnSalji;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox txtFiltriraj;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label labelOdjava;
    }
}