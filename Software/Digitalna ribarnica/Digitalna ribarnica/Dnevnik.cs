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
namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Nikola Muše
    /// Author: Božo Kvesić
    /// </summary>
    public partial class Dnevnik : Form
    {
        Iform Iform;
        List<Ponude.Dnevnik> zapisi = new List<Ponude.Dnevnik>();
        List<TipoviRadnje> sviTipovi = new List<TipoviRadnje>();
        public Dnevnik(Iform novo)
        {
            InitializeComponent();
            Iform = novo;
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

        private void Dnevnik_Load(object sender, EventArgs e)
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
            dataGridView1.DataSource = null;
            zapisi = PonudeRepozitory.DohvatiZapiseDnevnika();
            sviTipovi= PonudeRepozitory.DohvatiTipoveRadnji();
            foreach (var item in zapisi)
            {
               Korisnik korisnik= KorisnikRepository.DohvatiKorisnikaPoIDU(item.IDkorisnik);
                item.ImeiPrezimeKorisnika = korisnik.Ime + " " + korisnik.Prezime;
                item.NazivRadnje = sviTipovi.Find(x => x.ID == item.IDTipRadnje).Naziv;
            }
            zapisi.Sort((x, y) => y.DatumRadnje.CompareTo(x.DatumRadnje));
            dataGridView1.DataSource = zapisi;
            SakrijStupce();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox1.Text.ToLower();
            int broj = 0;
            if (filter != null)
            {
                if (int.TryParse(filter, out broj))
                {
                    var result = from zapis in zapisi
                                 where zapis.DatumRadnje.ToString().Contains(broj.ToString()) || zapis.Radnja.Contains(broj.ToString())
                                 orderby zapis.DatumRadnje descending
                                 select zapis;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = result.ToList();
                    SakrijStupce();
                }
                else
                {
                    var result = from zapis in zapisi
                                 where zapis.NazivRadnje.ToLower().Contains(filter) || zapis.Radnja.ToLower().Contains(filter) || zapis.ImeiPrezimeKorisnika.ToLower().Contains(filter)
                                 orderby zapis.DatumRadnje descending
                                 select zapis;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = result.ToList();
                    SakrijStupce();
                }

            }
            else
            {
                var result = from zapis in zapisi
                             orderby zapis.DatumRadnje descending
                             select zapis;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.ToList() ;
                SakrijStupce();
            }
        }

        /// <summary>
        /// Metoda koja sakriva stupce koji sadrža složeni tip podataka
        /// </summary>
        private void SakrijStupce()
        {
            dataGridView1.Columns[0].Width = 500;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[4].Width = 250;
        }
    }
}
