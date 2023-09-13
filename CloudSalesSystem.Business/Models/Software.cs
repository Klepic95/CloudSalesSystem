namespace CloudSalesSystem.Business.Models
{
    public class Software
    {
        public string SoftwareId { get; set; }
        public string SoftwareName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCancelled { get; set; }
    }
}
