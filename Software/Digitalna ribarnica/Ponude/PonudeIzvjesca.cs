using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponude
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public class PonudeIzvjesca
    {

        public string naziv { get; set; }
        public double cijena { get; set; }

        public string mjerna { get; set; }

        public PonudeIzvjesca(string naziv,double cijena, string mjerna)
        {
            this.naziv = naziv;
            this.cijena = cijena;
            this.mjerna = mjerna;
        }
    }
}
