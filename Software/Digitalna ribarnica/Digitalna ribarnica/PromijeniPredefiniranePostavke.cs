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
using Ponude;
using Prijava;

namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Nikola Muše
    /// </summary>
    public partial class PromijeniPredefiniranePostavke : Form
    {
        Iform Iform;
        public PromijeniPredefiniranePostavke(Iform novo)
        {
            InitializeComponent();
            Iform = novo;
        }

        private void PromijeniPredefiniranePostavke_Load(object sender, EventArgs e)
        {
            PredefiniranePostavke predefiniranePostavke = new PredefiniranePostavke();
            predefiniranePostavke = PonudeRepozitory.PredefiniranePostavke();
            txtCijena.Text = predefiniranePostavke.Cijena.ToString();
            txtKolicina.Text = predefiniranePostavke.Kolicina.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                form.zatvoriForme();
            }
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            if (txtCijena.Text != "" && txtKolicina.Text != "")
            {
                float cijena = float.Parse(txtCijena.Text);
                int kolicina = int.Parse(txtKolicina.Text);
                PonudeRepozitory.AzurirajPredefirniranePostavke(cijena, kolicina);
                PonudeRepozitory.UnesiUDnevnik(KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik), "Korisnik " + Iform.autentifikator.AktivanKorisnik + " je promijenio predefinirane postavke za ponude", 15);
            }
            else
            {
                notifyIcon1.ShowBalloonTip(1000, "Prazna polja", "Cijena ili količina nisu uneseni", ToolTipIcon.Error);
                return;
            }
            formPocetna form = Application.OpenForms.OfType<formPocetna>().FirstOrDefault();
            if (form != null)
            {
                form.zatvoriForme();
            }
        }
    }
}
