using eKorpa.Data;
using eKorpa.EntityModels;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class KategorijaController : Controller
    {
        private ApplicationDbContext _database;

        public KategorijaController(ApplicationDbContext context)
        {
            _database = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DodajKategoriju(KategorijaIndexVM novi)
        {
            var novaKategorija = new Kategorija
            {
                NazivKategorije = novi.Kategorija
            };

            _database.Add(novaKategorija);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
