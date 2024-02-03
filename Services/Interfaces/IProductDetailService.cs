using proiect.Models;
using System.Threading.Tasks;


public interface IProductDetailService
{
    Task<ProductDetail> GetByIdAsync(int productId);
    Task CreateAsync(ProductDetail productDetail);
    Task UpdateAsync(ProductDetail productDetail);
    Task DeleteAsync(int productId);
}
