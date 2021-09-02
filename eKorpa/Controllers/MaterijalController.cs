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
    public class BrendController : Controller
    {
        private ApplicationDbContext _database;

        public BrendController(ApplicationDbContext context)
        {
            _database = context;
        }
        public IActionResult Index()
        {
            var objekat = new BrendIndexVM
            {
                brendovi = _database.Brend.Select(x => new BrendIndexVM.Brend
                {
                    id = x.ID,
                    naziv = x.Naziv
                }).ToList()
            };
            return View(objekat);
        }
        public IActionResult DodajBrend(BrendIndexVM noviBrend)
        {
            if (noviBrend == null)
            {
                return BadRequest("Brend je nula");
            }
            if (noviBrend.nazivNovogBrenda.Length < 3)
            {
                return BadRequest("Nepravilan naziv brenda");
            }
            var brend = new Brend
            {
                Naziv = noviBrend.nazivNovogBrenda
            };

            _database.Add(brend);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
