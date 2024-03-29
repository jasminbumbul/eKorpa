﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Data.EntityModels;
using eKorpa.EntityModels;

namespace eKorpa.EntityModels
{
    public class Artikal
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int KategorijaID { get; set; }
        public Kategorija Kategorija{ get; set; }
        public int PotkategorijaID { get; set; }
        public Potkategorija Potkategorija { get; set; }
        public string ProdavacID { get; set; }
        public string ImeProdavaca { get; set; }
        public float Cijena { get; set; }
        public float CijenaSaPopustom { get; set; }
        public int BrendID { get; set; }
        public Brend Brend { get; set; }
        public int BrojUSkladistu { get; set; }
        public int? BojaID { get; set; }
        public Boja Boja { get; set; }
        public int? MaterijalID { get; set; }
        public Materijal Materijal { get; set; }
        public int? VelicinaID { get; set; }
        public Velicina Velicina { get; set; }
        public DateTime DatumObjave { get; set; }
        public bool Izbrisan { get; set; }
    }
}
