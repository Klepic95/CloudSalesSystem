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

        public async Task<Software> CancelAccountSoftwareByIdAsnyc(string accountId, string softwareName)
        {
            var software = await _proxy.CancelAccountSoftwareAsync(accountId, softwareName);
            return await _repository.CancelAccountSoftwareAsync(accountId, software);
            
        }

        public async Task<Software> ChangeServiceQuantityAsync(string accountId, string softwareName, int quantity)
        {
            var software = await _proxy.ChangeServiceQuantityAsync(accountId, softwareName, quantity);
            return await _repository.UpdateServiceQuantityAsync(accountId, software, quantity);
        }

        public async Task<Software> ExtendSoftwareLicenceAsync(string accountId, string softwareName, DateTime extendedDate)
        {
            var software = await _proxy.ExtendSoftwareLicenceAsync(accountId, softwareName, extendedDate);
            return await _repository.ExtendSoftwareLicenceDateAsync(accountId, software, extendedDate);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _repository.GetAllAccountsAsync();
        }

        public async Task<IEnumerable<Software>> GetAllAvailableSoftwaresAsync()
        {
            return await _proxy.GetAllAvailableSoftwaresAsync();
        }

        public async Task<IEnumerable<Software>> GetAllPurchasedSoftwaresAsync(string accountId)
        {
            return await _repository.GetAllAccountSoftwaresAsync(accountId);
        }

        public async Task<Account> InsertNewAccountAsync(string accountName)
        {
            return await _repository.InsertNewAccountAsync(accountName);
        }

        public async Task<Software> OrderSoftwareAsync(string accountId, string softwareName)
        {
            var software = await _proxy.OrderSoftwareAsync(softwareName);
            await _repository.SavePurchasedSoftwareByAccountAsync(accountId, software);
            return software;
        }
    }
}