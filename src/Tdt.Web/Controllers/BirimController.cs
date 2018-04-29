using gtsiparis.Data;
using gtsiparis.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace gtsiparis.Controllers
{
    [Route("api/[controller]")]
    public class BirimController : Controller
    {
        private readonly TdtDbContext _dbContext;

        public BirimController(TdtDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// Sistemdeki tüm birimler
        /// </summary>
        /// <returns>IList</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Birim[]), 200)]
        public IActionResult GetAll()
        {
            return null;
        }
        
        /// <summary>
        /// Id ile Birim
        /// </summary>
        /// <returns>Birim</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Birim), 200)]
        [ProducesResponseType(typeof(void), 404)]
        public IActionResult GetById(int id)
        {
            return null;
        }
        
        /// <summary>
        /// Birim ekle
        /// </summary>
        /// <returns>Birim</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Birim), 200)]
        public IActionResult Create(string ad)
        {
            return null;
        }
        
        /// <summary>
        /// Birim guncelle
        /// </summary>
        /// <returns>Birim</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Birim), 200)]
        public IActionResult Update(int id, string ad)
        {
            return null;
        }
        
        /// <summary>
        /// Birim sil
        /// </summary>
        /// <returns>Birim</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Birim), 200)]
        public IActionResult Delete(int id)
        {
            return null;
        }
    }
}