using Ders26_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Ders26_Api.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisItem> SiparisItems { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunKategori> UrunKategoriler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server=SINAN\MSSQLSERVER01;
                DataBase=AlisVerisApi;
                Trusted_Connection=True;
                TrustServerCertificate=True;
            ");
        }
    }
}
