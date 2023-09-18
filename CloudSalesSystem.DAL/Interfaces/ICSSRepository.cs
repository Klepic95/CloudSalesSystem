using CloudSalesSystem.Shared.Models;

namespace CloudSalesSystem.DAL.Interfaces
{
    public interface ICSSRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(string accountId);
        Task<Software> GetSoftwareByCSSSoftwareIdAsync(int cssSoftwareId);
        Task SavePurchasedSoftwareByAccountAsync(string accountId, Software software);
        Task<IEnumerable<Software>> GetAllAccountSoftwaresAsync(string accountId);
        Task<Software> UpdateServiceQuantityAsync(string accountId, Software software, int quantity);
        Task<Software> CancelAccountSoftwareAsync(string accountId, Software software);
        Task<Software> ExtendSoftwareLicenceDateAsync(string accountId, Software software, DateTime newEndDate);
        Task<Account> InsertNewAccountAsync(string accountName);
    }
}