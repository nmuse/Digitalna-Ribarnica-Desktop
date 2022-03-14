using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registracija
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public class AutentifikacijaRegistracije
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorIme { get; set; }
        public string Adresa { get; set; }
        public string Mjesto { get; set; }
        public string BrojMobitela { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string PonoviLozinku { get; set; }

        public AutentifikacijaRegistracije()
        {

        }
        /// <summary>
        /// Konstruktor klase provjerava ispravnost podataka te u slučaju grešaka baca Exceptione
        /// </summary>
        /// <param name="ime"></param>
        /// <param name="prezime"></param>
        /// <param name="korime"></param>
        /// <param name="adresa"></param>
        /// <param name="mjesto"></param>
        /// <param name="brojMobitela"></param>
        /// <param name="email"></param>
        /// <param name="lozinka"></param>
        /// <param name="ponoviLozinku"></param>
        public AutentifikacijaRegistracije(string ime, string prezime, string korime, string adresa, string mjesto, string brojMobitela, string email, string lozinka, string ponoviLozinku)
        {
            
            //-------------IME NE SMIJE BITI PRAZNO------------------
            if (ime.Length != 0 && IsNameSurnameValid(ime))
                Ime = ime;
            else
                throw new RegistrationException("Nije uneseno ime ili ime sadrži broj");
            //-------------------------------------------------------
            //------------PREZIME NE SMIJE BITI PRAZNO---------------
            if (prezime.Length != 0 && IsNameSurnameValid(prezime))
                Prezime = prezime;
            else
                throw new RegistrationException("Nije uneseno prezime ili prezime sadrži broj");
            //-------------------------------------------------------
            //------------ADRESA MORA BITI UNESENA-------------------
            if (adresa.Length != 0)
                Adresa = adresa;
            else
                throw new RegistrationException("Nije unesena adresa");
            //-------------------------------------------------------
            //-----------MJESTO MORA BITI UNESENO--------------------
            if (mjesto.Length != 0)
                Mjesto = mjesto;
            else
                throw new RegistrationException("Nije uneseno mjesto");
            //-------------------------------------------------------
            //-----------PROVJERA BROJA MOBITELA---------------------
            if (IsMobilePhoneCorrect(brojMobitela))
            {
                BrojMobitela = brojMobitela;
            }
            else
            {
                throw new RegistrationException("Broj mobitela je krivo unesen ili krivog formata");
            }
            //-------------------------------------------------------
            //-----------PROVJERA MAILA------------------------------
            if (IsValidEmail(email) && email.Length!=0)
            {
                Email = email;
            }
            else
            {
                throw new RegistrationException("Email adresa nije dobro unesena");
            }
            //-------------------------------------------------------
            //-----------PROVJERA PONOVNO UNESENE LOZINKE------------
            if (IsPasswordsSame(lozinka, ponoviLozinku))
            {
                if (lozinka.Length > 6)
                {
                    Lozinka = lozinka;
                    PonoviLozinku = ponoviLozinku;
                }
                else
                    throw new RegistrationException("Lozinka mora sadržavati više od 6 znakova!");
            }
            else
            {
                throw new RegistrationException("Lozinke se ne podudaraju ili nisu unesene");
            }

        }
        /// <summary>
        /// Metoda koja provjerava da ime i prezime ne sadrže brojčane vrijednosti
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsNameSurnameValid(string name)
        {
            bool IsNumeric;
            for (int i = 0; i < name.Length; i++)
            {
                if (i != name.Length - 1)
                    IsNumeric = int.TryParse(name.Substring(i, 1), out int n);
                else
                    IsNumeric = int.TryParse(name.Substring(name.Length - 1), out int n);

                if (!IsNumeric)
                    continue;
                else
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Metoda koja provjerava ispravnost emaila
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Metoda koja provjerava sličnost lozinke i ponovljene lozinke
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="passAccept"></param>
        /// <returns></returns>
        public bool IsPasswordsSame(string pass,string passAccept)
        {
            if (pass == passAccept)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Metoda koja provjerava ispravnost unesenog mobilnog broja
        /// </summary>
        /// <param name="brojMobitela">String moblilnog broja</param>
        /// <returns></returns>
        public bool IsMobilePhoneCorrect(string brojMobitela)
        {
            if (brojMobitela.Length < 15 && brojMobitela.Length>7)
            {
                bool isNumeric;
                if (brojMobitela[0] == '+')
                {
                    if (brojMobitela.StartsWith("+385"))
                    {
                        for (int i = 1; i < brojMobitela.Length; i++)
                        {
                            if (i != brojMobitela.Length - 1)
                                isNumeric = int.TryParse(brojMobitela.Substring(i,1), out int n);
                            else
                                isNumeric = int.TryParse(brojMobitela.Substring(brojMobitela.Length-1),out int n);

                            if (isNumeric)
                                continue;
                            else
                            {
                                return false;
                            }
                        }
                        return true;
                        //isNumeric = int.TryParse(brojMobitela.Substring(1, brojMobitela.Length - 1), out int n);
                    }
                    else
                        return false;
                }
                else
                {
                    if (brojMobitela.StartsWith("09"))
                    {
                        for (int i = 0; i < brojMobitela.Length; i++)
                        {
                            if (i != brojMobitela.Length - 1)
                                isNumeric = int.TryParse(brojMobitela.Substring(i, 1), out int n);
                            else
                                isNumeric = int.TryParse(brojMobitela.Substring(brojMobitela.Length - 1), out int n);

                            if (isNumeric)
                                continue;
                            else
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                        //isNumeric = int.TryParse(brojMobitela, out int n);
                    else
                        return false;
                }
                /*
                if (isNumeric)
                {
                    return true;
                }
                else
                    return false;
                    //VISUAL STUDIO IMA WARNING DA OVAJ DIO PROVJERE NIKAD NIJE MOGUĆE PROVJERITI
                */
            }
            else
                return false;
        }
    }
}
