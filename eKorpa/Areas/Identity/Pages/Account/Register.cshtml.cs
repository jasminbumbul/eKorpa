﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using eKorpa.EntityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using NETCore.MailKit.Core;
using System.Net.Mail;
using System.Security.Claims;
using Microsoft.VisualBasic;
using System.Net;
using Data.EntityModels;
using eKorpa.Data;

namespace eKorpa.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Korisnik> _signInManager;
        private readonly UserManager<Korisnik> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IEmailService _emailService;
        private ApplicationDbContext _database;

        public RegisterModel(
            UserManager<Korisnik> userManager,
            SignInManager<Korisnik> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IEmailService emailService,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _emailService = emailService;
            _database = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Lozinka")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potvrda lozinke")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Ime")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Prezime")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Datum rođenja")]
            public DateTime DateOfBirth { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

#pragma warning disable MVC1002 // Route attributes cannot be applied to page handler methods.
        [HttpPost]
#pragma warning restore MVC1002 // Route attributes cannot be applied to page handler methods.
#pragma warning disable MVC1001 // Filters cannot be applied to page handler methods.
        [ValidateAntiForgeryToken]
#pragma warning restore MVC1001 // Filters cannot be applied to page handler methods.
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Korisnik 
                { 
                    UserName = Input.Email, 
                    Email = Input.Email, 
                    Ime = Input.FirstName, 
                    Prezime = Input.LastName, 
                    DatumRodjenja = Input.DateOfBirth,
                };

                Adresa novaAdresa = new Adresa();
                _database.Adresa.Add(novaAdresa);
                _database.SaveChanges();

                user.AdresaID = novaAdresa.ID;
                
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //adding the default role to a new user (Kupac/Prodavac)
                    var roles = _database.Roles.ToList();
                    foreach (var item in roles)
                    {
                        if(item.Name=="Kupac/Prodavac")
                        {
                            _database.UserRoles.Add(new IdentityUserRole<String> { RoleId = item.Id, UserId = user.Id });
                        }
                    }

                    _database.SaveChanges();


                    
                    //email confirmation
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var link = Url.Action("VerifyEmail", "Email", new { userID = user.Id, code }, Request.Scheme, Request.Host.ToString());

                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    var email = this.Input.Email;
                    message.To.Add(new MailAddress(email.ToString()));
                    message.From = new MailAddress("ekorpa.business@gmail.com");
                    message.Subject = "Verifikacija e-maila";
                    message.Body = string.Format(body, "eKorpa", "ekorpa.business@gmail.com", $"<a href='{link}'>Potvrdite email klikom na ovaj link<a>");

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
                    return Redirect("/Email/EmailVerification");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Redirect("/Identity/Account/Login");
        }
    }
}
