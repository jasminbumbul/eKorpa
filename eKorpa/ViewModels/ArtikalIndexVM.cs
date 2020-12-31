using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class ArtikalIndexVM
    {
        public class Row
        {
            public int ID { get; set; }
            public string NazivArtikla { get; set; }
            public string Kategorija { get; set; }
            public string ProdavacId { get; set; }
        }
        public List<Row> rows { get; set; }
    }
}
