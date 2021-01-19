using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.EntityModels
{
    public class Slika
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Naslov { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Naziv slike")]
        public string Naziv { get; set; }

        [DisplayName("Upload slike")]
        public byte[] SlikaFile { get; set; }

        public int ArtikalID { get; set; }
        public int Thumbnail { get; set; }
    }
}
