using System.Linq;
using gtsiparis.Data;
using gtsiparis.Data.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace gtsiparis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            SeedData(host);
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        
        public static void SeedData(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TdtDbContext>();
        
                if (context.Grup.Any()) return;
                
                var grup = CreateGrup(context);
                CreateBirim(context, grup);
                CreateKategori(context, grup);

                context.SaveChanges();
            }
        }

        private static void CreateKategori(TdtDbContext context, Grup grup)
        {
            var kategori = new Kategori
            {
                Id = 1,
                Ad = "Meyve",
                Aktif = true,
                Grup = grup
            };

            context.Kategori.Add(kategori);
        }

        private static Grup CreateGrup(TdtDbContext context)
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
            
            context.Grup.Add(grup);

            return grup;
        }

        private static void CreateBirim(TdtDbContext context, Grup grup)
        {
            context.Birim.Add(new Birim{ Id = 1, Ad = "Kg", Grup = grup});
        }
    }
}