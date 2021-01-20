using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eKorpa.ViewModels
{
    public class ArtikalDetaljiVM
    {
        public int ID { get; set; }
        public string NazivArtikla { get; set; }
        public string Kategorija { get; set; }
        public string Prodavac { get; set; }
        public float Cijena { get; set; }
        public List<byte[]> Slike{ get; set; }
        public List<int> SlikaID{ get; set; }
        public int kolicina { get; set; }
        //public int KategorijaID { get; set; }
        //public List<SelectListItem> Kategorije { get; set; }
    }
}
