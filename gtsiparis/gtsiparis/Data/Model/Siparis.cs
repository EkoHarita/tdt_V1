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

        [Column(TypeName = "datetime2")]
        public DateTime Tarih { get; set; }

        public virtual string KullaniciId { get; set; }
        
        public virtual Grup Grup { get; set; }
        
        public virtual ICollection<SiparisKalemi> SiparisKalemleri { get; set; }
    }
}
