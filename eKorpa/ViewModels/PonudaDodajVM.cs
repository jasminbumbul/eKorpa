using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class PonudaDodajVM
    { 
        public int ID { get; set; }
        public int KategorijaID { get; set; }
        public int PotkategorijaID { get; set; }
        public double Popust { get; set; }
        public string Opis { get; set; }
    }
}
