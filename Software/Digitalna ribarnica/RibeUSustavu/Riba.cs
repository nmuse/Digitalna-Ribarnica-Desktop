using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RibeUSustavu
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public class Riba
    {
        [DisplayName("ID ribe")]
        public int id { get; set; }
        [DisplayName("Naziv")]
        public string Naziv { get; set; }
        [DisplayName("Slika ribe")]
        public Image SlikaRibe { get; set; }
        [DisplayName("Jedinica prodaje")]
        public string MjernaJedinica { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

        public Riba()
        {

        }

        public Riba(string naziv)
        {
            Naziv = naziv;
        }
    }
}
