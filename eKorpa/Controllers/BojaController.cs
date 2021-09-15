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
    public class BojaController : Controller
    {
        private ApplicationDbContext _database;

        public BojaController(ApplicationDbContext context)
        {
            _database = context;
        }
        public IActionResult Index()
        {
            var objekat = new BojaIndexVM
            {
                boje = _database.Boja.Select(x => new BojaIndexVM.Boja
                {
                    id = x.ID,
                    naziv = x.Naziv
                }).ToList()
            };
            return View(objekat);
        }
        public IActionResult DodajBoju(BojaIndexVM novaBoja)
        {
            if (novaBoja==null)
            {
                return BadRequest("Boja je nula");
            }
            if (novaBoja.nazivNoveBoje.Length<3)
            {
                return BadRequest("Nepravilan naziv boje");
            }
            var boja = new Boja
            {
                Naziv = novaBoja.nazivNoveBoje
            };

            _database.Add(boja);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Izbrisi(int bojaId)
        {
            var boja = _database.Boja.Find(bojaId);

            if (boja != null)
            {
                _database.Remove(boja);
                _database.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
