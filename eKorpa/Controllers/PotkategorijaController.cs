using Data.EntityModels;
using eKorpa.Data;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "Admin,KorisnickaSluzba")]
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

            objekat.potkategorije = _database.Kategorija.Select(x => new PotkategorijaIndexVM.PotkategorijaVM
            {
                kategorijaId=x.ID,
                nazivKategorije=x.NazivKategorije,
                potkategorije=x.Potkategorija
            }).ToList();

            return View(objekat);
        }

        public IActionResult DodajPotkategoriju(PotkategorijaIndexVM novi)
        {
            var novaPotkategorija = new Potkategorija
            {
                Naziv = novi.nazivNovePotkategorije
            };

            _database.Add(novaPotkategorija);
            _database.SaveChanges();

            var kategorija = _database.Kategorija.Find(novi.KategorijaID);

            if (kategorija.Potkategorija == null)
            {
                kategorija.Potkategorija = new List<Potkategorija>();
            }

            kategorija.Potkategorija.Add(novaPotkategorija);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Izbrisi(int potkategorijaId)
        {
            var potkategorija = _database.Potkategorija.Find(potkategorijaId);

            if (potkategorija != null)
            {
                _database.Remove(potkategorija);
                _database.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}
