using Data.EntityModels;
using eKorpa.Data;
using eKorpa.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "Admin")]
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _database;
        public RoleManagerController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _database = context;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = _roleManager.FindByIdAsync(roleId);
            await _roleManager.DeleteAsync(await role);
            return RedirectToAction("Index");
        }
     }
}
