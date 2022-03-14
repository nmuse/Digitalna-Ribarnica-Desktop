using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.ComponentModel;

namespace Prijava
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public class Korisnik
    {
        [DisplayName("ID korisnika")]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        [DisplayName("Korisničko ime")]
        public string KorIme { get; set; }

        public string Adresa { get; set; }

        public string Mjesto { get; set; }

        [DisplayName("Broj mobitela")]
        public string BrojMobitela { get; set; }
        public string Lozinka { get; set; }

        public int Tip { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        [DisplayName("Datum rođenja")]
        public DateTime DatumRodenja { get; set; }
        [DisplayName("Profilna slika")]
        public Image ProfilnaSlika { get; set; }
        [DisplayName("Status korisnika")]
        public string NazivStatusa { get; set; }
        [DisplayName("Uloga korisnika")]
        public string ULOGA { get; set; }



        public Korisnik()
        {

        }
        public Korisnik(string korime, string lozinka, int tip, string email)
        {
            KorIme = korime;
            Lozinka = lozinka;
            Tip = tip;
            Email = email;
        }

        public Korisnik(string ime, string prezime, string korime, string adresa, string mjesto, string brojmobitela, string lozinka, string mail, int tip)
        {
            Ime = ime;
            Prezime = prezime;
            KorIme = korime;
            Adresa = adresa;
            Mjesto = mjesto;
            BrojMobitela = brojmobitela;
            Lozinka = lozinka;
            Email = mail;
            Tip = tip;
        }

        public Korisnik(string ime, string prezime, string mail, string korime, string brojmobitela, DateTime date, string lozinka, string adresa, string mjesto,Image image, int tip,int status)
        {
            Ime = ime;
            Prezime = prezime;
            KorIme = korime;
            Adresa = adresa;
            Mjesto = mjesto;
            BrojMobitela = brojmobitela;
            Lozinka = lozinka;
            Email = mail;
            Tip = tip;
            DatumRodenja = date;
            Status = status;
            ProfilnaSlika = image;
        }
    }
}
