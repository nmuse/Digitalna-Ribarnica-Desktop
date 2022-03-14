using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prijava
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public class PrijavaException:Exception
    {
        public string Poruka { get; set; }
        public PrijavaException(string poruka)
        {
            Poruka = poruka;
        }
    }
}
