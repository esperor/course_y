using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace course.Server.Data
{
    public class InsuranceCompanyContext : DbContext
    {
        public InsuranceCompanyContext(DbContextOptions<InsuranceCompanyContext> options) : base(options)
        {
            
        }

        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<InsuranceCase> InsuranceCases { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
               .HaveColumnType("date");
        }
    }

    public class DateOnlyConverter() : ValueConverter<DateOnly, DateTime>(d => d.ToDateTime(TimeOnly.MinValue),
        d => DateOnly.FromDateTime(d));
}
