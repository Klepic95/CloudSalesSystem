using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudSalesSystem.DAL.DTOs
{
    public class AccountDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }

        public ICollection<SoftwareDto> AccountSoftwares { get; set; }

        public AccountDto()
        {
            AccountSoftwares = new List<SoftwareDto>();
        }

        public AccountDto(string accountId, string accountName)
        {
            AccountId = accountId;
            AccountName = accountName;
            AccountSoftwares = new List<SoftwareDto>();
        }
    }

    public class AccountConfiguration : IEntityTypeConfiguration<AccountDto> 
    {
        public void Configure(EntityTypeBuilder<AccountDto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.AccountName).IsRequired();
            builder.HasMany(x => x.AccountSoftwares).WithOne(x => x.Account).HasForeignKey(x => x.AccountRefId);
        }
    }
}

