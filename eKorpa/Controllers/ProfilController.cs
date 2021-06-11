using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKorpa.Data;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Authorization;
using eKorpa.EntityModels;
using Data.EntityModels;
using System.Security.Claims;

namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
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
            }).SingleOrDefault();


            //int i = 0;
            //foreach (var item in _database.Artikal.ToList())
            //{
            //    profil.Slika[i] = _database.Slika.Where(x => x.ArtikalID == item.ID).Select(x => x.SlikaFile).SingleOrDefault();
            //    profil.Thumbnail[i] = _database.Slika.Where(x => x.ArtikalID == item.ID).Select(x => x.Thumbnail).SingleOrDefault();
            //    i++;
            //}


            return View(profil);
        }

        public IActionResult KupljeniArtikli(string KorisnikID)
        {
            var kupljeniArtikli = _database.ZavrseniArtikal.Where(x => x.KupacID == KorisnikID).ToList();

            var objekat = new ArtikalIndexVM
            {
                rows = kupljeniArtikli.Select(x => new ArtikalIndexVM.Row
                {
                    Brend = _database.Brend.Find(_database.Artikal.Find(x.ArtikalID).BrendID).Naziv,
                    Cijena = _database.Artikal.Find(x.Artikal.ID).Cijena,
                    CijenaSaPopustom = _database.Artikal.Find(x.Artikal.ID).CijenaSaPopustom,
                    ImeProdavaca = _database.Artikal.Find(x.Artikal.ID).ImeProdavaca,
                    Kategorija = _database.Kategorija.Find(x.Artikal.KategorijaID).NazivKategorije,
                    NazivArtikla = _database.Artikal.Find(x.Artikal.ID).Naziv,
                    Slika = _database.Slika.Where(a => a.ArtikalID == x.ID).Select(a => a.SlikaFile).ToList(),
                    Thumbnail = _database.Slika.Where(a => a.ArtikalID == x.ID).Select(a => a.Thumbnail).ToList(),
                    ProdavacId = x.ProdavacID,
                    RatingID = (int)x.RejtingID,
                    KupacOstavioDojam = _database.Rejting.Find(x.RejtingID).KupacOstavioDojam,
                    ProdavacOstavioDojam = _database.Rejting.Find(x.RejtingID).ProdavacOstavioDojam,
                    KupacID = x.KupacID
                }).ToList()
            };

            return View(objekat);
        }

        public IActionResult ProdaniArtikli(string KorisnikID)
        {
            var kupljeniArtikli = _database.ZavrseniArtikal.Where(x => x.ProdavacID == KorisnikID).ToList();

            var objekat = new ArtikalIndexVM
            {
                rows = kupljeniArtikli.Select(x => new ArtikalIndexVM.Row
                {
                    Brend = _database.Brend.Find(_database.Artikal.Find(x.ArtikalID).BrendID).Naziv,
                    Cijena = _database.Artikal.Find(x.Artikal.ID).Cijena,
                    CijenaSaPopustom = _database.Artikal.Find(x.Artikal.ID).CijenaSaPopustom,
                    ImeProdavaca = _database.Artikal.Find(x.Artikal.ID).ImeProdavaca,
                    Kategorija = _database.Kategorija.Find(x.Artikal.KategorijaID).NazivKategorije,
                    NazivArtikla = _database.Artikal.Find(x.Artikal.ID).Naziv,
                    Slika = _database.Slika.Where(a => a.ArtikalID == x.ID).Select(a => a.SlikaFile).ToList(),
                    Thumbnail = _database.Slika.Where(a => a.ArtikalID == x.ID).Select(a => a.Thumbnail).ToList(),
                    ProdavacId = x.ProdavacID,
                    RatingID = (int)x.RejtingID,
                    KupacOstavioDojam = _database.Rejting.Find(x.RejtingID).KupacOstavioDojam,
                    ProdavacOstavioDojam = _database.Rejting.Find(x.RejtingID).ProdavacOstavioDojam,
                    KupacID = x.KupacID
                }).ToList()
            };

            return View(objekat);
        }

        public IActionResult Dojmovi(string KorisnikID, string Tip = "a", bool Layout = true)
        {
            List<Rejting> dojmoviProdavaca = new List<Rejting>();
            List<Rejting> dojmoviKupaca = new List<Rejting>();
            switch (Tip)
            {
                case "a":
                    dojmoviProdavaca = _database.ZavrseniArtikal.Where(x => x.RejtingID != 0 && x.KupacID == KorisnikID).Select(x => x.Rejting).ToList();
                    dojmoviKupaca = _database.ZavrseniArtikal.Where(x => x.RejtingID != 0 && x.ProdavacID == KorisnikID).Select(x => x.Rejting).ToList();
                    break;
                case "k":
                    dojmoviKupaca = _database.ZavrseniArtikal.Where(x => x.RejtingID != 0 && x.ProdavacID == KorisnikID).Select(x => x.Rejting).ToList();
                    break;
                case "p":
                    dojmoviProdavaca = _database.ZavrseniArtikal.Where(x => x.RejtingID != 0 && x.KupacID == KorisnikID).Select(x => x.Rejting).ToList();
                    break;
            }



            var objekat = new DojamIndexVM();

            var korisnik = _database.Users.Where(x => x.Id == KorisnikID).SingleOrDefault();

            objekat.KorisnikID = korisnik.Id;
            objekat.ImeKorisnika = korisnik.Ime;

            objekat.rows = new List<DojamIndexVM.Row>();

            if (dojmoviProdavaca.Count > 0)
            {
                foreach (var item in dojmoviProdavaca)
                {
                    objekat.rows.Add(new DojamIndexVM.Row
                    {
                        Datum = item.DatumProdavac,
                        Dojam = item.DojamProdavaca,
                        Ocjena = item.OcjenaProdavaca
                    });
                }
            }

            if (dojmoviKupaca.Count > 0)
            {
                foreach (var item in dojmoviKupaca)
                {

                    objekat.rows.Add(new DojamIndexVM.Row
                    {
                        Datum = item.DatumKupac,
                        Dojam = item.DojamKupca,
                        Ocjena = item.OcjenaKupca
                    });
                }
            }

            objekat.Layout = Layout;

            return View(objekat);
        }

        public bool Provjera(string KorisnikID=null)
        {
            if (KorisnikID==null)
            {
                //ako korisnik nije prijavljen, vrati true. To znaci da se oznaka obavijesti nece prikazati.
                return true;
            }

            //provjera validnosti imena, prezimena, datuma rodjenja, opcine, mjesta/ulice, postanskoj broja, te nedovršenih dojmova

            var korisnik = _database.Users.Find(KorisnikID);
            if(korisnik==null){
                return true;
            }
            var adresa = _database.Adresa.Find(korisnik.AdresaID);

            if (string.IsNullOrEmpty(korisnik.Ime)
                || string.IsNullOrEmpty(korisnik.Prezime)
                || string.IsNullOrEmpty(adresa.MjestoStanovanja) 
                || adresa.PostanskiBroj<10000 
                || adresa.PostanskiBroj>99999
                || korisnik.DatumRodjenja==null
                || adresa.OpcinaID==0)
            {
                return false;
            }
            else { return true; }
        }

        public string GetID()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public bool ProvjeraDojamKupac(string KorisnikID=null)
        {
            var korisnik = _database.Users.Find(KorisnikID);
            if (korisnik==null)
            {
                return true;
            }
            var kupljeniArtikliRejtingID = _database.ZavrseniArtikal.Where(x => x.KupacID == korisnik.Id).Select(x=> x.RejtingID).ToList();

            var listaRejtinga = new List<Rejting>();

            foreach (var item in kupljeniArtikliRejtingID)
            {
                listaRejtinga.Add(_database.Rejting.Find(item));
            }

            foreach (var item in listaRejtinga)
            {
                if (item.KupacOstavioDojam == false)
                {
                    return false;
                }
            }

            return true;
        } 
        public bool ProvjeraDojamProdavac(string KorisnikID=null)
        {
            var korisnik = _database.Users.Find(KorisnikID);
            if (korisnik == null)
            {
                return true;
            }
            var ProdaniArtikliRejtingID = _database.ZavrseniArtikal.Where(x => x.ProdavacID == korisnik.Id).Select(x=> x.RejtingID).ToList();

            var listaRejtinga = new List<Rejting>();

            foreach (var item in ProdaniArtikliRejtingID)
            {
                listaRejtinga.Add(_database.Rejting.Find(item));
            }

            foreach (var item in listaRejtinga)
            {
                if (item.ProdavacOstavioDojam == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
