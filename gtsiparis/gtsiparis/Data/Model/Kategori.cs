using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gtsiparis.Data.Model
{
    [Table("tdt.Kategori")]
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public bool Aktif { get; set; }
        
        [Required]
        public virtual Grup Grup { get; set; }
    }
}
