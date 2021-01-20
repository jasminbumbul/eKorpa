using eKorpa.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class ProfilIndexVM
    {
        public string ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email{ get; set; }
        public string BrojTelefona{ get; set; }
        public List<Artikal> PostavljeniArtikli{ get; set; }
    }
}
