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
using INSform;
using Baza;
namespace Ponude
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public partial class DetaljiPonude : Form
    {
        Ponuda Ponuda;
        Iform iform;
        public DetaljiPonude(Ponuda ponuda, Iform novo)
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
        }

        private void DetaljiPonude_Load(object sender, EventArgs e)
        {
            if(iform.autentifikator.AktivanKorisnik!=null)
            {
                hSbKolicina.Visible = true;
                txtKolicina.Visible = true;
                buttonRezerviraj.Visible = true;
                hSbKolicina.Maximum = Ponuda.Kolicina+9;
                hSbKolicina.Minimum = 1;
                hSbKolicina.Value = 1;
                txtKolicina.Text = hSbKolicina.Value.ToString();
                hSbKolicina.SmallChange = 1;

                if (KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik) == Ponuda.IDKORISNIKA)
                    buttonRezerviraj.Enabled = false;
                else
                    buttonRezerviraj.Enabled = true;
            }
            else
            {
                hSbKolicina.Visible = false;
                txtKolicina.Visible = false;
                buttonRezerviraj.Visible = false;
            }
            
        }

        private void hSbKolicina_ValueChanged(object sender, EventArgs e)
        {
            this.txtKolicina.Multiline = true;
            this.txtKolicina.WordWrap = false;
            this.txtKolicina.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            txtKolicina.Text = hSbKolicina.Value.ToString();
        }

        private void buttonRezerviraj_Click(object sender, EventArgs e)
        {
            List<string> mailovi = new List<string>();
            mailovi.Add(KorisnikRepository.DohvatiEmailKorisnika(Ponuda.IDKORISNIKA));
            if ((PonudeRepozitory.ProvjeriKorisnikaIZahtjev(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), int.Parse(Ponuda.ID))) == 0)
            {
                

                Mail mail = new Mail(mailovi);
                mail.Title = "Zahtjev za rezervacijom";
                Korisnik korisnik = KorisnikRepository.DohvatiKorisnikaPoIDU(KorisnikRepository.DohvatiIdKorisnika( iform.autentifikator.AktivanKorisnik));
                mail.Text = "Korisnik " + korisnik.Ime + " " + korisnik.Prezime + " je poslao zahtjev na ponudu " + Ponuda.Naziv + " u količini od " + txtKolicina.Text + " " +Ponuda.Mjerna ;
                mail.RequireAutentication = true;
                mail.Send();
                PonudeRepozitory.UnesiZahtjevZaRezervaciju(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), int.Parse(Ponuda.ID), int.Parse(txtKolicina.Text));
                PonudeRepozitory.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), "Korisnik " + iform.autentifikator.AktivanKorisnik + " je poslao zahtjev za ponudu " + Ponuda.ID, 5);
                notifyRezerviraj.ShowBalloonTip(1000, "Zahtjev za rezervacijom", "Uspješno ste kreirali zahtjev za rezervacijom", ToolTipIcon.Info);
            } 
            else
            {
                Mail mail = new Mail(mailovi);
                mail.Title = "Zahtjev za rezervacijom";
                Korisnik korisnik = KorisnikRepository.DohvatiKorisnikaPoIDU(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik));
                mail.Text = "Korisnik " + korisnik.Ime + " " + korisnik.Prezime + " je ažurirao zahtjev za ponudu " + Ponuda.Naziv + " u količini od " + txtKolicina.Text + " " + Ponuda.Mjerna;
                mail.RequireAutentication = true;
                mail.Send();
                PonudeRepozitory.AzurirajZahtjev(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), int.Parse(Ponuda.ID), int.Parse(txtKolicina.Text));
                PonudeRepozitory.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik), "Korisnik " + iform.autentifikator.AktivanKorisnik + " je ažurirao zahtjev za ponudu " + Ponuda.ID, 25);
                notifyRezerviraj.ShowBalloonTip(1000, "Zahtjev za rezervacijom", "Uspješno ste ažurirali zahtjev za rezervacijom", ToolTipIcon.Info);
            }
            Close();
        }
    }
}
