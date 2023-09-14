using CloudSalesSystem.Business.Models;
using CloudSalesSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSalesSystem.DAL
{
    public class CSSRepository : ICSSRepository
    {
        public Task<Software> CancelAccountSoftwareAsync(string accountId, Software software)
        {
            throw new NotImplementedException();
        }

        public Task<Software> ExtendSoftwareLicenceDateAsync(string accountId, Software software)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByIdAsync(string accountId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Software>> GetAllAccountSoftwaresAsync(string accountId)
        {
            throw new NotImplementedException();
        }

        public Task SavePurchasedSoftwareByAccountAsync(string accountId, Software software)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServiceQuantityAsync(int quantityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
