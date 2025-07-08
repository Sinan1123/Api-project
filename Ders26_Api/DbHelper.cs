using Ders26_Api.Data;
using Ders26_Api.Models;

namespace Ders26_Api
{
    public class DbHelper
    {
        private AppDbContext _db = new AppDbContext();

        #region Urun
        public List<Urun> UrunleriListele()
        {
            return _db.Urunler.ToList();
        }
        public string UrunEkle(Urun data)
        {
            _db.Urunler.Add(data);
            _db.SaveChanges();
            return $"{data.Adi} başarıyla eklendi";
        }
        #endregion

        #region Urun Kategorileri
        public string KategoriEkle(UrunKategori data)
        {
            _db.UrunKategoriler.Add(data);
            _db.SaveChanges();
            return $"{data.Adi} eklendi";
        }

        public List<UrunKategori> UrunKategorileriListele()
        {
            return _db.UrunKategoriler.OrderBy(p => p.Sira).ToList();
        }
        
        public UrunKategori GetKategori(int kategoriId)
        {
            return _db.UrunKategoriler.Where(p => p.Id == kategoriId).First();
        }
        public string GetKategoriAdi(int kategoriId)
        {
            return _db.UrunKategoriler
                .Where(p => p.Id == kategoriId)
                .Select(s => s.Adi)
                .First();
        }
        #endregion

        #region dummyJson


        public async Task<string> DummyKullanicilariKaydetAsync(List<DummyUser> dummyUsers)
        {
            var yeniKullanicilar = dummyUsers
                .Where(dummy => !_db.Kullanicilar.Any(k => k.Email == dummy.Email))
                .Select(dummy => new Kullanici
                {
                    AdSoyad = $"{dummy.FirstName} {dummy.LastName}",
                    Email = dummy.Email,
                    Sifre = dummy.Password,
                    OlusturulmaTarihi = DateTime.Now
                })
                .ToList();

            _db.Kullanicilar.AddRange(yeniKullanicilar);
            await _db.SaveChangesAsync();

            return $"{yeniKullanicilar.Count} kullanıcı eklendi.";
        }
        #endregion
    }
}
