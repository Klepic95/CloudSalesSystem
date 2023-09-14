using CloudSalesSystem.Shared.Models;

namespace CloudSalesSystem.Proxy.Interfaces
{
    public interface ICCPProxy
    {
        Task<IEnumerable<Software>> GetAllAvailableSoftwaresAsync();
        Task<Software> GetSoftwareByIdAsync(string softwareId);
        Task<Software> GetSoftwareByNameAsync(string softwareName);
        Task<Software> OrderSoftwareAsync(string softwareName);
        Task<Software> ChangeServiceQuantityAsync(string softwareId, string accountId, int quantity);
        Task CancelAccountSoftwareAsync(string accountId, string softwareId);
        Task<Software> ExtendSoftwareLicenceAsync(string accountId, string softwareName, DateTime endDate);
        Task<Software> InsertNewSoftwareForAccountAsync(string accountId, string softwareName);
    }
}
