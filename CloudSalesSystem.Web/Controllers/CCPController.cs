using CloudSalesSystem.Business.Interfaces;
using CloudSalesSystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCPController : ControllerBase
    {
        private readonly ICSSService _cSSService;
        public CCPController(ICSSService cSSService)
        {
            _cSSService = cSSService;
        }

        [HttpGet("getAllAvailableSoftwares")]
        public async Task<ActionResult<IEnumerable<Software>>> GetAllAvailableSoftwaresAsync()
        {
            return Ok(await _cSSService.GetAllAvailableSoftwaresAsync());
        }

        [HttpPut("changeServiceQuantity")]
        public async Task<ActionResult<Software>> ChangeServiceQuantity(int quantity, string accountId, string softwareId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cSSService.ChangeServiceQuantityAsync(softwareId, accountId, quantity);
            return Ok(result);

        }
    }
}
