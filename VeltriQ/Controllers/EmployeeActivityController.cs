using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;

namespace VeltriQ.Controllers
{
    public class EmployeeActivityController : BaseController
    {
        private readonly TenantDbContext _context;

        public EmployeeActivityController
        (
            TenantDbContext context,

            MasterDbContext masterContext,

            UserManager<ApplicationUser> userManager
        )

            : base(context, masterContext, userManager)

        {
            _context = context;
        }
        // TIMELINE

        public async Task<IActionResult> Index(int employeeId)
        {
            ViewBag.EmployeeId = employeeId;

            var activities = await _context.EmployeeActivities

                .Where(x => x.EmployeeId == employeeId)

                .OrderByDescending(x => x.ActivityDate)

                .ToListAsync();

            return PartialView
            (
                "_EmployeeTimelinePartial",
                activities
            );
        }
    }
}