using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ders26_Api.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public double BirimFiyat { get; set; }
        public bool IsPassive { get; set; } = false;
        public int Stok { get; set; }
        public string BarkodNo { get; set; }
        public int Sira { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        public UrunKategori Kategori { get; set; }
    }
}
