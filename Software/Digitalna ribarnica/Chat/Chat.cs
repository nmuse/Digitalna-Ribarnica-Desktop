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
using Prijava;
using Ponude;
namespace Chat
{
    /// <summary>
    /// Author: Nikola Muše
    /// </summary>
    public partial class Chat : Form
    {
        Iform Iform;
        List<Korisnik> korisnici = new List<Korisnik>();
        List<Korisnik> postojiRazgovorSKorisnikom = new List<Korisnik>();
        int IDPrimatelja = 0;
        public Chat(Iform iform)
        {
            InitializeComponent();
            Iform = iform;
            ObrisiKontake();
            korisnici = KorisnikRepository.DohvatiSveKorisnike();
            List<int> ostvareRazgovor = ChatRepository.DohvatiKorisnike(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
         
            Korisnik aktivan = new Korisnik();
            foreach (var item in korisnici)
            {
                if (item.KorIme == Iform.autentifikator.AktivanKorisnik)
                    aktivan = item;

            }
            korisnici.Remove(aktivan);
            foreach (var item in ostvareRazgovor)
            {
                foreach (var korisnik in korisnici)
                {
                    if (korisnik.ID == item)
                        postojiRazgovorSKorisnikom.Add(korisnik);
                }
            }
            if(Iform.autentifikator.tipKorisnika(iform.autentifikator.AktivanKorisnik)!=1)
                DodajKorisnika(postojiRazgovorSKorisnikom, Iform);
            else
                DodajKorisnika(korisnici, Iform);

        }

        /// <summary>
        /// Metoda koja prikazuje sve korisnike preko user controla na panelu
        /// </summary>
        /// <param name="korisnici">Lista korisnika koju želimo prikazati</param>
        /// <param name="iform"></param>

        private void DodajKorisnika(IEnumerable<Korisnik> korisnici, Iform iform)
        {
            foreach (var item in korisnici)
            {
                User user = new User(Iform);
                user.IDKORISNIKA = item.ID;
                user.Naziv = item.Ime + " " + item.Prezime;
                user.Profilna = KorisnikRepository.DohvatiProfilnu(item.ID);
                user.Status = KorisnikRepository.DohvatiSlikuStatusa(item.Status);
                this.flowLayoutPanel1.Controls.Add(user.PrikazUC);
                this.Controls.Remove(user.PrikazUC);
            }
        }

        /// <summary>
        /// Brisanje svih korisnika iz panela
        /// </summary>

        private void ObrisiKontake()
        {
            List<int> index = new List<int>();
            int brojac = 0;
            foreach (UCKorisnik item in flowLayoutPanel1.Controls)
            {
                index.Add(flowLayoutPanel1.Controls.GetChildIndex(item));
            }

            foreach (var item in index)
            {
                flowLayoutPanel1.Controls.RemoveAt(item - brojac);
                brojac++;
            }
        }

        /// <summary>
        /// Brisanje svih poruka iz panela
        /// </summary>

        public void ObrisiPoruke()
        {
            flowLayoutPanel2.Controls.Clear();
        }
        /// <summary>
        /// Dodavanje poruka u panel između dva korisnika
        /// </summary>
        /// <param name="poruke">Lista poruka</param>
        /// <param name="iform"></param>
        private void DodajPoruke(IEnumerable<PorukeIzBaze> poruke, Iform iform)
        {
            foreach (var item in poruke)
            {
                bool zastava;
                Poruka poruka;
                if (item.ID == KorisnikRepository.DohvatiIdKorisnika(iform.autentifikator.AktivanKorisnik))
                {
                    poruka = new Poruka(iform, -1);
                    zastava = true;
                }
                else
                {
                    poruka = new Poruka(iform, 0);
                    zastava = false;
                }
                poruka.IDKORISNIKA = item.ID;
                poruka.Opis = item.sadrzaj;
                poruka.Datum = item.datum;
                poruka.Profilna = KorisnikRepository.DohvatiProfilnu(item.ID);
                if (zastava)
                {
                    this.flowLayoutPanel2.Controls.Add(poruka.PrikazUC);
                    this.Controls.Remove(poruka.PrikazUC);
                }
                else
                {
                    this.flowLayoutPanel2.Controls.Add(poruka.SaljemUC);
                    this.Controls.Remove(poruka.SaljemUC);
                }
            }
        }
        /// <summary>
        /// Metoda koja obrađuje cijeli proces odabira korisnika, brisanja starih poruka te dodavanja poruka s novim korisnikom
        /// </summary>
        /// <param name="idPrimatelja">ID korisnika s kojim želimo vidjeti poruke</param>

        public void PrikaziPorukue(int idPrimatelja)
        {
            int Posiljatelj =KorisnikRepository.DohvatiIdKorisnika( Iform.autentifikator.AktivanKorisnik);
            lblNaziv.Text = KorisnikRepository.DohvatiKorisnikaPoIDU(idPrimatelja).Ime + " " + KorisnikRepository.DohvatiKorisnikaPoIDU(idPrimatelja).Prezime;
            ObrisiPoruke();
            DodajPoruke(ChatRepository.DohvatiPoruke(Posiljatelj, idPrimatelja), Iform);
            lblSadrzajPoruke.Visible = true;
            btnSalji.Visible = true;
            this.IDPrimatelja = idPrimatelja;
            System.Windows.Forms.Application.DoEvents();

            flowLayoutPanel2.VerticalScroll.Value = flowLayoutPanel2.VerticalScroll.Maximum;
            flowLayoutPanel2.PerformLayout();
        }


        private void Chat_Load(object sender, EventArgs e)
        {
            lblSadrzajPoruke.Visible = false;
            btnSalji.Visible = false;
        }

        private void btnSalji_Click(object sender, EventArgs e)
        {
            if (lblSadrzajPoruke.Text != "")
            {
                List<string> mailovi = new List<string>();
                mailovi.Add(KorisnikRepository.DohvatiEmailKorisnika(IDPrimatelja));
                Mail mail = new Mail(mailovi);
                Korisnik korisnik = KorisnikRepository.DohvatiKorisnikaPoIDU(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
                mail.Title = "Korisnik " + korisnik.Ime + " " + korisnik.Prezime + " Vam šalje poruku!";
                mail.Text = lblSadrzajPoruke.Text;
                mail.RequireAutentication = true;
                mail.Send();
                mailovi.Clear();
                mailovi.Add(KorisnikRepository.DohvatiEmailKorisnika(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik)));
                Mail mail1 = new Mail(mailovi);
                Korisnik korisnik1 = KorisnikRepository.DohvatiKorisnikaPoIDU(IDPrimatelja);
                mail.Title = "Poslali ste korisniku "+ korisnik1.Ime + " " + korisnik1.Prezime +" poruku!";
                mail.Text = lblSadrzajPoruke.Text;
                mail.RequireAutentication = true;
                mail.Send();
                if(ChatRepository.DohvatiRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik)) != -1)
                {
                    int IDRazgovora=ChatRepository.DohvatiRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
                    ChatRepository.UnesiPoruku(lblSadrzajPoruke.Text, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik),IDRazgovora);
                }
                else
                {
                    ChatRepository.DodajRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
                    int IDRazgovora=ChatRepository.DohvatiRazgovor(IDPrimatelja, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
                    ChatRepository.UnesiPoruku(lblSadrzajPoruke.Text, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), IDRazgovora);
                }
                lblSadrzajPoruke.Text = "";
                PrikaziPorukue(IDPrimatelja);
            }
            else
                notifyIcon1.ShowBalloonTip(1000, "Chat", "Ne možemo poslati praznu poruku", ToolTipIcon.Warning);
        }

        private void txtFiltriraj_TextChanged(object sender, EventArgs e)
        {
            List<Korisnik> aktivniKorisnici = new List<Korisnik>();
            if (Iform.autentifikator.tipKorisnika(Iform.autentifikator.AktivanKorisnik) != 1)
                aktivniKorisnici = postojiRazgovorSKorisnikom;
            else
                aktivniKorisnici = korisnici;

            string filter = txtFiltriraj.Text.ToLower();
            if (filter != null)
            {

                var result = from korisnik in aktivniKorisnici
                             where korisnik.Ime.ToLower().Contains(filter) || korisnik.Prezime.ToLower().Contains(filter) || (korisnik.Ime.ToLower()+" "+korisnik.Prezime.ToLower()).Contains(filter)
                             orderby korisnik.Prezime
                             select korisnik;
                ObrisiKontake();
                DodajKorisnika(result, Iform);
            }
            else
            {
                var result = from korisnik in aktivniKorisnici
                             orderby korisnik.Prezime
                             select korisnik;
                ObrisiKontake();
                DodajKorisnika(result, Iform);
            }
        }
    }
}
