using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using VeltriQ.Data;
using VeltriQ.Models.Core;

namespace VeltriQ.Controllers
{
    public class SettingsController : BaseController
    {
        public SettingsController
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