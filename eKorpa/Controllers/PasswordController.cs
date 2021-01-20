using eKorpa.EntityModels;
using eKorpa.Models;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.Controllers
{
    public class PasswordController : Controller
    {
        private readonly UserManager<Korisnik> _userManager;

        public PasswordController(UserManager<Korisnik> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ResetPassword(string code, string email)
        {
            return View("ResetPassword");
        }


        public async Task<IActionResult> ResetujPassword(ResetPassVM resetPassVM)
        {

            var user = await _userManager.FindByEmailAsync(resetPassVM.Email);
            if (user == null)
                RedirectToAction("/Identity/Account/Login");
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassVM.Code, resetPassVM.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return Redirect("/Identity/Account/Login");
            }
            return RedirectToAction("ResetPasswordConfirmation");
        }

        public IActionResult ResetPasswordConfirmation() { return View(); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
