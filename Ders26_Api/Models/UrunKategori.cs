using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ders26_Api.Models
{
    public class UrunKategori
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool IsPassive { get; set; } = false;
        public string? Aciklama { get; set; }
        public string KategoriNo { get; set; }
        public int Sira { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        [JsonIgnore]
        public ICollection<Urun> Urunler { get; set; } = new List<Urun>();
    }
}
