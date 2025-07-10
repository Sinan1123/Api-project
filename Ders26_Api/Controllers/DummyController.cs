using Ders26_Api.Data;
using Ders26_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

namespace Ders26_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DummyController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IHttpClientFactory _httpClientFactory;

        public DummyController(AppDbContext db, IHttpClientFactory httpClientFactory)
        {
            _db = db;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> ImportDummyKullanicilar()
        {
            var client = _httpClientFactory.CreateClient();
            var url = "https://dummyjson.com/users";
            var response = await client.GetFromJsonAsync<DummyUserResponse>(url);

            if (response?.Users == null || !response.Users.Any())
                return BadRequest("Veri alınamadı.");

            List<Kullanici> yeniKullanicilar = response.Users
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

            return Ok($"{yeniKullanicilar.Count} kullanıcı eklendi.");
        }

        [HttpPost]
        public async Task<IActionResult> ImportDummyKullanicilar2()
        {
            var dbHelper = new DbHelper();

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<DummyUserResponse>("https://dummyjson.com/users");

            if (response?.Users == null || !response.Users.Any())
                return BadRequest("Veri alınamadı.");

            var sonucMesaji = await dbHelper.DummyKullanicilariKaydetAsync(response.Users);

            return Ok(sonucMesaji);
        }



    }
}
