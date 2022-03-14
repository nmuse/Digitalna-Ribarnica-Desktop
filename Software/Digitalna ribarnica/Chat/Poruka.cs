using INSform;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
	/// <summary>
	/// Author: Nikola Muše
	/// </summary>
	public class Poruka
    {
		public UCPoruka PrikazUC = null;
		public UCSaljem SaljemUC = null;
		private DateTime datum;
		private string sadrzaj;
		private Image profilna;
		private int idkorisnik;
		int zastava = 0;

		/// <summary>
		/// ID korisnika kojemu poruka pripada
		/// </summary>

		public int IDKORISNIKA
		{
			get { return idkorisnik; }
			set
			{
				if (zastava == -1)
				{
					idkorisnik = value;
					PrikazUC.IDkorisnika = idkorisnik;
				}
				else
				{
					idkorisnik = value;
					SaljemUC.IDkorisnika = idkorisnik;
				}

			}
		}
		/// <summary>
		/// Datum slanja poruke
		/// </summary>

		public DateTime Datum
		{
			get { return datum; }
			set
			{
				if (zastava == -1)
				{
					datum = value;
					PrikazUC.ucDatum.Text = datum.ToString();
				}
				else
				{
					datum = value;
					SaljemUC.ucDatum.Text = datum.ToString();
				}

			}
		}

		/// <summary>
		/// Profilna slika pošiljatelja
		/// </summary>

		public Image Profilna
		{
			get { return profilna; }
			set
			{
				if (zastava == -1)
				{
					profilna = value;
					PrikazUC.ucProfilna.Image = profilna;
				}
				else
				{
					profilna = value;
					SaljemUC.ucProfilna.Image = profilna;
				}
			}
		}
		/// <summary>
		/// Sadržaj poruke
		/// </summary>
		public string Opis
		{
			get { return sadrzaj; }
			set
			{
				if (zastava == -1)
				{
					sadrzaj = value;
					PrikazUC.rtbxOpis.Text = sadrzaj;
				}
				else
				{
					sadrzaj = value;
					SaljemUC.rtbxOpis.Text = sadrzaj;
				}
			}
		}

		/// <summary>
		/// Konstruktor koji kreira poruku te ju prikazuje kao user kontrolu
		/// </summary>
		/// <param name="iform"></param>
		/// <param name="i"></param>
		public Poruka(Iform iform, int i=-1)
		{
			zastava = i;
			if (zastava == -1)
			{
				PrikazUC = new UCPoruka(iform);
				PrikazUC.LoadPonuda(this);
			}
			else
			{
				SaljemUC = new UCSaljem(iform);
				SaljemUC.LoadPonuda(this);
			}

		}
	}
}
