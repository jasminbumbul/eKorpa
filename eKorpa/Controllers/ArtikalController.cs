using eKorpa.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKorpa.ViewModels;
using eKorpa.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eKorpa.Controllers
{
    public class ArtikalController : Controller
    {
        ApplicationDbContext _database = new ApplicationDbContext();
        public IActionResult Index()
        {   
            var objekat = new ArtikalIndexVM
            {
                rows = _database.Artikal.Select(a => new ArtikalIndexVM.Row
                {
                    ID = a.ID,
                    NazivArtikla = a.Naziv,
                    Kategorija = a.Kategorija.NazivKategorije
                }).ToList()
            };
        
            return View(objekat);
        }

        public IActionResult Dodaj()
        {
            var noviArtikal = new ArtikalDodajVM()
            {
                Kategorije = _database.Kategorija.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.NazivKategorije }).ToList()
            };
            
            return View(noviArtikal);
        }

        public IActionResult Snimi(ArtikalDodajVM noviArtikal)
        {
            Artikal artikal = new Artikal();
            artikal.Naziv = noviArtikal.NazivArtikla;
            artikal.KategorijaID = noviArtikal.KategorijaID;
            _database.Artikal.Add(artikal);
            _database.SaveChanges();

            return Redirect("/Artikal/");
        }
    }
}
