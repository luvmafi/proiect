using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using YourNamespace.Data;
using YourNamespace.Models;

public class OrderDetailService : IOrderDetailService
{
    private readonly AppDbContext _context;

    public OrderDetailService(AppDbContext context)
    {
        _context = context;
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
