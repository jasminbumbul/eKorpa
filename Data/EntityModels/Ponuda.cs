using eKorpa.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModels
{
    public class Ponuda
    {
        public int ID { get; set; }
        public string Opis { get; set; }
        public float ProcenatSnizenja { get; set; }
        public int KategorijaID { get; set; }
        public Kategorija Kategorija { get; set; }
        public int PotkategorijaID { get; set; }
        public Potkategorija Potkategorija { get; set; }
        public bool IsAktivna { get; set; }
    }
}
