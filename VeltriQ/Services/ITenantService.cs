using VeltriQ.Models.Master;

namespace VeltriQ.Services.Interfaces
{
    public interface ITenantService
    {
        TenantInfo GetCurrentTenant();
    }
}