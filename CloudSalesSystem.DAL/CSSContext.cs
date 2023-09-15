using CloudSalesSystem.DAL.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CloudSalesSystem.DAL
{
    public class CSSContext : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<AccountDto> Account { get; set; }
        public DbSet<SoftwareDto> Software { get; set; }

        public CSSContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CSSContext(IConfiguration configuration, DbContextOptions options): base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SoftwareConfiguration).Assembly);
        }
    }
}
