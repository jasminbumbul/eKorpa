using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class BojaIndexVM
    {
        public class Boja
        {
            public int id { get; set; }
            public string naziv { get; set; }
        }

        public List<Boja> boje{ get; set; }
        public string nazivNoveBoje { get; set; }
    }
}
