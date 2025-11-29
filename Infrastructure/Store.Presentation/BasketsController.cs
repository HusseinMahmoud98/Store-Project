using Microsoft.AspNetCore.Mvc;
using Store.Domain.Contract;
using Store.Shared.Dtos.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketsController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet] //Get: baseUrl/api/baskets?id
        public async Task<IActionResult> GetBasketById(string id)
        {
            var result = await _serviceManager.BasketService.GetBasketAsync(id);
            return Ok(result);
        }

        [HttpPost] //Post: BaseUrl/api/baskets
        public async Task<IActionResult> CreateOrUpdateBasket(BasketDto basketDto)
        {
            var result = await _serviceManager.BasketService.CreateBasketAsync(basketDto,  TimeSpan.FromDays(1));
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasketById(string id)
        {
            var result = await _serviceManager.BasketService.DeleteBasketAsync(id);
            return NoContent(); //204
        }


    }
}
