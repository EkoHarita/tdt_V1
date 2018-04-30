using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tdt.Web.Data.Model
{
    [Table("tdt.SiparisKalemi")]
    public class SiparisKalemi
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Miktar { get; set; }
        public decimal Tutar { get; set; }
        public decimal BirimFiyat { get; set; }
        [Required]
        public Siparis Siparis { get; set; }
        [Required]
        public Urun Urun { get; set; }
    }
}