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
using PagedList;
using PagedList.Mvc;
using cloudscribe.Pagination.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using eKorpa.SignalR;
using System.Net.Mail;
using System.Net;

namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ArtikalController : Controller
    {
        ApplicationDbContext _database = new ApplicationDbContext();
        IHubContext<MyHub> _hubContext;

        private readonly IWebHostEnvironment _hostEnvironment;

        public ArtikalController(IWebHostEnvironment hostEnvironment, IHubContext<MyHub> hubContext)
        {
            this._hostEnvironment = hostEnvironment;
            _hubContext = hubContext;
        }

        public IActionResult IndexKateg(string Kategorija, int pageNumber = 1, int pageSize = 8)
        {
            ArtikalIndexVM objekat = new ArtikalIndexVM();
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int total = 0;

            switch (Kategorija)
            {
                case "Žene":
                    var model = _database.Artikal.Where(x => x.Kategorija.NazivKategorije == "Žene" && x.Izbrisan == false).Select(a => new ArtikalIndexVM.Row
                    {
                        ID = a.ID,
                        NazivArtikla = a.Naziv,
                        Kategorija = a.Kategorija.NazivKategorije,
                        ProdavacId = a.ProdavacID,
                        ImeProdavaca = _database.Users.Where(y=> y.Id==a.ProdavacID).Select(x=>x.Ime+" "+x.Prezime).SingleOrDefault(),
                        CijenaSaPopustom = a.CijenaSaPopustom,
                        Cijena = a.Cijena,
                        Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                        Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                        Brend = a.Brend.Naziv
                    }).Skip(excludeRecords).Take(pageSize);

                    total = _database.Artikal.Where(x => x.Kategorija.NazivKategorije == "Žene" && x.Izbrisan == false).Count();
                    objekat.rows = model.AsNoTracking().ToList();

                    break;

                case "Muškarci":

                    model = _database.Artikal.Where(x => x.Kategorija.NazivKategorije == "Muškarci" && x.Izbrisan == false).Select(a => new ArtikalIndexVM.Row
                    {
                        ID = a.ID,
                        NazivArtikla = a.Naziv,
                        Kategorija = a.Kategorija.NazivKategorije,
                        ProdavacId = a.ProdavacID,
                        ImeProdavaca = _database.Users.Where(y=> y.Id==a.ProdavacID).Select(x=>x.Ime+" "+x.Prezime).SingleOrDefault(),
                        CijenaSaPopustom = a.CijenaSaPopustom,
                        Cijena = a.Cijena,
                        Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                        Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                        Brend = a.Brend.Naziv
                    }).Skip(excludeRecords).Take(pageSize);

                    total = _database.Artikal.Where(x => x.Kategorija.NazivKategorije == "Muškarci" && x.Izbrisan == false).Count();
                    objekat.rows = model.AsNoTracking().ToList();

                    break;

                case "Djeca":

                    model = _database.Artikal.Where(x => x.Izbrisan == false && (x.Kategorija.NazivKategorije == "Dječaci" || x.Kategorija.NazivKategorije == "Djevojčice" || x.Kategorija.NazivKategorije == "Bebe")).Select(a => new ArtikalIndexVM.Row
                    {
                        ID = a.ID,
                        NazivArtikla = a.Naziv,
                        Kategorija = a.Kategorija.NazivKategorije,
                        ProdavacId = a.ProdavacID,
                        ImeProdavaca = _database.Users.Where(y => y.Id == a.ProdavacID).Select(x => x.Ime + " " + x.Prezime).SingleOrDefault(),
                        CijenaSaPopustom = a.CijenaSaPopustom,
                        Cijena = a.Cijena,
                        Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                        Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                        Brend = a.Brend.Naziv
                    }).Skip(excludeRecords).Take(pageSize);

                    total = _database.Artikal.Where(x => x.Izbrisan == false && (x.Kategorija.NazivKategorije == "Dječaci" || x.Kategorija.NazivKategorije == "Djevojčice" || x.Kategorija.NazivKategorije == "Bebe")).Count();
                    objekat.rows = model.AsNoTracking().ToList();

                    break;

                case "Ostalo":

                    model = _database.Artikal.Where(x => x.Kategorija.NazivKategorije == "Ostalo" && x.Izbrisan == false).Select(a => new ArtikalIndexVM.Row
                    {
                        ID = a.ID,
                        NazivArtikla = a.Naziv,
                        Kategorija = a.Kategorija.NazivKategorije,
                        ProdavacId = a.ProdavacID,
                        ImeProdavaca = _database.Users.Where(y=> y.Id==a.ProdavacID).Select(x=>x.Ime+" "+x.Prezime).SingleOrDefault(),
                        CijenaSaPopustom = a.CijenaSaPopustom,
                        Cijena = a.Cijena,
                        Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                        Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                        Brend = a.Brend.Naziv
                    }).Skip(excludeRecords).Take(pageSize);

                    total = _database.Artikal.Where(x => x.Kategorija.NazivKategorije == "Ostalo" && x.Izbrisan == false).Count();
                    objekat.rows = model.AsNoTracking().ToList();



                    break;
            }

            LoadEverythingElse(objekat);

            int brojac = 0;
            if ((float)(total / 8.0) - (int)(total / 8) > 0)
            {
                brojac = (total / 8) + 1;
            }
            else
            {
                brojac = (total / 8);
            }

            var result = new PagedResult<ArtikalIndexVM.Row>
            {
                Data = objekat.rows,
                TotalItems = brojac,
                PageNumber = pageNumber,
                PageSize = pageSize
            };


            ViewData["result"] = result;
            ViewData["type"] = "IndexKateg";

            return View("Index", objekat);
        }


        public IActionResult Index(int pageNumber = 1, int pageSize = 8, string querry = null)
        {

            ArtikalIndexVM objekat = new ArtikalIndexVM();
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            int total = 0;
            if (querry == null)
            {
                var model = _database.Artikal.Where(x => x.Izbrisan == false).Select(a => new ArtikalIndexVM.Row
                {
                    ID = a.ID,
                    NazivArtikla = a.Naziv,
                    Kategorija = a.Kategorija.NazivKategorije,
                    ProdavacId = a.ProdavacID,
                    ImeProdavaca = _database.Users.Where(y=> y.Id==a.ProdavacID).Select(x=>x.Ime+" "+x.Prezime).SingleOrDefault(),
                    CijenaSaPopustom = a.CijenaSaPopustom,
                    Cijena = a.Cijena,
                    Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                    Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                    Brend = a.Brend.Naziv
                }).Skip(excludeRecords).Take(pageSize);

                total = _database.Artikal.Count();
                objekat.rows = model.AsNoTracking().ToList();

            }
            else
            {
                var model = _database.Artikal.Where(x => x.Izbrisan == false && (x.Naziv.ToLower().Contains(querry.ToLower()) || x.Kategorija.NazivKategorije.ToLower().Contains(querry.ToLower()))).Select(a => new ArtikalIndexVM.Row
                {
                    ID = a.ID,
                    NazivArtikla = a.Naziv,
                    Kategorija = a.Kategorija.NazivKategorije,
                    ProdavacId = a.ProdavacID,
                    ImeProdavaca = _database.Users.Where(y => y.Id == a.ProdavacID).Select(x => x.Ime + " " + x.Prezime).SingleOrDefault(),
                    CijenaSaPopustom = a.CijenaSaPopustom,
                    Cijena = a.Cijena,
                    Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                    Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                    Brend = a.Brend.Naziv
                }).Skip(excludeRecords).Take(pageSize);

                total = _database.Artikal.Where(x => x.Izbrisan == false && (x.Naziv.ToLower().Contains(querry.ToLower()) || x.Kategorija.NazivKategorije.ToLower().Contains(querry.ToLower()))).Count();
                objekat.rows = model.AsNoTracking().ToList();
            }

            LoadEverythingElse(objekat);


            int brojac = 0;
            if ((float)(total / 8.0) - (int)(total / 8) > 0)
            {
                brojac = (total / 8) + 1;
            }
            else
            {
                brojac = (total / 8);
            }

            var result = new PagedResult<ArtikalIndexVM.Row>
            {
                Data = objekat.rows,
                TotalItems = brojac,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            ViewData["type"] = "Index";
            ViewData["result"] = result;


            return View(objekat);
        }

        //prikaz profila
        public IActionResult IndexW(string ProfilID)
        {
            ArtikalIndexVM objekat = new ArtikalIndexVM
            {
                rows = _database.Artikal.Where(x => x.Izbrisan == false && x.ProdavacID == ProfilID).Select(a => new ArtikalIndexVM.Row
                {
                    ID = a.ID,
                    NazivArtikla = a.Naziv,
                    Kategorija = a.Kategorija.NazivKategorije,
                    ProdavacId = a.ProdavacID,
                    ImeProdavaca = _database.Users.Where(y => y.Id == a.ProdavacID).Select(x => x.Ime + " " + x.Prezime).SingleOrDefault(),
                    Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.SlikaFile).ToList(),
                    CijenaSaPopustom = a.CijenaSaPopustom,
                    Cijena = a.Cijena,
                    Thumbnail = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x => x.Thumbnail).ToList(),
                    Brend = a.Brend.Naziv
                }).ToList()
            };
            objekat.Layout = false;

            foreach (var item in objekat.rows)
            {
                foreach (var temp in _database.ListaZelja)
                {
                    if (item.ID == temp.ArtikalID)
                        item.jestUListi = true;
                }
            }

            return View("Index", objekat);
        }

        public IActionResult IndexFilter(int KategorijaID = 0, int PotkategorijaID = 0, int BrendID = 0, int BojaID = 0, int MaterijalID = 0, int VelicinaID = 0, int MaxCijena = 0, int MinCijena = 0, int pageNumber = 1, int pageSize = 8)
        {
            var artikli = _database.Artikal.Where(x => x.Izbrisan == false).ToList();
            int total = 0;

            if (KategorijaID != 0)
            {
                foreach (var item in artikli.ToList())
                {
                    if (item.KategorijaID != KategorijaID)
                        artikli.Remove(item);
                }
            }

            if (PotkategorijaID != 0)
            {
                foreach (var item in artikli.ToList())
                {
                    if (item.PotkategorijaID != PotkategorijaID)
                        artikli.Remove(item);
                }
            }

            if (BrendID != 0)
            {
                foreach (var item in artikli.ToList())
                {
                    if (item.BrendID != BrendID)
                        artikli.Remove(item);
                }
            }

            if (BojaID != 0)
            {
                foreach (var item in artikli.ToList())
                {
                    if (item.BojaID != BojaID)
                        artikli.Remove(item);
                }
            }

            if (MaterijalID != 0)
            {
                foreach (var item in artikli.ToList())
                {
                    if (item.MaterijalID != MaterijalID)
                        artikli.Remove(item);
                }
            }

            if (VelicinaID != 0)
            {
                foreach (var item in artikli.ToList())
                {
                    if (item.VelicinaID != VelicinaID)
                        artikli.Remove(item);
                }
            }

            if (MaxCijena != 0 || MinCijena != 0)
            {
                foreach (var item in artikli.ToList())
                {
                    if (MaxCijena != 0)
                    {
                        if (item.Cijena > MaxCijena)
                            artikli.Remove(item);
                    }

                    if (item.Cijena < MinCijena)
                        artikli.Remove(item);

                }
            }

            int excludeRecords = (pageSize * pageNumber) - pageSize;

            var model = artikli.Select(x => new ArtikalIndexVM.Row
            {
                ID = x.ID,
                NazivArtikla = x.Naziv,
                Kategorija = _database.Kategorija.Where(y => y.ID == x.KategorijaID).Select(y => y.NazivKategorije).SingleOrDefault(),
                ProdavacId = x.ProdavacID,
                ImeProdavaca = _database.Users.Where(y => y.Id == x.ProdavacID).Select(x => x.Ime + " " + x.Prezime).SingleOrDefault(),
                CijenaSaPopustom = x.CijenaSaPopustom,
                Cijena = x.Cijena,
                Slika = _database.Slika.Where(y => y.ArtikalID == x.ID).Select(y => y.SlikaFile).ToList(),
                Thumbnail = _database.Slika.Where(y => y.ArtikalID == x.ID).Select(y => y.Thumbnail).ToList(),
                Brend = _database.Brend.Where(y => y.ID == x.BrendID).Select(y => y.Naziv).SingleOrDefault()
            }).Skip(excludeRecords).Take(pageSize);

            var filter = new ArtikalIndexVM();

            filter.KategorijaID = KategorijaID;
            filter.PotkategorijaID = PotkategorijaID;
            filter.BrendID = BrendID;
            filter.BojaID = BojaID;
            filter.MaterijalID = MaterijalID;
            filter.VelicinaID = VelicinaID;
            filter.MaxCijena = MaxCijena;
            filter.MinCijena = MinCijena;


            filter.rows = model.ToList();
            LoadEverythingElse(filter);

            total = artikli.Count();
            int brojac = 0;
            if ((float)(total / 8.0) - (int)(total / 8) > 0)
            {
                brojac = (total / 8) + 1;
            }
            else
            {
                brojac = (total / 8);
            }

            var result = new PagedResult<ArtikalIndexVM.Row>
            {
                Data = filter.rows,
                TotalItems = brojac,
                PageNumber = pageNumber,
                PageSize = pageSize
            };


            ViewData["result"] = result;
            ViewData["type"] = "IndexFilter";


            return View("Index", filter);
        }

        //[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,KorisnickaSluzba,Kupac/Prodavac")]
        public IActionResult Dodaj(int ArtikalID)
        {
            ArtikalDodajVM noviArtikal;

            if (ArtikalID == 0)
            {
                noviArtikal = new ArtikalDodajVM();
            }
            else
            {
                noviArtikal = _database.Artikal.Where(y => y.ID == ArtikalID)
                    .Select(y => new ArtikalDodajVM
                    {
                        ID = y.ID,
                        KategorijaID = y.KategorijaID,
                        PotkategorijaID = y.PotkategorijaID,
                        NazivArtikla = y.Naziv,
                        ProdavacId = y.ProdavacID,
                        ImeProdavaca = _database.Users.Where(x => x.Id == y.ProdavacID).Select(x => x.Ime + " " + x.Prezime).SingleOrDefault(),
                        Cijena = y.Cijena,
                        Slike = _database.Slika.Where(x => x.ArtikalID == y.ID).Select(x => x.SlikaFile).ToList(),
                        SlikaID = _database.Slika.Where(y => y.ArtikalID == ArtikalID).Select(x => x.ID).ToList(),
                        Thumbnail = _database.Slika.Where(x => x.ArtikalID == y.ID).Select(x => x.Thumbnail).ToList(),
                        BrojUSkladistu = y.BrojUSkladistu,
                        VelicinaID = (int)y.VelicinaID
                    }).SingleOrDefault();
            }

            noviArtikal.Kategorije = _database.Kategorija.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.NazivKategorije }).ToList();
            noviArtikal.Brend = _database.Brend.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Naziv }).ToList();
            noviArtikal.Boja = _database.Boja.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Naziv }).ToList();
            noviArtikal.Materijal = _database.Materijal.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Naziv }).ToList();
            //noviArtikal.Velicina = _database.Velicina.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.VelicinaOznaka }).ToList();

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

        public JsonResult UpdateVelicine(int PotkategorijaID)
        {
            List<Velicina> velicine = _database.Potkategorija.Where(x => x.ID == PotkategorijaID).Select(x => x.Velicina).FirstOrDefault();

            if (velicine.Count == 0)
            {
                velicine = _database.Potkategorija.Where(x => x.ID == 51).Select(x => x.Velicina).FirstOrDefault();
            }

            List<SelectListItem> novi = velicine.Select(a => new SelectListItem
            {
                Text = a.VelicinaOznaka,
                Value = a.ID.ToString()
            }).ToList();
            return Json(novi);
        }

        public IActionResult Detalji(int ArtikalID)
        {

            ArtikalDetaljiVM noviArtikal = _database.Artikal
                .Where(x => x.ID == ArtikalID && x.Izbrisan == false)
                .Select(x => new ArtikalDetaljiVM
                {
                    ID = x.ID,
                    NazivArtikla = x.Naziv,
                    Prodavac = x.ProdavacID,
                    Kategorija = x.Kategorija.NazivKategorije,
                    Cijena = x.Cijena,
                    CijenaSaPopustom = x.CijenaSaPopustom,
                    Slike = _database.Slika.Where(y => y.ArtikalID == ArtikalID).Select(x => x.SlikaFile).ToList(),
                    SlikaID = _database.Slika.Where(y => y.ArtikalID == ArtikalID).Select(x => x.ID).ToList(),
                    Thumbnail = _database.Slika.Where(y => y.ArtikalID == x.ID).Select(x => x.Thumbnail).ToList(),
                    Brend = x.Brend.Naziv,
                    BrojUSkladistu = x.BrojUSkladistu,
                    Boja=x.Boja.Naziv,
                    Materijal=x.Materijal.Naziv,
                    Potkategorija=x.Potkategorija.Naziv,
                    Velicina=x.Velicina.VelicinaOznaka
                }).Single();

            return View(noviArtikal);
        }


        [Authorize(Roles = "Admin,KorisnickaSluzba,Kupac/Prodavac")]
        public IActionResult Snimi(ArtikalDodajVM noviArtikal)
        {
            Artikal artikal;
            if (noviArtikal.ID == 0)
            {
                artikal = new Artikal();
                _database.Artikal.Add(artikal);
                artikal.ProdavacID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                artikal.ImeProdavaca = _database.Users.Find(artikal.ProdavacID).Ime + " " + _database.Users.Find(artikal.ProdavacID).Prezime;
                artikal.DatumObjave = DateTime.Now;
                TempData["PorukaInfo"] = "Uspješno ste dodali artikl " + artikal.Naziv;
            }
            else
            {
                artikal = _database.Artikal.Find(noviArtikal.ID);
                TempData["PorukaInfo"] = "Uspješno ste updateovali artikl " + noviArtikal.NazivArtikla;
            }
            artikal.Naziv = noviArtikal.NazivArtikla;
            artikal.KategorijaID = noviArtikal.KategorijaID;
            artikal.PotkategorijaID = noviArtikal.PotkategorijaID;
            artikal.Cijena = noviArtikal.Cijena;
            artikal.CijenaSaPopustom = noviArtikal.Cijena;
            artikal.BrendID = noviArtikal.BrendID;
            artikal.BrojUSkladistu = noviArtikal.BrojUSkladistu;
            artikal.BojaID = noviArtikal.BojaID;
            artikal.MaterijalID = noviArtikal.MaterijalID;
            artikal.VelicinaID = noviArtikal.VelicinaID;
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

        [Authorize(Roles = "Admin,KorisnickaSluzba,Kupac/Prodavac")]
        public IActionResult Obrisi(int ArtikalID)
        {
            Artikal artikal = _database.Artikal.Find(ArtikalID);
            artikal.Izbrisan = true;
            _database.SaveChanges();
            TempData["PorukaWarning"] = "Uspješno ste obrisali artikl " + artikal.Naziv;
            //List<Slika> slikeArtikla = _database.Slika.Where(x => x.ArtikalID == ArtikalID).ToList();
            //foreach (var item in slikeArtikla)
            //{
            //    _database.Remove(item);
            //}
            return Redirect("/Artikal/");
        }

        [Authorize(Roles = "Admin,KorisnickaSluzba,Kupac/Prodavac")]
        public IActionResult ObrisiSliku(int SlikaID, int ArtikalID)
        {
            var slika = _database.Slika.Find(SlikaID);
            _database.Slika.Remove(slika);
            _database.SaveChanges();
            return Redirect("/Artikal/Dodaj?ArtikalID=" + ArtikalID);
        }


        [Authorize(Roles = "Admin,KorisnickaSluzba,Kupac/Prodavac")]
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


        [Authorize(Roles = "Admin,KorisnickaSluzba,Kupac/Prodavac")]
        [HttpGet]
        public string Kupi()
        {
            var kupacID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var korisnik = _database.Users.Where(x => x.Id == kupacID).SingleOrDefault();


            var adresa = _database.Adresa.Where(x => x.ID == korisnik.AdresaID).SingleOrDefault();

            if (adresa.ID == 0 || adresa.MjestoStanovanja==null || adresa.MjestoStanovanja.Length < 5 || adresa.OpcinaID==0 || adresa.PostanskiBroj < 10000 || adresa.PostanskiBroj > 99999 || korisnik.Ime == null || korisnik.Prezime == null)
            {
                //implementirati poruku neuspjeha
                return "address404";
            }

            List<Korpa> stavkeUKorpi = _database.Korpa.Where(x => x.KupacID == kupacID).ToList();

                        foreach (var item in stavkeUKorpi)
            {
                //Slanje emaila prodavačima od kojih je korisnik kupio artikal.
                var poruka = new MailMessage();
                var artikal = _database.Artikal.Find(item.ArtikalID);
                var prodavac = _database.Users.Find(artikal.ProdavacID);
                var mail = prodavac.Email;
                poruka.To.Add(new MailAddress(mail.ToString()));
                poruka.From = new MailAddress("ekorpa.business@gmail.com");
                poruka.Subject = "Vaš artikal je upravo prodan!";
                poruka.Body += "Pozdrav " + " " + prodavac.Ime + ", </br> ";
                poruka.Body += "Uspješno ste prodali sljedeći artikal: </br> ";

                poruka.Body += "<ul>";
                poruka.Body += "<li>Naziv artikla : " + artikal.Naziv + "</li>";
                poruka.Body += "<li>Cijena artikla : " + artikal.Cijena + " KM </li> ";
                poruka.Body += "<li>Količina : " + item.kolicina + "</li> ";
                poruka.Body += "<li>Ukupna cijena : " + item.cijena + " KM </li>";
                poruka.Body += "<li>Naziv kupca : " + korisnik.Ime + " " + korisnik.Prezime + "</li>";
                var opcina = _database.Grad.Find(adresa.OpcinaID);
                poruka.Body += "<li>Adresa : " + adresa.MjestoStanovanja + " " + opcina.Naziv + " " + adresa.PostanskiBroj + "</li>";
                poruka.Body += "<li>Broj telefona : " + korisnik.PhoneNumber + "</li>";
                poruka.Body += "</ul>";

                poruka.Body += "<sub> Hvala Vam na korištenju eKorpe. Dužni ste da dostavite artikal kupcu u roku od 7 dana. " +
                    "</br>Ukoliko se to ne desi, biti ćete sankcionisani u skladu sa pravilima stranice. </br> Ukoliko zatrebate pomoć, molimo Vas da <a href='api.p2040.app.fit.ba/Kontakt/Index'>kontaktirate korisničku službu.</a></sub>";


                poruka.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "ekorpa.business@gmail.com",
                        Password = "Mostar2020!"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(poruka);
                }
            }


            //Slanje emaila kupcu u kojem pisu informacije o kupljenim artiklima
            var message = new MailMessage();
            var email = korisnik.Email;
            message.To.Add(new MailAddress(email.ToString()));
            message.From = new MailAddress("ekorpa.business@gmail.com");
            message.Subject = "Završetak kupovine";
            message.Body = "Uspješno ste kupili sljedeće artikle: </br> ";

            foreach (var item in stavkeUKorpi)
            {
                var artikal = _database.Artikal.Find(item.ArtikalID);
                var prodavac = _database.Users.Find(artikal.ProdavacID);
                message.Body += "<ul>";
                message.Body += "<li>Naziv artikla : " + artikal.Naziv + "</li>";
                message.Body += "<li>Cijena artikla : " + artikal.Cijena + " KM </li> ";
                message.Body += "<li>Količina : " + item.kolicina + "</li> ";
                message.Body += "<li>Ukupna cijena : " + item.cijena + " KM </li>";
                message.Body += "<li>Naziv prodavača : " + prodavac.Ime + " " + prodavac.Prezime + " KM </li>";
                message.Body += "<li>Broj telefona : " + prodavac.PhoneNumber + " </li>";
                message.Body += "</ul>";
            }

            message.Body += "<sub> Hvala Vam na kupovini. Prodavači su dužni da vam dostave artikle u roku od 7 dana. " +
                "</br>Ukoliko se to ne desi, molimo Vas da <a href='api.p2040.app.fit.ba/Kontakt/Index'>kontaktirate korisničku službu.</a></sub>";


            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "ekorpa.business@gmail.com",
                    Password = "Mostar2020!"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }

            List<Artikal> listaArtikalaUKorpi = new List<Artikal>();

            //smanjivanje kolicine u skladistu
            foreach (var item in stavkeUKorpi)
            {
                var artikal = _database.Artikal.Where(x => x.ID == item.ArtikalID && x.Izbrisan == false).SingleOrDefault();
                artikal.BrojUSkladistu -= item.kolicina;

                var prodavac = _database.Users.Where(x => x.Id == artikal.ProdavacID).SingleOrDefault();

                string poruka = "Upravo ste prodali artikal: " + artikal.Naziv;
                _hubContext.Clients.Group(prodavac.UserName).SendAsync("prijemPoruke", prodavac.Ime, poruka);
                //_hubContext.Clients.All.SendAsync("prijemPoruke", korisnik.Ime, poruka);

                _database.Korpa.Remove(item);
                //oznacavanje artikla kao zavrsenog(kupljen ili prodan)
                ZavrseniArtikal zavrseniArtikal = new ZavrseniArtikal
                {
                    ArtikalID = item.ArtikalID,
                    Datum = DateTime.Now,
                    Kolicina = item.kolicina,
                    KupacID = kupacID,
                    ProdavacID = artikal.ProdavacID,
                    SlikaID = _database.Slika.Where(x => x.ArtikalID == artikal.ID && x.Thumbnail == 1).Select(x => x.ID).SingleOrDefault()
                };
                _database.ZavrseniArtikal.Add(zavrseniArtikal);
                //kreiranje rejtinga
                var noviRejting = new Rejting();

                _database.Add(noviRejting);
                _database.SaveChanges();
                zavrseniArtikal.RejtingID = noviRejting.ID;
                _database.SaveChanges();
            }



            return "Ok";
        }

        private void LoadEverythingElse(ArtikalIndexVM objekat)
        {
            foreach (var item in objekat.rows)
            {
                foreach (var temp in _database.ListaZelja)
                {
                    if (item.ID == temp.ArtikalID)
                        item.jestUListi = true;
                }
            }
            objekat.Layout = true;
            objekat.Kategorije = _database.Kategorija.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.NazivKategorije }).ToList();
            objekat.Boja = _database.Boja.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.Naziv }).ToList();
            objekat.Materijal = _database.Materijal.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.Naziv }).ToList();
            objekat.Brend = _database.Brend.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.Naziv }).ToList();

            foreach (var item in objekat.rows)
            {
                foreach (var temp in _database.ListaZelja)
                {
                    if (item.ID == temp.ArtikalID)
                        item.jestUListi = true;
                }
            }

        }

    }
}
