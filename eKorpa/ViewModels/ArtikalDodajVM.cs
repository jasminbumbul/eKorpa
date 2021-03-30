using Data.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class ArtikalDodajVM
    {
        public int ID { get; set; }
        public string NazivArtikla { get; set; }
        public string ProdavacId { get; set; }
        public string ImeProdavaca { get; set; }
        public int KategorijaID { get; set; }
        public List<SelectListItem> Kategorije { get; set; }
        public int PotkategorijaID { get; set; }
        public List<SelectListItem> Potkategorija{ get; set; }
        public List<byte[]> Slike { get; set; }
        public List<int> SlikaID { get; set; }
        public List<IFormFile> Slika { get; set; }
        public float Cijena { get; set; }
        public int BrendID { get; set; }
        public List<SelectListItem> Brend { get; set; }
    }
}
