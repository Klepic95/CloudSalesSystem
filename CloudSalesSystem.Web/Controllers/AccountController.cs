using CloudSalesSystem.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllAccountsAsync()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Software>>> GetAllPurchasedSoftwaresAsync()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Software>> ExtendSoftwareLicence(string softwareId, DateTime extendedDate)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> CancelAccountSoftwareById(string accountId, string softwareId)
        {
            return Ok();
        }
    }
}
