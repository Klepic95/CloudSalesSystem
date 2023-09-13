using CloudSalesSystem.Business.Models;
using CloudSalesSystem.Proxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSalesSystem.Proxy
{
    // Implementation of CCPProxy is completely mocked
    public class CCPProxy : ICCPProxy
    {
        public async Task CancelAccountSoftwareAsync(string accountId, string softwareId)
        {
             
        }

        public async Task<Software> ChangeServiceQuantityAsync(Software software, int quantity)
        {
            software.Quantity = quantity;
            return await Task.FromResult(software);
        }

        public async Task<Software> ExtendSoftwareLicenceAsync(string accountId, Software software, DateTime endDate)
        {
            try
            {
                if (software.EndDate < endDate)
                {
                    // Based on accoutId it will update date on CCP side
                    software.EndDate = endDate;
                }
                else
                {
                    throw new Exception("Provided date is less than current end date!");
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return await Task.FromResult(software);
        }

        public async Task<IEnumerable<Software>> GetAllAvailableSoftwaresAsync()
        {
            var softwares = new List<Software>()
            {
                new Software() { SoftwareId = "12345", SoftwareName= "Microsoft Office", EndDate = DateTime.MaxValue, Price = 15.00, Quantity = 1, IsCancelled = false },
                new Software() { SoftwareId = "12346", SoftwareName= "Music Player", EndDate = DateTime.MaxValue, Price = 4.70, Quantity = 1, IsCancelled = false },
                new Software() { SoftwareId = "12347", SoftwareName= "Microsoft AI", EndDate = DateTime.MaxValue, Price = 20.00, Quantity = 1, IsCancelled = false },
                new Software() { SoftwareId = "12348", SoftwareName= "Cloud Storage", EndDate = DateTime.MaxValue, Price = 25.00, Quantity = 1, IsCancelled = false },
                new Software() { SoftwareId = "12349", SoftwareName= "Virtual Machine", EndDate = DateTime.MaxValue, Price = 30.00, Quantity = 1, IsCancelled = false },
                new Software() { SoftwareId = "123410", SoftwareName= "Picture Editor", EndDate = DateTime.MaxValue, Price = 7.50, Quantity = 1, IsCancelled = false },
            };


            return await Task.FromResult(softwares);
        }

        public async Task<Software> OrderSoftwareAsync(Software software)
        {
            return await Task.FromResult(software);
        }
    }
}
