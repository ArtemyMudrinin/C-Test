using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ProductController(ApplicationContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IEnumerable GetAll()
        {
            return _context.Product_Mudrinin.ToList();
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(int id)
        {
            var item = _context.Product_Mudrinin.FirstOrDefault(t => t.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            Product product = new Product { firstName = item.firstName, lastName = item.lastName, middleName = item.middleName, workplace = item.workplace };
            _context.Product_Mudrinin.Add(product);
            _context.SaveChanges();
            return new NoContentResult();
        }
  
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Product item)
        {
            if (item == null || item.ID != id)
            {
                return BadRequest();
            }

            var product = _context.Product_Mudrinin.FirstOrDefault(t => t.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            product.firstName = item.firstName;
            product.lastName = item.lastName;
            product.middleName = item.middleName;
            product.workplace = item.workplace;
            _context.Product_Mudrinin.Update(product);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var product = _context.Product_Mudrinin.FirstOrDefault(t => t.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product_Mudrinin.Remove(product);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

