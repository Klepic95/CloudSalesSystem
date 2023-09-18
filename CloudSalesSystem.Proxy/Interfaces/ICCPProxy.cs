using CloudSalesSystem.Shared.Models;

namespace CloudSalesSystem.Proxy.Interfaces
{
    public interface ICCPProxy
    {
        Task<IEnumerable<Software>> GetAllAvailableSoftwaresAsync();
        Task<Software> GetSoftwareByIdAsync(string softwareId);
        Task<Software> GetSoftwareByNameAsync(string softwareName);
        Task<Software> OrderSoftwareAsync(string softwareName);
        Task<Software> ChangeServiceQuantityAsync(string accountId, string softwareName, int quantity);
        Task<Software> CancelAccountSoftwareAsync(string accountId, string softwareName);
        Task<Software> ExtendSoftwareLicenceAsync(string accountId, string softwareName, DateTime endDate);
    }
}