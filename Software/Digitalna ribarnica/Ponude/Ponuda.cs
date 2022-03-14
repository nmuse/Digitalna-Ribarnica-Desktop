using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSform;
using Prijava;

namespace Ponude
{
	/// <summary>
	/// Author: Nikola Muše
	/// </summary>
	public class Ponuda
    {
		public UCPonuda PrikazUC = null;
		public UCUrediPonude PrikaziUrediPonudeUC = null;
		private string naziv;
		private Image fotografija;
		private float cijena;
		private int kolicina;
		private string mjerna;
		private string id;
		private string ime;
		private string lokacija;
		private int IDKorisnika;
		private Image znacka;
		int zastava = 0;


		public int IDKORISNIKA
		{
			get { return IDKorisnika; }
			set
			{
				if (zastava == 1)
				{
					IDKorisnika = value;
					PrikazUC.IDkorisnika = IDKorisnika;
				}
				else
				{
					IDKorisnika = value;
					PrikaziUrediPonudeUC.IDKorisnika = IDKorisnika;
				}
			}
		}
		public string Lokacija
		{
			get { return lokacija; }
			set
			{
				if (zastava == 1)
				{
					lokacija = value;
					PrikazUC.ucLokacija.Text = lokacija;
				}
				else
				{
					lokacija = value;
					PrikaziUrediPonudeUC.ucLokacija.Text = lokacija;
				}
			}
		}

		public string Ime
		{
			get { return ime; }
			set
			{
				if (zastava == 1)
				{
					ime = value;
					PrikazUC.ucPonuditelj.Text = ime;
				}
				else
				{
					ime = value;
					PrikaziUrediPonudeUC.ucPonuditelj.Text = ime;
				}
			}
		}
		public string ID
		{
			get { return id; }
			set
			{
				if (zastava == 1)
				{
					id = value;
					PrikazUC.ucID.Text = id;
				}
				else
				{
					id = value;
					PrikaziUrediPonudeUC.ucID.Text = id;
				}
			}
		}

		public string Mjerna
		{
			get { return mjerna; }
			set
			{
				if (zastava == 1)
				{
					mjerna = value;
					PrikazUC.ucMjerna.Text = mjerna;
				}
				else
				{
					mjerna = value;
					PrikaziUrediPonudeUC.ucMjerna.Text = mjerna;
				}
			}
		}
		public float Cijena
		{
			get { return cijena; }
			set 
			{
				if (zastava == 1)
				{
					cijena = value;
					PrikazUC.ucCijena.Text = cijena.ToString();
				}
				else
				{
					cijena = value;
					PrikaziUrediPonudeUC.ucCijena.Text = cijena.ToString();
				}
			}
		}

		public int Kolicina
		{
			get { return kolicina; }
			set
			{
				if (zastava == 1)
				{
					kolicina = value;
					PrikazUC.ucKolicina.Text = kolicina.ToString();
				}
				else
				{
					kolicina = value;
					PrikaziUrediPonudeUC.ucKolicina.Text = kolicina.ToString();
				}
			}
		}

		public string Naziv
		{
			get { return naziv; }
			set
			{
				if (zastava == 1)
				{
					naziv = value;
					PrikazUC.ucNaziv.Text = naziv;
				}
				else
				{
					naziv = value;
					PrikaziUrediPonudeUC.ucNaziv.Text = naziv;
				}
			}
		}

		public Image Fotografija
		{
			get { return fotografija; }
			set
			{
				if (zastava == 1)
				{
					fotografija = value;
					PrikazUC.ucFotografija.Image = fotografija;
				}
				else
				{
					fotografija = value;
					PrikaziUrediPonudeUC.ucFotografija.Image = fotografija;
				}
			}
		}

		public Image Znacka
		{
			get { return znacka; }
			set
			{
				if (zastava == 1)
				{
					znacka = value;
					PrikazUC.ucZnacka.Image = znacka;
				}
				else
				{
					znacka = value;
					PrikaziUrediPonudeUC.ucZnacka.Image = znacka;
				}
			}
		}
		/*
		public Ponuda()
		{
			PrikazUC = new UCPonuda();
			PrikazUC.LoadPonuda(this);
		}
		*/

		public void ProvjeraKontaktiranjaSamogSebe(Iform Iform)
		{
			if (IDKORISNIKA == KorisnikRepository.DohvatiIdKorisnika(Iform.autentifikator.AktivanKorisnik) && Iform.autentifikator.prijavljen!=0)
				PrikazUC.btnKontaktirajKupca.Visible = false;
			else if(Iform.autentifikator.prijavljen != 0)
				PrikazUC.btnKontaktirajKupca.Visible = true;
			else if (Iform.autentifikator.prijavljen==0)
				PrikazUC.btnKontaktirajKupca.Visible = false;
			
		}

		public void PostojiUloga(Iform Iform)
		{
			if (Iform.autentifikator.prijavljen==0)
				PrikazUC.btnKontaktirajKupca.Visible = false;
			else
				PrikazUC.btnKontaktirajKupca.Visible = true;
		}
		public Ponuda(Iform iform, int i=1)
		{
			zastava = i;
			if (i == 1)
			{
				PrikazUC = new UCPonuda(iform);
				PrikazUC.LoadPonuda(this);
				
			}
			else
			{
				PrikaziUrediPonudeUC = new UCUrediPonude(iform);
				PrikaziUrediPonudeUC.LoadPonuda(this);
			}
		}
	}
}
