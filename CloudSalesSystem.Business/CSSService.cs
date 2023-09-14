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
            await _proxy.CancelAccountSoftwareAsync(accountId, softwareId);
            return await _repository.CancelAccountSoftwareAsync(accountId, softwareId);
            
        }

        public async Task<Software> ChangeServiceQuantityAsync(string softwareId, string accountId, int quantity)
        {
            await _proxy.ChangeServiceQuantityAsync(softwareId, accountId, quantity);
            return await _repository.UpdateServiceQuantityAsync(softwareId, accountId, quantity);
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

        public async Task<Account> InsertNewAccountAsync(Account account)
        {
            return await _repository.InsertNewAccountAsync(account);
        }

        public async Task<Software> InsertNewAccountSoftwareAsync(string accountId, Software software)
        {
            await _proxy.InsertNewSoftwareForAccountAsync(accountId, software);
            return await _repository.InsertNewAccountSoftwareAsync(accountId, software);
        }

        public async Task<Software> OrderSoftwareAsync(string accountId, string softwareName)
        {
            var software = await _proxy.OrderSoftwareAsync(softwareName);
            await _repository.SavePurchasedSoftwareByAccountAsync(accountId, software);
            return software;
        }
    }
}
