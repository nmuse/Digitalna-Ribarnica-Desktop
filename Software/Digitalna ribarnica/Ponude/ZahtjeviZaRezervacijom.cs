using INSform;
using Prijava;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponude
{
    /// <summary>
    /// Author: Nikola Muše
    /// </summary>
    public partial class ZahtjeviZaRezervacijom : Form
    {
        public List<Zahtjev> zahtjevi = new List<Zahtjev>();
        Iform Iform;
        Ponuda ponuda;
        public ZahtjeviZaRezervacijom(Iform novi,Ponuda ponuda)
        {
            InitializeComponent();
            ObrisiPonude();
            zahtjevi = PonudeRepozitory.DohvatiZahtjeve(novi,int.Parse(ponuda.ID));
            DodajPonude(zahtjevi, novi);
            Iform = novi;
            this.ponuda = ponuda;
        }
        /// <summary>
        /// Metoda koja dodaje userControle zahtjeva u panel
        /// </summary>
        /// <param name="zahtjevi">Lista zahtjeva</param>
        /// <param name="iform"></param>

        private void DodajPonude(IEnumerable<Zahtjev> zahtjevi, Iform iform)
        {
            foreach (var item in zahtjevi)
            {
                Zahtjev zahtjev = new Zahtjev(iform);
                zahtjev.ID = item.ID;
                zahtjev.Ime = item.Ime;
                zahtjev.Kolicina = item.Kolicina;
                zahtjev.Max = item.Max;
                zahtjev.Fotografija = item.Fotografija;
                zahtjev.BrojSatiDana = item.BrojSatiDana;
                zahtjev.IDKORISNIKA = item.IDKORISNIKA;
                zahtjev.IDPONUDE = item.IDPONUDE;
                if(item.Znacka!=null)
                    zahtjev.Znacka = item.Znacka;
                if (item.Kolicina > int.Parse(item.Max))
                    zahtjev.nedozvoljenaPonuda();
                this.flowLayoutPanel1.Controls.Add(zahtjev.PrikazUC);
                this.Controls.Remove(zahtjev.PrikazUC);
            }
        }

        private void txtFiltriraj_TextChanged(object sender, EventArgs e)
        {
            List<Zahtjev> sviZahtjevi = PonudeRepozitory.DohvatiZahtjeve(Iform, int.Parse(ponuda.ID));
            string filter = txtFiltriraj.Text.ToLower();
            double broj = 0;
            if (filter != null)
            {
                if (double.TryParse(filter, out broj))
                {
                    var result = from zahtjevi in sviZahtjevi
                                 where zahtjevi.ID == broj || zahtjevi.Kolicina == broj || zahtjevi.Max== filter || zahtjevi.BrojSatiDana==filter
                                 select zahtjevi;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }
                else
                {
                    var result = from zahtjevi in sviZahtjevi
                                 where zahtjevi.Ime.ToLower().Contains(filter)
                                 select zahtjevi;
                    ObrisiPonude();
                    DodajPonude(result, Iform);
                }

            }
            else
            {
                var result = from zahtjevi in sviZahtjevi
                             select zahtjevi;
                ObrisiPonude();
                DodajPonude(result, Iform);
            }
        }

        /// <summary>
        /// Metoda koja briše sve zahtjeve iz panela
        /// </summary>
        private void ObrisiPonude()
        {
            List<int> index = new List<int>();
            int brojac = 0;
            foreach (UCZahtjev item in flowLayoutPanel1.Controls)
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
