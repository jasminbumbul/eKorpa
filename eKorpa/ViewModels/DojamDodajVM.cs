using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.ViewModels
{
    public class DojamDodajVM
    {
        public int RatingID { get; set; }
        public string Dojam { get; set; }

        [MinLength(1), MaxLength(5)]
        public string Ocjena { get; set; }
        public string TipKorisnika { get; set; }
    }
}
