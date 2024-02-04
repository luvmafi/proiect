using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using proiect.Data;
using proiect.Models;
using proiect.Services.Interfaces;

namespace proiect.Services.Implementations
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly AppDbContext _context;

        public OrderDetailService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<OrderDetail> GetByIdAsync(int orderId, int productId)
        {
            return await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderId == orderId && od.ProductId == productId);
        }
        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await _context.OrderDetails.Include(od => od.Product).ToListAsync();
        }
        public async Task<OrderDetail> GetDetailAsync(int orderId, int productId)
        {
            return await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderId == orderId && od.ProductId == productId);
        }

        public async Task CreateAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderId, int productId)
        {
            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderId == orderId && od.ProductId == productId);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
