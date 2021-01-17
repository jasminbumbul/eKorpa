using System;
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

        public RegisterModel(
            UserManager<Korisnik> userManager,
            SignInManager<Korisnik> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _emailService = emailService;
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
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }
     
        [HttpPost]
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Korisnik { UserName = Input.Email, Email = Input.Email, Ime = Input.FirstName, Prezime = Input.LastName };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var link = Url.Action("VerifyEmail", "Home", new { userID = user.Id, code }, Request.Scheme, Request.Host.ToString());
                    //await _emailService.SendAsync(Input.Email, "Confirm your email", $"<a href=\"{link}\">Verify Email</a>", true);

                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    var email = this.Input.Email;
                    message.To.Add(new MailAddress(email.ToString()));
                    message.From = new MailAddress("ekorpa.business@gmail.com");
                    message.Subject = "Verifikacija e-maila";
                    message.Body = string.Format(body, "eKorpa", "ekorpa.business@gmail.com", link);

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
                        return RedirectToAction("EmailVerification");
                    }
                }
            }
            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError(string.Empty, error.Description);
            //}
            return Redirect("/Identity/Account/Login");
        }


        //// If we got this far, something failed, redisplay form
        //return Page();
    }

    //public async Task<IActionResult> VerifyEmail(string userID, string code)
    //{
    //    var user = await _userManager.FindByIdAsync(userID);

    //    if (user == null) return BadRequest();

    //    var result = await _userManager.ConfirmEmailAsync(user, code);

    //    if (result.Succeeded)
    //    {
    //        return Redirect("/Identity/Account/Login");
    //    }

    //    return BadRequest();
    //}

    //public IActionResult EmailVerification() { return Redirect("/Home/EmailVerification"); }

}
