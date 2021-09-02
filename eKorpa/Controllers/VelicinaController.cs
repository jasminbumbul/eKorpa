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
    public class VelicinaController : Controller
    {
        private ApplicationDbContext _database;

        public VelicinaController(ApplicationDbContext context)
        {
            _database = context;
        }
        public IActionResult Index()
        {
            var objekat = new VelicinaIndexVM
            {
                potkategorija = _database.Potkategorija.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Naziv
                }).ToList()
            };

            objekat.velicine = _database.Potkategorija.Select(x => new VelicinaIndexVM.VelicinaVM
            {
               potkategorijaId=x.ID,
               nazivPotkategorije=x.Naziv,
               velicine=x.Velicina
            }).ToList();

            return View(objekat);
        }

        public IActionResult DodajVelicinu(VelicinaIndexVM novi)
        {
            var novaVelicina = new Velicina
            {
                VelicinaOznaka = novi.nazivNoveVelicine
            };

            _database.Add(novaVelicina);
            _database.SaveChanges();

            var potkategorija = _database.Potkategorija.Find(novi.potkategorijaId);

            if (potkategorija.Velicina == null)
            {
                potkategorija.Velicina = new List<Velicina>();
            }

            potkategorija.Velicina.Add(novaVelicina);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
