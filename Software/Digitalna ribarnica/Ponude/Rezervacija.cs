using INSform;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponude
{
	/// <summary>
	/// Author: Božo Kvesić
	/// </summary>
	public class Rezervacija
	{
		public UCRezevacija PrikazUC = null;
		private Image fotografija;
		private int kolicina;
		private int Id;
		private string mjerna;
		private float cijena;
		private string naziv;
		private string lokacija;
		private string ime;
		private string kupac;
		private int IDKUPCA;
		private DateTime datum;

	
		public int IDkupca
		{
			get { return IDKUPCA; }
			set
			{
				IDKUPCA = value;
				PrikazUC.IDKupca = IDKUPCA;
			}
		}
		public string Ime
		{
			get { return ime; }
			set
			{
				ime = value;
				PrikazUC.ucPonuditelj.Text = ime;
			}
		}
		public string Lokacija
		{
			get { return lokacija; }
			set
			{
				lokacija = value;
				PrikazUC.ucLokacija.Text = lokacija;
			}
		}
		public string Mjerna
		{
			get { return mjerna; }
			set
			{
				mjerna = value;
				PrikazUC.ucMjerna.Text = mjerna;

			}
		}
		public float Cijena
		{
			get { return cijena; }
			set
			{
				cijena = value;
				PrikazUC.ucCijena.Text = cijena.ToString();

			}
		}
		public int ID
		{
			get { return Id; }
			set
			{
				Id = value;
				PrikazUC.ucID.Text = Id.ToString();
			}
		}

		public int Kolicina
		{
			get { return kolicina; }
			set
			{
				kolicina = value;
				PrikazUC.ucKolicina.Text = kolicina.ToString();
			}
		}

		public Image Fotografija
		{
			get { return fotografija; }
			set
			{
				fotografija = value;
				PrikazUC.ucFotografija.Image = fotografija;
			}
		}


		public string Naziv
		{
			get { return naziv; }
			set
			{
				naziv = value;
				PrikazUC.ucNaziv.Text = naziv;
			}
		}

		public string Kupac
		{
			get { return kupac; }
			set
			{
				kupac = value;
				PrikazUC.ucKupac.Text = kupac;
			}
		}

		public void GotovaRezervacija()
		{
			if(Kupac=="Kupac")
				PrikazUC.btnPreuzeto.Visible = true;
			else
				PrikazUC.btnPreuzeto.Visible = false;
		}

		public DateTime Datum
		{
			get { return datum; }
			set
			{
				datum = value;
			}
		}

		public Rezervacija(Iform iform)
		{
			PrikazUC = new UCRezevacija(iform);
			PrikazUC.LoadPonuda(this);

		}
	}
}
