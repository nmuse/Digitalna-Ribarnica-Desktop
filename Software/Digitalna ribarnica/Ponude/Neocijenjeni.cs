using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INSform;
using Ponude;
using Prijava;
namespace Ocjene
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public partial class Neocijenjeni : Form
    {
        Iform Iform;
        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }
        public Neocijenjeni(Iform iform)
        {
            InitializeComponent();
            Iform = iform;
            Trenutna = iform.nova;
            panelStranice = iform.panel;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(1, 131, 131);
            this.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 57, 63);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
        
        }

        private void Neocijenjeni_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(1, 131, 131);
            this.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 57, 63);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView2.DefaultCellStyle.ForeColor = Color.FromArgb(1, 131, 131);
            this.dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView2.DefaultCellStyle.SelectionForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 57, 63);
            this.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView2.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = Ponude.PonudeRepozitory.GotoveRezervacije(Iform,KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
            dataGridView2.DataSource= Ponude.PonudeRepozitory.GotoveRezeracijePonuditelj(Iform, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));

            if (dataGridView1.RowCount > 0)
                dataGridView1.Rows[0].Selected = true;
            if (dataGridView2.RowCount > 0)
                dataGridView2.Rows[0].Selected = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[7].Visible = false;
            dataGridView2.Columns[9].Visible = false;
            
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            this.dataGridView2.DefaultCellStyle.ForeColor = Color.FromArgb(1, 131, 131);
            this.dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView2.DefaultCellStyle.SelectionForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 57, 63);
            this.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView2.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
        }
        /// <summary>
        /// Metoda koja zatvara trenutno aktivnu formu te otvara novu
        /// </summary>
        /// <param name="childForm">Novo poslana forma</param>
        public void openChildForm(Form childForm)
        {
            if (Trenutna != null)
                Trenutna.Close();
            Trenutna = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelStranice.Controls.Add(childForm);
            panelStranice.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnOcijeniKupca_Click(object sender, EventArgs e)
        {
            Rezervacija rezervacija = dataGridView1.CurrentRow.DataBoundItem as Rezervacija;
            openChildForm(new OcijeniKorisnika(Iform, rezervacija));
        }

        private void btnOcijeniPonuditelja_Click(object sender, EventArgs e)
        {
            Rezervacija rezervacija = dataGridView2.CurrentRow.DataBoundItem as Rezervacija;
            openChildForm(new OcijeniKorisnika(Iform, rezervacija));
        }
    }
}
