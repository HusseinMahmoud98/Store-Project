using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Contract;
using Store.Shared.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.Presentation
{
    // create order
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(IServiceManager _serviceManager) : ControllerBase
    {
        //create order
        [HttpPost] //POST: BaseUrl/api/orders
        [Authorize]
        public async Task<IActionResult> CreateOrder(OrderRequest orderRequest)
        {
            var userEmailClaim = User.FindFirst(ClaimTypes.Email);
            var result = await _serviceManager.OrderService.CreateOrderAsync(orderRequest, userEmailClaim.Value);
            return Ok(result);
        }

        //get all delievery methods
        [HttpGet("deliveryMethods")]  //POST: BaseUrl/api/orders/deliverymethod
        public async Task<IActionResult> GetAllDeliveryMethods()
        {
            var result = await _serviceManager.OrderService.GetAllDeliveryMethodsAsync();
            return Ok(result);
        }

        //Get order for specific user
        [HttpGet]  //POST: BaseUrl/api/orders
        [Authorize]
        public async Task<IActionResult?> GetOrderForSpecificUser()
        {
            var userEmailClaim = User.FindFirst(ClaimTypes.Email);
            var result = await _serviceManager.OrderService.GetOrderForSpecificUserAsync(userEmailClaim.Value);
            return Ok(result);
        }

        //Get order for specific user by Id
        [HttpGet("{id}")]  //POST: BaseUrl/api/id
        [Authorize]
        public async Task<IActionResult?> GetOrderForSpecificUserById(Guid id)
        {
            var userEmailClaim = User.FindFirst(ClaimTypes.Email);
            var result = await _serviceManager.OrderService.GetOrderByIdForSpecificUserAsync(id, userEmailClaim.Value);
            return Ok(result);
        }
    }
}
