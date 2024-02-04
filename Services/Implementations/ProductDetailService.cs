using Microsoft.EntityFrameworkCore;
using proiect.Models;
using System.Threading.Tasks;
using proiect.Data;
using proiect.Services.Interfaces;

namespace proiect.Services.Implementations
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly AppDbContext _context;

        public ProductDetailService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDetail> GetByIdAsync(int productId)
        {
            return await _context.ProductDetails
                .FirstOrDefaultAsync(pd => pd.ProductId == productId);
        }

        public async Task CreateAsync(ProductDetail productDetail)
        {
            _context.ProductDetails.Add(productDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDetail productDetail)
        {
            _context.ProductDetails.Update(productDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return false; 
            }

            _context.ProductDetails.Remove(productDetail);
            await _context.SaveChangesAsync();
            return true; 
        }

    }
}