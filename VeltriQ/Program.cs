using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Middleware;
using VeltriQ.Models.Core;
using VeltriQ.Services;
using VeltriQ.Services.Interfaces;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<MasterDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MasterConnection")));
//builder.Services.AddDbContext<TenantDbContext>
//(
//    (serviceProvider, options) =>
//    {
//        var tenantService =
//            serviceProvider
//                .GetRequiredService<ITenantService>();

//        var tenant =
//            tenantService.GetCurrentTenant();

//        options.UseSqlServer
//        (
//            tenant.ConnectionString
//        );
//    }
//);
builder.Services.AddDbContext<TenantDbContext>
(
    (serviceProvider, options) =>
    {
        try
        {
            var tenantService =
                serviceProvider
                    .GetRequiredService<ITenantService>();

            var tenant =
                tenantService.GetCurrentTenant();

            options.UseSqlServer
            (
                tenant.ConnectionString
            );
        }

        catch
        {
            // DESIGN TIME FALLBACK
            options.UseSqlServer
            (
                builder.Configuration
                    .GetConnectionString
                    (
                        "DefaultConnection"
                    )
            );
        }
    }
);
builder.Services

    .AddIdentity<ApplicationUser, IdentityRole>

    (options =>
    {
        options.Password.RequireDigit = false;

        options.Password.RequireLowercase = false;

        options.Password.RequireUppercase = false;

        options.Password.RequireNonAlphanumeric = false;

        options.Password.RequiredLength = 6;
    })

    .AddRoles<IdentityRole>()

    .AddEntityFrameworkStores<ApplicationDbContext>()

    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<TenantContext>();
builder.Services.AddScoped<IMenuService, MenuService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseMiddleware<TenantMiddleware>();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var roleManager =
        services.GetRequiredService
        <
            RoleManager<IdentityRole>
        >();

    var userManager =
        services.GetRequiredService
        <
            UserManager<ApplicationUser>
        >();

    // =========================
    // CREATE ROLES
    // =========================

    string[] roles =
    {
        "Admin",
        "HR",
        "Manager",
        "Employee"
    };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync
            (
                new IdentityRole(role)
            );
        }
    }

    // =========================
    // CREATE DEFAULT ADMIN
    // =========================

    await CreateUser
    (
        userManager,
        "TCS Super Admin",
        "admin@tcs.com",
        "Admin@123",
        "Admin"
    );

    await CreateUser
    (
        userManager,
        "TCS HR Manager",
        "hr@tcs.com",
        "Hr@123",
        "HR"
    );

    await CreateUser
    (
        userManager,
        "TCS Delivery Manager",
        "manager@tcs.com",
        "Manager@123",
        "Manager"
    );
}

// =========================
// METHOD
// =========================

static async Task CreateUser
(
    UserManager<ApplicationUser> userManager,
    string fullName,
    string email,
    string password,
    string role
)
{
    var existingUser =
        await userManager.FindByEmailAsync(email);

    if (existingUser == null)
    {
        var user = new ApplicationUser
        {
            FullName = fullName,
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            IsActive = true
        };

        var result =
            await userManager.CreateAsync
            (
                user,
                password
            );

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync
            (
                user,
                role
            );
        }
    }
}
app.Run();
