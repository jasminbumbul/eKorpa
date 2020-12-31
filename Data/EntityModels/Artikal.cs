using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using eKorpa.EntityModels;

namespace eKorpa.EntityModels
{
    public class Artikal
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        public int KategorijaID { get; set; }
        public Kategorija Kategorija{ get; set; }
        public string ProdavacID { get; set; }
    }
}
