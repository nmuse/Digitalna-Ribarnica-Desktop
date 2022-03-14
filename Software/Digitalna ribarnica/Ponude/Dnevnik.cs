using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponude
{
    /// <summary>
    /// Author: Nikola Muše
    /// Author: Božo Kvesić
    /// </summary>
    public class Dnevnik
    {
        [DisplayName("Opis radnje")]
        public string Radnja { get; set; }

        [DisplayName("Datum izvršene radnje")]
        public DateTime DatumRadnje { get; set; }
        public int IDkorisnik { get; set; }

        [DisplayName("Ime i prezime korisnika")]
        public string ImeiPrezimeKorisnika { get; set; }

        [DisplayName("Vrsta radnje")]
        public string NazivRadnje { get; set; }
        public int IDTipRadnje { get; set; }



    }
}
