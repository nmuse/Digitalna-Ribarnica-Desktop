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

namespace Ponude
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public partial class UrediPonudu : Form
    {
        Ponuda Ponuda;
        public Iform iform;

        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }
        public UrediPonudu(Ponuda ponuda, Iform novo)
        {
            InitializeComponent();
            Ponuda = ponuda;
            pbxSlika.Image = Ponuda.Fotografija;
            ucNaziv.Text = Ponuda.Naziv;
            ucMjerna.Text = Ponuda.Mjerna;
            ucLokacija.Text = Ponuda.Lokacija;
            ucKolicina.Text = Ponuda.Kolicina.ToString();
            ucCijena.Text = Ponuda.Cijena.ToString();
            ucPonuditelj.Text = Ponuda.Ime;
            rtbxOpis.Text = PonudeRepozitory.DohvatiOpisPonude(int.Parse(Ponuda.ID));
            iform = novo;
            Trenutna = iform.nova;
            panelStranice = iform.panel;
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            PonudeRepozitory.ObrisiPonudu(int.Parse(Ponuda.ID));
            PonudeRepozitory.AzurirajZahtjeveNakonBrisanja(iform, int.Parse(Ponuda.ID));
            PonudeRepozitory.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), "Korisnik " + iform.autentifikator.AktivanKorisnik + " je obrisao ponudu s ID: " + Ponuda.ID, 23);
            Close();
            zatvoriForme();
            

        }
        /// <summary>
        /// Metoda koja zatvara sve forme osim početne
        /// </summary>
        public void zatvoriForme()
        {
            FormCollection fc = Application.OpenForms;
            List<Form> aktivne = new List<Form>();
            foreach (Form frm in fc)
            {
                if (frm.Name != "formPocetna")
                {
                    //frm.Close();
                    aktivne.Add(frm);
                }
            }

            foreach (var item in aktivne)
            {
                item.Close();
            }
        }

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

        private void buttonRezerviraj_Click(object sender, EventArgs e)
        {
            openChildForm(new AzurirajFormu(Ponuda,iform));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new ZahtjeviZaRezervacijom(iform, Ponuda));
        }
    }
}
