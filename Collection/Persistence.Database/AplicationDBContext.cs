using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Database.Configuration;

namespace Persistence.Database
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options) { }
        public DbSet<Debtor> Debtor { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private static void ModelConfig(ModelBuilder modelBuilder)
        {
            _ = new ConfigDebtor(modelBuilder.Entity<Debtor>());
        }
    }
}
