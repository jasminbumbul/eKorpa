using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class KontaktIndexVM
    {
        [Required]
        public string ImePrezime{ get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Predmet mora biti duži od 4 karaktera.", MinimumLength = 4)]
        public string Predmet { get; set; }

        [StringLength(100, ErrorMessage = "Poruka mora biti duža od 10 karaktera.", MinimumLength = 10)]
        public string Poruka { get; set; }
    }
}
