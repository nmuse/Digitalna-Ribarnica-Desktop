using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prijava;
using Registracija;
namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public partial class PromijeniLozinku : Form
    {
        Autentifikator autentifikator;
        Code code;
        string Email;
        public PromijeniLozinku(Autentifikator korisnici,Code kod, string email )
        {
            InitializeComponent();
            autentifikator = korisnici;
            code = kod;
            Email = email;
        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            if ((textCode1.Text == (code.Broj / 10000).ToString()) && (textCode2.Text == ((code.Broj / 1000) % 10).ToString()) && (textCode3.Text == ((code.Broj / 100) % 10).ToString()) && (textCode4.Text == ((code.Broj % 100) / 10).ToString()) && (textCode5.Text == (code.Broj % 10).ToString()))
            {
                if (DateTime.Compare(DateTime.Now, code.DatumIsteka) <= 0) //Ovdje provjervamo vrijedi li uneseni kod pomoću usporedbe trentunog datuma s datumom isteka koda
                {

                    formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
                    if (form != null)
                    {
                        form.openChildForm(new NovaLozinka(autentifikator,Email));
                    }
                    Close();
                }
                else
                {
                    notifyUnesiKodZaPromjenu.ShowBalloonTip(1000, "Registration", "Kod ne vrijedi", ToolTipIcon.Info);
                }
            }
            else
            {
                notifyUnesiKodZaPromjenu.ShowBalloonTip(1000, "Promjena lozinke", "Unijeli ste krivi kod!!!", ToolTipIcon.Error);
            }
        }

        private void buttonSaljiPonovno_Click(object sender, EventArgs e)
        {
            timerPromjenaLozinke.Interval = 5000;
            timerPromjenaLozinke.Enabled = true;
            labelObavijest.Visible = true;
            Random codePonovi = new Random();
            int broj = codePonovi.Next(10000, 99999);
            Code noviCode = new Code(broj);
            MailMessage msg = new MailMessage("eribarnica@gmail.com", Email, "Digitalna ribarnica", "<br>Vaš kod za promjenu lozinke je: </br>" + broj);
            msg.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
            sc.UseDefaultCredentials = false;
            NetworkCredential cre = new NetworkCredential("eribarnica@gmail.com", ">H3/Wr9H");//your mail password
            sc.Credentials = cre;
            sc.EnableSsl = true;
            sc.Send(msg);
            code = noviCode;
            notifyUnesiKodZaPromjenu.ShowBalloonTip(1000, "Promjena lozinke", "Poslan vam je novi kod za promjenu lozinke. ",ToolTipIcon.Info);
        }

        private void timerPromjenaLozinke_Tick(object sender, EventArgs e)
        {
            labelObavijest.Visible = false;
            timerPromjenaLozinke.Stop();
        }

        private void textCode1_TextChanged(object sender, EventArgs e)
        {
            if (textCode1.Text.Length == 1)
            {
                textCode2.Focus();
            }
        }

        private void textCode2_TextChanged(object sender, EventArgs e)
        {
            if (textCode2.Text.Length == 1)
            {
                textCode3.Focus();
            }
            else if (textCode2.Text.Length == 0)
            {
                textCode1.Focus();
            }
        }

        private void textCode3_TextChanged(object sender, EventArgs e)
        {
            if (textCode3.Text.Length == 1)
            {
                textCode4.Focus();
            }
            else if (textCode3.Text.Length == 0)
            {
                textCode2.Focus();
            }
        }

        private void textCode4_TextChanged(object sender, EventArgs e)
        {
            if (textCode4.Text.Length == 1)
            {
                textCode5.Focus();
            }
            else if (textCode4.Text.Length == 0)
            {
                textCode3.Focus();
            }
        }

        private void textCode5_TextChanged(object sender, EventArgs e)
        {
            if (textCode5.Text.Length == 1)
            {
                buttonPotvrdi.Focus();
            }
            else if (textCode5.Text.Length == 0)
            {
                textCode4.Focus();
            }
        }
    }
}
