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
        public async Task<ActionResult<IEnumerable<Software>>> GetAllAvailableSoftwares()
        {
            return Ok(await _cSSService.GetAllAvailableSoftwaresAsync());
        }

        [HttpPost("orderServiceLicence")]
        public async Task<ActionResult<Software>> OrderServiceLicence(string accountId, string softwareName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cSSService.OrderSoftwareAsync( accountId, softwareName);
            return Ok(result);

        }
    }
}
