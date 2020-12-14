using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.EntityModels
{
    public class Korisnik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public int? OpcinaStanovanjaID { get; set; }
        public Opcina OpcinaStanovanja { get; set; }
    }
}
