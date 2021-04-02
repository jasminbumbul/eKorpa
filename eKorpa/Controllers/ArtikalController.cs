using eKorpa.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using eKorpa.ViewModels;
using eKorpa.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Data.EntityModels;
using System.Drawing;
using Data.Helper;
using Microsoft.AspNetCore.Identity;

namespace eKorpa.Controllers
{
    //[Authorize(Roles = "Admin, Kupac, Prodavac")]
    public class ArtikalController : Controller
    {
        ApplicationDbContext _database = new ApplicationDbContext();

        private readonly IWebHostEnvironment _hostEnvironment;


        public ArtikalController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }

        public IActionResult IndexKateg(string Kategorija)
        {
            ArtikalIndexVM objekat = null;
            switch (Kategorija)
            {
                case "Žene":
                    objekat = new ArtikalIndexVM
                    {
                        rows = _database.Artikal.Where(x => x.Kategorija.NazivKategorije == "Žene").Select(a => new ArtikalIndexVM.Row
                        {
                            ID = a.ID,
                            NazivArtikla = a.Naziv,
                            Kategorija = a.Kategorija.NazivKategorije,
                            ProdavacId = a.ProdavacID,
                            ImeProdavaca = a.ImeProdavaca,
                            Cijena = a.Cijena,
                            CijenaSaPopustom=a.CijenaSaPopustom,
                            Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                            Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                            Brend=a.Brend.Naziv
                        }).ToList()
                    };
                    break;

                case "Muškarci":
                    objekat = new ArtikalIndexVM
                    {
                        rows = _database.Artikal.Where(x => x.Kategorija.NazivKategorije == "Muškarci").Select(a => new ArtikalIndexVM.Row
                        {
                            ID = a.ID,
                            NazivArtikla = a.Naziv,
                            Kategorija = a.Kategorija.NazivKategorije,
                            ProdavacId = a.ProdavacID,
                            ImeProdavaca = a.ImeProdavaca,
                            Cijena = a.Cijena,
                            CijenaSaPopustom = a.CijenaSaPopustom,
                            Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                            Brend = a.Brend.Naziv,
                            Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList()
                        }).ToList()
                    };
                    break;

                case "Djeca":
                    objekat = new ArtikalIndexVM
                    {
                        rows = _database.Artikal.Where(x => x.Kategorija.NazivKategorije == "Dječaci" || x.Kategorija.NazivKategorije == "Djevojčice" || x.Kategorija.NazivKategorije == "Bebe").Select(a => new ArtikalIndexVM.Row
                        {
                            ID = a.ID,
                            NazivArtikla = a.Naziv,
                            Kategorija = a.Kategorija.NazivKategorije,
                            ProdavacId = a.ProdavacID,
                            ImeProdavaca = a.ImeProdavaca,
                            CijenaSaPopustom=a.CijenaSaPopustom,
                            Cijena = a.Cijena,
                            Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                            Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                            Brend = a.Brend.Naziv
                        }).ToList()
                    };
                    break;
            }
            foreach (var item in objekat.rows)
            {
                foreach (var temp in _database.ListaZelja)
                {
                    if (item.ID == temp.ArtikalID)
                        item.jestUListi = true;
                }
            }
            objekat.Layout = true;
            return View("Index",objekat);
        }
        public IActionResult Index(string querry = null)
        {
            ArtikalIndexVM objekat;
            if (querry == null)
            {
                objekat = new ArtikalIndexVM
                {
                    rows = _database.Artikal.Select(a => new ArtikalIndexVM.Row
                    {
                        ID = a.ID,
                        NazivArtikla = a.Naziv,
                        Kategorija = a.Kategorija.NazivKategorije,
                        ProdavacId = a.ProdavacID,
                        ImeProdavaca = a.ImeProdavaca,
                        Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                            CijenaSaPopustom=a.CijenaSaPopustom,
                        Cijena = a.Cijena,
                        Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                        Brend = a.Brend.Naziv
                    }).ToList()
                };
            }
            else
            {
                objekat = new ArtikalIndexVM
                {
                    rows = _database.Artikal.Where(x => x.Naziv.ToLower().Contains(querry.ToLower()) || x.Kategorija.NazivKategorije.ToLower().Contains(querry.ToLower())).Select(a => new ArtikalIndexVM.Row
                    {
                        ID = a.ID,
                        NazivArtikla = a.Naziv,
                        Kategorija = a.Kategorija.NazivKategorije,
                        ProdavacId = a.ProdavacID,
                        ImeProdavaca = a.ImeProdavaca,
                        CijenaSaPopustom=a.CijenaSaPopustom,
                        Cijena = a.Cijena,
                        Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                        Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                        Brend = a.Brend.Naziv
                    }).ToList()
                };
            }
            foreach (var item in objekat.rows)
            {
                foreach (var temp in _database.ListaZelja)
                {
                    if (item.ID == temp.ArtikalID)
                        item.jestUListi = true;
                }
            }
            objekat.Layout = true;
            return View(objekat);
        }

