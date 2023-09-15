using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudSalesSystem.DAL.DTOs
{
    public class SoftwareDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SoftwareId { get; set; }
        public string SoftwareName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCancelled { get; set; } = true;

        public string AccountRefId { get; set; }
        public AccountDto Account { get; set; }

        public SoftwareDto()
        {
            Account = new AccountDto();
        }

        public SoftwareDto(string softwareId, string softwareName, int quantity, double price, DateTime endDate, bool isCancelled, string accountRefId)
        {
            SoftwareId = softwareId;
            SoftwareName = softwareName;
            Quantity = quantity;
            Price = price;
            EndDate = endDate;
            IsCancelled = isCancelled;
            AccountRefId = accountRefId;
        }
    }

    public class SoftwareConfiguration: IEntityTypeConfiguration<SoftwareDto>
    {
        public void Configure(EntityTypeBuilder<SoftwareDto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SoftwareId).IsRequired();
            builder.Property(x => x.SoftwareName).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.HasOne(x => x.Account).WithMany(x => x.AccountSoftwares).HasForeignKey(x => x.AccountRefId).IsRequired();
        }
    }
}
