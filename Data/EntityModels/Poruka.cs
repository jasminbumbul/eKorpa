using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.EntityModels
{
    public class Poruka
    {
        public int ID { get; set; }
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        public string Predmet { get; set; }
        public string Sadrzaj { get; set; }
    }
}
