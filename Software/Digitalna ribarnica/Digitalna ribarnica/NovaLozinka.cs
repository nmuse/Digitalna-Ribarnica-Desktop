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
using Baza;
using Ponude;

namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public partial class NovaLozinka : Form
    {
        Autentifikator autentifikator;
        string Email;
        public NovaLozinka(Autentifikator korisnici,string email)
        {
            InitializeComponent();
            autentifikator=korisnici;
            Email = email;
        }

        private void NovaLozinka_Load(object sender, EventArgs e)
        {
            txtLozinka.PasswordChar = '\u25CF';
            txtPonoviLozinku.PasswordChar = '\u25CF';
        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLozinka.Text == txtPonoviLozinku.Text)
                {
                    if (txtLozinka.TextLength > 6)
                    {
                        //autentifikator.findKorisnik(Email).Lozinka = txtLozinka.Text;
                        KorisnikRepository.PromjeniLozinku(txtLozinka.Text, Email);
                        KorisnikRepository.UnesiUDnevnik(KorisnikRepository.DohvatiIDpoEmailu(Email).ID, "Korisnik " + KorisnikRepository.DohvatiIDpoEmailu(Email).KorIme + " je promijenio lozinku ", 24);
                        formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
                        if (form != null)
                        {
                            form.labelOdjava.Text = "Uspješna promjena lozinke!";
                            form.labelOdjava.Visible = true;
                        }
                        notifyPromijeni.ShowBalloonTip(1000, "Promjena lozinke", "Uspješno ste promijenili lozinku!", ToolTipIcon.Info);
                        Close();
                    }
                    else
                      throw new PrijavaException("Lozinka mora sadržavati minimalno 7 znakova");
                }
                else
                    throw new PrijavaException("Lozinka se mora podudarati sa ponovi lozinku");
            }
            catch (PrijavaException ex)
            {
                notifyPromijeni.ShowBalloonTip(1000, "Upozorenje", ex.Poruka, ToolTipIcon.Error);
            }

        }
    }
}
