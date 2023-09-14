using CloudSalesSystem.Proxy.Interfaces;
using CloudSalesSystem.Shared.Models;

namespace CloudSalesSystem.Proxy
{
    // Implementation of CCPProxy is completely mocked
    public class CCPProxy : ICCPProxy
    {
        public async Task CancelAccountSoftwareAsync(string accountId, string softwareId)
        {
             // Since CCPProxy is mocked, this method would actually not do anything here
        }

        public async Task<Software> ChangeServiceQuantityAsync(string softwareId, string accountId, int quantity)
        {
            var software = await GetSoftwareByIdAsync(softwareId);
            // In real service update quanity based on specific account
            software.Quantity = quantity;
            return await Task.FromResult(software);
        }

        public async Task<Software> ExtendSoftwareLicenceAsync(string accountId, string softwareName, DateTime endDate)
        {
            try
            {
                var software = await GetSoftwareByNameAsync(softwareName);
                if (software.EndDate < endDate)
                {
                    // Based on accoutId it will update date on CCP side
                    software.EndDate = endDate;
                }
                else
                {
                    throw new Exception("Provided date is less than current end date!");
                }
                return await Task.FromResult(software);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Software>> GetAllAvailableSoftwaresAsync()
        {
            return await Task.FromResult(GetSoftwares());
        }

        public async Task<Software> GetSoftwareByIdAsync(string softwareId)
        {
            Software software;
            try
            {
                software = GetSoftwares().FirstOrDefault(x => x.SoftwareId == softwareId);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            return await Task.FromResult(software);
        }

        public async Task<Software> GetSoftwareByNameAsync(string softwareName)
        {
            Software software;
            try
            {
                software = GetSoftwares().FirstOrDefault(x => x.SoftwareName == softwareName);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            return await Task.FromResult(software);
        }

        public async Task<Software> InsertNewSoftwareForAccountAsync(string accountId, string softwareName)
        {
            // This method is reponsible for creating/buying a software for specific account
            // Only neccessary logic is implemented right now, where other is mocked
            try
            {
                return await GetSoftwareByNameAsync(softwareName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Software> OrderSoftwareAsync(string softwareName)
        {
            Software software = await GetSoftwareByNameAsync(softwareName);
            return await Task.FromResult(software);
        }

        private IEnumerable<Software> GetSoftwares()
        {
            return new List<Software>()
            {
                new Software() { SoftwareId = "12345", SoftwareName= "Microsoft Office", EndDate = DateTime.UtcNow.AddMonths(6), Price = 15.00, Quantity = 1, IsCancelled = false },
                new Software() { SoftwareId = "12346", SoftwareName= "Music Player", EndDate = DateTime.UtcNow.AddMonths(6), Price = 4.70, Quantity = 1, IsCancelled = false },
                new Software() { SoftwareId = "12347", SoftwareName= "Microsoft AI", EndDate = DateTime.UtcNow.AddMonths(6), Price = 20.00, Quantity = 1, IsCancelled = false },
                new Software() { SoftwareId = "12348", SoftwareName= "Cloud Storage", EndDate = DateTime.UtcNow.AddMonths(6), Price = 25.00, Quantity = 1, IsCancelled = false },
                new Software() { SoftwareId = "12349", SoftwareName= "Virtual Machine", EndDate = DateTime.UtcNow.AddMonths(6), Price = 30.00, Quantity = 1, IsCancelled = false },
                new Software() { SoftwareId = "123410", SoftwareName= "Picture Editor", EndDate = DateTime.UtcNow.AddMonths(6), Price = 7.50, Quantity = 1, IsCancelled = false },
            };
        }
    }
}
