using Ders26_Api.DTOs;
using Ders26_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ders26_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UrunController : ControllerBase
    {
        #region urun
        //[HttpGet] // veri çekmek için
        //public List<Urun> GetUrunler()
        //{
        //    DbHelper dbHelper = new DbHelper();
        //    var urunler = dbHelper.UrunleriListele();
        //    return urunler;
        //}
        //[HttpPost] // veri kaydetmek için
        //public string UrunKaydet(Urun data)
        //{
        //    DbHelper dbHelper = new DbHelper();
        //    var sonuc = dbHelper.UrunEkle(data);
        //    return sonuc;
        //}
        #endregion

        // URUNLER
        [HttpPost]
        public string UrunKaydet(Urun data)
        {
            DbHelper dbHelper = new DbHelper();
            var sonuc = dbHelper.UrunEkle(data);
            return sonuc;
        }

        // parametre olarak id alalım
        // geriye o id yi döndürelim

        [HttpGet]
        public Urun GetUrun(int urunId)
        {
            DbHelper dbHelper = new DbHelper();
            return dbHelper.UrunBul(urunId);
        }
        [HttpPut]
        public string UpdateProduct(dtoUrunUpdateRequest veri)
        {
            DbHelper dbHelper = new DbHelper();
            return dbHelper.ProductUpdate(veri);
        }


        [HttpPost]
        public string BosVeri()
        {
            return "çalıştı";
        }
        [HttpGet]
        public List<Urun> GetUrunler()
        {
            DbHelper dbHelper = new DbHelper();
            var urunler = dbHelper.UrunListele();
            return urunler;
        }

    }
}
