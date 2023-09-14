using CloudSalesSystem.Shared.Models;

namespace CloudSalesSystem.DAL.Interfaces
{
    public interface ICSSRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(string accountId);
        Task SavePurchasedSoftwareByAccountAsync(string accountId, Software software);
        Task<IEnumerable<Software>> GetAllAccountSoftwaresAsync(string accountId);
        Task UpdateServiceQuantityAsync(string softwareId, int quantityToUpdate);
        Task<Software> CancelAccountSoftwareAsync(string accountId, string softwareId);
        Task<Software> ExtendSoftwareLicenceDateAsync(string accountId, string softwareId, DateTime newEndDate);
        Task<Software> InsertNewAccountSoftwareAsync(string accountId, Software software);
        Task<Account> InsertNewAccountAsync(Account account);
    }
}
