using ItemCounterAPI.Models;
using ItemCounterAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItemCounterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemCounterController : ControllerBase
    {
        private readonly ItemCounterService _counterService = new ItemCounterService();

        [HttpPost]
        public IActionResult CountItems([FromBody] ItemCountRequest request)
        {
            if (request.Items == null || request.Items.Count == 0)
                return BadRequest("List cannot be empty.");

            var result = _counterService.CountItems(request.Items);
            return Ok(result);
        }
    }
}
