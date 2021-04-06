using eKorpa.EntityModels;
using eKorpa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Authorization;
using eKorpa.Data;

namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Korisnik> _userManager;
        ApplicationDbContext _database = new ApplicationDbContext();


        public HomeController(ILogger<HomeController> logger, UserManager<Korisnik> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Pretraga(string querry)
        {
            return Redirect("/Artikal/Index?querry="+querry);
        }
    }
}
