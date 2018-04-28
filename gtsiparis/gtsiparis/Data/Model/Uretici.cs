using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gtsiparis.Data.Model
{
    [Table("tdt.Uretici")]
    public class Uretici
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string SemtBelde { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
        public string Mobile { get; set; }
        public virtual Grup Grup { get; set; }
    }
}