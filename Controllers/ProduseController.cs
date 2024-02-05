using Microsoft.AspNetCore.Mvc;
using proiect.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using proiect.Services.Implementations; 
using proiect.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using proiect.Data;

namespace proiect.Controllers
{
    
    public class ProduseController : Controller
    {
        private readonly IProductService _productService;

        private readonly AppDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public ProduseController(
            AppDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public ProduseController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _productService.GetAllAsync());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _productService.CreateAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productService.UpdateAsync(product);
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("ProductsByCategory")]
        public async Task<ActionResult> GetProductsGroupedByCategory() // groupby si select
        {
            var productsByCategory = (await _productService.GetAllAsync())
                .GroupBy(p => p.CategoryId)
                .Select(g => new { CategoryId = g.Key, Products = g.ToList() });

            return Ok(productsByCategory);
        }

        [HttpGet("ProductsWithDetails")]

        public async Task<ActionResult> GetProductsWithDetails()
        {
            var productsWithDetails = await _productService.GetProductsWithDetailsAsync();
            return Ok(productsWithDetails);
        }



    }
}
