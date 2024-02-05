using Microsoft.AspNetCore.Mvc;
using proiect.Models;
using System.Threading.Tasks;
using proiect.Services.Implementations;
using proiect.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using proiect.Data;

namespace proiect.Controllers
{
    
    public class DetaliiProduseController : Controller
    {
        private readonly AppDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public DetaliiProduseController(
            AppDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        private readonly IProductDetailService _productDetailService;

        public DetaliiProduseController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        // GET: api/ProductDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetail>> GetProductDetail(int id)
        {
            var productDetail = await _productDetailService.GetByIdAsync(id);

            if (productDetail == null)
            {
                return NotFound();
            }

            return productDetail;
        }

        // POST: api/ProductDetails
        [HttpPost]
        public async Task<ActionResult<ProductDetail>> PostProductDetail(ProductDetail productDetail)
        {
            await _productDetailService.CreateAsync(productDetail);
            return CreatedAtAction(nameof(GetProductDetail), new { id = productDetail.ProductId }, productDetail);
        }

        // PUT: api/ProductDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetail(int id, ProductDetail productDetail)
        {
            if (id != productDetail.ProductId)
            {
                return BadRequest();
            }

            await _productDetailService.UpdateAsync(productDetail);
            return NoContent();
        }

        // DELETE: api/ProductDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(int id)
        {
            var success = await _productDetailService.DeleteAsync(id); 
            if (!success) 
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}