using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class ArtikalDodajVM
    {
        public int ID { get; set; }
        public string NazivArtikla { get; set; }
        public string ProdavacId { get; set; }
        public int KategorijaID { get; set; }
        public List<SelectListItem> Kategorije { get; set; }
    }
}
