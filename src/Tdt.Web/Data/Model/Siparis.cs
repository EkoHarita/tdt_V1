using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gtsiparis.Data.Model
{
    [Table("tdt.Siparis")]
    public class Siparis
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Tarih { get; set; }

        public string KullaniciId { get; set; }

        public int GrupId { get; set; }
        [Required]
        public Grup Grup { get; set; }
        
        public ICollection<SiparisKalemi> SiparisKalemleri { get; set; }
    }
}
