using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.Master;

namespace VeltriQ.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly MasterDbContext _context;

        public CompanyController
        (
            TenantDbContext tenantContext,

            MasterDbContext masterContext,

            UserManager<ApplicationUser> userManager
        )

            : base(tenantContext, masterContext, userManager)

        {
            _context = masterContext;
        }

        public async Task<IActionResult> Index()
        {
            var companies =
                await _context.Companies
                    .ToListAsync();

            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create
        (
            MasterCompany model
        )
        {
            if (ModelState.IsValid)
            {
              

                _context.Companies.Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult SwitchCompany
            (
                [FromBody] SwitchCompanyRequest request
            )
        {
            var userId =
                _userManager.GetUserId(User);

            var company =
                (
                    from access in _context.UserCompanyAccesses

                    join comp in _context.Companies
                    on access.CompanyId equals comp.CompanyId

                    where access.UserId == userId
                          && access.CompanyId == request.CompanyId

                    select comp
                )

                .FirstOrDefault();

            if (company == null)
            {
                return Unauthorized();
            }

            HttpContext.Session.SetInt32
            (
                "ActiveCompanyId",
                company.CompanyId
            );

            HttpContext.Session.SetString
            (
                "ActiveCompanyName",
                company.CompanyName
            );

            return Ok();
        }
    }
}