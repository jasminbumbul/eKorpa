using eKorpa.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.EF
{
    public class MyDBContext: DbContext
    {
        public DbSet<Opcina> Opcina { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@" Server=app.fit.ba,1431;
                                        Database=p2040_eKorpa;
                                        Trusted_Connection=false;
                                        User ID=p2040;
                                        Password=KSCTFQ3!;
                                        MultipleActiveResultSets=true;
                                        ");
        }
    }
}
