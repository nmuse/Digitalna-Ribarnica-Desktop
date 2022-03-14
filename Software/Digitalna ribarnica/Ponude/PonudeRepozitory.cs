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
using INSform;
namespace Ponude
{
    /// <summary>
    /// Author: Nikola Muše
    /// Author: Anabela Pranjić
    /// Author: Božo Kvesić
    /// </summary>
    public class PonudeRepozitory
    {
        public static List<Ponuda> _ponude = new List<Ponuda>();

        public static List<Zahtjev> _zahtjevi = new List<Zahtjev>();
        public static List<Rezervacija> _rezervacije = new List<Rezervacija>();
        public static List<Rezervacija> _rezervacije1 = new List<Rezervacija>();
        static Iform Iform;
        /// <summary>
        /// Metoda koja dohvaća sve ponude iz baze
        /// </summary>
        /// <param name="nova"></param>
        /// <returns></returns>
        public static List<Ponuda> DohvatiPonude(Iform nova)
        {
            Iform = nova;
            _ponude.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader("select ponude.*, ribe.mjerna_jedinica, ribe.naziv, ribe.slika, lokacije.naziv AS lokacija, korisnici.ime, korisnici.prezime from ponude, ribe, lokacije, korisnici WHERE ponude.id_riba = ribe.id_riba AND ponude.id_lokacija = lokacije.id_lokacija AND ponude.id_korisnik = korisnici.id_korisnik AND ponude.status = 1");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            if (rezultat != null)
                rezultat.Close();
            foreach (var item in returnMe)
            {
                
                Ponuda ponuda = new Ponuda(nova);

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["dodatna_fotografija"]);
                    ponuda.Fotografija = Image.FromStream(ms);
                }
                catch (Exception)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                        ponuda.Fotografija = Image.FromStream(ms);
                    }
                    catch (Exception)
                    {
                        ponuda.Fotografija = null;
                    }
                }

                ponuda.ID = item["id_ponuda"].ToString();
                ponuda.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    ponuda.Mjerna = "kg";
                else
                    ponuda.Mjerna = "kom";
                ponuda.Kolicina = int.Parse(item["kolicina"].ToString());
                ponuda.Cijena = float.Parse(item["cijena"].ToString());
                ponuda.Ime = item["ime"] + " " + item["prezime"];
                ponuda.Lokacija = item["lokacija"].ToString();
                ponuda.IDKORISNIKA = int.Parse(item["id_korisnik"].ToString());
                if (DohvatiSlikuZnackePonuditelja(ponuda.IDKORISNIKA) != null)
                    ponuda.Znacka = DohvatiSlikuZnackePonuditelja(ponuda.IDKORISNIKA);
                _ponude.Add(ponuda);
            }
          
            return _ponude;
        }
        /// <summary>
        /// Metoda koja dohvaća sve ponude koje je kreirao određeni korisnik kreirao
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Ponuda> DohvatiPonudePoID(Iform nova,int id)
        {
            Iform = nova;
            _ponude.Clear();
            System.Data.SqlClient.SqlDataReader rezultat = null;
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            if (id!=-1)
                rezultat = DB.Instance.DohvatiDataReader($"select ponude.*, ribe.mjerna_jedinica, ribe.naziv, ribe.slika, lokacije.naziv AS lokacija, korisnici.ime, korisnici.prezime from ponude, ribe, lokacije, korisnici WHERE ponude.id_riba = ribe.id_riba AND ponude.id_lokacija = lokacije.id_lokacija AND ponude.id_korisnik = korisnici.id_korisnik AND ponude.status = 1 AND korisnici.id_korisnik={id}");
            else
                rezultat = DB.Instance.DohvatiDataReader($"select ponude.*, ribe.mjerna_jedinica, ribe.naziv, ribe.slika, lokacije.naziv AS lokacija, korisnici.ime, korisnici.prezime from ponude, ribe, lokacije, korisnici WHERE ponude.id_riba = ribe.id_riba AND ponude.id_lokacija = lokacije.id_lokacija AND ponude.id_korisnik = korisnici.id_korisnik AND ponude.status = 1");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            if (rezultat != null)
                rezultat.Close();
            foreach (var item in returnMe)
            {

                Ponuda ponuda = new Ponuda(nova);

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["dodatna_fotografija"]);
                    ponuda.Fotografija = Image.FromStream(ms);
                }
                catch (Exception)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                        ponuda.Fotografija = Image.FromStream(ms);
                    }
                    catch (Exception)
                    {
                        ponuda.Fotografija = null;
                    }
                }

                ponuda.ID = item["id_ponuda"].ToString();
                ponuda.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    ponuda.Mjerna = "kg";
                else
                    ponuda.Mjerna = "kom";
                ponuda.Kolicina = int.Parse(item["kolicina"].ToString());
                ponuda.Cijena = float.Parse(item["cijena"].ToString());
                ponuda.Ime = item["ime"] + " " + item["prezime"];
                ponuda.Lokacija = item["lokacija"].ToString();
                if (DohvatiSlikuZnackePonuditelja(int.Parse(item["id_korisnik"].ToString())) != null)
                    ponuda.Znacka = DohvatiSlikuZnackePonuditelja(int.Parse(item["id_korisnik"].ToString()));
                _ponude.Add(ponuda);
            }
           
            return _ponude;
        }
        /// <summary>
        /// Metoda koja dohvaća sliku značke za pojedinog ponuditelja
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Image DohvatiSlikuZnackePonuditelja(int id)
        {
            Image znacka = null;
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select slikeZnackePonuditelj.slika from slikeZnackePonuditelj, korisnici, imaju_znacku_ponuditelj where slikeZnackePonuditelj.id_Znacke = imaju_znacku_ponuditelj.id_znacke and imaju_znacku_ponuditelj.id_korisnik = korisnici.id_korisnik and korisnici.id_korisnik = {id}");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            foreach (var item in returnMe)
            {

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    znacka = Image.FromStream(ms);
                }
                catch (Exception)
                {
                    znacka = null;
                }

            }
            if (rezultat != null)
                rezultat.Close();
            return znacka;
        }

        /// <summary>
        /// Metoda koja dohvaća opis ponude po ID-u ponude
        /// </summary>
        /// <param name="id">ID ponude</param>
        /// <returns></returns>
        public static string DohvatiOpisPonude(int id)
        {
            var rezultat = DB.Instance.DohvatiDataReader($"select ponude.opis FROM ponude WHERE ponude.id_ponuda={id}");
            string opis="";
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            foreach (DbDataRecord item in rezultat)
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < item.FieldCount; i++)
                {
                    row.Add(item.GetName(i), item[i]);
                }
                returnMe.Add(row);
            }
            foreach (var item in returnMe)
            {
                opis = item["opis"].ToString();
            }
            rezultat.Close();
            return opis;
        }
        /// <summary>
        /// Metoda koja dohvaća podatke potrebne na prikazu izvjesca rezervacije
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PonudeIzvjesca DohvatiPonuduIzvjesca(int id)
        {
            var rezultat = $"select ribe.naziv, ribe.mjerna_jedinica, ponude.cijena from ribe, ponude where ponude.id_ponuda = {id} and ponude.id_riba=ribe.id_riba";
            PonudeIzvjesca ponuda=null;
            SqlDataReader dr = DB.Instance.DohvatiDataReader(rezultat);
            if (dr != null)
            {
                while (dr.Read())
                {
                    string mjerna = "";
                    string naziv = (dr["naziv"].ToString());
                    if (dr["mjerna_jedinica"].ToString() == "1")
                        mjerna = "kom";
                    else
                        mjerna = "kg";
                    double cijena = double.Parse(dr["cijena"].ToString());
                    ponuda = new PonudeIzvjesca(naziv, cijena, mjerna);
                }
                dr.Close();
            }
            dr.Close();
            return ponuda;
        }
        /// <summary>
        /// Metoda koja kreiraja zahtjev u bazi
        /// </summary>
        /// <param name="idKorisnika">ID korisnika koji je kreirao zahtjev</param>
        /// <param name="idPonuda">ID ponude</param>
        /// <param name="kolicina">Količina ribe koja se planira rezervirati</param>

        public static void UnesiZahtjevZaRezervaciju(int idKorisnika, int idPonuda, int kolicina)
        {
            var parameters1 = new Dictionary<string, object>();
            parameters1.Add("@idKorisnika", idKorisnika);
            parameters1.Add("@idponuda", idPonuda);
            parameters1.Add("@kolicina", kolicina);
            parameters1.Add("@datum", DateTime.Now);
            DB.Instance.ExecuteParamQuery("INSERT INTO [zahtjevi] ([id_korisnik], [id_ponuda], [kolicina], [datum_vrijeme]) VALUES((@idKorisnika), (@idponuda), (@kolicina), (@datum));", parameters1);
        }
        /// <summary>
        /// Metoda koja briše ponudu iz baze
        /// </summary>
        /// <param name="id"></param>
        public static void ObrisiPonudu(int id)
        {
            string sqlUpit = $"DELETE FROM ponude WHERE id_ponuda={id};";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Metoda koja dohvaća id rezervacija
        /// </summary>
        public static void IDRezervacijeZaProvjeruRoka()
        {
            var rezultat = DB.Instance.DohvatiDataReader($"select id_rezervacija FROM rezervacije");
            int id = 0;
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            foreach (DbDataRecord item in rezultat)
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < item.FieldCount; i++)
                {
                    row.Add(item.GetName(i), item[i]);
                }
                returnMe.Add(row);
            }
            rezultat.Close();
            foreach (var item in returnMe)
            {
                id =int.Parse(item["id_rezervacija"].ToString());
                ProvjeriRokRezervacija(id);
            }
          
        }
        /// <summary>
        /// Metoda koja služi za pokretanje triggera za provjeru roka rezervacije
        /// </summary>
        /// <param name="id"></param>
        private static void ProvjeriRokRezervacija(int id)
        {
            string sqlUpit = $"update rezervacije set kolicina=kolicina+0 where id_rezervacija={id};";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Metoda koja dohvaća zahtjeve za korisnika po ponudi
        /// </summary>
        /// <param name="idKorisnika">ID korisnika</param>
        /// <param name="idPonuda">ID ponude</param>
        /// <returns></returns>
        public static int ProvjeriKorisnikaIZahtjev(int idKorisnika, int idPonuda)
        {
            int id = 0;
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat=DB.Instance.DohvatiDataReader($"SELECT * FROM zahtjevi WHERE id_korisnik='{idKorisnika}' AND id_ponuda='{idPonuda}';");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }

            foreach (var item in returnMe)
            {
                id= int.Parse(item["id_zahtjev"].ToString());
            }
            rezultat.Close();
            return id;
        }

        /// <summary>
        /// Metoda koja ažurira zahtjev
        /// </summary>
        /// <param name="idKorisnika">ID korisnika</param>
        /// <param name="idPonuda">ID ponude</param>
        /// <param name="kolicina">Nova količina</param>
        public static void AzurirajZahtjev(int idKorisnika, int idPonuda, int kolicina)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@idKorisnika", idKorisnika);
            parameters.Add("@idponuda", idPonuda);
            parameters.Add("@kolicina", kolicina);
            parameters.Add("@datum", DateTime.Now);
            parameters.Add("@status", 1);
            DB.Instance.ExecuteParamQuery("UPDATE [zahtjevi] SET [kolicina] = (@kolicina), datum_vrijeme = (@datum), status = (@status) WHERE [id_korisnik] = (@idKorisnika) AND [id_ponuda] = (@idponuda);", parameters);
        }
        /// <summary>
        /// Metoda koja dohvaća sve zahtjeve
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Zahtjev> DohvatiZahtjeve(Iform nova,int id)
        {
            Iform = nova;
            _zahtjevi.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT zahtjevi.id_korisnik,zahtjevi.id_ponuda, korisnici.slika, korisnici.ime, korisnici.prezime, zahtjevi.kolicina, ponude.kolicina AS MAX, ponude.trajanje_rezervacije_u_satima, zahtjevi.id_zahtjev FROM korisnici, zahtjevi, ponude WHERE korisnici.id_korisnik = zahtjevi.id_korisnik AND ponude.id_ponuda = zahtjevi.id_ponuda AND ponude.id_ponuda = {id} AND zahtjevi.status = 1 AND ponude.status = 1");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            if (rezultat != null)
                rezultat.Close();
            foreach (var item in returnMe)
            {

                Zahtjev zahtjev = new Zahtjev(nova);

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    zahtjev.Fotografija = Image.FromStream(ms);
                }
                catch (Exception)
                {
                    zahtjev.Fotografija = null;
                }
               
                zahtjev.IDKORISNIKA =int.Parse(item["id_korisnik"].ToString());
                zahtjev.Ime = item["ime"] + " " + item["prezime"];
                zahtjev.Kolicina = int.Parse(item["kolicina"].ToString());
                zahtjev.Max = item["MAX"].ToString();
                zahtjev.BrojSatiDana = item["trajanje_rezervacije_u_satima"].ToString();
                zahtjev.ID = int.Parse(item["id_zahtjev"].ToString());
                zahtjev.IDPONUDE= int.Parse(item["id_ponuda"].ToString());
                if (DohvatiSlikuZnackeKupca(zahtjev.IDKORISNIKA) != null)
                    zahtjev.Znacka = DohvatiSlikuZnackeKupca(zahtjev.IDKORISNIKA);
                _zahtjevi.Add(zahtjev);
            }
       
            return _zahtjevi;
        }
        /// <summary>
        /// Metoda koja dohvaća slike značke kupca
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Image DohvatiSlikuZnackeKupca(int id)
        {
            Image znacka = null;
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select slikeZnackeKupac.slika from slikeZnackeKupac, korisnici, imaju_znacku_kupac where slikeZnackeKupac.id_Znacke = imaju_znacku_kupac.id_znacke and imaju_znacku_kupac.id_korisnik = korisnici.id_korisnik and korisnici.id_korisnik = {id}");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            foreach (var item in returnMe)
            {

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    znacka = Image.FromStream(ms);
                }
                catch (Exception)
                {
                    znacka = null;
                }

            }
            if (rezultat != null)
                rezultat.Close();
            return znacka;
        }
        /// <summary>
        /// Stavljanje zahtjeva da nije aktivan
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id">ID zahtjeva</param>
        public static void AzurirajZahtjeveNakonBrisanja(Iform nova,int id)
        {
            string sqlUpit = $"UPDATE zahtjevi set status = 0 WHERE id_ponuda={id};";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Odbijanje zahtjeva
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id">ID zahtjeva</param>
        public static void OdbaciZahtjev(Iform nova, int id)
        {
            string sqlUpit = $"UPDATE zahtjevi set status = 0 WHERE id_zahtjev={id};";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Metoda koja kreira rezervaciju na osnovi poslanog zahtjeva
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="zahtjev">Zahtjev na osnovi kojeg se kreira rezervacija</param>
        /// <param name="idPonude">ID ponude</param>
        public static void KreirajRezervaciju(Iform nova, Zahtjev zahtjev,int idPonude)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("@datum", DateTime.Now.AddHours(double.Parse(zahtjev.BrojSatiDana)));
            parameters.Add("@kolicina", zahtjev.Kolicina);
            parameters.Add("@idKupca", zahtjev.IDKORISNIKA);
            parameters.Add("@idPonude", idPonude);
            parameters.Add("@tip", 1);
            DB.Instance.ExecuteParamQuery("INSERT INTO [rezervacije]([datum_i_vrijeme], [kolicina], [id_kupac], [id_ponuda], [id_tip_statusa]) VALUES((@datum), (@kolicina), (@idKupca), (@idPonude), (@tip)); ", parameters);
        }
        /// <summary>
        /// Ažuriranje ponude količine nakon rezerviranja ponude
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="zahtjev">Zahtjev na osnovi kojeg se kreira rezervacija</param>
        /// <param name="idPonude">ID ponude gdje ćemo smanjiti količinu</param>
        public static void AzurirajPonuduKolicine(Iform nova, Zahtjev zahtjev, int idPonude)
        {
            string sqlUpit = $"UPDATE ponude SET kolicina=kolicina-{zahtjev.Kolicina} WHERE id_ponuda={idPonude};";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Metoda koja briše zahtjev
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="zahtjev">Zahtjev koji želimo obrisati</param>
        public static void ObrisiZahtjev(Iform nova, Zahtjev zahtjev)
        {
            string sqlUpit = $"delete from zahtjevi where id_zahtjev={zahtjev.ID}";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Metoda koja dohvaća sve rezeracije pojedinog korisnika
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id">ID korisnika za kojeg dohvaćamo rezervacije</param>
        /// <returns></returns>
        public static List<Rezervacija> DohvatiRezervacije(Iform nova,int id)
        {
            Iform = nova;
            _rezervacije.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select ribe.*,ponude.cijena, rezervacije.id_rezervacija,korisnici.id_korisnik as kupac, korisnici.ime, korisnici.prezime, lokacije.naziv as lokacija, ponude.dodatna_fotografija, rezervacije.kolicina from rezervacije, ribe, korisnici, lokacije, ponude where rezervacije.id_ponuda = ponude.id_ponuda and ponude.id_korisnik = korisnici.id_korisnik and rezervacije.id_kupac = {id} and ponude.id_lokacija = lokacije.id_lokacija and ponude.id_riba = ribe.id_riba and rezervacije.id_tip_statusa=1");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            foreach (var item in returnMe)
            {

                Rezervacija rezervacija = new Rezervacija(nova);

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["dodatna_fotografija"]);
                    rezervacija.Fotografija = Image.FromStream(ms);
                }
                catch (Exception)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                        rezervacija.Fotografija = Image.FromStream(ms);
                    }
                    catch (Exception)
                    {
                        rezervacija.Fotografija = null;
                    }
                }

                rezervacija.ID = int.Parse(item["id_rezervacija"].ToString());
                rezervacija.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    rezervacija.Mjerna = "kg";
                else
                    rezervacija.Mjerna = "kom";
                rezervacija.Kolicina = int.Parse(item["kolicina"].ToString());
                rezervacija.Cijena = float.Parse(item["cijena"].ToString());
                rezervacija.Ime = item["ime"] + " " + item["prezime"];
                rezervacija.Lokacija = item["lokacija"].ToString();
                rezervacija.IDkupca= int.Parse(item["kupac"].ToString());
                _rezervacije.Add(rezervacija);
            }
            if (rezultat != null)
                rezultat.Close();
            return _rezervacije;
        }
        /// <summary>
        /// Metoda koja dohvaća odobrene rezervacije
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id">ID korisnika za kojega se dohvaćaju</param>
        /// <returns></returns>
        public static List<Rezervacija> DohvatiOdobreneRezervacije(Iform nova, int id)
        {
            Iform = nova;
            _rezervacije.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select  ribe.*, rezervacije.id_rezervacija,korisnici.id_korisnik, korisnici.ime, korisnici.prezime, lokacije.naziv as lokacija, ponude.dodatna_fotografija, rezervacije.kolicina, ponude.cijena from rezervacije, ribe, korisnici, lokacije, ponude where korisnici.id_korisnik = rezervacije.id_kupac and rezervacije.id_ponuda = ponude.id_ponuda and ponude.id_korisnik = {id} and ponude.id_lokacija = lokacije.id_lokacija and ponude.id_riba = ribe.id_riba and rezervacije.id_tip_statusa=1");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            foreach (var item in returnMe)
            {

                Rezervacija rezervacija = new Rezervacija(nova);

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["dodatna_fotografija"]);
                    rezervacija.Fotografija = Image.FromStream(ms);
                }
                catch (Exception)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                        rezervacija.Fotografija = Image.FromStream(ms);
                    }
                    catch (Exception)
                    {
                        rezervacija.Fotografija = null;
                    }
                }

                rezervacija.ID = int.Parse(item["id_rezervacija"].ToString());
                rezervacija.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    rezervacija.Mjerna = "kg";
                else
                    rezervacija.Mjerna = "kom";
                rezervacija.Kolicina = int.Parse(item["kolicina"].ToString());
                rezervacija.Cijena = float.Parse(item["cijena"].ToString());
                rezervacija.Ime = item["ime"] + " " + item["prezime"];
                rezervacija.Lokacija = item["lokacija"].ToString();
                rezervacija.IDkupca =int.Parse( item["id_korisnik"].ToString());
                _rezervacije.Add(rezervacija);
            }
            if (rezultat != null)
                rezultat.Close();
            return _rezervacije;
        }
        /// <summary>
        /// Dohvaća sve gotove rezervacije
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id">ID korisnika</param>
        /// <returns></returns>
        public static List<Rezervacija> GotoveRezervacije(Iform nova, int id)
        {
            Iform = nova;
            _rezervacije.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select ribe.naziv, ribe.mjerna_jedinica,rezervacije.datum_i_vrijeme, rezervacije.id_rezervacija, korisnici.id_korisnik, korisnici.ime, korisnici.prezime, lokacije.naziv as lokacija, rezervacije.kolicina, ponude.cijena, rezervacije.id_tip_statusa from rezervacije, ribe, korisnici, lokacije, ponude where korisnici.id_korisnik = rezervacije.id_kupac and rezervacije.id_ponuda = ponude.id_ponuda and ponude.id_korisnik = {id} and ponude.id_lokacija = lokacije.id_lokacija and ponude.id_riba = ribe.id_riba and(rezervacije.id_tip_statusa = 2 or rezervacije.id_tip_statusa = 3 or rezervacije.id_tip_statusa = 4)");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            foreach (var item in returnMe)
            {

                Rezervacija rezervacija = new Rezervacija(nova);

                rezervacija.ID = int.Parse(item["id_rezervacija"].ToString());
                rezervacija.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    rezervacija.Mjerna = "kg";
                else
                    rezervacija.Mjerna = "kom";
                rezervacija.Kolicina = int.Parse(item["kolicina"].ToString());
                rezervacija.Cijena = float.Parse(item["cijena"].ToString());
                rezervacija.Ime = item["ime"] + " " + item["prezime"];
                rezervacija.Lokacija = item["lokacija"].ToString();
                rezervacija.IDkupca = int.Parse(item["id_korisnik"].ToString());
                rezervacija.Datum = DateTime.Parse(item["datum_i_vrijeme"].ToString());
                _rezervacije.Add(rezervacija);
            }
            if (rezultat != null)
                rezultat.Close();
            return _rezervacije;
        }
        /// <summary>
        /// Dohvaća sve gotove rezervacije za Ponuditelja
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id">ID korisnika</param>
        /// <returns></returns>
        public static List<Rezervacija> GotoveRezeracijePonuditelj(Iform nova, int id)
        {
            Iform = nova;
            _rezervacije1.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select ribe.naziv, ribe.mjerna_jedinica,rezervacije.datum_i_vrijeme, rezervacije.id_rezervacija,korisnici.id_korisnik, korisnici.ime, korisnici.prezime, lokacije.naziv as lokacija, ponude.dodatna_fotografija, ponude.cijena, rezervacije.kolicina, rezervacije.id_tip_statusa from rezervacije, ribe, korisnici, lokacije, ponude where rezervacije.id_ponuda = ponude.id_ponuda and ponude.id_korisnik = korisnici.id_korisnik and rezervacije.id_kupac = {id} and ponude.id_lokacija = lokacije.id_lokacija and ponude.id_riba = ribe.id_riba and(rezervacije.id_tip_statusa = 2 or rezervacije.id_tip_statusa = 3 or rezervacije.id_tip_statusa = 4)");
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            foreach (var item in returnMe)
            {

                Rezervacija rezervacija = new Rezervacija(nova);

                rezervacija.ID = int.Parse(item["id_rezervacija"].ToString());
                rezervacija.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 0)
                    rezervacija.Mjerna = "kg";
                else
                    rezervacija.Mjerna = "kom";
                rezervacija.Kolicina = int.Parse(item["kolicina"].ToString());
                rezervacija.Cijena = float.Parse(item["cijena"].ToString());
                rezervacija.Ime = item["ime"] + " " + item["prezime"];
                rezervacija.Lokacija = item["lokacija"].ToString();
                rezervacija.IDkupca = int.Parse(item["id_korisnik"].ToString());
                rezervacija.Datum = DateTime.Parse(item["datum_i_vrijeme"].ToString());
                _rezervacije1.Add(rezervacija);
            }
            if (rezultat != null)
                rezultat.Close();
            return _rezervacije1;
        }
        /// <summary>
        /// Metoda koja označava rezervaciju kao završenu
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id">ID rezervacije</param>
        public static void RezervacijaDovrsena(Iform nova, int id)
        {
            string sqlUpit = $"update rezervacije set id_tip_statusa=3 where id_rezervacija={id}";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Metoda koja označava rezervaciju kao blokiranu
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id">ID korisnika</param>
        public static void RezervacijaBlokirana(Iform nova, int id)
        {
            string sqlUpit = $"update rezervacije set id_tip_statusa=2 where id_rezervacija={id}";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Unesi ocjenu u bazu
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="ocjena">Ocjena 1-5</param>
        /// <param name="komentar">Komentar na ocjenu</param>
        /// <param name="tkoocjenjuje">ID korisnika tko ocjenjuje</param>
        /// <param name="kogaocjenjuje">ID korisnika koga ocjenjuje</param>
        /// <param name="idrezervacije">ID rezervacije na koju se ocjena odnosi</param>
        public static void UnesiOcjenu(Iform nova, int ocjena,string komentar, int tkoocjenjuje,int kogaocjenjuje, int idrezervacije)
        {
            string sqlUpit = $"insert into ocjene(ocjena, komentar, tko_ocjenjuje, koga_ocjenjuje, id_rezervacije)values('{ocjena}','{komentar}','{tkoocjenjuje}','{kogaocjenjuje}','{idrezervacije}')";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Metoda koja ažurira ocjenu
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="ocjena">Ocjena 1-5</param>
        /// <param name="komentar">Komentar na ocjenu</param>
        /// <param name="idocjene">ID ocjene koja se ažurira</param>
        public static void AzurirajOcjenu(Iform nova, int ocjena, string komentar, int idocjene)
        {
            string sqlUpit = $"update ocjene set ocjena='{ocjena}', komentar='{komentar}' where id_ocjena='{idocjene}'";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }
        /// <summary>
        /// Dohvaćanje ocjena 
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="tkoocjenjuje">ID ocjenjivača</param>
        /// <param name="kogaocjenjuje">ID korisnika</param>
        /// <param name="idrezervacije">ID rezervacije</param>
        /// <returns></returns>
        public static Ocjena ProvjeriOcjene(Iform nova, int tkoocjenjuje, int kogaocjenjuje, int idrezervacije)
        {
            Ocjena ocjena = new Ocjena();
            ocjena.Id = -1;
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            string sqlUpit = $"select * from ocjene where tko_ocjenjuje='{tkoocjenjuje}' and koga_ocjenjuje='{kogaocjenjuje}' and id_rezervacije='{idrezervacije}';";
            var rezultat = DB.Instance.DohvatiDataReader(sqlUpit);
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            foreach (var item in returnMe)
            {
                ocjena.Id = int.Parse(item["id_ocjena"].ToString());
                ocjena.Komentar = item["komentar"].ToString();
                ocjena.ocjena = int.Parse(item["ocjena"].ToString()); 

            }
            if (rezultat != null)
                rezultat.Close();
            return ocjena;
        }
        /// <summary>
        /// Dohvaćanje predefiniranih postavki za korisnika
        /// </summary>
        /// <returns></returns>
        public static PredefiniranePostavke PredefiniranePostavke()
        {
            PredefiniranePostavke predefiniranePostavke = new PredefiniranePostavke();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            string sqlUpit = $"select * from postavke;";
            var rezultat = DB.Instance.DohvatiDataReader(sqlUpit);
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            foreach (var item in returnMe)
            {
                predefiniranePostavke.Cijena = float.Parse(item["min_cijena"].ToString());
                predefiniranePostavke.Kolicina = int.Parse(item["min_kolicina"].ToString());

            }
            if (rezultat != null)
                rezultat.Close();
            return predefiniranePostavke;
        }
        /// <summary>
        /// Ažuriranje predefiniranih postavki
        /// </summary>
        /// <param name="cijena">Nova cijena</param>
        /// <param name="kolicina">Nova količina</param>
        public static void AzurirajPredefirniranePostavke(float cijena, int kolicina)
        {
            string sqlUpit = $"update postavke set min_cijena={cijena}, min_kolicina={kolicina}";
            DB.Instance.IzvrsiUpit(sqlUpit);
        }

        /// <summary>
        /// Dohvaćanje svih zapisa dnevnika
        /// </summary>
        /// <returns></returns>
        public static List<Dnevnik> DohvatiZapiseDnevnika()
        {
            List<Dnevnik> _sviZapisi = new List<Dnevnik>();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            string sqlUpit = $"select * from dnevnik;";
            var rezultat = DB.Instance.DohvatiDataReader(sqlUpit);
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            if (rezultat != null)
                rezultat.Close();
            foreach (var item in returnMe)
            {
                Dnevnik dnevnik = new Dnevnik();
                dnevnik.DatumRadnje = DateTime.Parse(item["datum_i_vrijeme_radnje"].ToString());
                dnevnik.Radnja = item["radnja"].ToString();
                if(item["id_korisnik"]!=DBNull.Value)
                    dnevnik.IDkorisnik = int.Parse(item["id_korisnik"].ToString());
                dnevnik.IDTipRadnje= int.Parse(item["id_tip_radnje"].ToString());
                _sviZapisi.Add(dnevnik);
            }
           
            return _sviZapisi;
        }
        /// <summary>
        /// Dohvaćanje svih tipova radnje za dnevnik
        /// </summary>
        /// <returns></returns>
        public static List<TipoviRadnje> DohvatiTipoveRadnji()
        {
            List<TipoviRadnje> _sviZapisi = new List<TipoviRadnje>();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            string sqlUpit = $"select * from tipovi_radnje;";
            var rezultat = DB.Instance.DohvatiDataReader(sqlUpit);
            if (rezultat != null)
            {
                foreach (DbDataRecord item in rezultat)
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row.Add(item.GetName(i), item[i]);
                    }
                    returnMe.Add(row);
                }
            }
            if (rezultat != null)
                rezultat.Close();
            foreach (var item in returnMe)
            {
                TipoviRadnje tip = new TipoviRadnje();
                tip.ID= int.Parse(item["id_tip_radnje"].ToString());
                tip.Naziv = item["naziv"].ToString();
                _sviZapisi.Add(tip);
            }

            return _sviZapisi;
        }
        /// <summary>
        /// Unos aktivnosti u dnevnik
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opis">Opis radnje</param>
        /// <param name="idTipRadnje">Tip radnje</param>
        public static void UnesiUDnevnik(int id, string opis,int idTipRadnje)
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
