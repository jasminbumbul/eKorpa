using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.EntityModels
{
    public class ArtikliKorisnici
    {
        public int ID { get; set; }

        public virtual Artikal Artikal { get; set; }
        public int ArtikalID { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        //+svoji atributi
    }
}
