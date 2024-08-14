using ECommerceApp.Models;
using ECommerceApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;


        public OrderItemsController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderItems = await _orderItemRepository.GetAllAsync();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            return Ok(orderItem);
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderItem orderItem)
        {
            await _orderItemRepository.AddAsync(orderItem);
            return CreatedAtAction(nameof(GetById), new { id = orderItem.Id }, orderItem);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return BadRequest();

            }
            await _orderItemRepository.UpdateAsync(orderItem);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderItemRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
