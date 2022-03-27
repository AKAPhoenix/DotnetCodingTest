using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTest.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }


        Dictionary<string, List<List<string>>> countryDetails = new Dictionary<string, List<List<string>>>
        {
            {
                "Nigeria" , new List<List<string>>{
                    new List<string>{"1", "MTN Nigeria","MTN NG"},
                    new List<string>{"2", "Airtel Nigeria","ANG"},
                    new List<string>{"3", "9 Mobile Nigeria","ETN"},
                    new List<string>{"4", "Globacom Nigeria","GLO NG"}
                }
            },
            {
                "Ghana" , new List<List<string>>{
                    new List<string>{"5", "Vodafone Ghana","Vodafone GH"},
                    new List<string>{"6", "MTN Ghana","MTN Ghana"},
                    new List<string>{"7", "Tigo Ghana","Tigo Ghana"},
                }
            },
            {
                "Benin" , new List<List<string>>{
                    new List<string>{"8", "MTN Benin","MTN Benin"},
                    new List<string>{"9", "Moov Benin","Moov Benin"},
                }
            },
            {
                "CIV" , new List<List<string>>{
                    new List<string>{"10", "MTN Cote d Ivoire","MTN CIV"}
                }
            }
        };


        List<List<string>> countries = new List<List<string>>
            {
                new List<string>{"1","234", "Nigeria","NG"},
                new List<string>{"2","233", "Ghana","GH"},
                new List<string>{"3","229", "Benin Replubic","BN"},
                new List<string>{"4","225", "Cote d'Ivoire","CIV"}
            };

        int ind=0;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
            .HasMany(b => b.countryDetails)
            .WithOne();

            foreach (var c in countries)
            {
                modelBuilder.Entity<Country>()
                .HasData(new { Id = Int32.Parse(c[0]), countryIso = c[1], name = c[2], countryCode = c[3] });
                KeyValuePair<string, List<List<string>>> entry = countryDetails.ElementAt(ind);

                Console.WriteLine($"IdCountry is - {Int16.Parse(c[0])}");

                foreach(var lst in entry.Value)
                {
                    modelBuilder.Entity<Country>()
                    .OwnsMany(m => m.countryDetails)
                    .HasData(new { Id = Int32.Parse(lst[0]), operatorCode = lst[2], ooperator = lst[1] });
                }
                ind++;
            }
        }
    }
}
