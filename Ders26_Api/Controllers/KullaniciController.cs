using Ders26_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ders26_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KullaniciController : ControllerBase
    {
        // Kullanicinin idsini parametre olarak alsın
        // Db helperda ilgili metota göndersin
        // gelen kullanıcı verisini geriye dönsün

        [HttpGet("{kullaniciId}")]
        public Kullanici GetKullanici(int kullaniciId)
        {
            DbHelper dbHelper = new DbHelper();
            return dbHelper.GetKullaniciFromDbHelper(kullaniciId);
        }


    }
}
