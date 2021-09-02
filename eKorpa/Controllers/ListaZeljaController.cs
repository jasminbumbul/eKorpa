using Data.EntityModels;
using eKorpa.Data;
using eKorpa.EntityModels;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "Admin,KorisnickaSluzba,Kupac/Prodavac")]
    public class ListaZeljaController : Controller
    {
        ApplicationDbContext _database = new ApplicationDbContext();
        public IActionResult Detalji()
        {
            var kupacID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var objekat = new ListaZeljaDetaljiVM
            {
                rows = _database.ListaZelja.Where(x => x.KupacID == kupacID).Select(x => new ListaZeljaDetaljiVM.Row
                {
                    ID = x.ID,
                    Cijena = _database.Artikal.Where(z => z.ID == x.ArtikalID).Select(p => p.Cijena).Single(),
                    Kategorija = _database.Artikal.Where(z => z.ID == x.ArtikalID).Select(p => p.Kategorija.NazivKategorije).Single(),
                    NazivArtikla = _database.Artikal.Where(z => z.ID == x.ArtikalID).Select(p => p.Naziv).Single(),
                    StanjeZaliha = true,
                }).ToList()
            };

            return View(objekat);
        }
        public IActionResult Dodaj(int ArtikalID)
        {
            Artikal artikal = _database.Artikal.Find(ArtikalID);
            ListaZelja listaZelja;
            listaZelja = new ListaZelja();
            listaZelja.ArtikalID = ArtikalID;
            listaZelja.KupacID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _database.ListaZelja.Add(listaZelja);

            _database.SaveChanges();
            return Redirect("/Artikal/Index");
        }
        public IActionResult Obrisi(int listaZeljaID)
        {
            ListaZelja listaZelja= _database.ListaZelja.Find(listaZeljaID);
            _database.Remove(listaZelja);
            _database.SaveChanges();
            return Redirect("/ListaZelja/Detalji");
        }
        public IActionResult Provjeri(int ArtikalID)
        {
            var kupacID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            bool flag = false;
            foreach(var item in _database.ListaZelja)
            {
                if(item.ArtikalID == ArtikalID && item.KupacID == kupacID)
                {
                    flag = true;
                }
            }
            if (flag)
                return Redirect("./Detalji");
            else
                return RedirectToAction("Dodaj", new { ArtikalID = ArtikalID });
        }

    }
}
