using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class PonudaIndexVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int ID { get; set; }
            public string Opis { get; set; }
            public bool IsAktivna { get; set; }
            public int KategorijaID { get; set; }
            public string NazivKategorije { get; set; }
            public int PotkategorijaID { get; set; }
            public string NazivPotkategorije { get; set; }
            public string VelicinaPopusta { get; set; }
        }
    }
}
