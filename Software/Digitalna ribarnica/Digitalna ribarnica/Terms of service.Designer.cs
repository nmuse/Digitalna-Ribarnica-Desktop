namespace Digitalna_ribarnica
{
    partial class Terms_of_service
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
            this.richTerms = new System.Windows.Forms.RichTextBox();
            this.buttonOdbijam = new System.Windows.Forms.Button();
            this.buttonPrihvacam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTerms
            // 
            this.richTerms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.richTerms.Location = new System.Drawing.Point(12, 12);
            this.richTerms.Name = "richTerms";
            this.richTerms.Size = new System.Drawing.Size(719, 341);
            this.richTerms.TabIndex = 0;
            this.richTerms.Text = "";
            // 
            // buttonOdbijam
            // 
            this.buttonOdbijam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.buttonOdbijam.FlatAppearance.BorderSize = 0;
            this.buttonOdbijam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOdbijam.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOdbijam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(154)))));
            this.buttonOdbijam.Location = new System.Drawing.Point(489, 359);
            this.buttonOdbijam.Name = "buttonOdbijam";
            this.buttonOdbijam.Size = new System.Drawing.Size(122, 45);
            this.buttonOdbijam.TabIndex = 1;
            this.buttonOdbijam.Text = "Odbijam";
            this.buttonOdbijam.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonOdbijam.UseVisualStyleBackColor = false;
            this.buttonOdbijam.Click += new System.EventHandler(this.buttonOdbijam_Click);
            // 
            // buttonPrihvacam
            // 
            this.buttonPrihvacam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.buttonPrihvacam.FlatAppearance.BorderSize = 0;
            this.buttonPrihvacam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrihvacam.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPrihvacam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(200)))), ((int)(((byte)(154)))));
            this.buttonPrihvacam.Location = new System.Drawing.Point(617, 359);
            this.buttonPrihvacam.Name = "buttonPrihvacam";
            this.buttonPrihvacam.Size = new System.Drawing.Size(114, 45);
            this.buttonPrihvacam.TabIndex = 2;
            this.buttonPrihvacam.Text = "Prihvaćam";
            this.buttonPrihvacam.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonPrihvacam.UseVisualStyleBackColor = false;
            this.buttonPrihvacam.Click += new System.EventHandler(this.buttonPrihvacam_Click);
            // 
            // Terms_of_service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(783, 424);
            this.Controls.Add(this.buttonPrihvacam);
            this.Controls.Add(this.buttonOdbijam);
            this.Controls.Add(this.richTerms);
            this.Name = "Terms_of_service";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Terms_of_service";
            this.Load += new System.EventHandler(this.Terms_of_service_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTerms;
        private System.Windows.Forms.Button buttonOdbijam;
        private System.Windows.Forms.Button buttonPrihvacam;
    }
}