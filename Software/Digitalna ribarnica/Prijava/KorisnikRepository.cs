using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza;
namespace Prijava
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public class KorisnikRepository
    {
        /// <summary>
        /// Metoda koja dohvaća sva svojstva korisnika osim profilne slike
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static Korisnik DohvatiKorisnika(SqlDataReader dr)
        {
            Korisnik korisnik = null;
            if (dr != null)
            {
                korisnik = new Korisnik();
                korisnik.ID = int.Parse(dr["id_korisnik"].ToString());
                korisnik.Ime = dr["ime"].ToString();
                korisnik.Prezime = dr["prezime"].ToString();
                korisnik.Email = dr["email"].ToString();
                korisnik.KorIme = dr["korisnicko_ime"].ToString();
                korisnik.BrojMobitela = dr["broj_mobitela"].ToString();
                if(dr["datum_rodenja"].ToString()!="")
                    korisnik.DatumRodenja = DateTime.Parse(dr["datum_rodenja"].ToString());
                korisnik.Lozinka = dr["lozinka"].ToString();
                korisnik.Adresa = dr["adresa"].ToString();
                korisnik.Mjesto = dr["mjesto"].ToString();
                korisnik.Tip = int.Parse(dr["id_tip_korisnika"].ToString());
                korisnik.Status = int.Parse(dr["id_status"].ToString());      
            }
            return korisnik;
        }

        /// <summary>
        /// Metoda koja dohvaća sve korisnike iz baze
        /// </summary>
        /// <returns></returns>
        public static List<Korisnik> DohvatiSveKorisnike()
        {
            List<Korisnik> lista = new List<Korisnik>();
            string sqlUpit = $"SELECT * FROM korisnici";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlUpit);
            if (dr != null)
            {
                while (dr.Read())
                {
                    Korisnik korisnik = DohvatiKorisnika(dr);
                    lista.Add(korisnik);
                }
                dr.Close();     //DataReader treba obavezno zatvoriti nakon uporabe.
            }
            return lista;
        }
        /// <summary>
        /// Metoda koja dohvaća profilnu sliku za korisnika s ID-om
        /// </summary>
        /// <param name="id">ID korisnika</param>
        /// <returns></returns>
        public static Image DohvatiProfilnu(int id)
        {
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT * FROM korisnici WHERE id_korisnik='{id}';");
            foreach (DbDataRecord item in rezultat)
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < item.FieldCount; i++)
                {
                    row.Add(item.GetName(i), item[i]);
                }
                returnMe.Add(row);
            }
            Image image = null;
            foreach (var item in returnMe)
            {
                if (item["slika"].ToString() != "")
                {
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    image = Image.FromStream(ms);
                }
            }
            rezultat.Close();
            return image;
        }
        /// <summary>
        /// Dohvaćanje slike statusa aktivan/neaktivan ovisno o ID statusa
        /// </summary>
        /// <param name="id">ID statusa</param>
        /// <returns></returns>
        public static Image DohvatiSlikuStatusa(int id)
        {
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select slika from slikeStatusi where id_slika_status='{id}';");
            foreach (DbDataRecord item in rezultat)
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < item.FieldCount; i++)
                {
                    row.Add(item.GetName(i), item[i]);
                }
                returnMe.Add(row);
            }
            Image image = null;
            foreach (var item in returnMe)
            {
                if (item["slika"].ToString() != "")
                {
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    image = Image.FromStream(ms);
                }
            }
            rezultat.Close();
            return image;
        }
        /// <summary>
        /// Dohvaćanje ID-korisnika po korisničkom imenu
        /// </summary>
        /// <param name="korime">Korisničko ime</param>
        /// <returns></returns>
        public static int DohvatiIdKorisnika(string korime)
        {
            int id = 0;
            string sqlUpit = $"SELECT id_korisnik FROM korisnici WHERE korisnicko_ime='{korime}';";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlUpit);
            if (dr != null)
            {
                while (dr.Read())
                {
                    id = int.Parse(dr["id_korisnik"].ToString());
                }
                dr.Close(); 
            }
            return id;
        }
        /// <summary>
        /// Provjera korisničkog imena aktivnog korisnika i korisnika kojega želim provjeriti
        /// </summary>
        /// <param name="korime">Korisničko ime korisnika kojeg želimo provjeriti</param>
        /// <param name="aktivni">Korisničko ime trenutno aktivnog korisnika</param>
        /// <returns></returns>
        public static int ProvjeriKorIme(string korime, string aktivni)
        {
            int id = 0;
            string sqlUpit = $"SELECT id_korisnik FROM korisnici WHERE korisnicko_ime='{korime}' AND korisnicko_ime<>'{aktivni}';";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlUpit);
            if (dr != null)
            {
                while (dr.Read())
                {
                    id = int.Parse(dr["id_korisnik"].ToString());
                }
                dr.Close();
            }
            return id;
        }
        /// <summary>
        /// Provjera postojanja korisnika s emailom i korisničkim imenom
        /// </summary>
        /// <param name="email"></param>
        /// <param name="korime"></param>
        /// <returns></returns>
        public static int ProvjeriEmail(string email,string korime)
        {
            int id = 0;
            string sqlUpit = $"SELECT id_korisnik FROM korisnici WHERE email='{email}' AND korisnicko_ime<>'{korime}';";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlUpit);
            if (dr != null)
            {
                while (dr.Read())
                {
                    id = int.Parse(dr["id_korisnik"].ToString());
                }
                dr.Close();
            }
            return id;
        }
        /// <summary>
        /// Dohvaćanje emaila korisnika po ID-u korisnika
        /// </summary>
        /// <param name="id">ID korisnika</param>
        /// <returns></returns>
        public static string DohvatiEmailKorisnika(int id)
        {
            string emailKorisnika = "";
            string sqlUpit = $"SELECT email FROM korisnici WHERE id_korisnik='{id}';";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlUpit);
            if (dr != null)
            {
                while (dr.Read())
                {
                    emailKorisnika = (dr["email"].ToString());
                }
                dr.Close();
            }
            return emailKorisnika;
        }
        /// <summary>
        /// Dohvaćanje korisnika i svih njegovih svojstava osim profilne po ID-u
        /// </summary>
        /// <param name="id">ID korisnika</param>
        /// <returns></returns>
        public static Korisnik DohvatiKorisnikaPoIDU(int id)
        {
            Korisnik korisnik = new Korisnik();
            string sqlUpit = $"select * from korisnici where id_korisnik='{id}';";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlUpit);
            if (dr != null)
            {
                while (dr.Read())
                {
                    korisnik = DohvatiKorisnika(dr);
                }
                dr.Close();
            }
            return korisnik;
        }
        /// <summary>
        /// Dohvaćanje ID korisnika po mailu
        /// </summary>
        /// <param name="email">Email korisnika</param>
        /// <returns></returns>
        public static Korisnik DohvatiIDpoEmailu(string email)
        {
            Korisnik korisnik = new Korisnik();
            string sqlUpit = $"select * from korisnici where email='{email}';";
            SqlDataReader dr = DB.Instance.DohvatiDataReader(sqlUpit);
            if (dr != null)
            {
                while (dr.Read())
                {
                    korisnik = DohvatiKorisnika(dr);
                }
                dr.Close();
            }
            return korisnik;
        }
        /// <summary>
        /// Spremanje korisnika neParametarski način
        /// </summary>
        /// <param name="korisnik"></param>
        /// <returns></returns>
        public static int Spremi(Korisnik korisnik)
        {
            string sqlUpit = "";
            if (korisnik.ID == 0)
            {
                sqlUpit = $"INSERT INTO korisnici(ime, prezime, email, korisnicko_ime, broj_mobitela, datum_rodenja, lozinka, mjesto, slika, id_tip_korisnika, id_status) VALUES('{korisnik.Ime}', '{korisnik.Prezime}', '{korisnik.Email}', '{korisnik.KorIme}', '{korisnik.BrojMobitela}', NULL, '{korisnik.Lozinka}', '{korisnik.Mjesto}', NULL,2, 2); ";
            }
            int insertUBazu= DB.Instance.IzvrsiUpit(sqlUpit);
            return insertUBazu;
        }
        /// <summary>
        /// Metoda koja ažurira lozinku po emailu
        /// </summary>
        /// <param name="lozinka">Nova lozinka koja nije kriptirana</param>
        /// <param name="email">Email korisnika</param>
        /// <returns></returns>
        public static int PromjeniLozinku(string lozinka,string email)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(lozinka, BCrypt.Net.BCrypt.GenerateSalt(12));
            string sqlUpit = $"UPDATE korisnici SET lozinka = '{hash}' WHERE email = '{email}'; ";
            return DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Metoda koja briše korisnika iz baze
        /// </summary>
        /// <param name="korisnik">Korisnik kojeg brišemo</param>
        /// <returns></returns>
        public static int Obrisi(Korisnik korisnik)
        {
            string sqlDelete = "DELETE FROM korisnici WHERE id_korisnik = " + korisnik.ID;
            return DB.Instance.IzvrsiUpit(sqlDelete);
        }
        /// <summary>
        /// Metoda koja blokira korisnika 
        /// </summary>
        /// <param name="id">ID korisnika</param>
        /// <param name="uloga">Uloga blokiranog korisnika je različita od registriranih korisnika</param>
        /// <returns></returns>
        public static int BlokirajKorisnika(int id, int uloga)
        {
            string sqlUpit = $"update korisnici set id_tip_korisnika='{uloga}' where id_korisnik='{id}'; ";
            return DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Metoda koja postavlja da je korisnik aktivan
        /// </summary>
        /// <param name="id">ID korisnika</param>
        /// <returns></returns>
        public static int AktivanKorisnik(int id)
        {
            string sqlUpit = $"update korisnici set id_status=1 where id_korisnik='{id}'; ";
            return DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Metoda koja postavlja da je korisnik neaktivan
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int NeaktivanKorisnik(int id)
        {
            string sqlUpit = $"update korisnici set id_status=2 where id_korisnik='{id}'; ";
            return DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Metoda koja unosi u dnevnik opis i tip radnje
        /// </summary>
        /// <param name="id">ID aktivnog korisnika</param>
        /// <param name="opis">Opis radnje</param>
        /// <param name="idTipRadnje">Tip radnje</param>
        public static void UnesiUDnevnik(int id, string opis, int idTipRadnje)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@datum", DateTime.Now);
            parameters.Add("@opisRadnje", opis);
            parameters.Add("@idKorisnik", id);
            parameters.Add("@idTip", idTipRadnje);
            DB.Instance.ExecuteParamQuery("insert into [dnevnik]([datum_i_vrijeme_radnje], [radnja], [id_korisnik], [id_tip_radnje]) values((@datum), (@opisRadnje), (@idKorisnik), (@idTip)); ", parameters);
        }
    }
}
