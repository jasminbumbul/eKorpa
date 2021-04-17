using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class ArtikalIndexVM
    {
        public class Row
        {
            public int ID { get; set; }
            public string NazivArtikla { get; set; }
            public string Kategorija { get; set; }
            public string ProdavacId { get; set; }
            public string ImeProdavaca { get; set; }
            public List<byte[]> Slika { get; set; }
            public List<int[]> SlikaID { get; set; }
            public List<int> Thumbnail { get; set; }
            public float Cijena { get; set; }
            public float CijenaSaPopustom { get; set; }
            public bool jestUListi { get; set; }
            public string Brend { get; set; }
            public int RatingID { get; set; }
            public bool KupacOstavioDojam { get; set; }
            public bool ProdavacOstavioDojam { get; set; }
            public string KupacID { get; set; }
        }
        public bool Layout { get; set; }
        //filter
        public int KategorijaID { get; set; }
        public List<SelectListItem> Kategorije { get; set; }
        public int PotkategorijaID { get; set; }
        public List<SelectListItem> Potkategorija { get; set; }
        public float MinCijena { get; set; }
        public float MaxCijena { get; set; }
        public int BojaID { get; set; }
        public List<SelectListItem> Boja { get; set; }
        public int MaterijalID{ get; set; }
        public List<SelectListItem> Materijal{ get; set; }
        public int VelicinaID{ get; set; }
        public List<SelectListItem> Velicina{ get; set; }
        public int BrendID{ get; set; }
        public List<SelectListItem> Brend{ get; set; }
        //


        public List<Row> rows { get; set; }
    }
}
