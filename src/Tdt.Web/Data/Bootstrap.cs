using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Tdt.Web.Core;
using Tdt.Web.Data.Model;

namespace Tdt.Web.Data
{
    public class Bootstrap
    {
        private readonly TdtDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Bootstrap(TdtDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await InitializeDatabase();
            await SeedRoles();
            await SeedUsers();

            await SeedDomain();
        }
        
        private async Task SeedDomain()
        {
            if (_dbContext.Grup.Any()) return;
                
            var grup = await CreateGrup();
            await CreateBirim(grup);
            await CreateKategori(grup);

            await _dbContext.SaveChangesAsync();
        }

        private async Task CreateKategori(Grup grup)
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
                await _dbContext.Kategori.AddAsync(new Kategori
                {
                    Id = i + 1,
                    Ad = kategori[i],
                    Aktif = true,
                    Grup = grup
                });                
            }
        }

        private async Task<Grup> CreateGrup()
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
            
            await _dbContext.Grup.AddAsync(grup);

            return grup;
        }

        private async Task CreateBirim(Grup grup)
        {
            await _dbContext.Birim.AddAsync(new Birim{ Id = 1, Ad = "Kg", Grup = grup});
            await _dbContext.Birim.AddAsync(new Birim{ Id = 2, Ad = "Lt", Grup = grup});
            await _dbContext.Birim.AddAsync(new Birim{ Id = 3, Ad = "Adet", Grup = grup});
            await _dbContext.Birim.AddAsync(new Birim{ Id = 4, Ad = "Demet", Grup = grup});
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
                    SecurityStamp = "secure",
                    EmailConfirmed = true,
                };

                await _userManager.CreateAsync(user, "3k0t0pluluk!");
                await _userManager.AddToRoleAsync(user, role);
            }
        }

        private async Task SeedRoles()
        {
            if (!await _roleManager.RoleExistsAsync(Roles.Default))
                await _roleManager.CreateAsync(new IdentityRole(Roles.Default));

            var adminRole = new IdentityRole(Roles.Administrator);
            if (!await _roleManager.RoleExistsAsync(Roles.Administrator))
            {
                await _roleManager.CreateAsync(adminRole);

                adminRole = await _roleManager.FindByNameAsync(adminRole.Name);

                foreach (var claim in ApplicationPermissions.GetAllPermissionValues())
                {
                    await _roleManager.AddClaimAsync(adminRole,
                        new Claim(CustomClaimTypes.Permission, ApplicationPermissions.GetPermissionByValue(claim)));
                }
            }
        }

        private async Task InitializeDatabase()
        {
            await _dbContext.Database.MigrateAsync().ConfigureAwait(false);
        }
    }
}