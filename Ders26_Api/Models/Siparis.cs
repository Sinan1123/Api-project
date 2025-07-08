using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ders26_Api.Models
{
    public class Siparis
    {
        public int Id { get; set; }
        public string SiparisNo { get; set; }
        public double Toplam { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int KullaniciId { get; set; }
        [ForeignKey("KullaniciId")]
        public Kullanici Kullanici { get; set; }
        public ICollection<SiparisItem> SiparisItems { get; set; } = new List<SiparisItem>();
    }
}
