using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class MaterijalIndexVM
    {
        public class Materijal
        {
            public int id { get; set; }
            public string naziv { get; set; }
        }

        public List<Materijal> materijali{ get; set; }
        public string nazivNovogMaterijala { get; set; }
    }
}
