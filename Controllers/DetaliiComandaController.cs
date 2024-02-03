using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using proiect.Models;
using proiect.Services;

[Route("api/[controller]")]
[ApiController]
public class DetaliiComandaController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;

    public DetaliiComandaController(IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
    }

    // GET: api/OrderDetails
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
    {
        return Ok(await _orderDetailService.GetAllAsync());
    }

    // GET: api/OrderDetails/5
    [HttpGet("{orderId}/{productId}")]
    public async Task<ActionResult<OrderDetail>> GetOrderDetail(int orderId, int productId)
    {
        var orderDetail = await _orderDetailService.GetByIdAsync(orderId, productId);

        if (orderDetail == null)
        {
            return NotFound();
        }

        return orderDetail;
    }

    // POST: api/OrderDetails
    [HttpPost]
    public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
    {
        await _orderDetailService.CreateAsync(orderDetail);
        return CreatedAtAction(nameof(GetOrderDetail), new { orderId = orderDetail.OrderId, productId = orderDetail.ProductId }, orderDetail);
    }

    // PUT: api/OrderDetails/5/1
    [HttpPut("{orderId}/{productId}")]
    public async Task<IActionResult> PutOrderDetail(int orderId, int productId, OrderDetail orderDetail)
    {
        if (orderId != orderDetail.OrderId || productId != orderDetail.ProductId)
        {
            return BadRequest();
        }

        await _orderDetailService.UpdateAsync(orderDetail);
        return NoContent();
    }

    // DELETE: api/OrderDetails/5/1
    [HttpDelete("{orderId}/{productId}")]
    public async Task<IActionResult> DeleteOrderDetail(int orderId, int productId)
    {
        var orderDetail = await _orderDetailService.GetByIdAsync(orderId, productId);
        if (orderDetail == null)
        {
            return NotFound();
        }

        await _orderDetailService.DeleteAsync(orderDetail);
        return NoContent();
    }
}
