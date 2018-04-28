using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gtsiparis.Data.Model
{
    [Table("tdt.SiparisKalemi")]
    public class SiparisKalemi
    {
        [Key]
        public int Id { get; set; }
        public decimal Miktar { get; set; }
        public decimal Tutar { get; set; }
        public decimal BirimFiyat { get; set; }
        public virtual Siparis Siparis { get; set; }
        public virtual Urun Urun { get; set; }
    }
}