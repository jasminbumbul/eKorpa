using eKorpa.EntityModels;
using eKorpa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Authorization;
using eKorpa.Data;

namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Korisnik> _userManager;
        ApplicationDbContext _database = new ApplicationDbContext();


        public HomeController(ILogger<HomeController> logger, UserManager<Korisnik> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            HomeIndexVM objekat = new HomeIndexVM()
            {
                rows = _database.Artikal.Where(x=> x.Izbrisan==false).OrderBy(x => x.DatumObjave).Select(a => new HomeIndexVM.Row
                {
                    ID = a.ID,
                    NazivArtikla = a.Naziv,
                    Kategorija = a.Kategorija.NazivKategorije,
                    ProdavacId = a.ProdavacID,
                    ImeProdavaca = a.ImeProdavaca,
                    CijenaSaPopustom = a.CijenaSaPopustom,
                    Cijena = a.Cijena,
                    Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).SingleOrDefault(),
                    Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).SingleOrDefault(),
                    Brend = a.Brend.Naziv,
                    DatumObjave = a.DatumObjave.ToString("dd.MM.yyyy"),
                }).Take(4).ToList()
            };

            foreach (var item in objekat.rows)
            {
                foreach (var temp in _database.ListaZelja)
                {
                    if (item.ID == temp.ArtikalID)
                        item.jestUListi = true;
                }
            }

            return View(objekat);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Pretraga(string querry)
        {
            return Redirect("/Artikal/Index?querry=" + querry);
        }
    }
}