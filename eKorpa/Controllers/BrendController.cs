using Data.EntityModels;
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
    public class BrendController : Controller
    {
        private ApplicationDbContext _database;

        public BrendController(ApplicationDbContext context)
        {
            _database = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DodajBrend(BrendIndexVM novi)
        {
            var noviBrend = new Brend
            {
                Naziv = novi.Naziv
            };

            _database.Add(noviBrend);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
