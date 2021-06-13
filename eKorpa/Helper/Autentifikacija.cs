using eKorpa.Data;
using eKorpa.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace eKorpa.Helper
{
    public static class Autentifikacija
    {
        public static Korisnik LogiraniKorisnik(this HttpContext httpContext)
        {
            //Preuzimamo DbContext preko app services
            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();


            //Preuzimamo userManager preko app services
            UserManager<Korisnik> userManager = httpContext.RequestServices.GetService<UserManager<Korisnik>>();

            if (httpContext.User == null)
                return null;

            //TrenutniKorisnikID
            string userId = userManager.GetUserId(httpContext.User);

            //Korisnik k = db.Korisnik.Where(s => s.Id == userId)
            //    .Include(s => s.Nastavnik)
            //    .Include(s => s.Student)
            //    .SingleOrDefault();

            Korisnik k2 = userManager.Users.Where(s=>s.Id ==userId).SingleOrDefault();
            return k2;
        }
    }
}
