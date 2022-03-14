using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Prijava;
using System.Data.Common;
using System.IO;
using Baza;
using Ponude;
namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public partial class Prijava : Form
    {
        public Label label_prijava;
        public Button prijava_prijava;
        public Button odjava_prijava;
        public Button novosti;
        public Button Registracija;
        public Button Korisnicki_racun;
        Autentifikator autentifikator;
        public PictureBox Profilna;
        public Button RibeUSustavu;
        public Button Lokacija;
        public Button MojeRezervacije;
        public Button MojePonude;
        public Button OdobreneRezervacije;
        public Button Neocijenjen;
        public Button Korisnici;
        public Button Predefinirane;
        public Button Dnevnik;
        public Button Chat;
        //bool focus = false;
        public Prijava()
        {
            InitializeComponent();
        }

        public Prijava(Label label,Button prijava, Button odjava,Button novosti,Button registracija,Autentifikator korisnici,Button Korisnicki_racun,PictureBox profilnaSlika,Button ribe,Button lokacija,Button mojeRezervacije, Button mojePonude, Button Odobrene, Button Neocijenjen,Button btnKorisnici,Button predefinirane,Button dnevnik,Button chat)
        {
            InitializeComponent();
            label_prijava = label;
            prijava_prijava = prijava;
            odjava_prijava = odjava;
            this.novosti = novosti;
            Registracija = registracija;
            autentifikator = korisnici;
            this.Korisnicki_racun = Korisnicki_racun;
            Profilna = profilnaSlika;
            RibeUSustavu = ribe;
            Lokacija = lokacija;
            MojeRezervacije = mojeRezervacije;
            MojePonude = mojePonude;
            OdobreneRezervacije = Odobrene;
            this.Neocijenjen = Neocijenjen;
            this.Korisnici = btnKorisnici;
            Predefinirane = predefinirane;
            Dnevnik = dnevnik;
            Chat = chat;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPrijavi_Click(object sender, EventArgs e)
        {
            if(txtKorIme.TextLength!=0 && txtLozinka.TextLength != 0)
            {
                if (autentifikator.prijava(txtKorIme.Text, txtLozinka.Text))
                {
                    /*
                    if (autentifikator.tipKorisnika(txtKorIme.Text) == 1)
                    {
                        notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava ADMIN", ToolTipIcon.Info);
                    }
                    else if (autentifikator.tipKorisnika(txtKorIme.Text) == 2)
                    {
                        notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava KORISNIK", ToolTipIcon.Info);
                    }
                    else if (autentifikator.tipKorisnika(txtKorIme.Text) == 3)
                    {
                        notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava KUPAC", ToolTipIcon.Info);
                    }
                    else
                    {
                        notifyPrijava.ShowBalloonTip(1000, "Prijava", "Vaš račun je blokiran", ToolTipIcon.Error);
                    }
                    */
                    PonudeRepozitory.IDRezervacijeZaProvjeruRoka();
                    PonudeRepozitory.IDRezervacijeZaProvjeruRoka();
                    autentifikator.prijavljen = 1;
                    switch (autentifikator.tipKorisnika(txtKorIme.Text))
                    {
                        case 1:
                            //MessageBox.Show("Uspješna prijava ADMIN");
                            notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava ADMIN", ToolTipIcon.Info);
                            label_prijava.Text = "Dobro došli " + txtKorIme.Text;
                            autentifikator.AktivanKorisnik = txtKorIme.Text;
                            KorisnikRepository.AktivanKorisnik(KorisnikRepository.DohvatiIdKorisnika(autentifikator.AktivanKorisnik));
                            PonudeRepozitory.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(autentifikator.AktivanKorisnik), "Korisnik " + autentifikator.AktivanKorisnik + " se prijavio", 1);
                            //MessageBox.Show(autentifikator.AktivanKorisnik);
                            prijava_prijava.Visible = false;
                            odjava_prijava.Visible = true;
                            novosti.Visible = true;
                            Registracija.Visible = false;
                            Korisnicki_racun.Visible = true;
                            RibeUSustavu.Visible = true;
                            Lokacija.Visible = true;
                            MojeRezervacije.Visible = true;
                            MojePonude.Visible = true;
                            OdobreneRezervacije.Visible = true;
                            Neocijenjen.Visible = true;
                            Korisnici.Visible = true;
                            Predefinirane.Visible = true;
                            Dnevnik.Visible = true;
                            Chat.Visible = true;
                            postaviSlikuProfila();
                            Close();
                            break;
                        case 2:
                            //MessageBox.Show("Uspješna prijava KORISNIK");
                            notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava KORISNIK", ToolTipIcon.Info);
                            label_prijava.Text = "Dobro došli " + txtKorIme.Text;
                            autentifikator.AktivanKorisnik = txtKorIme.Text;
                            KorisnikRepository.AktivanKorisnik(KorisnikRepository.DohvatiIdKorisnika(autentifikator.AktivanKorisnik));
                            PonudeRepozitory.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(autentifikator.AktivanKorisnik), "Korisnik " + autentifikator.AktivanKorisnik + " se prijavio", 1);
                            prijava_prijava.Visible = false;
                            odjava_prijava.Visible = true;
                            novosti.Visible = true;
                            Registracija.Visible = false;
                            Korisnicki_racun.Visible = true;
                            MojeRezervacije.Visible = true;
                            MojePonude.Visible = true;
                            OdobreneRezervacije.Visible = true;
                            Neocijenjen.Visible = true;
                            Chat.Visible = true;
                            postaviSlikuProfila();
                            Close();
                            break;
                        case 3:
                            //MessageBox.Show("Uspješna prijava KUPAC");
                            notifyPrijava.ShowBalloonTip(1000, "Prijava", "Uspješna prijava KUPAC", ToolTipIcon.Info);
                            label_prijava.Text = "Dobro došli " + txtKorIme.Text;
                            autentifikator.AktivanKorisnik = txtKorIme.Text;
                            KorisnikRepository.AktivanKorisnik(KorisnikRepository.DohvatiIdKorisnika(autentifikator.AktivanKorisnik));
                            PonudeRepozitory.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(autentifikator.AktivanKorisnik), "Korisnik " + autentifikator.AktivanKorisnik + " se prijavio", 1);
                            prijava_prijava.Visible = false;
                            odjava_prijava.Visible = true;
                            novosti.Visible = true;
                            Registracija.Visible = false;
                            Korisnicki_racun.Visible = true;
                            MojeRezervacije.Visible = true;
                            MojePonude.Visible = true;
                            OdobreneRezervacije.Visible = true;
                            Neocijenjen.Visible = true;
                            Chat.Visible = true;
                            postaviSlikuProfila();
                            Close();
                            break;
                        default:
                            //MessageBox.Show("Blokiran račun");
                            notifyPrijava.ShowBalloonTip(1000, "Prijava", "Vaš račun je blokiran", ToolTipIcon.Error);
                            break;
                    }
                    
                }
                else
                {
                    //MessageBox.Show("Pogrešna lozinka ili korisničko ime");
                    notifyPrijava.ShowBalloonTip(1000, "Prijava", "Pogrešna lozinka ili korisničko ime", ToolTipIcon.Error);
                }
            }
            else {
                notifyPrijava.ShowBalloonTip(1000, "Prijava", "Ostavili ste prazno polje", ToolTipIcon.Error);
            }
            
        }

        /// <summary>
        /// Metoda koja postavlja profilnu sliku korisnika kod prijave korisnika
        /// </summary>
        public void postaviSlikuProfila()
        {
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            //var rezultat = DB.Instance.DohvatiDataReader("SELECT * FROM Slika_test;");A}
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT * FROM korisnici WHERE korisnicko_ime='{autentifikator.AktivanKorisnik}';");
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
                    Image image = Image.FromStream(ms);
                    Profilna.Visible = true;
                    Profilna.Image = Image.FromStream(ms);
                }
            }
            rezultat.Close();
        }
        private void labelRegistracija_Click(object sender, EventArgs e)
        {
            /*
            //this.Hide();
            Registracija registracija = new Registracija();   
            registracija.ShowDialog();
            */
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                form.openChildForm(new Registracija());
            }
        }

        private void Prijava_Load(object sender, EventArgs e)
        {
            txtLozinka.PasswordChar = '\u25CF';
            
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                labelCapsLock.Text = "Uključeno je pisanje VELIKIM SLOVIMA!";
                labelCapsLock.Visible = true;
            }
            else
            {
                labelCapsLock.Visible = false;
            }
            
        }

        private void txtKorIme_KeyUp(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                labelCapsLock.Text = "Uključeno je pisanje VELIKIM SLOVIMA!";
                labelCapsLock.Visible = true;
            }
            else
            {
                labelCapsLock.Visible = false;
            }
        }

        private void txtLozinka_KeyUp(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                labelCapsLock.Text = "Uključeno je pisanje VELIKIM SLOVIMA!";
                labelCapsLock.Visible = true;
            }
            else
            {
                labelCapsLock.Visible = false;
            }
        }
        
        private void Prijava_Paint(object sender, PaintEventArgs e)
        {
            /*
            if (focus)
            {
                txtKorIme.BorderStyle = BorderStyle.None;
                Pen p = new Pen(Color.Red);
                Graphics g = e.Graphics;
                int variance = 3;
                g.DrawRectangle(p, new Rectangle(txtKorIme.Location.X - variance, txtKorIme.Location.Y - variance, txtKorIme.Width + variance, txtKorIme.Height + variance));
            }
            else
            {
                txtKorIme.BorderStyle = BorderStyle.FixedSingle;
            }
            */
        }

        private void txtKorIme_Enter(object sender, EventArgs e)
        {
            /*
            focus = true;
            this.Refresh();
            */

            //Placeholder
            if (txtKorIme.Text == "pperic13")
            {
                txtKorIme.Text = "";
                txtKorIme.ForeColor = Color.Black;
            }
            txtKorIme.ForeColor = Color.FromArgb(165, 243, 212);
        }

        private void txtKorIme_Leave(object sender, EventArgs e)
        {
            /*
            focus = false;
            this.Refresh();
            */

            //Placeholder
            if (txtKorIme.Text == "")
            {
                txtKorIme.Text = "pperic13";
                txtKorIme.ForeColor = Color.Silver;
            }
        }

        private void labelZaboravljenaLozinka_Click(object sender, EventArgs e)
        {
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                form.openChildForm(new ZaboravljenaLozinkaEmail(autentifikator));
            }
        }
    }
}
