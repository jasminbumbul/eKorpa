using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModels
{
    public class Adresa
    {
        public int ID { get; set; }
        public int? OpcinaID { get; set; }
        public Grad Opcina { get; set; }
        public string MjestoStanovanja { get; set; }
        public int PostanskiBroj { get; set; }
    }
}
