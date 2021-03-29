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
        public string Potkategorija { get; set; }
    }
}
