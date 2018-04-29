using Microsoft.AspNetCore.Mvc;
using Tdt.Web.Data;
using Tdt.Web.Data.Model;

namespace Tdt.Web.Controllers
{
    [Route("api/[controller]")]
    public class KategoriController : Controller
    {
        private readonly TdtDbContext _dbContext;

        public KategoriController(TdtDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// Sistemdeki tüm kategoriler
        /// </summary>
        /// <returns>IList</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Kategori[]), 200)]
        public IActionResult GetAll()
        {
            return null;
        }
        
        /// <summary>
        /// Id ile Kategori
        /// </summary>
        /// <returns>Kategori</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Kategori), 200)]
        [ProducesResponseType(typeof(void), 404)]
        public IActionResult GetById(int id)
        {
            return null;
        }
        
        /// <summary>
        /// Kategori ekle
        /// </summary>
        /// <returns>Kategori</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Kategori), 200)]
        public IActionResult Create(string ad)
        {
            return null;
        }
        
        /// <summary>
        /// Kategori guncelle
        /// </summary>
        /// <returns>Kategori</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Kategori), 200)]
        public IActionResult Update(int id, string ad)
        {
            return null;
        }
        
        /// <summary>
        /// Kategori sil
        /// </summary>
        /// <returns>Kategori</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Kategori), 200)]
        public IActionResult Delete(int id)
        {
            return null;
        }
    }
}