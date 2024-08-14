using ECommerceApp.Models;
using ECommerceApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderRepository.GetAllAsync();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            await _orderRepository.AddAsync(order);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            await _orderRepository.UpdateAsync(order);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
