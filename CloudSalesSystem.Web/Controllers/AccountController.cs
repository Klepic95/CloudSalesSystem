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

        [HttpGet("getAllAccounts")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllAccountsAsync()
        {
            return Ok();
        }

        [HttpGet("getAllPurchasedSoftwares")]
        public async Task<ActionResult<IEnumerable<Software>>> GetAllPurchasedSoftwaresAsync()
        {
            return Ok();
        }

        [HttpPost("createNewAccount")]
        public async Task<ActionResult<Account>> CreateNewAccount([FromBody] Account account)
        {
            return Ok();
        }

        [HttpPost("createNewAccountSoftware")]
        public async Task<ActionResult<Software>> CreateNewAccountSoftware(string accountId, [FromBody] Software software)
        {
            return Ok();
        }

        [HttpPut("extendSoftwareLicence")]
        public async Task<ActionResult<Software>> ExtendSoftwareLicence(string softwareId, DateTime extendedDate)
        {
            return Ok();
        }

        [HttpDelete("cancelAccountSoftware")]
        public async Task<IActionResult> CancelAccountSoftwareById(string accountId, string softwareId)
        {
            return Ok();
        }
    }
}
