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
            optionsBuilder.UseSqlServer("server = (localdb)\\mssqllocaldb; initial catalog = SinemaAppDb_v1; integrated security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bilet>()
                .HasOne(b => b.Kullanici) //bir biletin bir kullanıcısı var 
                .WithMany(k => k.Biletler) // bir kullanıcının birden fazla bileti olabilir
                .HasForeignKey(b => b.KullaniciId) //biletin kullaniciId'si kullanici tablosundaki id'ye referans veriyor
                .OnDelete(DeleteBehavior.Cascade);//cascade: eğer bir kullanıcı silinirse, ona ait biletler de silinir

            modelBuilder.Entity<Bilet>()
                .HasOne(b => b.Seans)
                .WithMany(s => s.Biletler)
                .HasForeignKey(b => b.SeansId)
                .OnDelete(DeleteBehavior.Restrict); //seans silinirse biletler silinmez, sadece seansId'si null olur. Bu db tarafında çalışır

            modelBuilder.Entity<Bilet>()
                .HasOne(b => b.Film)
                .WithMany(f => f.Biletler)
                .HasForeignKey(b => b.FilmId)
                .OnDelete(DeleteBehavior.NoAction); //film silinirse biletler silinmez, sadece filmId'si null olur. Bu uygulama seviyesinde çalışır.

            modelBuilder.Entity<Bilet>()
                .HasOne(b => b.Koltuk)
                .WithOne(k => k.Bilet)
                .HasForeignKey<Bilet>(b => b.KoltukId)
                .OnDelete(DeleteBehavior.Restrict);
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
