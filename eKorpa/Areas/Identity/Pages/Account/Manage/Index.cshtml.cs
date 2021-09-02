using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eKorpa.Data;
using eKorpa.EntityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eKorpa.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<Korisnik> _userManager;
        private readonly SignInManager<Korisnik> _signInManager;
        private ApplicationDbContext _database;

        public IndexModel(
            UserManager<Korisnik> userManager,
            SignInManager<Korisnik> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _database = context;
        }

        public string Username { get; set; }
        public bool verifikovanBroj { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Broj telefona")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Datum rođenja")]
            public DateTime DatumRodjenja { get; set; }

            [Display(Name = "Ime")]
            public string Ime { get; set; }

            [Display(Name = "Prezime")]
            public string Prezime { get; set; }

            [Display(Name = "Opcina stanovanja")]
            public int OpcinaStanovanjaID { get; set; }
            public List<SelectListItem> OpcinaStanovanja { get; set; }


            [Display(Name = "Mjesto i ulica stanovanja")]
            public string MjestoStanovanja { get; set; }

            [Display(Name = "Poštanski broj")]
            public int PostanskiBroj { get; set; }

        }

        private async Task LoadAsync(Korisnik user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var adresa = _database.Adresa.Find(user.AdresaID);

            verifikovanBroj = user.PhoneNumberConfirmed;

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Ime = user.Ime,
                Prezime = user.Prezime,
                DatumRodjenja = user.DatumRodjenja,
                MjestoStanovanja = adresa.MjestoStanovanja,
                OpcinaStanovanja = _database.Grad.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                PostanskiBroj = adresa.PostanskiBroj
            };
            if (adresa.OpcinaID != null)
            {
                Input.OpcinaStanovanjaID = (int)adresa.OpcinaID;
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }





#pragma warning disable MVC1001 // Filters cannot be applied to page handler methods.
        [ValidateAntiForgeryToken]
#pragma warning restore MVC1001 // Filters cannot be applied to page handler methods.
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var adresa = _database.Adresa.Find(user.AdresaID);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (Input.PhoneNumber != null && (Input.PhoneNumber.Length != 12 || Input.PhoneNumber.Substring(0, 5) != "+3876"))
            {
                StatusMessage = "Broj telefona mora biti u formatu: '+3876XXXXXXX' i dužine 12 karaktera.";
                return RedirectToPage();
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            user.Ime = Input.Ime;
            user.Prezime = Input.Prezime;
            user.DatumRodjenja = Input.DatumRodjenja;
            if (Input.PhoneNumber != null)
            {
                user.PhoneNumber = Input.PhoneNumber;
            }
            adresa.MjestoStanovanja = Input.MjestoStanovanja;
            adresa.OpcinaID = Input.OpcinaStanovanjaID;
            adresa.PostanskiBroj = Input.PostanskiBroj;

            _database.SaveChanges();

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
