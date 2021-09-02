using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class OpcinaIndexVM
    {
        public class Opcina
        {
            public int id { get; set; }
            public string naziv { get; set; }
        }

        public List<Opcina> opcine { get; set; }
        public string nazivNoveOpcine { get; set; }
    }
}
