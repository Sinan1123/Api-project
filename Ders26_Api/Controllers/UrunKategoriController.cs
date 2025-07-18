﻿using Ders26_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ders26_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UrunKategoriController : ControllerBase
    {
        // KATEGORILER
        [HttpPost]
        public string KategoriKaydet(UrunKategori data)
        {
            DbHelper dbHelper = new DbHelper();

            UrunKategori kategori = new UrunKategori();
            kategori.Adi = data.Adi;
            kategori.Aciklama = data.Aciklama;
            kategori.Sira = data.Sira;
            kategori.IsPassive = data.IsPassive;
            kategori.KategoriNo = data.KategoriNo;

            var sonuc = dbHelper.KategoriEkle(data);
            return sonuc;
        }

        [HttpGet]
        public List<UrunKategori> GetKategoriler()
        {
            DbHelper dbhelper = new DbHelper();
            var kategoriler = dbhelper.UrunKategorileriListele();
            return kategoriler;
        }

        [HttpGet("{kategoriId}/{no}")]
        public string GetKategoriName(int kategoriId, string no)
        {
            DbHelper dbhelper = new DbHelper();
            var sonuc = dbhelper.GetKategoriAdi(kategoriId);
            return sonuc;
        }

        [HttpGet]
        public UrunKategori GetKategori(int kategoriId)
        {
            DbHelper dbhelper = new DbHelper();
            var sonuc = dbhelper.GetKategori(kategoriId);
            return sonuc;
        }

    }
}
