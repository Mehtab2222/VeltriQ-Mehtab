using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.Models.Master;
namespace VeltriQ.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext
        (
            DbContextOptions<ApplicationDbContext> options
        ) : base(options)
        {

        }

        // CORE

        public DbSet<AppMenu> AppMenus { get; set; }

        public DbSet<RoleMenuPermission> RoleMenuPermissions { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        // HR

        public DbSet<Company> Companies { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Designation> Designations { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<DocumentMaster> DocumentMasters { get; set; }

        public DbSet<AssetMaster> AssetMasters { get; set; }

        public DbSet<HRContact> HRContacts { get; set; }

        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }

        public DbSet<EmployeeAsset> EmployeeAssets { get; set; }

        public DbSet<EmployeeActivity> EmployeeActivities { get; set; }
        public DbSet<UserCompanyAccess> UserCompanyAccesses { get; set; }
        protected override void OnModelCreating
        (
            ModelBuilder modelBuilder
        )
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // CORE
            // =========================

            modelBuilder.Entity<AppMenu>()
                .HasKey(x => x.MenuId);

            modelBuilder.Entity<AppMenu>()
                .ToTable("AppMenu", "Core");

            modelBuilder.Entity<RoleMenuPermission>()
                .HasKey(x => x.RoleMenuPermissionId);

            modelBuilder.Entity<RoleMenuPermission>()
                .ToTable("RoleMenuPermission", "Core");

            modelBuilder.Entity<UserRole>()
                .HasKey(x => x.UserRoleId);

            modelBuilder.Entity<UserRole>()
                .ToTable("UserRole", "Core");

            // =========================
            // HR
            // =========================

            modelBuilder.Entity<Company>()
                .HasKey(x => x.CompanyId);

            modelBuilder.Entity<Company>()
                .ToTable("Company", "HR");

            modelBuilder.Entity<Branch>()
                .HasKey(x => x.BranchId);

            modelBuilder.Entity<Branch>()
                .ToTable("Branch", "HR");

            modelBuilder.Entity<Department>()
                .HasKey(x => x.DepartmentId);

            modelBuilder.Entity<Department>()
                .ToTable("Department", "HR");

            modelBuilder.Entity<Designation>()
                .HasKey(x => x.DesignationId);

            modelBuilder.Entity<Designation>()
                .ToTable("Designation", "HR");

            modelBuilder.Entity<Employee>()
                .HasKey(x => x.EmployeeId);

            modelBuilder.Entity<Employee>()
                .ToTable("Employee", "HR");

            modelBuilder.Entity<Division>()
                .HasKey(x => x.DivisionId);

            modelBuilder.Entity<Division>()
                .ToTable("Division", "HR");

            modelBuilder.Entity<Nationality>()
                .HasKey(x => x.NationalityId);

            modelBuilder.Entity<Nationality>()
                .ToTable("Nationality", "HR");

            modelBuilder.Entity<Country>()
                .HasKey(x => x.CountryId);

            modelBuilder.Entity<Country>()
                .ToTable("Country", "HR");

            modelBuilder.Entity<City>()
                .HasKey(x => x.CityId);

            modelBuilder.Entity<City>()
                .ToTable("City", "HR");

            modelBuilder.Entity<DocumentMaster>()
                .HasKey(x => x.DocumentMasterId);

            modelBuilder.Entity<DocumentMaster>()
                .ToTable("DocumentMaster", "HR");

            modelBuilder.Entity<AssetMaster>()
                .HasKey(x => x.AssetMasterId);

            modelBuilder.Entity<AssetMaster>()
                .ToTable("AssetMaster", "HR");

            modelBuilder.Entity<HRContact>()
                .HasKey(x => x.HRContactId);

            modelBuilder.Entity<HRContact>()
                .ToTable("HRContact", "HR");

            modelBuilder.Entity<EmployeeDocument>()
                .HasKey(x => x.EmployeeDocumentId);

            modelBuilder.Entity<EmployeeDocument>()
                .ToTable("EmployeeDocument", "HR");

            modelBuilder.Entity<EmployeeAsset>()
                .HasKey(x => x.EmployeeAssetId);

            modelBuilder.Entity<EmployeeAsset>()
                .ToTable("EmployeeAsset", "HR");

            modelBuilder.Entity<EmployeeActivity>()
                .HasKey(x => x.EmployeeActivityId);

            modelBuilder.Entity<EmployeeActivity>()
                .ToTable("EmployeeActivity", "HR");
            modelBuilder.Entity<Employee>()

    .HasOne(x => x.User)

    .WithMany()

    .HasForeignKey(x => x.UserId)

    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserCompanyAccess>()
    .HasKey(x => x.Id);

            modelBuilder.Entity<UserCompanyAccess>()
                .ToTable("UserCompanyAccess", "HR");
        }
    }
}