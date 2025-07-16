using System.Net;
using System.Net.Mail;
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

        [HttpPost]
        public string SendMail(string body)
        {
            var gonderilecekMailAdresi = new MailAddress("info@ayseguler.net.tr");

            string htmlBody = "<p>" + body + "</p>";

            MailMessage mail = new MailMessage();
            mail.From = gonderilecekMailAdresi;
            mail.To.Add(new MailAddress("ayseguler135@gmail.com"));
            mail.To.Add(new MailAddress("morrina389@gmail.com"));
            mail.To.Add(new MailAddress("kanaryaan1@hotmail.com"));
            mail.To.Add(new MailAddress("erkansun@gmail.com"));
            mail.To.Add(new MailAddress("sinangurses79@gmail.com"));
            mail.To.Add(new MailAddress("elifo3725@gmail.com"));
            mail.Subject = "Sipariş Onay";
            mail.IsBodyHtml = true;
            mail.Body = body;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("info@ayseguler.net.tr", "8&bpx2105");
            smtp.Port = 587;
            //smtp.Host = "smtp.gmail.com";
            //smtp.Host = "smtp.yandex.com.tr";
            //smtp.Host = "outlook.office365.com";
            smtp.Host = "mail.ayseguler.net.tr";
            smtp.EnableSsl = false;

            try
            {
                smtp.Send(mail);
                return "Mail gönderildi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
}
