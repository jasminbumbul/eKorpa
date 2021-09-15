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
    public class OpcinaController : Controller
    {
        private ApplicationDbContext _database;

        public OpcinaController(ApplicationDbContext context)
        {
            _database = context;
        }
        public IActionResult Index()
        {
            var objekat = new OpcinaIndexVM
            {
                opcine = _database.Grad.Select(x => new OpcinaIndexVM.Opcina
                {
                    id = x.ID,
                    naziv = x.Naziv
                }).ToList()
            };
            return View(objekat);
        }
        public IActionResult DodajOpcinu(OpcinaIndexVM novaOpcina)
        {
            if (novaOpcina.nazivNoveOpcine == null)
            {
                return BadRequest("Općina je nula");
            }
            if (novaOpcina.nazivNoveOpcine.Length < 3)
            {
                return BadRequest("Nepravilan naziv općine");
            }
            var opcina = new Grad
            {
                Naziv= novaOpcina.nazivNoveOpcine
            };

            _database.Add(opcina);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Izbrisi(int opcinaId)
        {
            var objekat = _database.Grad.Find(opcinaId);

            if (objekat != null)
            {
                _database.Remove(objekat);
                _database.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
