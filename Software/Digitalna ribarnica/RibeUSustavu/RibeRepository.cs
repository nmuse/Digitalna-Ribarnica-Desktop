using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza;
namespace RibeUSustavu
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public class RibeRepository
    {
        public static List<Riba> _ribe { get; set; } = new List<Riba>();

        /// <summary>
        /// Metoda koja dodaje novu ribu u bazu
        /// </summary>
        /// <param name="parameters"></param>
        public static void DodajNovuRibu(Dictionary<string, object> parameters)
        {
            DB.Instance.ExecuteParamQuery("INSERT INTO [ribe] ([naziv], [slika], [mjerna_jedinica]) VALUES ((@naziv), (@slika), (@mjerna_jedinica));", parameters);
        }
        /// <summary>
        /// Metoda koja dohvaća sve ribe iz baze
        /// </summary>
        /// <returns></returns>
        public static List<Riba> DohvatiRibe()
        {
            
            _ribe.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT * FROM ribe;");
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
                Riba riba = new Riba();
                if (item["slika"].ToString() != "")
                {
                    MemoryStream ms = new MemoryStream((byte[])item["slika"]);
                    riba.SlikaRibe = Image.FromStream(ms);
                }
                riba.id = (int)item["id_riba"];
                riba.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna==1)
                    riba.MjernaJedinica = "kom";
                else
                    riba.MjernaJedinica = "kg";
                _ribe.Add(riba);
            }
            rezultat.Close();
            return _ribe;
        }
        /// <summary>
        /// Metoda koja dohvaća sve naziva riba iz baze
        /// </summary>
        /// <returns></returns>
        public static List<Riba> DohvatiNaziveRibe()
        {

            _ribe.Clear();
            List<Dictionary<string, object>> returnMe = new List<Dictionary<string, object>>();
            var rezultat = DB.Instance.DohvatiDataReader($"SELECT id_riba, naziv, mjerna_jedinica FROM ribe;");
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
                Riba riba = new Riba();
                riba.id = (int)item["id_riba"];
                riba.Naziv = item["naziv"].ToString();
                int mjerna = int.Parse(item["mjerna_jedinica"].ToString());
                if (mjerna == 1)
                    riba.MjernaJedinica = "kom";
                else
                    riba.MjernaJedinica = "kg";
                _ribe.Add(riba);
            }
            rezultat.Close();
            return _ribe;
        }
        /// <summary>
        /// Metoda koja ažurira ribu
        /// </summary>
        /// <param name="parameters"></param>
        public static void AzurirajRibu(Dictionary<string, object> parameters)
        {
            DB.Instance.ExecuteParamQuery("UPDATE [ribe] SET [naziv] = (@naziv), [slika] = (@slika), [mjerna_jedinica] = (@mjerna_jedinica) WHERE [id_riba] =(@id_riba); ", parameters);
        }
        /// <summary>
        /// Metoda koja briše poslanu ribu
        /// </summary>
        /// <param name="riba">Riba koja se briše iz baze</param>
        public static void ObrisiRibu(Riba riba)
        {
            DB.Instance.IzvrsiUpit($"DELETE FROM ribe WHERE id_riba ={riba.id};");
        }
    }
}
