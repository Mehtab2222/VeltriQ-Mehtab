using Microsoft.EntityFrameworkCore;
using VeltriQ.Models.Core;
using VeltriQ.Models.Master;

namespace VeltriQ.Data
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext
        (
            DbContextOptions<MasterDbContext> options
        )
            : base(options)
        {
        }

        public DbSet<MasterCompany> Companies { get; set; }

        public DbSet<UserCompanyAccess> UserCompanyAccesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MasterCompany>()
                .ToTable("Companies", "MasterData");

            modelBuilder.Entity<UserCompanyAccess>()
                .ToTable("UserCompanyAccess", "MasterData");
        }
    }
}