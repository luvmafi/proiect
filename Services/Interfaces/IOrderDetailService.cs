using System.Threading.Tasks;
using proiect.Models;

namespace proiect.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task<OrderDetail> GetByIdAsync(int orderId, int productId);
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<OrderDetail> GetDetailAsync(int orderId, int productId);
        Task CreateAsync(OrderDetail orderDetail);
        Task UpdateAsync(OrderDetail orderDetail);
        Task DeleteAsync(int orderId, int productId);

    }
}