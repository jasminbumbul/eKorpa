using eKorpa.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModels
{
    public class ZavrseniArtikal
    {
        public int ID { get; set; }
        public int ArtikalID { get; set; }
        public Artikal Artikal { get; set; }
        public string ProdavacID { get; set; }
        public Korisnik Prodavac { get; set; }
        public string KupacID { get; set; }
        public Korisnik Kupac { get; set; }
        public DateTime Datum { get; set; }
        public int Kolicina { get; set; }
        public int? RejtingID { get; set; }
        public Rejting Rejting { get; set; }
    }
}
