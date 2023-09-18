using CloudSalesSystem.Business;
using CloudSalesSystem.DAL.Interfaces;
using CloudSalesSystem.Proxy.Interfaces;
using CloudSalesSystem.Shared.Models;
using Moq;

namespace YourUnitTestProjectNamespace
{
    [TestClass]
    public class CSSServiceTests
    {
        private Mock<ICCPProxy> proxyMock;
        private Mock<ICSSRepository> repositoryMock;

        private CSSService cssService;

        [TestInitialize]
        public void Initialize()
        {
            proxyMock = new Mock<ICCPProxy>();
            repositoryMock = new Mock<ICSSRepository>();
            cssService = new CSSService(proxyMock.Object, repositoryMock.Object);
        }

        [TestMethod]
        public async Task OrderSoftwareAsync_WhenCalled_ShouldReturnSoftware()
        {
            string accountId = "account123";
            string softwareName = "software123";
            var expectedSoftware = new Software { SoftwareName = softwareName };

            proxyMock.Setup(mock => mock.OrderSoftwareAsync(softwareName))
                .ReturnsAsync(expectedSoftware);

            repositoryMock.Setup(mock => mock.SavePurchasedSoftwareByAccountAsync(accountId, expectedSoftware))
                .Returns(Task.CompletedTask);

            var result = await cssService.OrderSoftwareAsync(accountId, softwareName);

            Assert.AreEqual(expectedSoftware, result);
        }

        [TestMethod]
        public async Task GetAllAccountsAsync_WhenCalled_ShouldReturnAccounts()
        {
            var expectedAccounts = new List<Account>
            {
                new Account { AccountId = "account1", AccountName = "Account 1" },
                new Account { AccountId = "account2", AccountName = "Account 2" }
            };

            repositoryMock.Setup(mock => mock.GetAllAccountsAsync())
                .ReturnsAsync(expectedAccounts);

            var result = await cssService.GetAllAccountsAsync();

            CollectionAssert.AreEqual(expectedAccounts.ToList(), result.ToList());
        }

        [TestMethod]
        public async Task CancelAccountSoftwareByIdAsnyc_WhenCalled_ShouldReturnSoftware()
        {
            string accountId = "account123";
            string softwareName = "software123";
            var expectedSoftware = new Software { SoftwareName = softwareName };

            proxyMock.Setup(mock => mock.CancelAccountSoftwareAsync(accountId, softwareName))
                .ReturnsAsync(expectedSoftware);

            repositoryMock.Setup(mock => mock.CancelAccountSoftwareAsync(accountId, expectedSoftware))
                .ReturnsAsync(expectedSoftware);

            var result = await cssService.CancelAccountSoftwareByIdAsnyc(accountId, softwareName);

            Assert.AreEqual(expectedSoftware, result);
        }

        [TestMethod]
        public async Task ChangeServiceQuantityAsync_WhenCalled_ShouldReturnSoftware()
        {
            string accountId = "account123";
            string softwareName = "software123";
            int quantity = 5;
            var expectedSoftware = new Software { SoftwareName = softwareName };

            proxyMock.Setup(mock => mock.ChangeServiceQuantityAsync(accountId, softwareName, quantity))
                .ReturnsAsync(expectedSoftware);

            repositoryMock.Setup(mock => mock.UpdateServiceQuantityAsync(accountId, expectedSoftware, quantity))
                .ReturnsAsync(expectedSoftware);

            var result = await cssService.ChangeServiceQuantityAsync(accountId, softwareName, quantity);

            Assert.AreEqual(expectedSoftware, result);
        }

        [TestMethod]
        public async Task ExtendSoftwareLicenceAsync_WhenCalled_ShouldReturnSoftware()
        {
            string accountId = "account123";
            string softwareName = "software123";
            DateTime extendedDate = DateTime.Now.AddMonths(1);
            var expectedSoftware = new Software { SoftwareName = softwareName };

            proxyMock.Setup(mock => mock.ExtendSoftwareLicenceAsync(accountId, softwareName, extendedDate))
                .ReturnsAsync(expectedSoftware);

            repositoryMock.Setup(mock => mock.ExtendSoftwareLicenceDateAsync(accountId, expectedSoftware, extendedDate))
                .ReturnsAsync(expectedSoftware);

            var result = await cssService.ExtendSoftwareLicenceAsync(accountId, softwareName, extendedDate);

            Assert.AreEqual(expectedSoftware, result);
        }

        [TestMethod]
        public async Task GetAllAvailableSoftwaresAsync_WhenCalled_ShouldReturnListOfSoftware()
        {
            var expectedSoftwares = new List<Software>
            {
            new Software { SoftwareName = "Software1" },
            new Software { SoftwareName = "Software2" }
            };

            proxyMock.Setup(mock => mock.GetAllAvailableSoftwaresAsync())
                .ReturnsAsync(expectedSoftwares);

            var result = await cssService.GetAllAvailableSoftwaresAsync();

            CollectionAssert.AreEqual(expectedSoftwares.ToList(), result.ToList());
        }

        [TestMethod]
        public async Task GetAllPurchasedSoftwaresAsync_WhenCalledWithValidAccountId_ShouldReturnListOfSoftware()
        {
            string accountId = "account123";
            var expectedPurchasedSoftwares = new List<Software>
            {
            new Software { SoftwareName = "PurchasedSoftware1" },
            new Software { SoftwareName = "PurchasedSoftware2" }
            };

            repositoryMock.Setup(mock => mock.GetAllAccountSoftwaresAsync(accountId))
                .ReturnsAsync(expectedPurchasedSoftwares);

            var result = await cssService.GetAllPurchasedSoftwaresAsync(accountId);

            CollectionAssert.AreEqual(expectedPurchasedSoftwares.ToList(), result.ToList());
        }

        [TestMethod]
        public async Task GetAllPurchasedSoftwaresAsync_WhenCalledWithInvalidAccountId_ShouldReturnEmptyList()
        {
            string accountId = "nonExistentAccount";

            repositoryMock.Setup(mock => mock.GetAllAccountSoftwaresAsync(accountId))
                .ReturnsAsync(new List<Software>());

            var result = await cssService.GetAllPurchasedSoftwaresAsync(accountId);

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public async Task InsertNewAccountAsync_WhenCalledWithValidName_ShouldReturnNewAccount()
        {
            string accountName = "NewAccount";
            var expectedAccount = new Account { AccountName = accountName };

            repositoryMock.Setup(mock => mock.InsertNewAccountAsync(accountName))
                .ReturnsAsync(expectedAccount);

            var result = await cssService.InsertNewAccountAsync(accountName);

            Assert.AreEqual(expectedAccount, result);
        }
    }
}