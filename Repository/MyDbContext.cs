using KontrolinisDarbas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolinisDarbas.Repository
{
    public class AppDbContext : DbContext
    {

        public DbSet<Pirkejas> Pirkejas { get; set; }
        public DbSet<Produktas> Produktas { get; set; }
        public DbSet<Uzsakymas> Uzsakymas { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Parduotuve;Trusted_Connection=true;TrustServerCertificate=True");
            }
        }
    }
}
