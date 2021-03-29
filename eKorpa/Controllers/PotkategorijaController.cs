using Data.EntityModels;
using eKorpa.Data;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.Controllers
{
    public class PotkategorijaController : Controller
    {
        private ApplicationDbContext _database;

        public PotkategorijaController(ApplicationDbContext context)
        {
            _database = context;
        }
        public IActionResult Index()
        {
            var objekat = new PotkategorijaIndexVM
            {
                Kategorija = _database.Kategorija.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.NazivKategorije
                }).ToList()
            };

            return View(objekat);
        }
        public IActionResult DodajPotkategoriju(PotkategorijaIndexVM novi)
        {
            var novaPotkategorija = new Potkategorija
            {
                Naziv = novi.Potkategorija
            };

            _database.Add(novaPotkategorija);
            _database.SaveChanges();

            var kategorija = _database.Kategorija.Find(novi.KategorijaID);

            if(kategorija.Potkategorija==null)
            {
                kategorija.Potkategorija = new List<Potkategorija>();
            }

            kategorija.Potkategorija.Add(novaPotkategorija);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
