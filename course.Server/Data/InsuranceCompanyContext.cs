using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<InsuranceType>().ToTable("InsuranceTypes");
            modelBuilder.Entity<InsuranceCase>().ToTable("InsuranceCases");
            modelBuilder.Entity<Agent>().ToTable("Agents");            
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Contract>().ToTable("Contracts");
        }
    }
}
