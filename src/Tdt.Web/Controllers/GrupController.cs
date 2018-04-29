using Microsoft.AspNetCore.Mvc;
using Tdt.Web.Data;
using Tdt.Web.Data.Model;

namespace Tdt.Web.Controllers
{
    [Route("api/[controller]")]
    public class GrupController : Controller
    {
        private readonly TdtDbContext _dbContext;

        public GrupController(TdtDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// Sistemdeki tüm gruplar
        /// </summary>
        /// <returns>IList</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Grup[]), 200)]
        public IActionResult GetAll()
        {
            return null;
        }
        
        /// <summary>
        /// Id ile Grup
        /// </summary>
        /// <returns>Grup</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Grup), 200)]
        [ProducesResponseType(typeof(void), 404)]
        public IActionResult GetById(int id)
        {
            return null;
        }
        
        /// <summary>
        /// Grup ekle
        /// </summary>
        /// <returns>Grup</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Grup), 200)]
        public IActionResult Create(string ad)
        {
            return null;
        }
        
        /// <summary>
        /// Grup guncelle
        /// </summary>
        /// <returns>Grup</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Grup), 200)]
        public IActionResult Update(int id, string ad)
        {
            return null;
        }
        
        /// <summary>
        /// Grup sil
        /// </summary>
        /// <returns>Grup</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Grup), 200)]
        public IActionResult Delete(int id)
        {
            return null;
        }
        
        /// <summary>
        /// Grubun dagitim donemleri
        /// </summary>
        /// <returns>IList</returns>
        [HttpGet("{id}/Donem")]
        [ProducesResponseType(typeof(Grup[]), 200)]
        public IActionResult GetTerm(int id)
        {
            return null;
        }
        
        /// <summary>
        /// Grubun dagitim donemleri
        /// </summary>
        /// <returns>IList</returns>
        [HttpGet("{id}/Donem/{donemId}")]
        [ProducesResponseType(typeof(Urun[]), 200)]
        public IActionResult GetUrunler(int id, int donemId)
        {
            return null;
        }
    }
}