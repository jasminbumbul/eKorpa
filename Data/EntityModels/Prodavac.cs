using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.EntityModels
{
    public class Prodavac
    {
        public int ID { get; set; }
        public bool isRadnja { get; set; }

        public string KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }

    }
}
