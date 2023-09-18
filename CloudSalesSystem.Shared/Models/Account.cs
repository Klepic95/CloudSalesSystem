namespace CloudSalesSystem.Shared.Models
{
    public class Account
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }

        public Account()
        {
            
        }

        public Account(string accountId, string accountName)
        {
            AccountId = accountId;
            AccountName = accountName;
        }
    }
}