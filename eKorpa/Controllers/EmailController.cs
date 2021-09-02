using eKorpa.EntityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "Admin,KorisnickaSluzba,Kupac/Prodavac")]
    public class EmailController : Controller
    {
        private readonly UserManager<Korisnik> _userManager;

        public EmailController(UserManager<Korisnik> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmailVerification()
        {
            return View();
        }

        public async Task<IActionResult> VerifyEmail(string userID, string code)
        {
            var user = await _userManager.FindByIdAsync(userID);

            if (user == null) return BadRequest();

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View("VerifyEmail");
            }

            return BadRequest();
        }

    }
}
