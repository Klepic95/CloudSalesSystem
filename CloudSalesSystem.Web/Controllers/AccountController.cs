using CloudSalesSystem.Business;
using CloudSalesSystem.Business.Interfaces;
using CloudSalesSystem.Shared.Models;
using CloudSalesSystem.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CloudSalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseCSSController
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
            if (!IsValidInput(accountId))
            {
                return BadRequest("Invalid input parameters.");
            }

            return Ok(await _cSSService.GetAllPurchasedSoftwaresAsync(accountId));
        }

        [HttpPost("createNewAccount")]
        public async Task<ActionResult<Account>> CreateNewAccount(string accountName)
        {
            if (!IsValidInput(accountName))
            {
                return BadRequest("Invalid input parameters.");
            }

            return Ok(await _cSSService.InsertNewAccountAsync(accountName));
        }

        [HttpPut("extendSoftwareLicence")]
        public async Task<ActionResult<Software>> ExtendSoftwareLicence(string accountId, string softwareName, DateTime extendedDate)
        {
            if (!IsValidInput(accountId) || !IsValidInput(softwareName))
            {
                return BadRequest("Invalid input parameters.");
            }

            var result = await _cSSService.ExtendSoftwareLicenceAsync(accountId, softwareName, extendedDate);
            return Accepted("Software have been extended sucessfully", result);
        }

        [HttpPut("changeServiceQuantity")]
        public async Task<ActionResult<Software>> ChangeServiceQuantity(string accountId, string softwareName, int quantity)
        {
            if (!IsValidInput(accountId) || !IsValidInput(softwareName))
            {
                return BadRequest("Invalid input parameters.");
            }

            var result = await _cSSService.ChangeServiceQuantityAsync(accountId, softwareName, quantity);
            return Ok(result);

        }

        [HttpDelete("cancelAccountSoftware")]
        public async Task<IActionResult> CancelAccountSoftwareById(string accountId, string softwareName)
        {
            if (!IsValidInput(accountId) || !IsValidInput(softwareName))
            {
                return BadRequest("Invalid input parameters.");
            }

            var result = await _cSSService.CancelAccountSoftwareByIdAsnyc(accountId, softwareName);
            return Accepted("Software have been cancelled sucessfully", result);
        }
}
}
