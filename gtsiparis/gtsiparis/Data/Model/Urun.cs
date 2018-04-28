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
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        [DataType(DataType.Currency)]
        public decimal Maliyet { get; set; }
        [DataType(DataType.Currency)]
        public decimal Fiyat { get; set; }
        public int? Mesafe { get; set; }
        public string UretimBolge { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? Baslangic { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? Bitis { get; set; }
        public bool Aktif { get; set; }
        public virtual Birim Birim { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Uretici Uretici { get; set; }
        public virtual Grup Grup { get; set; }       
    }
}
