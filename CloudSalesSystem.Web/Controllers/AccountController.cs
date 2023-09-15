using CloudSalesSystem.Business;
using CloudSalesSystem.Business.Interfaces;
using CloudSalesSystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICSSService _cSSService;

        public AccountController(ICSSService cSSService)
        {
            _cSSService = cSSService;
        }

        [HttpGet("getAllAccounts")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllAccounts()
        {
            return Ok(await _cSSService.GetAllAccountsAsync());
        }

        [HttpGet("getAllPurchasedSoftwares")]
        public async Task<ActionResult<IEnumerable<Software>>> GetAllPurchasedSoftwares(string accountId)
        {
            return Ok(await _cSSService.GetAllPurchasedSoftwaresAsync(accountId));
        }

        [HttpPost("createNewAccount")]
        public async Task<ActionResult<Account>> CreateNewAccount(string accountName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _cSSService.InsertNewAccountAsync(accountName));
        }

        [HttpPut("extendSoftwareLicence")]
        public async Task<ActionResult<Software>> ExtendSoftwareLicence(string accountId, string softwareName, DateTime extendedDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cSSService.ExtendSoftwareLicenceAsync(accountId, softwareName, extendedDate);
            return Accepted("Software have been extended sucessfully", result);
        }

        [HttpPut("changeServiceQuantity")]
        public async Task<ActionResult<Software>> ChangeServiceQuantity(string accountId, string softwareName, int quantity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cSSService.ChangeServiceQuantityAsync(accountId, softwareName, quantity);
            return Ok(result);

        }

        [HttpDelete("cancelAccountSoftware")]
        public async Task<IActionResult> CancelAccountSoftwareById(string accountId, string softwareName)
        {
            var result = await _cSSService.CancelAccountSoftwareByIdAsnyc(accountId, softwareName);
            return Accepted("Software have been cancelled sucessfully", result);
        }
    }
}
