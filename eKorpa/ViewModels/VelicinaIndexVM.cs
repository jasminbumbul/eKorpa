using Data.EntityModels;
using eKorpa.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class VelicinaIndexVM
    {
        public int potkategorijaId { get; set; }
        public List<SelectListItem> potkategorija  { get; set; }
        public string nazivNoveVelicine { get; set; }

        public List<VelicinaVM> velicine{ get; set; }

        public class VelicinaVM
        {
            public int potkategorijaId { get; set; }
            public string nazivPotkategorije { get; set; }
            public List<Velicina> velicine { get; set; }
        }
    }
}
