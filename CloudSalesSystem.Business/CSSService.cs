using CloudSalesSystem.Business.Interfaces;
using CloudSalesSystem.DAL.Interfaces;
using CloudSalesSystem.Proxy.Interfaces;
using CloudSalesSystem.Shared.Models;

namespace CloudSalesSystem.Business
{
    public class CSSService : ICSSService
    {
        private readonly ICCPProxy _proxy;
        private readonly ICSSRepository _repository;

        public CSSService(ICCPProxy proxy, ICSSRepository repository)
        {
            _proxy = proxy;
            _repository = repository;
        }

        public async Task<Software> CancelAccountSoftwareByIdAsnyc(string accountId, string softwareId)
        {
            throw new NotImplementedException();
        }

        public Task ChangeServiceQuantityAsync(string softwareId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<Software> ExtendSoftwareLicenceAsync(string accountId, string softwareName, DateTime extendedDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Software>> GetAllAvailableSoftwaresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Software>> GetAllPurchasedSoftwaresAsync(string accountId)
        {
            throw new NotImplementedException();
        }

        public Task<Account> InsertNewAccountAsync(string accountName)
        {
            throw new NotImplementedException();
        }

        public Task<Software> InsertNewAccountSoftwareAsync(string accountId, string softwareName)
        {
            throw new NotImplementedException();
        }

        public Task<Software> OrderSoftwareAsync(string accountId, string softwareName)
        {
            throw new NotImplementedException();
        }
    }
}
