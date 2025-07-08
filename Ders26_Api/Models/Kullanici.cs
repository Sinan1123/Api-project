using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ders26_Api.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public bool IsPassive { get; set; } = false;
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
    }
}
