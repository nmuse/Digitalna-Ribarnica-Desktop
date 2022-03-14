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
namespace Ocjene
{
    /// <summary>
    /// Author: Nikola Muše
    /// Author: Anabela Pranjić
    /// </summary>
    public partial class OcjeneKorisnika : Form
    {
        public List<Ocjena> ocjene = new List<Ocjena>();
        public List<Ocjena> prosjek = new List<Ocjena>();
        Iform Iform;
        public OcjeneKorisnika(Iform nova,int id)
        {
            InitializeComponent();
            Iform = nova;
            //ocjene = OcjeneRepozitory.DohvatiOcjene(nova,KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik));
            ocjene = OcjeneRepozitory.DohvatiOcjene(nova, id);
            ObrisiPonude();
            DodajPonude(ocjene, nova);
            prosjek = OcjeneRepozitory.DohvatiProsjek(nova, id);
            
            foreach (var item in prosjek)
            {
                
                ucOcjenaSlike.Image = item.SlikaOcjene;
                ucNaziv.Text = Math.Round(double.Parse(item.Prosjek.ToString()), 1).ToString();
            }
            if (ucNaziv.Text == "0")
            {
                lblObavijest.Text = "Korisnik još nema ocjena!";
                lblObavijest.Visible = true;
            }
            else
            {
                lblObavijest.Visible = false;
            }

        }

        /// <summary>
        /// Metoda koja prikazuje userControle ocjena u panelu
        /// </summary>
        /// <param name="ocjene">Lista ocjena</param>
        /// <param name="iform"></param>
        private void DodajPonude(IEnumerable<Ocjena> ocjene, Iform iform)
        {
            foreach (var item in ocjene)
            {
                Ocjena ocjena = new Ocjena(Iform);
                ocjena.Komentar = item.Komentar;
                ocjena.Ocjenaa = item.Ocjenaa;
                ocjena.ID = item.ID;
                ocjena.Profilna = item.Profilna;
                ocjena.SlikaOcjene = item.SlikaOcjene;
                this.flowLayoutPanel1.Controls.Add(ocjena.PrikazUC);
                this.Controls.Remove(ocjena.PrikazUC);
            }
        }

        /// <summary>
        /// Metoda koja briše sve ocjene iz panela ocjena
        /// </summary>
        private void ObrisiPonude()
        {
            List<int> index = new List<int>();
            int brojac = 0;
            foreach (UCOcjena item in flowLayoutPanel1.Controls)
            {
                index.Add(flowLayoutPanel1.Controls.GetChildIndex(item));
            }

            foreach (var item in index)
            {
                flowLayoutPanel1.Controls.RemoveAt(item - brojac);
                brojac++;
            }
        }
    }
}
