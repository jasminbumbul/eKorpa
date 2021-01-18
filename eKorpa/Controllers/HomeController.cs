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
            //return Redirect("/Artikal/");

        }

        public IActionResult Privacy()
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

        public IActionResult ResetPassword(string code, string email)
        {
            //var user = await _userManager.FindByEmailAsync(email);
            //if (user == null)
            //    RedirectToAction("/Identity/Account/Login");
            //var resetPassResult = await _userManager.ResetPasswordAsync(user, code,);
            //if (!resetPassResult.Succeeded)
            //{
            //    foreach (var error in resetPassResult.Errors)
            //    {
            //        ModelState.TryAddModelError(error.Code, error.Description);
            //    }
            //    return Redirect("/Identity/Account/Login");
            //}
            //return RedirectToAction("ResetPasswordConfirmation");

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

        public IActionResult Pretraga(string querry)
        {
            return Redirect("/Artikal/Index?querry="+querry);
        }
    }
}
