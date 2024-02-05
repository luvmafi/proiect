using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using proiect.Models;
using proiect.Services.Implementations;
using proiect.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using proiect.Data;

namespace proiect.Controllers
{
    
    public class DetaliiComandaController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;

        private readonly AppDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public DetaliiComandaController(
            AppDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
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
            var orderDetail = await _orderDetailService.GetByIdAsync(orderId, productId); // group  by sau where

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
        
        [HttpDelete("{orderId}/{productId}")]
        public async Task<IActionResult> DeleteOrderDetail(int orderId, int productId)
        {
            await _orderDetailService.DeleteAsync(orderId, productId); // Asigură-te că ambele parametri sunt furnizați
            return NoContent();
        }


    }
}