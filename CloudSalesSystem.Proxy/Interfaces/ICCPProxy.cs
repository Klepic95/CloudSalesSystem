using CloudSalesSystem.Business.Models;

namespace CloudSalesSystem.Proxy.Interfaces
{
    public interface ICCPProxy
    {
        Task<IEnumerable<Software>> GetAllAvailableSoftwaresAsync();
        Task<Software> GetSoftwareByIdAsync(string softwareId);
        Task<Software> GetSoftwareByNameAsync(string softwareName);
        Task<Software> OrderSoftwareAsync(Software software);
        Task<Software> ChangeServiceQuantityAsync(Software software, int quantity);
        Task CancelAccountSoftwareAsync(string accountId, string softwareId);
        Task<Software> ExtendSoftwareLicenceAsync(string accountId, Software software, DateTime endDate);
    }
}
