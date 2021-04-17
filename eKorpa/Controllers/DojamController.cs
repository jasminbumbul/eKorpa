using eKorpa.Data;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.Controllers
{
    public class DojamController : Controller
    {
        private ApplicationDbContext _database;

        public DojamController(ApplicationDbContext context)
        {
            _database = context;
        }

        public IActionResult Index(string KorisnikID)
        {

            return View();
        }

        //  <a href="/Dojam/DojamProdavaca?RejtingID=@item.RatingID">Dojam prodavača</a>

        public IActionResult DojamProdavaca(int RejtingID)
        {
            var rejting = _database.Rejting.Where(x => x.ID == RejtingID).SingleOrDefault();

            var artikal = _database.ZavrseniArtikal.Where(x => x.RejtingID == RejtingID).SingleOrDefault();

            var objekat = new DojamProdavacaIndexVM
            {
                Datum = rejting.DatumProdavac,
                Ime=_database.Users.Where(x=> x.Id==artikal.ProdavacID).Select(x=> $"{x.Ime} {x.Prezime}").FirstOrDefault(),
                Dojam=rejting.DojamProdavaca,
                Ocjena=rejting.OcjenaProdavaca
            };

            return View("Index", objekat);

        }
        
        public IActionResult DojamKupca(int RejtingID)
        {
            var rejting = _database.Rejting.Where(x => x.ID == RejtingID).SingleOrDefault();

            var artikal = _database.ZavrseniArtikal.Where(x => x.RejtingID == RejtingID).SingleOrDefault();

            var objekat = new DojamProdavacaIndexVM
            {
                Datum = rejting.DatumKupac,
                Ime=_database.Users.Where(x=> x.Id==artikal.KupacID).Select(x=> $"{x.Ime} {x.Prezime}").FirstOrDefault(),
                Dojam=rejting.DojamKupca,
                Ocjena=rejting.OcjenaKupca
            };

            return View("Index", objekat);

        }

        public IActionResult OstaviDojam(int RejtingID, string TipKorisnika)
        {
            var objekat = new DojamDodajVM
            {
                RatingID = RejtingID,
                TipKorisnika=TipKorisnika
            };

            return View("Dodaj",objekat);
        }

        public IActionResult SnimiDojam(DojamDodajVM novi)
        {
            var rejting = _database.Rejting.Find(novi.RatingID);
            string korisnikID;

            if (novi.TipKorisnika=="kupac")
            {
                rejting.DojamKupca = novi.Dojam;
                rejting.DatumKupac = DateTime.Now;
                rejting.OcjenaKupca = novi.Ocjena;
                korisnikID = _database.ZavrseniArtikal.Where(x => x.RejtingID == novi.RatingID).SingleOrDefault().KupacID;
                rejting.KupacOstavioDojam = true;
            }
            else
            {
                rejting.DojamProdavaca = novi.Dojam;
                rejting.OcjenaProdavaca = novi.Ocjena;
                rejting.DatumProdavac = DateTime.Now;
                korisnikID = _database.ZavrseniArtikal.Where(x => x.RejtingID == novi.RatingID).SingleOrDefault().ProdavacID;
                rejting.ProdavacOstavioDojam = true;
            }
            _database.SaveChanges();

            return Redirect("/Profil/Index?KorisnikID=" + korisnikID);
        }
    }
}
