using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using Prijava;
using Registracija;

namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// Author: Božo Kvesić
    /// </summary>
    public partial class Registracija : Form
    {
        Autentifikator autentifikator;
        AutentifikacijaRegistracije AutentifikacijaRegistracije;
        public Registracija()
        {
            InitializeComponent();
        }

        public Registracija(Autentifikator autentifikator)
        {
            InitializeComponent();
            this.autentifikator = autentifikator;
        }

        private void Registracija_Load(object sender, EventArgs e)
        {
            txtLozinka.PasswordChar = '\u25CF';
            txtPonoviLozinku.PasswordChar = '\u25CF';
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRegistracija_Click(object sender, EventArgs e)
        {
            try
            {
                    AutentifikacijaRegistracije = new AutentifikacijaRegistracije(txtIme.Text, txtPrezime.Text, txtKorIme.Text, txtAdresa.Text, txtMjesto.Text, txtMobitel.Text, textEmail.Text, txtLozinka.Text, txtPonoviLozinku.Text);
                    autentifikator.provjeriKorisnika(txtKorIme.Text);
                    autentifikator.provjeriKorisnika1(txtKorIme.Text);
                    autentifikator.provjeriKorisnika2(txtKorIme.Text);
                    autentifikator.NePostojiEmail(textEmail.Text);
                    Random verificationCode = new Random();
                    int broj = verificationCode.Next(10000, 99999);
                    Code code = new Code(broj);
                    MailMessage msg = new MailMessage("eribarnica@gmail.com", textEmail.Text, "Digitalna ribarnica", "<br>Vaš kod za aktivaciju računa je: </br>" + broj);
                    msg.IsBodyHtml = true;
                    SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                    sc.UseDefaultCredentials = false;
                    NetworkCredential cre = new NetworkCredential("eribarnica@gmail.com", ">H3/Wr9H");//your mail password
                    sc.Credentials = cre;
                    sc.EnableSsl = true;
                    sc.Send(msg);
                    //MessageBox.Show("Mail Send");
                    notifyRegistracija.ShowBalloonTip(1000, "Code", "Kod za registraciju je poslan na Vaš mail!", ToolTipIcon.Info);

                    formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
                    if (form != null)
                    {
                        //TODO dodati kontruktor VerificationCode koji prima sve podatke (ime, prezime, korime, adresa, mjesto, mobitel, email..)
                        //form.openChildForm(new VerificationCode(txtKorIme.Text, txtLozinka.Text, broj, textEmail.Text, autentifikator));
                        form.openChildForm(new VerificationCode(txtKorIme.Text, txtLozinka.Text, code, textEmail.Text, autentifikator,txtIme.Text,txtPrezime.Text,txtAdresa.Text,txtMjesto.Text,txtMobitel.Text));
                    }
            }
            catch (RegistrationException ex)
            {
                //MessageBox.Show(ex.Poruka);
                notifyRegistracija.ShowBalloonTip(1000, "Registracija", ex.Poruka, ToolTipIcon.Warning);
            }
            catch (PrijavaException ex)
            {
                //MessageBox.Show(ex.Poruka);
                notifyRegistracija.ShowBalloonTip(1000, "Registracija", ex.Poruka, ToolTipIcon.Warning);
            }
            
           
        }
        /// <summary>
        /// Ovdje se nalaze implementirani eventhandleri koji upravljaju placeholderom na stranici registracija
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIme_Enter(object sender, EventArgs e)
        {
            if (txtIme.Text == "Pero")
            {
                txtIme.Text = "";
                txtIme.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtIme.ForeColor=Color.FromArgb(210, 249, 233);
        }

        private void txtIme_Leave(object sender, EventArgs e)
        {
            if (txtIme.Text == "")
            {
                txtIme.Text = "Pero";
                txtIme.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtIme.ForeColor = Color.FromArgb(210, 249, 233);
        }

        private void txtPrezime_Enter(object sender, EventArgs e)
        {
            if (txtPrezime.Text == "Perić")
            {
                txtPrezime.Text = "";
                txtPrezime.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtPrezime.ForeColor = Color.FromArgb(210, 249, 233);
        }

        private void txtPrezime_Leave(object sender, EventArgs e)
        {
            if (txtPrezime.Text == "")
            {
                txtPrezime.Text = "Perić";
                txtPrezime.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtPrezime.ForeColor = Color.FromArgb(210, 249, 233);

        }

        private void txtKorIme_Enter(object sender, EventArgs e)
        {
            if (txtKorIme.Text == "pperic13")
            {
                txtKorIme.Text = "";
                txtKorIme.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtKorIme.ForeColor = Color.FromArgb(210, 249, 233);
        }

        private void txtKorIme_Leave(object sender, EventArgs e)
        {
            if (txtKorIme.Text == "")
            {
                txtKorIme.Text = "pperic13";
                txtKorIme.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtKorIme.ForeColor = Color.FromArgb(210, 249, 233);

        }

        private void txtAdresa_Enter(object sender, EventArgs e)
        {
            if (txtAdresa.Text == "ulica Pere Perica 30")
            {
                txtAdresa.Text = "";
                txtAdresa.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtAdresa.ForeColor = Color.FromArgb(210, 249, 233);
        }

        private void txtAdresa_Leave(object sender, EventArgs e)
        {
            if (txtAdresa.Text == "")
            {
                txtAdresa.Text = "ulica Pere Perica 30";
                txtAdresa.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtAdresa.ForeColor = Color.FromArgb(210, 249, 233);

        }

        private void txtMjesto_Enter(object sender, EventArgs e)
        {
            if (txtMjesto.Text == "Staro Petrovo selo 10000")
            {
                txtMjesto.Text = "";
                txtMjesto.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtMjesto.ForeColor = Color.FromArgb(210, 249, 233);
        }

        private void txtMjesto_Leave(object sender, EventArgs e)
        {
            if (txtMjesto.Text == "")
            {
                txtMjesto.Text = "Staro Petrovo selo 10000";
                txtMjesto.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtMjesto.ForeColor = Color.FromArgb(210, 249, 233);

        }

        private void txtMobitel_Enter(object sender, EventArgs e)
        {
            if (txtMobitel.Text == "+38599123456789")
            {
                txtMobitel.Text = "";
                txtMobitel.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtMobitel.ForeColor = Color.FromArgb(210, 249, 233);
        }

        private void txtMobitel_Leave(object sender, EventArgs e)
        {
            if (txtMobitel.Text == "")
            {
                txtMobitel.Text = "+38599123456789";
                txtMobitel.ForeColor = Color.FromArgb(210, 249, 233);
            }
            txtMobitel.ForeColor = Color.FromArgb(210, 249, 233);

        }

        private void textEmail_Enter(object sender, EventArgs e)
        {
            if (textEmail.Text == "pperic@gmail.com")
            {
                textEmail.Text = "";
                textEmail.ForeColor = Color.FromArgb(210, 249, 233);
            }
            textEmail.ForeColor = Color.FromArgb(210, 249, 233);
        }

        private void textEmail_Leave(object sender, EventArgs e)
        {
            if (textEmail.Text == "")
            {
                textEmail.Text = "pperic@gmail.com";
                textEmail.ForeColor = Color.FromArgb(210, 249, 233);
            }
            textEmail.ForeColor = Color.FromArgb(210, 249, 233);

        }
    }
}
