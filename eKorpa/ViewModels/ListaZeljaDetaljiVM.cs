using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class ListaZeljaDetaljiVM
    {
        public class Row
        {
            public int ID { get; set; }
            public string NazivArtikla { get; set; }
            public float Cijena { get; set; }
            public string Kategorija { get; set; }
            public bool StanjeZaliha{ get; set; }
            public bool jestUListi { get; set; }
        }
        public List<Row> rows { get; set; }

    }
}
