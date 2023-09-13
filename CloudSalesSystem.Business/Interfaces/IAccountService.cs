using CloudSalesSystem.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSalesSystem.Business.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<IEnumerable<Software>> GetAllPurchasedSoftwaresAsync();
        Task CancelAccountSoftwareByIdAsnyc(string accountId, string softwareId);
    }
}
