using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using VeltriQ.Data;
using VeltriQ.Models.Core;

namespace VeltriQ.Controllers
{
    public class RecruitmentController : BaseController
    {
        public RecruitmentController
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