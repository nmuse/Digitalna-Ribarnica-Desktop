using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INSform;
using Ocjene;
using Prijava;
namespace Ponude
{
    /// <summary>
    /// Author: Nikola Muše
    /// </summary>
    public partial class UCZahtjev : UserControl
    {
        private Zahtjev zahtjev = null;
        Iform iform;
        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }

        public int IDKorisnika { get; set; }
        public int IDponude { get; set; }
        public UCZahtjev(Iform novo)
        {
            InitializeComponent();
            iform = novo;
            Trenutna = iform.nova;
            panelStranice = iform.panel;
        }
        /// <summary>
        /// Metoda koja UCKorisnik dodijeljuje svojstva
        /// </summary>
        /// <param name="zahtjev"></param>
        public void LoadPonuda(Zahtjev zahtjev)
        {
            this.zahtjev = zahtjev;
        }
        /// <summary>
        /// Zatvaranje trenutne forme te otvaranje nove forme u panelu
        /// </summary>
        /// <param name="childForm">Trenutno aktivna forma koja će se zatvoriti</param>
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

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new OcjeneKorisnika(iform,zahtjev.IDKORISNIKA));
        }

        private void button3_Click(object sender, EventArgs e)
        {

            UrediPonudu form = Application.OpenForms.OfType<UrediPonudu>().FirstOrDefault();
            if (form != null)
                form.zatvoriForme();
        }

        private void ucOdbaci_Click(object sender, EventArgs e)
        {
            PonudeRepozitory.OdbaciZahtjev(iform, zahtjev.ID);
            KorisnikRepository.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), "Korisnik " + iform.autentifikator.AktivanKorisnik + " je odbacio zahtjev za rezervacijom ponude " + zahtjev.IDPONUDE + " na količinu " + zahtjev.Kolicina, 12);
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
                if (frm.Name != "formPocetna" && frm.Name!= "PregledPonuda")
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

        private void ucPrihvati_Click(object sender, EventArgs e)
        {
            PonudeRepozitory.OdbaciZahtjev(iform, zahtjev.ID);
            PonudeRepozitory.KreirajRezervaciju(iform, zahtjev, zahtjev.IDPONUDE);
            PonudeRepozitory.ObrisiZahtjev(iform, zahtjev);
            PonudeRepozitory.AzurirajPonuduKolicine(iform, zahtjev, zahtjev.IDPONUDE);
            KorisnikRepository.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), "Korisnik " + iform.autentifikator.AktivanKorisnik + " je prihvatio zahtjev za rezervacijom ponude "+zahtjev.IDPONUDE+" na količinu " + zahtjev.Kolicina, 11);
            List<string> mailovi = new List<string>();
            mailovi.Add(KorisnikRepository.DohvatiEmailKorisnika(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik)));
            mailovi.Add(KorisnikRepository.DohvatiEmailKorisnika(IDKorisnika));
            Korisnik kupac = KorisnikRepository.DohvatiKorisnikaPoIDU(IDKorisnika);
            Korisnik ponuditelj = KorisnikRepository.DohvatiKorisnikaPoIDU(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik));
            openChildForm(new Izvjesce(mailovi,kupac,ponuditelj,zahtjev));
            zatvoriForme();
        }
    }
}
