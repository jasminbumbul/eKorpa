using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class KorpaDetaljiVM
    {
        public class Row
        {
            public int ID { get; set; }
            public string Kupac { get; set; }
            public List<byte[]> Slika { get; set; }
            public List<byte[]> SlikaID { get; set; }
            public List<int> Thumbnail { get; set; }
            public string NazivArtikla { get; set; }
            public string Kategorija { get; set; }
            public int Kolicina { get; set; }
            public float Cijena { get; set; }

        }
        public List<Row> rows { get; set; }
    }
}
