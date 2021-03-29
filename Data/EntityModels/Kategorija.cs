using Data.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.EntityModels
{
    public class Kategorija
    {
        public int ID { get; set; }
        public string NazivKategorije { get; set; }
        public List<Potkategorija> Potkategorija { get; set; }

    }
}
