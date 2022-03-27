using Fashion_Friends_Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fashion_Friends_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    

    public class ProductControler : ControllerBase
    {

        private readonly DataContext _context;

        public ProductControler(DataContext context)
        {
            _context = context; 
        }
        // GET: api/<ProuctControler>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _context.products.Include(c=>c.Color).Include(s=>s.Size).ToListAsync());
        }

        // GET api/<ProuctControler>/5
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _context.products.FindAsync(id);

            if (product == null)
                return BadRequest("Product not found");
            return Ok(product);
        }

        // POST api/<ProuctControler>
        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(await _context.products.ToListAsync());
        }

        // PUT api/<ProuctControler>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProuctControler>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
