using eKorpa.EntityModels;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly UserManager<Korisnik> _userManager; 
        private readonly RoleManager<IdentityRole> _roleManager; 
        public UserRolesController(UserManager<Korisnik> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager; _userManager = userManager;
        }
        public async Task<IActionResult> Index() 
        { 
            var users = await _userManager.Users.ToListAsync(); 
            var userRolesViewModel = new List<UserRolesVM>(); 
            foreach (Korisnik user in users) 
            { 
                var thisViewModel = new UserRolesVM(); 
                thisViewModel.KorisnikID = user.Id; 
                thisViewModel.Email = user.Email; 
                thisViewModel.Ime = user.Ime; 
                thisViewModel.Prezime= user.Prezime; 
                thisViewModel.Roles = await GetUserRoles(user); 
                userRolesViewModel.Add(thisViewModel); 
            } 
            return View(userRolesViewModel); }
        public async Task<IActionResult> Manage(string userId) 
        { 
            ViewBag.userId = userId; 
            var user = await _userManager.FindByIdAsync(userId); 
            if (user == null) 
            { 
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found"; 
                return NotFound();
            } 
            ViewBag.UserName = user.UserName; 
            var model = new List<ManageUserRolesVM>(); 
            foreach (var role in _roleManager.Roles.ToList()) 
            { 
                var userRolesViewModel = new ManageUserRolesVM
                { 
                    UlogaID = role.Id, ImeUloge= role.Name }; 
                if (await _userManager.IsInRoleAsync(user, role.Name)) 
                { 
                    userRolesViewModel.Selected = true; 
                } 
                else 
                { 
                    userRolesViewModel.Selected = false; 
                } 
                model.Add(userRolesViewModel); 
            } 
            return View(model);
        }
        [HttpPost] 
        public async Task<IActionResult> Manage(List<ManageUserRolesVM> model, string userId) 
        { 
            var user = await _userManager.FindByIdAsync(userId); 
            if (user == null) 
            { 
                return View(); 
            } 
            var roles = await _userManager.GetRolesAsync(user); 
            var result = await _userManager.RemoveFromRolesAsync(user, roles); 
            if (!result.Succeeded) 
            { 
                ModelState.AddModelError("", "Cannot remove user existing roles"); 
                return View(model); 
            } 
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.ImeUloge)); 
            if (!result.Succeeded) 
            { 
                ModelState.AddModelError("", "Cannot add selected roles to user"); 
                return View(model); 
            } 
            return RedirectToAction("Index");
        }
        private async Task<List<string>> GetUserRoles(Korisnik user) 
        { 
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}

