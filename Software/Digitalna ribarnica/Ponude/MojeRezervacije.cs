using INSform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prijava;
namespace Ponude
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public partial class MojeRezervacije : Form
    {
        List<Rezervacija> rezervacije = new List<Rezervacija>();
        Iform Iform;
        public MojeRezervacije(Iform Iform)
        {
            InitializeComponent();
            this.Iform = Iform;
            ObrisiRezervacije();
            rezervacije = PonudeRepozitory.DohvatiRezervacije(Iform, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
            DodajPonude(rezervacije, Iform);
        }
        /// <summary>
        /// Metoda koja dodaje userControle rezervacija u panel
        /// </summary>
        /// <param name="rezervacije"></param>
        /// <param name="iform"></param>
        private void DodajPonude(IEnumerable<Rezervacija> rezervacije, Iform iform)
        {
            foreach (var item in rezervacije)
            {
                Rezervacija rezervacija = new Rezervacija(iform);
                rezervacija.ID = item.ID;
                rezervacija.Kolicina = item.Kolicina;
                rezervacija.Mjerna = item.Mjerna;
                rezervacija.Naziv = item.Naziv;
                rezervacija.Fotografija = item.Fotografija;
                rezervacija.Cijena = item.Cijena;
                rezervacija.Ime = item.Ime;
                rezervacija.Lokacija = item.Lokacija;
                rezervacija.Kupac = "Ponuditelj";
                rezervacija.GotovaRezervacija();
                rezervacija.IDkupca = item.IDkupca;
                this.flowLayoutPanel1.Controls.Add(rezervacija.PrikazUC);
                this.Controls.Remove(rezervacija.PrikazUC);
            }
        }
        /// <summary>
        /// Metoda koja briše sve rezervacije iz panela
        /// </summary>
        private void ObrisiRezervacije()
        {
            List<int> index = new List<int>();
            int brojac = 0;
            foreach (UCRezevacija item in flowLayoutPanel1.Controls)
            {
                index.Add(flowLayoutPanel1.Controls.GetChildIndex(item));
            }

            foreach (var item in index)
            {
                flowLayoutPanel1.Controls.RemoveAt(item - brojac);
                brojac++;
            }
        }
    }
}
