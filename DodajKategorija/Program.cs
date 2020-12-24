using System;
using eKorpa.EntityModels;
using eKorpa.Data;
using System.Threading;

namespace DodajKategorija
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Dodavanje kategorija***");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                Thread.Sleep(1000);
                Console.WriteLine("Unesite naziv kategorije koju želite dodati: ");

                var novaKategorija = new Kategorija { NazivKategorije = Console.ReadLine() };
                ApplicationDbContext dbContext = new ApplicationDbContext();
                dbContext.Add(novaKategorija);
                dbContext.SaveChanges();
            }
        }
    }
}
