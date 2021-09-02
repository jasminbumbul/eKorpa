using Data.EntityModels;
using eKorpa.Data;
using eKorpa.EntityModels;
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
    public class KategorijaController : Controller
    {
        private ApplicationDbContext _database;

        public KategorijaController(ApplicationDbContext context)
        {
            _database = context;
        }
        public IActionResult Index()
        {
            var objekat = new KategorijaIndexVM
            {
                kategorije = _database.Kategorija.Select(x => new KategorijaIndexVM.Kategorija
                {
                    id = x.ID,
                    naziv = x.NazivKategorije
                }).ToList()
            };
            return View(objekat);
        }
        public IActionResult DodajKategoriju(KategorijaIndexVM novaKategorija)
        {
            if (novaKategorija == null)
            {
                return BadRequest("Kategorija je nula");
            }
            if (novaKategorija.nazivNoveKategorije.Length < 3)
            {
                return BadRequest("Nepravilan naziv kategorije");
            }
            var kategorija = new Kategorija
            {
                NazivKategorije = novaKategorija.nazivNoveKategorije
            };

            _database.Add(kategorija);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult GetKategorije()
        {
            var objekat = _database.Kategorija.Select(x => new Kategorija
            {
                ID = x.ID,
                NazivKategorije = x.NazivKategorije,
                Potkategorija = x.Potkategorija
            });

            return Ok(objekat);
        }

        //public IActionResult GetPotkategorije()
        //{
        //    var objekat = _database.Potkategorija.Select(x => new Potkategorija
        //    {
        //        ID = x.ID,
        //        Naziv = x.Naziv
        //    });

        //    return Ok(objekat);
        //}

    }
}
