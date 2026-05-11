using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using VeltriQ.Data;
using VeltriQ.Models.Core;

namespace VeltriQ.Controllers
{
    public class Organization : BaseController
    {
        public Organization
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

        public IActionResult Company()
        {
            return View();
        }
    }
}