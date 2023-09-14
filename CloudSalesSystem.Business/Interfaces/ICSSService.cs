using CloudSalesSystem.Shared.Models;

namespace CloudSalesSystem.Business.Interfaces
{
    public interface ICSSService
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<IEnumerable<Software>> GetAllAvailableSoftwaresAsync();
        Task<Software> OrderSoftwareAsync(string accountId, string softwareName);
        Task<IEnumerable<Software>> GetAllPurchasedSoftwaresAsync(string accountId);
        Task ChangeServiceQuantityAsync(string softwareId, int quantity);
        Task<Software> CancelAccountSoftwareByIdAsnyc(string accountId, string softwareId);
        Task<Software> ExtendSoftwareLicenceAsync(string accountId, string softwareName, DateTime extendedDate);
        Task<Account> InsertNewAccountAsync(string accountName);
        Task<Software> InsertNewAccountSoftwareAsync(string accountId, string softwareName);
    }
}
