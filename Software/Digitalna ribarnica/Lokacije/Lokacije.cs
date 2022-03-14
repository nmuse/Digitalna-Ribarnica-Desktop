using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokacije
{
    /// <summary>
    /// Author: Anabela Pranjić
    /// </summary>
    public class Lokacije
    {
        [DisplayName("ID lokacije")]
        public int id { get; set; }

        [DisplayName("Naziv")]
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

        public Lokacije()
        {

        }

        public Lokacije(string naziv)
        {
            Naziv = naziv;
        }
    }
}
