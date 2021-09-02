using Data.EntityModels;
using eKorpa.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class PotkategorijaIndexVM
    {
        public int KategorijaID { get; set; }
        public List<SelectListItem> Kategorija  { get; set; }
        public string nazivNovePotkategorije { get; set; }

        public List<PotkategorijaVM> potkategorije{ get; set; }

        public class PotkategorijaVM
        {
            public int kategorijaId { get; set; }
            public string nazivKategorije { get; set; }
            public List<Potkategorija> potkategorije { get; set; }
        }
    }
}
