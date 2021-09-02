using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class KategorijaIndexVM
    {
        public class Kategorija
        {
            public int id { get; set; }
            public string naziv { get; set; }
        }

        public List<Kategorija> kategorije { get; set; }
        public string nazivNoveKategorije { get; set; }
    }
}
