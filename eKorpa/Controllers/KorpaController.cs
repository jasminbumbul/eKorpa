using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.EntityModels;
using eKorpa.Data;
using eKorpa.EntityModels;
using eKorpa.ViewModels;

namespace eKorpa.Controllers
{
    public class KorpaController : Controller
    {
        ApplicationDbContext _database = new ApplicationDbContext();
        public IActionResult Detalji()
        {
            var kupacID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var objekat = new KorpaDetaljiVM
            {
                rows = _database.Korpa.Where(x=> x.KupacID==kupacID).Select(x => new KorpaDetaljiVM.Row
                {
                    ID = x.ID,
                    Kupac = _database.Users.Where(z => z.Id == x.KupacID).Select(p => p.Ime).Single() + " " + _database.Users.Where(z => z.Id == x.KupacID).Select(p => p.Prezime).Single(),
                    NazivArtikla = _database.Artikal.Where(z=>z.ID == x.ArtikalID).Select(p=>p.Naziv).Single(),
                    Kategorija = _database.Artikal.Where(z => z.ID == x.ArtikalID).Select(p => p.Kategorija.NazivKategorije).Single(),
                    Kolicina = x.kolicina,
                    Cijena = x.cijena,
                    Slika = _database.Slika.Where(y => y.ArtikalID == x.ID).Select(y => y.SlikaFile).ToList(),
                    Thumbnail = _database.Slika.Where(y => y.ArtikalID == x.ID).Select(y => y.Thumbnail).ToList()
                }).ToList()
            };
            
            return View(objekat);
        }
        public IActionResult Dodaj(int ArtikalID, int kolicina)
        {
            Artikal artikal = _database.Artikal.Find(ArtikalID);
            
            Korpa korpa, temp = null;
            bool flag = false;
            foreach(var item in _database.Korpa)
            {
                if (item.ArtikalID == ArtikalID)
                {
                    flag = true;
                    temp = item;
                }
            }
            if (flag)
            {
                korpa = temp;
                korpa.kolicina += kolicina;
                korpa.cijena = korpa.kolicina * artikal.Cijena;
            }
            else
            {
                korpa = new Korpa();
                korpa.ArtikalID = ArtikalID;
                korpa.KupacID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                korpa.kolicina += kolicina;
                korpa.cijena = korpa.kolicina * artikal.Cijena;
                _database.Korpa.Add(korpa);
            }
            _database.SaveChanges();
            return Redirect("/Korpa/Detalji");
        }

        public IActionResult Obrisi(int KorpaID)
        {
            Korpa korpa = _database.Korpa.Find(KorpaID);
            _database.Remove(korpa);
            _database.SaveChanges();
            return Redirect("/Korpa/Detalji");
        }
    }
}
