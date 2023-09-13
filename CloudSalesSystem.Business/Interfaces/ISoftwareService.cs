using CloudSalesSystem.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSalesSystem.Business.Interfaces
{
    public interface ISoftwareService
    {
        Task<IEnumerable<Software>> GetAllAvailableSoftwaresAsync();
        Task ChangeServiceQuantityAsync(int quantity, string subscriptionId, string softwareId);
        Task<Software> ExtendSoftwareLicenceAsync(string accountId, Software software, DateTime extendedDate);
    }
}
