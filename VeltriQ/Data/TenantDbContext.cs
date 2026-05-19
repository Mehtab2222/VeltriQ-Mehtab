using Microsoft.EntityFrameworkCore;

using VeltriQ.Models.HR;
using VeltriQ.Models.Recruitment;

namespace VeltriQ.Data
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext
        (
            DbContextOptions<TenantDbContext> options
        )
            : base(options)
        {
        }

        // =========================
        // HR MODULE TABLES
        // =========================

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Designation> Designations { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<HRContact> HRContacts { get; set; }

        public DbSet<DocumentMaster> DocumentMasters { get; set; }

        public DbSet<AssetMaster> AssetMasters { get; set; }

        public DbSet<EmployeeAsset> EmployeeAssets { get; set; }

        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }

        public DbSet<EmployeeActivity> EmployeeActivities { get; set; }
        public DbSet<EmployeeTransfer> EmployeeTransfers{ get; set; }
        public DbSet<EmployeeExit> EmployeeExits { get; set; }
        public DbSet<EmployeeSuspension> EmployeeSuspensions{ get; set; }
        public DbSet<ManpowerRequest> ManpowerRequests { get; set; }

        // =========================
        // MAP SCHEMAS
        // =========================

        protected override void OnModelCreating
        (
            ModelBuilder modelBuilder
        )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .ToTable("Employee", "HR");

            modelBuilder.Entity<Department>()
                .ToTable("Department", "HR");

            modelBuilder.Entity<Designation>()
                .ToTable("Designation", "HR");

            modelBuilder.Entity<Branch>()
                .ToTable("Branch", "HR");

            modelBuilder.Entity<Division>()
                .ToTable("Division", "HR");

            modelBuilder.Entity<Country>()
                .ToTable("Country", "HR");

            modelBuilder.Entity<City>()
                .ToTable("City", "HR");

            modelBuilder.Entity<Nationality>()
                .ToTable("Nationality", "HR");

            modelBuilder.Entity<HRContact>()
                .ToTable("HRContact", "HR");

            modelBuilder.Entity<DocumentMaster>()
                .ToTable("DocumentMaster", "HR");

            modelBuilder.Entity<AssetMaster>()
                .ToTable("AssetMaster", "HR");

            modelBuilder.Entity<EmployeeAsset>()
                .ToTable("EmployeeAsset", "HR");

            modelBuilder.Entity<EmployeeDocument>()
                .ToTable("EmployeeDocument", "HR");

            modelBuilder.Entity<EmployeeActivity>()
                .ToTable("EmployeeActivity", "HR");
            modelBuilder.Entity<EmployeeTransfer>()
    .ToTable("EmployeeTransfer", "HR");
            modelBuilder.Entity<EmployeeExit>()
    .ToTable("EmployeeExit", "HR");
            modelBuilder.Entity<EmployeeSuspension>()
    .ToTable("EmployeeSuspension", "HR");
            modelBuilder.Entity<ManpowerRequest>()
    .ToTable("ManpowerRequest", "Recruitment");
        }
    }
}