using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VeltriQ.Controllers;
using VeltriQ.Data;
using VeltriQ.Models.Core;

namespace VeltriQ.Web.Controllers
{
    public class DashboardController : BaseController
    {
        public DashboardController
        (
            TenantDbContext context,

            MasterDbContext masterContext,

            UserManager<ApplicationUser> userManager
        )

            : base(context, masterContext, userManager)

        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}