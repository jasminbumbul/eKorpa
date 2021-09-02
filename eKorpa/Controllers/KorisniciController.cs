﻿using Data.EntityModels;
using eKorpa.Data;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "Admin,KorisnickaSluzba")]
    public class KorisniciController: Controller
    {
        private ApplicationDbContext _database;

        public KorisniciController(ApplicationDbContext context)
        {
            _database = context;
        }

        public IActionResult Index()
        {
            var objekat = new KorisniciIndexVM();
            objekat.rows = _database.Users.Select(a => new KorisniciIndexVM.Row
            {
                id = a.Id,
                brojTelefona = a.PhoneNumber,
                email = a.Email,
                username = a.UserName,
                emailVerified = a.EmailConfirmed,
                phoneVerified = a.PhoneNumberConfirmed,
                ime = a.Ime,
                prezime = a.Prezime
            }).ToList();

            return View(objekat);
        }

    }
}
