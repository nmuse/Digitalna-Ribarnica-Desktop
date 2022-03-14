using Baza;
using INSform;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocjene
{
    /// <summary>
    /// Author: Nikola Muše
    /// Author: Anabela Pranjić
    /// </summary>
    public class OcjeneRepozitory
    {
        public static List<Ocjena> _ocjene = new List<Ocjena>();
        static Iform Iform;
        /// <summary>
        /// Metoda koja dohvaća sve ocjene te podatke potrebne za prikaz userControle ocjena
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Ocjena> DohvatiOcjene(Iform nova,int id)
        {
            Iform = nova;
            _ocjene.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT korisnici.slika as profilna, ocjene.id_ocjena, ocjene.komentar, ocjene.ocjena FROM korisnici,ocjene WHERE korisnici.id_korisnik = ocjene.tko_ocjenjuje AND ocjene.koga_ocjenjuje={id}");
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
            List<Dictionary<string, object>> ocjene = new List<Dictionary<string, object>>();
            var rezultat1 = DB.Instance.DohvatiDataReader("SELECT * FROM slikeOcjena");
            if (rezultat1 != null)
            {
                foreach (DbDataRecord item in rezultat1)
                {
                    var row1 = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row1.Add(item.GetName(i), item[i]);
                    }
                    ocjene.Add(row1);
                }
            }
            if (rezultat1 != null)
                rezultat1.Close();
            foreach (var item in returnMe)
            {

                Ocjena ocjena = new Ocjena(nova);

                try
                {
                    MemoryStream ms = new MemoryStream((byte[])item["profilna"]);
                    ocjena.Profilna = Image.FromStream(ms);
                }
                catch (Exception)
                {
                    ocjena.Profilna = null;
                }
                ocjena.ID = int.Parse(item["id_ocjena"].ToString());
                ocjena.Komentar = item["komentar"].ToString();
                ocjena.Ocjenaa = int.Parse(item["ocjena"].ToString());

                foreach (var item1 in ocjene)
                {
                    if(int.Parse(item1["id_slika"].ToString())==ocjena.Ocjenaa+1)
                    try
                    {
                        MemoryStream ms = new MemoryStream((byte[])item1["slika"]);
                        ocjena.SlikaOcjene = Image.FromStream(ms);
                    }
                    catch (Exception)
                    {
                        ocjena.SlikaOcjene = null;
                    }
                }
                _ocjene.Add(ocjena);
            }
 
            return _ocjene;
        }
        /// <summary>
        /// Metoda koja dohvaća prosjek ocjena za pojedinog korisnika
        /// </summary>
        /// <param name="nova"></param>
        /// <param name="id">ID korisnika kojemu želimo dohvatiti prosjek</param>
        /// <returns></returns>
        public static List<Ocjena> DohvatiProsjek(Iform nova, int id)
        {
            Iform = nova;
            _ocjene.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT AVG(Cast(ocjene.ocjena as Float)) as aritm_sred FROM korisnici, ocjene WHERE korisnici.id_korisnik = ocjene.tko_ocjenjuje and ocjene.koga_ocjenjuje ={id}");
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
            List<Dictionary<string, object>> ocjene = new List<Dictionary<string, object>>();
            var rezultat1 = DB.Instance.DohvatiDataReader("SELECT * FROM slikeOcjena");
            if (rezultat1 != null)
            {
                foreach (DbDataRecord item in rezultat1)
                {
                    var row1 = new Dictionary<string, object>();
                    for (int i = 0; i < item.FieldCount; i++)
                    {
                        row1.Add(item.GetName(i), item[i]);
                    }
                    ocjene.Add(row1);
                }
            }
            if (rezultat1 != null)
                rezultat1.Close();
            foreach (var item in returnMe)
            {

                Ocjena ocjena = new Ocjena(nova);
                if(item["aritm_sred"]!=System.DBNull.Value)
                    ocjena.Prosjek = float.Parse(item["aritm_sred"].ToString());
                else
                    ocjena.Prosjek = 0;

                foreach (var item1 in ocjene)
                {
                    if (int.Parse(item1["id_slika"].ToString()) == Math.Round(ocjena.Prosjek + 1))
                        try
                        {
                            MemoryStream ms = new MemoryStream((byte[])item1["slika"]);
                            ocjena.SlikaOcjene = Image.FromStream(ms);
                        }
                        catch (Exception)
                        {
                            ocjena.SlikaOcjene = null;
                        }
                }
                _ocjene.Add(ocjena);
            }

            return _ocjene;
        }


    }
}
