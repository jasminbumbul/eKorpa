using eKorpa.EF;
using eKorpa.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.Controllers
{
    public class KorisnikController : Controller
    {
        MyDBContext db = new MyDBContext();
        public IActionResult Prikaz()
        {
      

            List<Korisnik> korisnici = db.Korisnik.Include(o => o.OpcinaStanovanja).ToList();

            ViewData["korisnici"] = korisnici;

            return View();
        }
    }
}
