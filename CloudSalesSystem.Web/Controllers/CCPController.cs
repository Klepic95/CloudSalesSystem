using CloudSalesSystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCPController : ControllerBase
    {
        public CCPController()
        {
            
        }

        [HttpGet("getAllAvailableSoftwares")]
        public async Task<ActionResult<IEnumerable<Software>>> GetAllAvailableSoftwaresAsync()
        {
            return Ok();
        }

        [HttpPut("changeServiceQuantity")]
        public async Task<IActionResult> ChangeServiceQuantity(int quantity, string subscriptionId, string softwareId)
        {
            return Ok();
        }
    }
}
