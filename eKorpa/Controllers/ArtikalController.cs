﻿using eKorpa.Data;
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

        public IActionResult Index(string querry= null)
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
                        Slika = _database.Slika.Where(x => x.ArtikalID == a.ID).Select(x=> x.SlikaFile).ToList()
                    }).ToList()
                };
            }
            else
            {
                objekat = new ArtikalIndexVM
                {
                    rows = _database.Artikal.Where(x=> x.Naziv.ToLower().Contains(querry.ToLower()) || x.Kategorija.NazivKategorije.ToLower().Contains(querry.ToLower())).Select(a => new ArtikalIndexVM.Row
                    {
                        ID = a.ID,
                        NazivArtikla = a.Naziv,
                        Kategorija = a.Kategorija.NazivKategorije,
                        ProdavacId = a.ProdavacID,
                        ImeProdavaca = a.ImeProdavaca
                    }).ToList()
                };
            }


            return View(objekat);
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
                    Kategorija=x.Kategorija.NazivKategorije,
                    //Kategorije = _database.Kategorija.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.NazivKategorije }).ToList()
                    }).Single();

            return View(noviArtikal);
        }

        public IActionResult Dodaj(int ArtikalID)
        {
            ArtikalDodajVM noviArtikal = ArtikalID == 0
                ? new ArtikalDodajVM()
                {
                    Kategorije = _database.Kategorija.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.NazivKategorije }).ToList()
                }
                : _database.Artikal
                    .Where(x => x.ID == ArtikalID)
                    .Select(x => new ArtikalDodajVM
                    {
                        ID = x.ID,
                        KategorijaID = x.KategorijaID,
                        NazivArtikla = x.Naziv,
                        ProdavacId = x.ProdavacID,
                        ImeProdavaca= x.ImeProdavaca,
                        Kategorije = _database.Kategorija.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.NazivKategorije }).ToList() //optimizacija???
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
            }
            else
            {
                artikal = _database.Artikal.Find(noviArtikal.ID);
            }
            artikal.Naziv = noviArtikal.NazivArtikla;
            artikal.KategorijaID = noviArtikal.KategorijaID;
            artikal.ProdavacID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            artikal.ImeProdavaca = _database.Users.Find(artikal.ProdavacID).Ime + " " + _database.Users.Find(artikal.ProdavacID).Prezime;
            //Korisnik korisnik;//naci korisnika preko userId
            _database.Add(artikal);
            _database.SaveChanges();

            Artikal artikalID = _database.Artikal.Find(artikal.ID);





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
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                            Slika newImage = new Slika() { ArtikalID = artikalID.ID, SlikaFile = p1 };
                            _database.Slika.Add(newImage);
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
            _database.SaveChanges();
            return Redirect("/Artikal/");
        }
    }
}
