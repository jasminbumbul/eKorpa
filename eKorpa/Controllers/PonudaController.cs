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
                ID = x.ID,
                IsAktivna = x.IsAktivna,
                KategorijaID = x.KategorijaID,
                PotkategorijaID = x.PotkategorijaID,
                NazivKategorije = x.Kategorija.NazivKategorije,
                NazivPotkategorije = x.Potkategorija.Naziv,
                Opis = x.Opis,
                VelicinaPopusta = x.ProcenatSnizenja.ToString()
            }).ToList();

            return Ok(objekat);
        }

        public IActionResult GetPonudaById(int ponudaId)
        {
            var ponuda = _database.Ponuda.Find(ponudaId);
            if (ponuda != null)
            {
                return Ok(ponuda);
            }
            return NotFound("Ponuda sa proslijedjenim id-om ne postoji");
        }


        public IActionResult Izbrisi(int ponudaId)
        {
            var ponuda = _database.Ponuda.Find(ponudaId);

            if (ponuda != null)
            {
                _database.Remove(ponuda);
                _database.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult SnimiPonudu([FromBody] PonudaDodajVM ponudaFilter) 
        { 
            if(ponudaFilter == null)
            {
                return NotFound("Ponuda is null");
            }
            var novaPonuda = new Ponuda
            {
                IsAktivna = false,
                KategorijaID = ponudaFilter.KategorijaID,
                Kategorija = _database.Kategorija.Find(ponudaFilter.KategorijaID),
                Opis = ponudaFilter.Opis,
                PotkategorijaID = ponudaFilter.PotkategorijaID,
                Potkategorija = _database.Potkategorija.Find(ponudaFilter.PotkategorijaID),
                ProcenatSnizenja = (float)ponudaFilter.Popust
            };

            _database.Add(novaPonuda);
            _database.SaveChanges();

            var objekat = _database.Artikal.Where(x => x.KategorijaID == ponudaFilter.KategorijaID && x.PotkategorijaID == ponudaFilter.PotkategorijaID);
            foreach (var item in objekat)
            {
                item.CijenaSaPopustom = item.Cijena - (item.Cijena * ((float)ponudaFilter.Popust / 100));
            }
            _database.SaveChanges();


            return Ok(novaPonuda);
        }

        [HttpPut]
        public IActionResult UrediPonudu([FromBody] PonudaDodajVM novi)
        {
            if (novi == null)
            {
                return NotFound("Ponuda is null");
            }

            var ponuda = _database.Ponuda.Find(novi.ID);
            ponuda.Opis = novi.Opis;
            ponuda.KategorijaID = novi.KategorijaID;
            ponuda.PotkategorijaID = novi.PotkategorijaID;
            ponuda.ProcenatSnizenja = (float)novi.Popust;

            _database.SaveChanges();

            var objekat = _database.Artikal.Where(x => x.KategorijaID == novi.KategorijaID && x.PotkategorijaID == novi.PotkategorijaID);
            foreach (var item in objekat)
            {
                item.CijenaSaPopustom = item.Cijena - (item.Cijena * ((float)novi.Popust / 100));
            }
            _database.SaveChanges();


            return Ok(ponuda);
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
                item.CijenaSaPopustom = item.Cijena - (item.Cijena * (ponuda.ProcenatSnizenja / 100));
            }
            _database.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
