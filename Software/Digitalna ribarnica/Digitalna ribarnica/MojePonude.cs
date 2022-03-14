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
using Lokacije;
using Ponude;
using Prijava;
using RibeUSustavu;
namespace Digitalna_ribarnica
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public partial class MojePonude : Form
    {
        public List<Ponuda> ponude = new List<Ponuda>();
        Iform Iform;
        public MojePonude(Iform novi)
        {
            InitializeComponent();
            if(novi.autentifikator.tipKorisnika(novi.autentifikator.AktivanKorisnik)==1)
                ponude= PonudeRepozitory.DohvatiPonudePoID(novi, -1);
            else
                ponude = PonudeRepozitory.DohvatiPonudePoID(novi, KorisnikRepository.DohvatiIdKorisnika(novi.autentifikator.AktivanKorisnik));
            DodajPonude(ponude, novi);
            Iform = novi;
        }
        /// <summary>
        /// Metoda koja dodaje ponude preko userControle na panel
        /// </summary>
        /// <param name="ponude">Lista svih ponuda</param>
        /// <param name="iform"></param>

        private void DodajPonude(IEnumerable<Ponuda> ponude, Iform iform)
        {
            foreach (var item in ponude)
            {
                Ponuda ponuda = new Ponuda(iform,0);
                ponuda.ID = item.ID;
                ponuda.Kolicina = item.Kolicina;
                ponuda.Mjerna = item.Mjerna;
                ponuda.Naziv = item.Naziv;
                ponuda.Fotografija = item.Fotografija;
                ponuda.Cijena = item.Cijena;
                ponuda.Ime = item.Ime;
                ponuda.Lokacija = item.Lokacija;
                if (item.Znacka != null)
                    ponuda.Znacka = item.Znacka;
                this.flowLayoutPanel1.Controls.Add(ponuda.PrikaziUrediPonudeUC);
                this.Controls.Remove(ponuda.PrikaziUrediPonudeUC);
            }
        }

        private void MojePonude_Load(object sender, EventArgs e)
        {
            List<Riba> ribe = new List<Riba>();
            ribe = RibeRepository.DohvatiNaziveRibe();
            List<Riba> sortiraneRibe = ribe.OrderBy(o => o.Naziv).ToList();
            sortiraneRibe.Insert(0, new Riba("Sve ribe"));
            List<Lokacije.Lokacije> lokacije = new List<Lokacije.Lokacije>();
            lokacije = LokacijeRepozitory.dohvatiLokacije();
            List<Lokacije.Lokacije> sortiraneLokacije = lokacije.OrderBy(o => o.Naziv).ToList();
            sortiraneLokacije.Insert(0, new Lokacije.Lokacije("Sve lokacije"));
            cmbRibe.DataSource = sortiraneRibe;
            cmbLokacije.DataSource = sortiraneLokacije;
        }

        private void txtFiltriraj_TextChanged(object sender, EventArgs e)
        {
            List<Ponuda> svePonude;
            if (Iform.autentifikator.tipKorisnika(Iform.autentifikator.AktivanKorisnik) == 1)
                svePonude = PonudeRepozitory.DohvatiPonudePoID(Iform, -1);
            else
                svePonude = PonudeRepozitory.DohvatiPonudePoID(Iform, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
      
            string filter = txtFiltriraj.Text.ToLower();
            double broj = 0;
            if (filter != null)
            {
                if (double.TryParse(filter, out broj))
                {
                    var result = from ponude in svePonude
                                 where ponude.Cijena == broj || ponude.Kolicina == broj || ponude.ID == filter
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else
                {
                    var result = from ponude in svePonude
                                 where ponude.Naziv.ToLower().Contains(filter) || ponude.Ime.ToLower().Contains(filter) || ponude.Lokacija.ToLower().Contains(filter) || ponude.Mjerna.ToLower().Contains(filter)
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }

            }
            else
            {
                var result = from ponude in svePonude
                             select ponude;
                ObrisiPonude();
                DodajPonude(result, Iform);
            }
        }

        /// <summary>
        /// Metoda koja briše ponude iz panela prikaza ponuda
        /// </summary>
        private void ObrisiPonude()
        {
            List<int> index = new List<int>();
            int brojac = 0;
            foreach (UCUrediPonude item in flowLayoutPanel1.Controls)
            {
                index.Add(flowLayoutPanel1.Controls.GetChildIndex(item));
            }

            foreach (var item in index)
            {
                flowLayoutPanel1.Controls.RemoveAt(item - brojac);
                brojac++;
            }
        }

        private void btnSortiraj_Click(object sender, EventArgs e)
        {
            List<Ponuda> svePonude;
            if (Iform.autentifikator.tipKorisnika(Iform.autentifikator.AktivanKorisnik) == 1)
                svePonude = PonudeRepozitory.DohvatiPonudePoID(Iform, -1);
            else
                svePonude = PonudeRepozitory.DohvatiPonudePoID(Iform, KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
            string lokacije = cmbLokacije.SelectedItem.ToString();
            string ribe = cmbRibe.SelectedItem.ToString();
            double cijenaMin = -1;
            double cijenaMax = -1;
            bool radioButtonAscending = radioButton1.Checked;
            bool radioButtonDescending = radioButton2.Checked;
            if (txtMin.Text != "")
                cijenaMin = double.Parse(txtMin.Text);
            if (txtMax.Text != "")
                cijenaMax = double.Parse(txtMax.Text);
            if (lokacije != null && cijenaMax != -1 && cijenaMin != -1 && ribe!=null)
            {
                if (radioButtonAscending && lokacije != "Sve lokacije" && ribe!="Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Lokacija == lokacije && ponude.Cijena >= cijenaMin && ponude.Cijena <= cijenaMax && ponude.Naziv == ribe
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if(radioButtonAscending && lokacije != "Sve lokacije" && ribe=="Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Lokacija == lokacije && ponude.Cijena >= cijenaMin && ponude.Cijena <= cijenaMax
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (lokacije == "Sve lokacije" && radioButtonAscending && ribe!="Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Cijena >= cijenaMin && ponude.Cijena <= cijenaMax && ponude.Naziv==ribe
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if(lokacije == "Sve lokacije" && radioButtonAscending && ribe == "Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Cijena >= cijenaMin && ponude.Cijena <= cijenaMax
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (lokacije == "Sve lokacije" && radioButtonDescending && ribe != "Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Cijena >= cijenaMin && ponude.Cijena <= cijenaMax && ponude.Naziv==ribe
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (lokacije == "Sve lokacije" && radioButtonDescending && ribe == "Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Cijena >= cijenaMin && ponude.Cijena <= cijenaMax
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (lokacije != "Sve lokacije" && radioButtonDescending && ribe != "Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Cijena >= cijenaMin && ponude.Cijena <= cijenaMax && ponude.Naziv == ribe && ponude.Lokacija==lokacije
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (lokacije != "Sve lokacije" && radioButtonDescending && ribe == "Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Cijena >= cijenaMin && ponude.Cijena <= cijenaMax && ponude.Lokacija==lokacije
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else
                {
                    var result = from ponude in svePonude
                                 where ponude.Lokacija == lokacije && ponude.Cijena >= cijenaMin && ponude.Cijena <= cijenaMax && ponude.Naziv==ribe
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
            }
            else if (lokacije != null && (cijenaMin == -1 || cijenaMax == -1))
            {
                if (radioButtonAscending && lokacije != "Sve lokacije" && ribe!="Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Lokacija == lokacije && ponude.Naziv==ribe
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (radioButtonAscending && lokacije != "Sve lokacije" && ribe == "Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Lokacija == lokacije
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (lokacije == "Sve lokacije" && radioButtonAscending && ribe!="Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Naziv==ribe
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (lokacije == "Sve lokacije" && radioButtonAscending && ribe == "Sve ribe")
                {
                    var result = from ponude in svePonude
                                 orderby ponude.Cijena ascending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (lokacije == "Sve lokacije" && radioButtonDescending && ribe!="Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Naziv==ribe
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (lokacije == "Sve lokacije" && radioButtonDescending && ribe == "Sve ribe")
                {
                    var result = from ponude in svePonude
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (lokacije != "Sve lokacije" && radioButtonDescending && ribe != "Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Naziv == ribe && ponude.Lokacija==lokacije
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else if (lokacije != "Sve lokacije" && radioButtonDescending && ribe == "Sve ribe")
                {
                    var result = from ponude in svePonude
                                 where ponude.Lokacija == lokacije
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else
                {
                    var result = from ponude in svePonude
                                 where ponude.Lokacija == lokacije && ponude.Naziv==ribe
                                 orderby ponude.Cijena descending
                                 select ponude;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                radioButton1.Checked = false;
        }
    }
}
