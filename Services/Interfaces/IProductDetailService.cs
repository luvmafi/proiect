using proiect.Models;
using System.Threading.Tasks;

namespace proiect.Services.Interfaces
{
    public interface IProductDetailService
    {
        Task<ProductDetail> GetByIdAsync(int productId);
        Task CreateAsync(ProductDetail productDetail);
        Task UpdateAsync(ProductDetail productDetail);
        Task<bool> DeleteAsync(int id);
    }
}