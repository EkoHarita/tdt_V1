using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gtsiparis.Data.Model
{
    [Table("tdt.Birim")]
    public class Birim
    {
        [Key]
        public int Id { get; set; }

        public string Ad { get; set; }

        public int GrupId { get; set; }
        
        [Required]
        public Grup  Grup { get; set; }
    }
}
