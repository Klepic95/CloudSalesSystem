using CloudSalesSystem.DAL.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.DAL
{
    public class CSSContext : DbContext
    {
        public DbSet<AccountDto> Account { get; set; }
        public DbSet<SoftwareDto> Software { get; set; }

        public CSSContext()
        {
            
        }

        public CSSContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionstring());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SoftwareConfiguration).Assembly);
        }

        private static string GetConnectionstring()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = "localhost,1433",
                UserID = "sa",
                Password = "cssPass1!",
                TrustServerCertificate = true,
            };
            return builder.ConnectionString;
        }
    }
}