        public IActionResult IndexW(string ProfilID)
        {
            ArtikalIndexVM objekat = new ArtikalIndexVM
            {
                rows = _database.Artikal.Where(x => x.ProdavacID == ProfilID).Select(a => new ArtikalIndexVM.Row
                {
                    ID = a.ID,
                    NazivArtikla = a.Naziv,
                    Kategorija = a.Kategorija.NazivKategorije,
                    ProdavacId = a.ProdavacID,
                    ImeProdavaca = a.ImeProdavaca,
                    Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                            CijenaSaPopustom=a.CijenaSaPopustom,
                    Cijena = a.Cijena,
                    Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                    Brend = a.Brend.Naziv
                }).ToList()
            };
            objekat.Layout = false;
            return View("Index", objekat);
        }
        public IActionResult Dodaj(int ArtikalID)
        {
            ArtikalDodajVM noviArtikal = ArtikalID == 0
                ? new ArtikalDodajVM()
                {
                    Kategorije = _database.Kategorija.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.NazivKategorije }).ToList(),
                    Brend=_database.Brend.Select(x=> new SelectListItem { Value=x.ID.ToString(),Text=x.Naziv}).ToList()
                }
                : _database.Artikal
                    .Where(y => y.ID == ArtikalID)
                    .Select(y => new ArtikalDodajVM
                    {
                        ID = y.ID,
                        KategorijaID = y.KategorijaID,
                        NazivArtikla = y.Naziv,
                        ProdavacId = y.ProdavacID,
                        ImeProdavaca = y.ImeProdavaca,
                        Cijena = y.Cijena,
                        Kategorije = _database.Kategorija.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.NazivKategorije }).ToList(),
                        Brend = _database.Brend.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Naziv }).ToList(),
                        Slike = _database.Slika.Where(x => x.ArtikalID == y.ID).Select(x => x.SlikaFile).ToList(),
                        SlikaID = _database.Slika.Where(y => y.ArtikalID == ArtikalID).Select(x => x.ID).ToList()
                    }).Single();

            return View(noviArtikal);
        }

        public JsonResult UpdatePotkategorije(int KategorijaID)
        {
            List<Potkategorija> potkategorije = _database.Kategorija.Where(x => x.ID == KategorijaID).Select(x => x.Potkategorija).FirstOrDefault();

            List<SelectListItem> novi = potkategorije.Select(a => new SelectListItem
            {
                Text = a.Naziv,
                Value = a.ID.ToString()
            }).ToList();
            return Json(novi);
        }

        public IActionResult Detalji(int ArtikalID)
        {

            ArtikalDetaljiVM noviArtikal = _database.Artikal
                .Where(x => x.ID == ArtikalID)
                .Select(x => new ArtikalDetaljiVM
                {
                    ID = x.ID,
                    NazivArtikla = x.Naziv,
                    Prodavac = x.ProdavacID,
                    Kategorija = x.Kategorija.NazivKategorije,
                    Cijena = x.Cijena,
                    CijenaSaPopustom=x.CijenaSaPopustom,
                    Slike = _database.Slika.Where(y => y.ArtikalID == ArtikalID).Select(x => x.SlikaFile).ToList(),
                    SlikaID = _database.Slika.Where(y => y.ArtikalID == ArtikalID).Select(x => x.ID).ToList(),
                    Thumbnail = _database.Slika.Where(y => y.ArtikalID == x.ID).Select(x => x.Thumbnail).ToList(),
                    Brend=x.Brend.Naziv,
                    BrojUSkladistu=x.BrojUSkladistu
                }).Single();

            return View(noviArtikal);
        }



        public async Task<IActionResult> Snimi(ArtikalDodajVM noviArtikal)
        {
            Artikal artikal;
            if (noviArtikal.ID == 0)
            {
                artikal = new Artikal();
                _database.Artikal.Add(artikal);
                artikal.ProdavacID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                artikal.ImeProdavaca = _database.Users.Find(artikal.ProdavacID).Ime + " " + _database.Users.Find(artikal.ProdavacID).Prezime;
            }
            else
            {
                artikal = _database.Artikal.Find(noviArtikal.ID);
            }
            artikal.Naziv = noviArtikal.NazivArtikla;
            artikal.KategorijaID = noviArtikal.KategorijaID;
            artikal.PotkategorijaID = noviArtikal.PotkategorijaID;
            artikal.Cijena = noviArtikal.Cijena;
            artikal.CijenaSaPopustom = noviArtikal.Cijena;
            artikal.BrendID = noviArtikal.BrendID;
            artikal.BrojUSkladistu = noviArtikal.BrojUSkladistu;
            _database.SaveChanges();
            Artikal artikl = _database.Artikal.Find(artikal.ID);
            int brojacProlaza = 0;
            if (noviArtikal.Slika != null)
            {
                foreach (var slika in noviArtikal.Slika)
                {
                    string uniqueFileName = UploadedFile(noviArtikal);
                    if (slika != null)
                    {
                        //Convert Image to byte and save to database
                        if (slika.Length > 0)
                        {
                            byte[] p1 = null;
                            using (var fs1 = slika.OpenReadStream())
                            using (var ms1 = new MemoryStream())
                            {
                                Slika newImage;
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                                foreach (var item in _database.Slika)
                                {
                                    if (item.ArtikalID == artikl.ID)
                                    {
                                        if (item.Thumbnail == 1)
                                        {
                                            brojacProlaza++;
                                        }
                                    }
                                }
                                if (brojacProlaza == 0)
                                {
                                    newImage = new Slika() { ArtikalID = artikl.ID, SlikaFile = p1, Thumbnail = 1 };
                                    brojacProlaza++;
                                }
                                else
                                {
                                    newImage = new Slika() { ArtikalID = artikl.ID, SlikaFile = p1 };
                                }
                                _database.Slika.Add(newImage);
                            }
                        }
                    }
                }
            }
            _database.SaveChanges();
            return Redirect("/Artikal/");
        }

        private string UploadedFile(ArtikalDodajVM model)
        {
            string uniqueFileName = null;
            foreach (var item in model.Slika)
            {
                if (item != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + item.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(fileStream);
                    }
                }
            }
            return uniqueFileName;
        }
        public IActionResult Obrisi(int ArtikalID)
        {
            Artikal artikal = _database.Artikal.Find(ArtikalID);
            _database.Remove(artikal);
            List<Slika> slikeArtikla = _database.Slika.Where(x => x.ArtikalID == ArtikalID).ToList();
            foreach (var item in slikeArtikla)
            {
                _database.Remove(item);
            }
            _database.SaveChanges();
            return Redirect("/Artikal/");
        }

        public IActionResult ObrisiSliku(int SlikaID, int ArtikalID)
        {
            var slika = _database.Slika.Find(SlikaID);
            _database.Slika.Remove(slika);
            _database.SaveChanges();
            return Redirect("/Artikal/Dodaj?ArtikalID=" + ArtikalID);
        }

        public IActionResult SetThumbnail(int SlikaID, int ArtikalID)
        {
            var slikeArtikla = _database.Slika.Where(x => x.ArtikalID == ArtikalID);
            foreach (var item in slikeArtikla)
            {
                item.Thumbnail = 0;
            }
            var slika = _database.Slika.Where(x => x.ID == SlikaID).Single();
            slika.Thumbnail = 1;
            _database.SaveChanges();
            return Redirect("/Artikal/Dodaj?ArtikalID=" + ArtikalID);
        }

        public string Kupi()
        {
            var kupacID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var korisnik = _database.Users.Where(x => x.Id == kupacID).SingleOrDefault();

            if(korisnik.Adresa==null || korisnik.Adresa.Count()<5)
            {
                //implementirati poruku neuspjeha
                return "address404";
            }

            List<Korpa> stavkeUKorpi = _database.Korpa.Where(x => x.KupacID == kupacID).ToList();

            List<Artikal> listaArtikalaUKorpi = new List<Artikal>();

            //smanjivanje kolicine u skladistu
            foreach (var item in stavkeUKorpi)
            {
                _database.Artikal.Where(x => x.ID == item.ArtikalID).SingleOrDefault().BrojUSkladistu -= item.kolicina;
                _database.Korpa.Remove(item);
                _database.SaveChanges();
            }

            return "success";
        }
    }
}
