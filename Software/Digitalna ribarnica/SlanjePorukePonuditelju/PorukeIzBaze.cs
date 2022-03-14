using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlanjePorukePonuditelju
{
    /// <summary>
    /// Author: Nikola Muše
    /// Author: Božo Kvesić
    /// </summary>
    public class PorukeIzBaze
    {
        public int ID { get; set; }
        public DateTime datum { get; set; }
        public string sadrzaj { get; set; }
    }
}
