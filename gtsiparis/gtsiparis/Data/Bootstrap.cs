using System.Threading.Tasks;
using gtsiparis.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace gtsiparis.Data
{
    public class Bootstrap
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Bootstrap(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void SeedData(IApplicationBuilder applicationBuilder)
        {
            InitializeDatabase(applicationBuilder);
            await SeedRoles();
            await SeedUsers();

            await SeedDomain(applicationBuilder);
        }
        
        private static async Task SeedDomain(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TdtDbContext>();
                if (context.Grup.Any()) return;
                
                var grup = await CreateGrup(context);
                await CreateBirim(context, grup);
                await CreateKategori(context, grup);

                await context.SaveChangesAsync();
            }
        }

        private static async Task CreateKategori(TdtDbContext context, Grup grup)
        {
            var kategori = new[]
            {
                "Baharat",
                "Zeytin",
                "Konserve",
                "Süt / Yumurta",
                "Bakliyat",
                "Tahıl",
                "Sebze / Meyve",
                "Kuruyemiş",
                "Diğer",
                "Bal / Reçel",
                "Şifalı ot",
                "Temizlik",
                "Bitkisel Yağ",
                "Ekşi / Sirke"
            };
            
            for (var i = 0; i < kategori.Length; i++)
            {
                await context.Kategori.AddAsync(new Kategori
                {
                    Id = i + 1,
                    Ad = kategori[i],
                    Aktif = true,
                    Grup = grup
                });                
            }
        }

        private static async Task<Grup> CreateGrup(TdtDbContext context)
        {
            var grup = new Grup
            {
                Id = 1000,
                Ad = "Ekoharita TDT",
                Il = "İstanbul",
                Ilce = "Kadıköy",
                Mahalle = "Cami",
                SemtBelde = "Dortyol",
                PostaKodu = "34750"
            };
            
            await context.Grup.AddAsync(grup);

            return grup;
        }

        private static async Task CreateBirim(TdtDbContext context, Grup grup)
        {
            await context.Birim.AddAsync(new Birim{ Id = 1, Ad = "Kg", Grup = grup});
            await context.Birim.AddAsync(new Birim{ Id = 2, Ad = "Lt", Grup = grup});
            await context.Birim.AddAsync(new Birim{ Id = 3, Ad = "Adet", Grup = grup});
            await context.Birim.AddAsync(new Birim{ Id = 4, Ad = "Demet", Grup = grup});
        }

        private async Task SeedUsers()
        {
            await AddUser("admin@ekotopluluk.xyz", Roles.Administrator);
            await AddUser("user@ekotopluluk.xyz");
        }

        private async Task AddUser(string email, string role = Roles.Default)
        {
            if (await _userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    Ad = "Eko",
                    Soyad = "Topluluk",
                    SecurityStamp = "secure"
                };

                await _userManager.CreateAsync(user, "3k0t0pluluk!");
                await _userManager.AddToRoleAsync(user, role);
            }
        }

        private async Task SeedRoles()
        {
            if (!await _roleManager.RoleExistsAsync(Roles.Default))
                await _roleManager.CreateAsync(new IdentityRole(Roles.Default));

            if (!await _roleManager.RoleExistsAsync(Roles.Administrator))
                await _roleManager.CreateAsync(new IdentityRole(Roles.Administrator));
        }

        private static void InitializeDatabase(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<TdtDbContext>().Database.Migrate();
            }
        }
    }
}