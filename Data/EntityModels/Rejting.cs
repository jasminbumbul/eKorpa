using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModels
{
    public class Rejting
    {
        public int ID { get; set; }
        public string DojamKupca { get; set; }
        public string DojamProdavaca { get; set; }
        public bool KupacOstavioDojam { get; set; }
        public bool ProdavacOstavioDojam { get; set; }
        public float OcjenaKupca { get; set; }
        public float OcjenaProdavaca { get; set; }
        public DateTime DatumProdavac { get; set; }
        public DateTime DatumKupac { get; set; }
    }
}
