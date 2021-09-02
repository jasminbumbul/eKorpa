using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class RoleIndexVM
    {
        public class Row
        {
            public string id { get; set; }
            public string name { get; set; }
            public bool isDefault { get; set; }
        }

        public List<Row> rows { get; set; }
    }
}
