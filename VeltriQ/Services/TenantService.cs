using VeltriQ.Data;
using VeltriQ.Models.Master;
using VeltriQ.Services.Interfaces;

namespace VeltriQ.Services
{
    public class TenantService : ITenantService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly MasterDbContext _masterContext;

        public TenantService
        (
            IHttpContextAccessor httpContextAccessor,
            MasterDbContext masterContext
        )
        {
            _httpContextAccessor = httpContextAccessor;

            _masterContext = masterContext;
        }

        public TenantInfo GetCurrentTenant()
        {
            var session =
                _httpContextAccessor.HttpContext?.Session;

            var companyId =
                session?.GetInt32("ActiveCompanyId");

            if (companyId == null)
            {
                throw new Exception
                (
                    "No tenant selected in session."
                );
            }

            var company =
                _masterContext.Companies
                    .FirstOrDefault(x =>
                        x.CompanyId == companyId);

            if (company == null)
            {
                throw new Exception
                (
                    "No active tenant company found in session."
                );
            }
            return new TenantInfo
            {
                CompanyId = company.CompanyId,

                CompanyName = company.CompanyName,

                ConnectionString = company.ConnectionString
            };
        }
    }
}