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
    /// Author: Nikola Muše
    /// </summary>
    public partial class OcijeniKorisnika : Form
    {
        Iform Iform;
        List<int> ocjene = new List<int>() { 1,2,3,4,5};
        Rezervacija Rezervacija;
        public Form Trenutna { get; set; }
        public Panel panelStranice { get; set; }
        public int IDOcjena = -1;
        bool azuriranje = false;
        public OcijeniKorisnika(Iform nova,Rezervacija poslana)
        {
            InitializeComponent();
            Iform = nova;
            cmbOcjena.DataSource = ocjene;
            Rezervacija = poslana;
            Trenutna = Iform.nova;
            panelStranice = Iform.panel;
   
     
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            zatvoriForme();
        }
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

        private void btnOcjeni_Click(object sender, EventArgs e)
        {
            if (!azuriranje)
            {
                PonudeRepozitory.UnesiOcjenu(Iform, int.Parse(cmbOcjena.SelectedItem.ToString()), rtbxOpis.Text, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), Rezervacija.IDkupca, Rezervacija.ID);
                KorisnikRepository.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), "Korisnik " + Iform.autentifikator.AktivanKorisnik + " je unio ocjenu za korisnika " + Rezervacija.Ime, 10);

            }
            else
            {
                PonudeRepozitory.AzurirajOcjenu(Iform, int.Parse(cmbOcjena.SelectedItem.ToString()), rtbxOpis.Text, IDOcjena);
                KorisnikRepository.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), "Korisnik " + Iform.autentifikator.AktivanKorisnik + " je ažurirao ocjenu za korisnika " + Rezervacija.Ime, 26);
            }
            zatvoriForme();
        }

        private void OcijeniKorisnika_Load(object sender, EventArgs e)
        {
            if (PonudeRepozitory.ProvjeriOcjene(Iform, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), Rezervacija.IDkupca, Rezervacija.ID).Id != -1)
            {
                azuriranje = true;
                cmbOcjena.SelectedItem = PonudeRepozitory.ProvjeriOcjene(Iform, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), Rezervacija.IDkupca, Rezervacija.ID).ocjena;
                rtbxOpis.Text = PonudeRepozitory.ProvjeriOcjene(Iform, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), Rezervacija.IDkupca, Rezervacija.ID).Komentar;
                IDOcjena = PonudeRepozitory.ProvjeriOcjene(Iform, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), Rezervacija.IDkupca, Rezervacija.ID).Id;
            }
            else
                azuriranje = false;
        }
    }
}
