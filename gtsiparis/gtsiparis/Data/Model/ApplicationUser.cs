using Microsoft.AspNetCore.Identity;

namespace gtsiparis.Data.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Mobil { get; set; }
        
        public string AdSoyad
        {
            get { return Ad + " " + Soyad; }
        }
    }
}