using Microsoft.AspNetCore.Authentication;
using VeltriQ.Services;
using VeltriQ.Services.Interfaces;

namespace VeltriQ.Middleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync
        (
            HttpContext context,
            ITenantService tenantService,
            TenantContext tenantContext
        )
        {
            var path =
                context.Request.Path.Value?.ToLower();

            // Skip login/logout/static files
            if
            (
                path != null
                &&
                (
                    path.Contains("/account/login")
                    ||
                    path.Contains("/account/logout")
                    ||
                    path.Contains("/css/")
                    ||
                    path.Contains("/js/")
                    ||
                    path.Contains("/lib/")
                )
            )
            {
                await _next(context);

                return;
            }

            // Only resolve tenant for authenticated users
            if
            (
                context.User.Identity != null
                &&
                context.User.Identity.IsAuthenticated
            )
            {
                try
                {
                    var tenant =
                        tenantService.GetCurrentTenant();

                    tenantContext.ConnectionString =
                        tenant.ConnectionString;
                }

                catch
                {
                    await context.SignOutAsync();

                    context.Session.Clear();

                    context.Response.Redirect("/Account/Login");

                    return;
                }
            }

            await _next(context);
        }
    }
}