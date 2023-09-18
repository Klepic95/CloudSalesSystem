using Microsoft.AspNetCore.Mvc;

namespace CloudSalesSystem.Web.Controllers
{
    public abstract class BaseCSSController : ControllerBase
    {
        protected bool IsValidInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}