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

    public class MaterijalController : Controller
    {
        private ApplicationDbContext _database;

        public MaterijalController(ApplicationDbContext context)
        {
            _database = context;
        }
        public IActionResult Index()
        {
            var objekat = new MaterijalIndexVM
            {
                materijali = _database.Materijal.Select(x => new MaterijalIndexVM.Materijal
                {
                    id = x.ID,
                    naziv = x.Naziv
                }).ToList()
            };
            return View(objekat);
        }
        public IActionResult DodajMaterijal(MaterijalIndexVM noviMaterijal)
        {
            if (noviMaterijal.nazivNovogMaterijala == null)
            {
                return BadRequest("Materijal je nula");
            }
            if (noviMaterijal.nazivNovogMaterijala.Length < 3)
            {
                return BadRequest("Nepravilan naziv materijala");
            }
            var materijal = new Materijal
            {
                Naziv=noviMaterijal.nazivNovogMaterijala
            };

            _database.Add(materijal);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
