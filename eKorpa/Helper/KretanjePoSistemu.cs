using Data.EntityModels;
using eKorpa.Data;
using eKorpa.EntityModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Mail;

namespace eKorpa.Helper
{
    public class KretanjePoSistemu
    {
        public static int Save(HttpContext httpContext, Exception exceptionMessage = null)
        {
            Korisnik korisnik = httpContext.LogiraniKorisnik();

            var request = httpContext.Request;

            var queryString = request.Query;

            if (queryString.Count == 0 && !request.HasFormContentType)
                return 0;

            //IHttpRequestFeature feature = request.HttpContext.Features.Get<IHttpRequestFeature>();
            string detalji = "";
            if (request.HasFormContentType)
            {
                foreach (string key in request.Form.Keys)
                {
                    detalji += " | " + key + "=" + request.Form[key];
                }
            }

            var x = new LogKretanjePoSistemu
            {
                Korisnik = korisnik,
                Vrijeme = DateTime.Now,
                QueryPath = request.GetEncodedPathAndQuery(),
                PostData = detalji,
                IpAdresa = request.HttpContext.Connection.RemoteIpAddress.ToString(),

            };

            if (exceptionMessage != null)
            {
                x.isException = true;
                x.exceptionMessage = exceptionMessage.Message + " |" + exceptionMessage.InnerException;
            }


            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            db.Add(x);
            db.SaveChanges();

            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("ekorpa.business@gmail.com"));
            message.From = new MailAddress("ekorpa.business@gmail.com");
            message.Subject = "Error filter preko e-maila";
            message.Body = string.Format(body, "eKorpa", "ekorpa.business@gmail.com", "ID: " + x.ID + ". " + x.exceptionMessage + " query path: " + x.QueryPath);

            message.IsBodyHtml = true;
            var smtp = new SmtpClient();
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
            

            return x.ID;
        }
    }
}
