using CloudSalesSystem.Shared.Models;

namespace CloudSalesSystem.DAL.Interfaces
{
    public interface ICSSRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(string accountId);
        Task SavePurchasedSoftwareByAccountAsync(string accountId, Software software);
        Task<IEnumerable<Software>> GetAllAccountSoftwaresAsync(string accountId);
        Task<Software> UpdateServiceQuantityAsync(string softwareId, string accountId, int quantity);
        Task<Software> CancelAccountSoftwareAsync(string accountId, string softwareId);
        Task<Software> ExtendSoftwareLicenceDateAsync(string accountId, Software software, DateTime newEndDate);
        Task<Software> InsertNewAccountSoftwareAsync(string accountId, Software software);
        Task<Account> InsertNewAccountAsync(Account account);
    }
}
