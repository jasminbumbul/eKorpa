using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKorpa.Data;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace eKorpa.Controllers
{
    public class ProfilController : Controller
    {
        ApplicationDbContext _database = new ApplicationDbContext();

        public IActionResult Index(string KorisnikID)
        {
            var profil = _database.Users.Where(x => x.Id == KorisnikID).Select(x => new ProfilIndexVM
            {
                BrojTelefona = x.PhoneNumber,
                Email = x.Email,
                ID = KorisnikID,
                Ime = x.Ime,
                Prezime = x.Prezime,
                PostavljeniArtikli = _database.Artikal.Where(x => x.ProdavacID == KorisnikID).ToList()
            }).Single();

            
            //int i = 0;
            //foreach (var item in _database.Artikal.ToList())
            //{
            //    profil.Slika[i] = _database.Slika.Where(x => x.ArtikalID == item.ID ).Select(x=> x.SlikaFile).Single();
            //    profil.Thumbnail[i] = _database.Slika.Where(x => x.ArtikalID == item.ID ).Select(x=> x.Thumbnail).Single();
            //    i++;
            //}

            return View(profil);
        }
    }
}
