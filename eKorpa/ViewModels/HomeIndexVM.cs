using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class HomeIndexVM
    {
        public class Row
        {
            public int ID { get; set; }
            public string NazivArtikla { get; set; }
            public string Kategorija { get; set; }
            public string ProdavacId { get; set; }
            public string ImeProdavaca { get; set; }
            public byte[] Slika { get; set; }
            public int[] SlikaID { get; set; }
            public int Thumbnail { get; set; }
            public float Cijena { get; set; }
            public float CijenaSaPopustom { get; set; }
            public bool jestUListi { get; set; }
            public string Brend { get; set; }
            public string DatumObjave { get; set; }
        }

        public List<Row> rows { get; set; }

    }
}
