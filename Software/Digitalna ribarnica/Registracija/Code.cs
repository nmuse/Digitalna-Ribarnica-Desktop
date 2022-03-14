using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registracija
{
    /// <summary>
    /// Author: Božo Kvesić
    /// </summary>
    public class Code
    {
        public int Broj { get; set; }
        public  DateTime DatumIsteka { get; set; }

        public Code(int broj)
        {
            Broj = broj;
            DatumIsteka = DateTime.Now.AddMinutes(15); //Kod vrijedi 15 minuta nakon aktivacije
        }

        //Ovdje je potrebno dodavanje u bazu kako bi se znalo koji kodovi su aktivni do kojeg datuma
    }
}
