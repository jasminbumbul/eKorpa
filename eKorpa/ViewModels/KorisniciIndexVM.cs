using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class KorisniciIndexVM
    {
        public class Row
        {
            public string id { get; set; }
            public string username { get; set; }
            public string ime { get; set; }
            public string prezime { get; set; }
            public string email { get; set; }
            public string brojTelefona { get; set; }
            public bool emailVerified { get; set; }
            public bool phoneVerified { get; set; }
        }

        public List<Row> rows { get; set; }
    }
}
