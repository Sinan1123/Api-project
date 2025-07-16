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
            // local
            //optionsBuilder.UseSqlServer(@"
            //    Server=localhost;
            //    DataBase=AlisVerisApi;
            //    Trusted_Connection=True;
            //    TrustServerCertificate=True;
            //");

            // guzelhosting
            optionsBuilder.UseSqlServer(@"
                Server=ipadresi\MSSQLSERVER2022;
                Database=veritabanı adı;
                User Id=kullanıcı adı;
                Password=şifre;
                Trusted_Connection=True;
                TrustServerCertificate=True;
            ");
        }
    }
}
