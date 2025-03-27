using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinemaApp.Entities.Concrete;
using Microsoft.Extensions.Configuration;

namespace SinemaApp.DataAccessLayer.Context
{
    public class SinemaAppContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public SinemaAppContext(DbContextOptions<SinemaAppContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        //public Context()
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = _configuration.GetConnectionString("SinemaAppConnection");
            optionsBuilder.UseSqlServer("server = (localdb)\\mssqllocaldb; initial catalog = SinemaAppDb; integrated security = true");
        }


        public DbSet<Bilet> Biletler { get; set; }
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Koltuk> Koltuklar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Salon> Salonlar { get; set; }
        public DbSet<Seans> Seanslar { get; set; }
        public DbSet<Rol> Roller {get; set; }
    }

    
}
