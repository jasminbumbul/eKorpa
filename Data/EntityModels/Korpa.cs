using eKorpa.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModels
{
    public class Korpa
    {
        public int ID { get; set; }
        public string KupacID { get; set; }
        public Korisnik Kupac { get; set; }
        public int ArtikalID { get; set; }
        public Artikal Artikal { get; set; }
        public int kolicina { get; set; }
        public float cijena { get; set; }
        
    }
}
