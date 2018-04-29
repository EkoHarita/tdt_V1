using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gtsiparis.Data.Model
{
    [Table("tdt.Urun")]
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        [DataType(DataType.Currency)]
        public decimal Maliyet { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Fiyat { get; set; }
        public int? Mesafe { get; set; }
        public string UretimBolge { get; set; }
        public bool Aktif { get; set; }
        public int BirimId { get; set; }
        [Required]
        public Birim Birim { get; set; }
        public int KategoriId { get; set; }
        [Required]
        public Kategori Kategori { get; set; }
        public int UreticiId { get; set; }
        [Required]
        public Uretici Uretici { get; set; }
        public int GrupId { get; set; }
        [Required]
        public Grup Grup { get; set; }       
    }
}
