using eKorpa.EntityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Data.EntityModels;

namespace eKorpa.Data
{
    public class ApplicationDbContext : IdentityDbContext<Korisnik>
    {
        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("server=app.fit.ba,1431;Database=p2040_eKorpa;User Id=P2040; Password=KSCTFQ3!;");

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artikal> Artikal { get; set; }
        public DbSet<Kategorija> Kategorija  { get; set; }
        public DbSet<Potkategorija> Potkategorija { get; set; }
        public DbSet<Korpa> Korpa  { get; set; }
        public DbSet<Slika> Slika { get; set; }
        public DbSet<ListaZelja> ListaZelja { get; set; }
        public DbSet<Ponuda> Ponuda { get; set; }
        public DbSet<Brend> Brend { get; set; }
        public DbSet<Rejting> Rejting { get; set; }
        public DbSet<ZavrseniArtikal> ZavrseniArtikal { get; set; }
        public DbSet<Boja> Boja { get; set; }
        public DbSet<Materijal> Materijal { get; set; }
        public DbSet<Velicina> Velicina{ get; set; }
        public DbSet<Adresa> Adresa{ get; set; }
        public DbSet<Grad> Grad{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);

           // modelBuilder.Entity<Korisnik>()
           // .HasOne<Kupac>(s => s.Kupac)
           // .WithOne(ad => ad.Korisnik)
           // .HasForeignKey<Kupac>(ad => ad.KorisnikID);

           // modelBuilder.Entity<Korisnik>()
           //.HasOne<Prodavac>(s => s.Prodavac)
           //.WithOne(ad => ad.Korisnik)
           //.HasForeignKey<Prodavac>(ad => ad.KorisnikID);

          



        }
    }
}
