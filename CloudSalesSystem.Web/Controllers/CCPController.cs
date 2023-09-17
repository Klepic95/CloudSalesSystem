using CloudSalesSystem.Business.Interfaces;
using CloudSalesSystem.Shared.Models;
using CloudSalesSystem.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCPController : BaseCSSController
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
    }
}
