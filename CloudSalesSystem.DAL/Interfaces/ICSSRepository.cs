using CloudSalesSystem.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSalesSystem.DAL.Interfaces
{
    public interface ICSSRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(string accountId);
        Task SavePurchasedSoftwareByAccountAsync(string accountId, Software software);
        Task<IEnumerable<Software>> GetAllAccountSoftwaresAsync(string accountId);
        Task UpdateServiceQuantityAsync(int quantityToUpdate);
        Task<Software> CancelAccountSoftwareAsync(string accountId, Software software);
        Task<Software> ExtendSoftwareLicenceDateAsync(string accountId, Software software);
    }
}
