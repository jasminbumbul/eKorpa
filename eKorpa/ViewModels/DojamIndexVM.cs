using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class DojamIndexVM
    {
        public string KorisnikID { get; set; }
        public string ImeKorisnika { get; set; }
        public class Row
        {
            public string Dojam { get; set; }
            public float Ocjena { get; set; }
            public DateTime Datum { get; set; }
        }

        public List<Row> rows { get; set; }

        public bool Layout { get; set; }

    }
}
