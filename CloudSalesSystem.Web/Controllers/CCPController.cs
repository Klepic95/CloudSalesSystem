using CloudSalesSystem.Business.Models;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Software>>> GetAllAvailableSoftwaresAsync()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeServiceQuantity(int quantity, string subscriptionId, string softwareId)
        {
            return Ok();
        }
    }
}
