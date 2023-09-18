namespace CloudSalesSystem.Shared.Models
{
    public class Software
    {
        public string SoftwareId { get; set; }
        public string SoftwareName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCancelled { get; set; }

        public Software()
        {
               
        }

        public Software(string softwareId, string softwareName, int quantity, double price, DateTime endDate, bool isCancelled)
        {
            SoftwareId = softwareId;
            SoftwareName = softwareName;
            Quantity = quantity;
            Price = price;
            EndDate = endDate;
            IsCancelled = isCancelled;
        }
    }
}