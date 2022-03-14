using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Baza;
using INSform;
using Prijava;
using Registracija;
namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public partial class NoviKorisnik : Form
    {
        Iform Iform = null;
        Image defaultSlika;
        Korisnik Korisnik = null;
        public string TrenutnoKorIme = "";
        Autentifikator Autentifikator = null;
        public NoviKorisnik(Iform novi)
        {
            InitializeComponent();
            Iform = novi;
        }

        public NoviKorisnik(Iform novi, Korisnik korisnik)
        {
            InitializeComponent();
            Iform = novi;
            Korisnik = korisnik;
        }

        public NoviKorisnik(Korisnik korisnik,Autentifikator autentifikator)
        {
            InitializeComponent();
            Iform = null;
            Korisnik = korisnik;
            Autentifikator = autentifikator;
        }
        /// <summary>
        /// Metoda koja dohvaća defaultnu sliku korisnika ako ne postoji u bazi
        /// </summary>
        public void dohhvatiDefaultSliku()
        {
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT * FROM slike;");
            foreach (DbDataRecord item in rezultat)
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < item.FieldCount; i++)
                {
                    row.Add(item.GetName(i), item[i]);
                }
                returnMe.Add(row);
            }

            foreach (var item in returnMe)
            {
                if (item["slika"].ToString() != "")
                {
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    defaultSlika = Image.FromStream(ms);
                }
            }
            rezultat.Close();
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            var parameters = new Dictionary<string, object>();
            MemoryStream ms = new MemoryStream();
            dohhvatiDefaultSliku();
            defaultSlika.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            if (KorisnikRepository.ProvjeriKorIme(txtKorIme.Text,TrenutnoKorIme) != 0)
            {
                notifyIcon1.ShowBalloonTip(1000, "Korisničko ime", "Korisnik s tim korisničkim imenom postoji", ToolTipIcon.Warning);
                return;
            }
            else
            {
                if (KorisnikRepository.ProvjeriEmail(txtEmail.Text,TrenutnoKorIme) != 0)
                {
                    notifyIcon1.ShowBalloonTip(1000, "Email", "Takav mail je već registriran", ToolTipIcon.Warning);
                    return;
                }
                else
                {
                    if (txtLozinka.TextLength==0)
                    {
                        notifyIcon1.ShowBalloonTip(1000, "Lozinka", "Unesite lozinku", ToolTipIcon.Warning);
                        return;
                    }
                    else
                    {
                        try
                        {
                            AutentifikacijaRegistracije autentifikacijaRegistracije = new AutentifikacijaRegistracije(txtIme.Text, txtPrezime.Text, txtKorIme.Text, txtadresa.Text, txtMjesto.Text, txtMob.Text, txtEmail.Text, txtLozinka.Text, txtLozinka.Text);
                            Autentifikator autentifikator = new Autentifikator();
                            autentifikator.provjeriKorisnika(txtKorIme.Text);
                            autentifikator.provjeriKorisnika2(txtKorIme.Text);
                            string hash = BCrypt.Net.BCrypt.HashPassword(txtLozinka.Text, BCrypt.Net.BCrypt.GenerateSalt(12));
                            parameters.Add("@ime", txtIme.Text);
                            parameters.Add("@prezime", txtPrezime.Text);
                            parameters.Add("@email", txtEmail.Text);
                            parameters.Add("@korime", txtKorIme.Text);
                            parameters.Add("@broj", txtMob.Text);
                            parameters.Add("@datum", DateTime.Now);
                            parameters.Add("@lozinka", hash);
                            parameters.Add("@adresa", txtadresa.Text);
                            parameters.Add("@mjesto", txtMjesto.Text);
                            if (Korisnik == null)
                                parameters.Add("@slika", ms.ToArray());
                            if (Iform != null)
                            {
                                if (cmbTip.SelectedItem.ToString() == "Admin")
                                    parameters.Add("@tip", 1);
                                else
                                    parameters.Add("@tip", 2);
                            }
                            else
                                parameters.Add("@tip", Korisnik.Tip);
                            parameters.Add("@status", 2);

                            if (Korisnik != null)
                            {
                                if (Iform == null)
                                {
                                    Autentifikator.AktivanKorisnik = txtKorIme.Text;
                                }
                                parameters.Add("@id", Korisnik.ID);
                                DB.Instance.ExecuteParamQuery("UPDATE [korisnici] set [ime] = (@ime), [prezime] = (@prezime), [email] = (@email), [korisnicko_ime] = (@korime), [broj_mobitela] = (@broj), [lozinka] = (@lozinka), [adresa] = (@adresa), [mjesto] = (@mjesto), [id_tip_korisnika] = (@tip), [id_status]=(@status) where [id_korisnik] = (@id)", parameters);
                                if (Autentifikator != null)
                                    KorisnikRepository.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(Autentifikator.AktivanKorisnik), "Korisnik " + Autentifikator.AktivanKorisnik + " je ažurirao korisnika " + txtKorIme.Text, 9);
                                else
                                    KorisnikRepository.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), "Korisnik " + Iform.autentifikator.AktivanKorisnik + " je ažurirao korisnika " + txtKorIme.Text, 9);
                            }
                            else
                            {
                                DB.Instance.ExecuteParamQuery("INSERT INTO [korisnici] ([ime], [prezime], [email], [korisnicko_ime], [broj_mobitela], [datum_rodenja], [lozinka], [adresa], [mjesto], [slika], [id_tip_korisnika], [id_status]) VALUES((@ime), (@prezime), (@email), (@korime), (@broj), (@datum), (@lozinka), (@adresa), (@mjesto), (@slika), (@tip), (@status));", parameters);
                                KorisnikRepository.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), "Korisnik " + Iform.autentifikator.AktivanKorisnik + " je registrirao korisnika " + txtKorIme.Text, 8);
                            }
                            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
                            if (form != null)
                                form.zatvoriForme();
                        }
                        catch (RegistrationException ex)
                        {
                            notifyIcon1.ShowBalloonTip(1000, "Registracija", ex.Poruka, ToolTipIcon.Warning);
                        }
                        catch (PrijavaException ex)
                        {
                            //MessageBox.Show(ex.Poruka);
                            notifyIcon1.ShowBalloonTip(1000, "Registracija", ex.Poruka, ToolTipIcon.Warning);
                        }
                    }
                }
            }
        }

        private void NoviKorisnik_Load(object sender, EventArgs e)
        {

            txtLozinka.PasswordChar = '\u25CF';

            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                lblCapsLock.Text = "Uključeno je pisanje VELIKIM SLOVIMA!";
                lblCapsLock.Visible = true;
            }
            else
            {
                lblCapsLock.Visible = false;
            }
            List<string> tipovi = new List<string>() { "Admin", "Korisnik" };
            cmbTip.DataSource = tipovi;
            if (Korisnik != null && Iform !=null)
            {
                cmbTip.Visible = true;
                lblTip.Visible = true;
                btnKreiraj.Text = "Ažuriraj";
                txtadresa.Text = Korisnik.Adresa;
                txtEmail.Text = Korisnik.Email;
                txtIme.Text = Korisnik.Ime;
                txtKorIme.Text = Korisnik.KorIme;
                //txtLozinka.Text = Korisnik.Lozinka;
                txtMjesto.Text = Korisnik.Mjesto;
                txtMob.Text = Korisnik.BrojMobitela;
                txtPrezime.Text = Korisnik.Prezime;
                TrenutnoKorIme = txtKorIme.Text;
                if (Korisnik.Tip == 1)
                    cmbTip.SelectedIndex = 0;
                else
                    cmbTip.SelectedIndex = 1;
            }
            else if (Iform == null && Korisnik != null)
            {
                cmbTip.Visible = false;
                lblTip.Visible = false;
                btnKreiraj.Text = "Ažuriraj";
                txtadresa.Text = Korisnik.Adresa;
                txtEmail.Text = Korisnik.Email;
                txtIme.Text = Korisnik.Ime;
                txtKorIme.Text = Korisnik.KorIme;
                //txtLozinka.Text = Korisnik.Lozinka;
                txtMjesto.Text = Korisnik.Mjesto;
                txtMob.Text = Korisnik.BrojMobitela;
                txtPrezime.Text = Korisnik.Prezime;
                TrenutnoKorIme = txtKorIme.Text;
            }
            else
            {
                btnKreiraj.Text = "Kreiraj";
                cmbTip.Visible = true;
                lblTip.Visible = true;

            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
