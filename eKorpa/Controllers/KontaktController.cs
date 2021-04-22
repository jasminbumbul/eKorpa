using Data.EntityModels;
using eKorpa.Data;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace eKorpa.Controllers
{
    public class KontaktController : Controller
    {
        private ApplicationDbContext _database;

        public KontaktController(ApplicationDbContext context)
        {
            _database = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PosaljiPoruku(KontaktIndexVM novaPoruka)
        {
            var poruka = new Poruka
            {
                Email = novaPoruka.Email,
                ImePrezime = novaPoruka.ImePrezime,
                Predmet = novaPoruka.Predmet,
                Sadrzaj = novaPoruka.Poruka
            };

            _database.Add(poruka);
            _database.SaveChanges();

            var message = new MailMessage();
            var email = "ekorpa.business@gmail.com";
            message.To.Add(new MailAddress(email.ToString()));
            message.From = new MailAddress("ekorpa.business@gmail.com");
            message.Subject = "Nova poruka klijenata";
            message.Body = string.Format($"Poruka od {poruka.Email} : {poruka.Sadrzaj}");

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
                await smtp.SendMailAsync(message);
            }
            return Redirect("/Kontakt");

        }

    }
}
