using proiect.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proiect.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);

        Task<IEnumerable<ProductWithDetailsDto>> GetProductsWithDetailsAsync();
        Task DeleteAsync(int id);
    }
}