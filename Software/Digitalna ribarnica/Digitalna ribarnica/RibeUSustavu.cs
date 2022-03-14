using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RibeUSustavu;
using INSform;
using Prijava;
using Ponude;

namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public partial class RibeUSustavu : Form
    {
        Iform Iform;
        public RibeUSustavu(Iform iform)
        {
            InitializeComponent();
            Iform = iform;
        }

        private void RibeUSustavu_Load(object sender, EventArgs e)
        {
            
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(1, 131, 131);
            this.dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(29, 70, 75);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(66, 230, 164);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = RibeRepository.DohvatiRibe();
            if(dataGridView1.RowCount>0)
                dataGridView1.Rows[0].Selected = true;
            kalibrirajSlike();

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                form.openChildForm(new DodajRibu(Iform));
            }
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            Riba riba = dataGridView1.CurrentRow.DataBoundItem as Riba;
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                form.openChildForm(new DodajRibu(riba,Iform));
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Riba riba = dataGridView1.CurrentRow.DataBoundItem as Riba;
            if (riba != null)
            {
                RibeRepository.ObrisiRibu(riba);
                PonudeRepozitory.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), "Korisnik " + Iform.autentifikator.AktivanKorisnik + " je obrisao ribu: " + riba.Naziv + " s ID-om " + riba.id, 18);
            }
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                notifyRiba.ShowBalloonTip(1000, "Ribe u sustavu", "Uspješno ste obrisali ribu!", ToolTipIcon.Info);
                form.openChildForm(new RibeUSustavu(Iform));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Riba> sveRibe = RibeRepository.DohvatiRibe();
            string filter = textBox1.Text.ToLower();
            int broj = 0;
            if (filter != null)
            {
                if (int.TryParse(filter, out broj))
                {
                    var result = from riba in sveRibe
                                 where riba.id==broj
                                 select riba;

                        dataGridView1.DataSource = result.ToList();
                        kalibrirajSlike();
                }
                else
                {
                    var result = from riba in sveRibe
                                 where riba.MjernaJedinica.ToLower().Contains(filter) || riba.Naziv.ToLower().Contains(filter)
                                 select riba;
                        dataGridView1.DataSource = result.ToList();
                        kalibrirajSlike();
                }
             
            }
            else
            {
                var result = from riba in sveRibe
                             select riba;
                dataGridView1.DataSource = result;
                kalibrirajSlike();
            }
        }
        /// <summary>
        /// Slike se prikazuju cijele u Zoom načinu kako bi svi pixeli bili vidljivi na maloj rezoluciji
        /// </summary>

        public void kalibrirajSlike()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }
        }

        private void buttonPrijavi_Click(object sender, EventArgs e)
        {
            List<Riba> sveRibe = RibeRepository.DohvatiRibe();
            var result = from riba in sveRibe
                         orderby riba.Naziv ascending
                         select riba;

            dataGridView1.DataSource = result.ToList();
            kalibrirajSlike();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
