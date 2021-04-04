using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKorpa.Data;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Authorization;
using eKorpa.EntityModels;

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

        public IActionResult KupljeniArtikli(string KorisnikID)
        {
            var kupljeniArtikli = _database.ZavrseniArtikal.Where(x => x.KupacID == KorisnikID).Select(x=> x.Artikal).ToList();

            //List<Artikal> artikli = new List<Artikal>();

            //foreach (var item in kupljeniArtikli)
            //{
            //    artikli.Add(_database.Artikal.Find(item));    
            //}

            var objekat = new ArtikalIndexVM
            {
                rows = kupljeniArtikli.Select(x => new ArtikalIndexVM.Row
                {
                    Brend=_database.Brend.Find(x.BrendID).Naziv,
                    Cijena=x.Cijena,
                    CijenaSaPopustom=x.CijenaSaPopustom,
                    ImeProdavaca=x.ImeProdavaca,
                    Kategorija=_database.Kategorija.Find(x.KategorijaID).NazivKategorije,
                    NazivArtikla=x.Naziv,
                    Slika = _database.Slika.Where(a => a.ArtikalID == x.ID).Select(a => a.SlikaFile).ToList(),
                    Thumbnail = _database.Slika.Where(a => a.ArtikalID == x.ID).Select(a => a.Thumbnail).ToList()
                }).ToList()
            };

            return View(objekat);
        }

        public IActionResult ProdaniArtikli(string KorisnikID)
        {
            var prodaniArtikli = _database.ZavrseniArtikal.Where(x => x.ProdavacID == KorisnikID).Select(x => x.Artikal).ToList();

            //List<Artikal> artikli = new List<Artikal>();

            //foreach (var item in kupljeniArtikli)
            //{
            //    artikli.Add(_database.Artikal.Find(item));    
            //}

            var objekat = new ArtikalIndexVM
            {
                rows = prodaniArtikli.Select(x => new ArtikalIndexVM.Row
                {
                    Brend = _database.Brend.Find(x.BrendID).Naziv,
                    Cijena = x.Cijena,
                    CijenaSaPopustom = x.CijenaSaPopustom,
                    ImeProdavaca = x.ImeProdavaca,
                    Kategorija = _database.Kategorija.Find(x.KategorijaID).NazivKategorije,
                    NazivArtikla = x.Naziv,
                    Slika = _database.Slika.Where(a => a.ArtikalID == x.ID).Select(a => a.SlikaFile).ToList(),
                    Thumbnail = _database.Slika.Where(a => a.ArtikalID == x.ID).Select(a => a.Thumbnail).ToList()
                }).ToList()
            };

            return View(objekat);
        }
    }
}
