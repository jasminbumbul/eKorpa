using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class PonudaDodajVM
    {
        public string Opis { get; set; }
        public int KategorijaID { get; set; }
        public List<SelectListItem> Kategorija { get; set; }
        public int PotkategorijaID { get; set; }
        public List<SelectListItem> Potkategorija { get; set; }
        public float Popust { get; set; }
    }
}
