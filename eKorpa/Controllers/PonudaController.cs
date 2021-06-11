using Data.EntityModels;
using eKorpa.Data;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class PonudaController : Controller
    {
        private ApplicationDbContext _database;

        public PonudaController(ApplicationDbContext context)
        {
            _database = context;
        }

        public IActionResult Index()
        {
            var objekat = new PonudaIndexVM();

            objekat.rows = _database.Ponuda.Select(x => new PonudaIndexVM.Row
            {
                ID=x.ID,
                IsAktivna=x.IsAktivna,
                KategorijaID=x.KategorijaID,
                PotkategorijaID=x.PotkategorijaID,
                NazivKategorije=x.Kategorija.NazivKategorije,
                NazivPotkategorije=x.Potkategorija.Naziv,
                Opis=x.Opis,
                VelicinaPopusta=x.ProcenatSnizenja.ToString()
            }).ToList();

            return View(objekat);
        }

        public IActionResult Dodaj()
        {
            var objekat = new PonudaDodajVM
            {
                Kategorija=_database.Kategorija.Select(x=> new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value=x.ID.ToString(),
                    Text=x.NazivKategorije
                }).ToList(),

            };

            return View(objekat);
        }

        public IActionResult SnimiPonudu(PonudaDodajVM novi)
        {
            var novaPonuda = new Ponuda
            {
                IsAktivna = false,
                KategorijaID = novi.KategorijaID,
                Kategorija = _database.Kategorija.Find(novi.KategorijaID),
                Opis = novi.Opis,
                PotkategorijaID = novi.PotkategorijaID,
                Potkategorija = _database.Potkategorija.Find(novi.PotkategorijaID),
                ProcenatSnizenja = novi.Popust
            };

            _database.Add(novaPonuda);
            _database.SaveChanges();

            var objekat = _database.Artikal.Where(x => x.KategorijaID == novi.KategorijaID && x.PotkategorijaID == novi.PotkategorijaID);
            foreach (var item in objekat)
            {
                item.CijenaSaPopustom = item.Cijena - (item.Cijena * (novi.Popust / 100));
            }
            _database.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult DeaktivirajPonudu(int PonudaID)
        {
            var ponuda = _database.Ponuda.Find(PonudaID);
            ponuda.IsAktivna = false;
            _database.SaveChanges();

            var objekat = _database.Artikal.Where(x => x.KategorijaID == ponuda.KategorijaID && x.PotkategorijaID == ponuda.PotkategorijaID);
            foreach (var item in objekat)
            {
                item.CijenaSaPopustom = item.Cijena;
            }
            _database.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult AktivirajPonudu(int PonudaID)
        {
            var ponuda = _database.Ponuda.Find(PonudaID);
            ponuda.IsAktivna = true;
            _database.SaveChanges();

            var objekat = _database.Artikal.Where(x => x.KategorijaID == ponuda.KategorijaID && x.PotkategorijaID == ponuda.PotkategorijaID);
            foreach (var item in objekat)
            {
                item.CijenaSaPopustom = item.Cijena - (item.Cijena * (ponuda.ProcenatSnizenja/ 100));
            }
            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
