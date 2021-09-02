using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class BrendIndexVM
    {
        public class Brend
        {
            public int id { get; set; }
            public string naziv { get; set; }
        }

        public List<Brend> brendovi { get; set; }
        public string nazivNovogBrenda { get; set; }
    }
}
