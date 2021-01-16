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
        public DbSet<ArtikliKorisnici> ArtikalKorisnik  { get; set; }
        public DbSet<Kategorija> Kategorija  { get; set; }
        public DbSet<Korpa> Korpa  { get; set; }

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
