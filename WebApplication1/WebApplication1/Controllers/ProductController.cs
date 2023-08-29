using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Linq;
using System.Collections;


namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : Controller
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



        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
