using gtsiparis.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gtsiparis.Data
{
    public class TdtDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Birim> Birim { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Uretici> Uretici { get; set; }
        public DbSet<Grup> Grup { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<SiparisKalemi> SiparisKalemi { get; set; }
        
        public TdtDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}