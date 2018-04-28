using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gtsiparis.Data.Model
{
    [Table("tdt.Kategori")]
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ad { get; set; }
        public bool Aktif { get; set; }
        
        public int GrupId { get; set; }
        [Required]
        public Grup Grup { get; set; }
    }
}
