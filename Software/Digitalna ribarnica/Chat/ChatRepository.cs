using Baza;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public static class ChatRepository
    {
        /// <summary>
        /// Metoda koje dohvaća sve poruke između dva korisnika
        /// </summary>
        /// <param name="idAktivan">ID trenutno aktivnog korisnika</param>
        /// <param name="idPrimatelj">ID korisnika s kojim želimo dohvatiti poruke</param>
        /// <returns></returns>
        public static List<PorukeIzBaze> DohvatiPoruke(int idAktivan, int idPrimatelj)
        {
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select poruke.sadrzaj, poruke.vrijeme, poruke.posiljatelj from poruke, razgovori where razgovori.id_razgovora = poruke.id_razgovora and ((razgovori.korisnik1 = {idAktivan} or razgovori.korisnik1 = {idPrimatelj}) and(razgovori.korisnik2 = {idAktivan} or razgovori.korisnik2 = {idPrimatelj}))");
            foreach (DbDataRecord item in rezultat)
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i<item.FieldCount; i++)
                {
                    row.Add(item.GetName(i), item[i]);
                }
                returnMe.Add(row);
            }
            rezultat.Close();
            List<PorukeIzBaze> _poruke = new List<PorukeIzBaze>();
            foreach (var item in returnMe)
            {
                PorukeIzBaze poruka = new PorukeIzBaze();
                poruka.ID = int.Parse(item["posiljatelj"].ToString());
                poruka.sadrzaj = item["sadrzaj"].ToString();
                poruka.datum = DateTime.Parse(item["vrijeme"].ToString());
                _poruke.Add(poruka);
            }
            return _poruke;
        }
        /// <summary>
        /// Metoda koja dodaje novi razgovor u bazu
        /// </summary>
        /// <param name="idPrimatelj">ID prvog korisnika</param>
        /// <param name="idPosiljate">ID drugog korisnika</param>
        /// <returns></returns>

        public static int DodajRazgovor(int idPrimatelj,int idPosiljate)
        {
            string sqlUpit = "";
            sqlUpit = $"insert into razgovori(korisnik1, korisnik2) values({idPrimatelj},{idPosiljate})";
            int insertUBazu = DB.Instance.IzvrsiUpit(sqlUpit);
            return insertUBazu;
        }
        /// <summary>
        /// Metoda koja dohvaća razgovor između dva korisnika
        /// </summary>
        /// <param name="idPrimatelj">ID prvog korisnika</param>
        /// <param name="idPosiljate">ID drugog korisnika</param>
        /// <returns></returns>

        public static int DohvatiRazgovor(int idPrimatelj, int idPosiljate)
        {
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"select id_razgovora from razgovori where (korisnik1 = {idPrimatelj} or korisnik1 = {idPosiljate}) and(korisnik2 = {idPrimatelj} or korisnik2 = {idPosiljate}); ");
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
            int IDRazgovora = -1;
            if (returnMe != null)
            {
                foreach (var item in returnMe)
                {
                    IDRazgovora = int.Parse(item["id_razgovora"].ToString());
                }
            }
 
            return IDRazgovora;
        }
        /// <summary>
        /// Metoda koja dohvaća sve korisnike koji su sudjelovali u razgovoru s korisnikom čiji ID pošaljemo
        /// </summary>
        /// <param name="idAktivan">ID korisnika</param>
        /// <returns></returns>
        public static List<int> DohvatiKorisnike(int idAktivan)
        {
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            List<int> chatKorisnici = new List<int>();
            var rezultat = DB.Instance.DohvatiDataReader($"select korisnik1, korisnik2 from razgovori where korisnik1={idAktivan} or korisnik2={idAktivan}");
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
            if (returnMe != null)
            {
                foreach (var item in returnMe)
                {
                    if (int.Parse(item["korisnik1"].ToString()) != idAktivan)
                        chatKorisnici.Add(int.Parse(item["korisnik1"].ToString()));
                    if (int.Parse(item["korisnik2"].ToString()) != idAktivan)
                        chatKorisnici.Add(int.Parse(item["korisnik2"].ToString()));
                }
            }

            return chatKorisnici;
        }
        /// <summary>
        /// Metoda koja unosi novu poruku u bazu
        /// </summary>
        /// <param name="sadrzaj">Sadržaj poruke</param>
        /// <param name="posiljatelj">ID pošiljatelja</param>
        /// <param name="idRazgovora">ID razgovora kojem poruka pripada</param>
        public static void UnesiPoruku(string sadrzaj,int posiljatelj,int idRazgovora)
        {
            var parameters = new Dictionary<string, object>();
            
            parameters.Add("@sadrzaj", sadrzaj);
            parameters.Add("@datum", DateTime.Now);
            parameters.Add("@posiljatelj", posiljatelj);
            parameters.Add("@idRazgovora", idRazgovora);
            DB.Instance.ExecuteParamQuery("insert into [poruke]([sadrzaj], [vrijeme], [posiljatelj], [id_razgovora]) values((@sadrzaj),(@datum),(@posiljatelj),(@idRazgovora));", parameters);
        }
    }
}
