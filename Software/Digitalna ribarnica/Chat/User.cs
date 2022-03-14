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
	/// Author: Božo Kvesić
	/// </summary>
	public class User
    {
		public UCKorisnik PrikazUC = null;
		private string naziv;
		private Image profilna;
		private Image status;
		private int idkorisnik;


		public int IDKORISNIKA
		{
			get { return idkorisnik; }
			set
			{

				idkorisnik = value;
				PrikazUC.IDkorisnika = idkorisnik;

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

		public Image Profilna
		{
			get { return profilna; }
			set
			{
				profilna = value;
				PrikazUC.ucProfilna.Image = profilna;
			}
		}

		public Image Status
		{
			get { return status; }
			set
			{
				status = value;
				PrikazUC.ucStatus.Image = status;
			}
		}

		public User(Iform iform)
		{

				PrikazUC = new UCKorisnik(iform);
				PrikazUC.LoadPonuda(this);

		}
	}
}
