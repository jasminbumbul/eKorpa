﻿using eKorpa.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKorpa.ViewModels;
using eKorpa.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eKorpa.Controllers
{
    public class ArtikalController : Controller
    {
        ApplicationDbContext _database = new ApplicationDbContext();
        public IActionResult Index()
        {   
            var objekat = new ArtikalIndexVM
            {
                rows = _database.Artikal.Select(a => new ArtikalIndexVM.Row
                {
                    ID = a.ID,
                    NazivArtikla = a.Naziv,
                    Kategorija = a.Kategorija.NazivKategorije
                }).ToList()
            };
        
            return View(objekat);
        }

        public IActionResult Dodaj(int ArtikalID)
        {
            ArtikalDodajVM noviArtikal = ArtikalID == 0
                ? new ArtikalDodajVM()
                {
                    Kategorije = _database.Kategorija.Select(k => new SelectListItem {Value = k.ID.ToString(), Text = k.NazivKategorije}).ToList()
                }
                : _database.Artikal
                    .Where(x => x.ID == ArtikalID)
                    .Select(x => new ArtikalDodajVM
                    {
                        ID = x.ID,
                        KategorijaID = x.KategorijaID,
                        NazivArtikla = x.Naziv,
                        Kategorije = _database.Kategorija.Select(k => new SelectListItem { Value = k.ID.ToString(), Text = k.NazivKategorije }).ToList() //optimizacija???
                    }).Single();

            return View(noviArtikal);
        }

        public IActionResult Snimi(ArtikalDodajVM noviArtikal)
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
            _database.SaveChanges();

            return Redirect("/Artikal/");
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
