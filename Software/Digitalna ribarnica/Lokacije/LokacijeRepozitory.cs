using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza;
namespace Lokacije
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public class LokacijeRepozitory
    {
        public static List<Lokacije> _lokacije { get; set; }

        /// <summary>
        /// Metoda koja dohvaća sve lokacije iz baze i sprema ih u listu
        /// </summary>
        /// <returns></returns>
        public static List<Lokacije> dohvatiLokacije()
        {
            _lokacije = new List<Lokacije>();
            _lokacije.Clear();
            string sqlUpit= $"SELECT * FROM lokacije;";
            SqlDataReader rezultat = DB.Instance.DohvatiDataReader(sqlUpit);
            if (rezultat != null)
            {
                while (rezultat.Read())
                {
                    Lokacije lokacija = new Lokacije();
                    lokacija.id = int.Parse(rezultat["id_lokacija"].ToString());
                    lokacija.Naziv = rezultat["naziv"].ToString();
                    _lokacije.Add(lokacija);

                }

                rezultat.Close();
            }
            return _lokacije;
        }
        /// <summary>
        /// Metoda koja dodaje novu lokaciju
        /// </summary>
        /// <param name="naziv">Naziv nove lokacije</param>
        public static void dodajLokacij(string naziv)
        {
            DB.Instance.IzvrsiUpit($"INSERT INTO lokacije (naziv) VALUES ('{naziv}');");
        }
        /// <summary>
        /// Metoda koja briše poslanu lokaciju iz baze
        /// </summary>
        /// <param name="lokacije"></param>
        public static void obrisiLokaciju(Lokacije lokacije)
        {
            DB.Instance.IzvrsiUpit($"DELETE FROM lokacije WHERE id_lokacija = '{lokacije.id}'; ");
        }
        /// <summary>
        /// Metoda koja ažurirana poslanu lokaciju
        /// </summary>
        /// <param name="lokacije">Stara lokacija</param>
        /// <param name="naziv">Novi naziv</param>
        public static void azurirajLokaciju(Lokacije lokacije,string naziv)
        {
            DB.Instance.IzvrsiUpit($"UPDATE lokacije SET naziv='{naziv}' WHERE id_lokacija='{lokacije.id}';");
        }
    }
}
