using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.ViewModels.ConvertToEmployee;

namespace VeltriQ.Controllers
{
    public class ConvertToEmployeeController : BaseController
    {
        private readonly TenantDbContext _context;

        public ConvertToEmployeeController(
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager)
            : base(context, masterContext, userManager)
        {
            _context = context;
        }

        //====================================================
        // INDEX
        //====================================================

        public async Task<IActionResult> Index()
        {
            var model = new ConvertToEmployeeIndexViewModel();

            //====================================================
            // DASHBOARD
            //====================================================

            model.TotalApproved = await _context.EmployeeOnboardings
                .CountAsync(x =>
                    x.IsActive &&
                    x.OnboardingStatus.StatusCode == "APPROVED");

            model.Converted = await _context.EmployeeOnboardings
                .CountAsync(x =>
                    x.IsActive &&
                    x.OnboardingStatus.StatusCode == "CONVERTED");

            model.PendingConversion =
                model.TotalApproved - model.Converted;

            model.ApprovedToday = await _context.EmployeeOnboardings
                .CountAsync(x =>
                    x.IsActive &&
                    x.OnboardingStatus.StatusCode == "APPROVED" &&
                    x.ApprovedOn.HasValue &&
                    x.ApprovedOn.Value.Date == DateTime.Today);

            //====================================================
            // DEPARTMENT DROPDOWN
            //====================================================

            model.Departments = await _context.Departments
                .Where(x => x.IsActive)
                .OrderBy(x => x.DepartmentName)
                .Select(x => new SelectListItem
                {
                    Value = x.DepartmentId.ToString(),
                    Text = x.DepartmentName
                })
                .ToListAsync();

            model.Departments.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "All Departments"
            });

            //====================================================
            // CONVERSION STATUS
            //====================================================

            model.ConversionStatuses.Add(new SelectListItem
            {
                Value = "",
                Text = "All"
            });

            model.ConversionStatuses.Add(new SelectListItem
            {
                Value = "Pending",
                Text = "Pending Conversion"
            });

            model.ConversionStatuses.Add(new SelectListItem
            {
                Value = "Converted",
                Text = "Converted"
            });

            //====================================================
            // MANPOWER REQUEST
            //====================================================

            model.ManpowerRequests.Add(new SelectListItem
            {
                Value = "",
                Text = "All Requests"
            });

            // We'll load actual Manpower Requests later.

            //====================================================
            // GRID
            //====================================================

            model.Items = await _context.EmployeeOnboardings

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.Department)

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.Designation)

                .Include(x => x.OnboardingTemplate)

                .Include(x => x.OnboardingStatus)

                .Where(x =>
                    x.IsActive &&
                    (
                        x.OnboardingStatus.StatusCode == "APPROVED" ||
                        x.OnboardingStatus.StatusCode == "CONVERTED"
                    ))

                .OrderByDescending(x => x.ApprovedOn)

                .Select(x => new ConvertToEmployeeListItemViewModel
                {
                    EmployeeOnboardingId = x.EmployeeOnboardingId,

                    OnboardingCandidateId = x.OnboardingCandidateId,

                    CandidateCode = x.OnboardingCandidate.CandidateCode,

                    CandidateName = x.OnboardingCandidate.FullName,

                    Department = x.OnboardingCandidate.Department.DepartmentName,

                    Designation = x.OnboardingCandidate.Designation.DesignationName,

                    TemplateName = x.OnboardingTemplate.TemplateName,

                    ApprovedOn = x.ApprovedOn,

                    ConversionStatus =
                        x.OnboardingStatus.StatusCode == "CONVERTED"
                        ? "Converted"
                        : "Pending Conversion",

                    IsConverted =
                        x.OnboardingStatus.StatusCode == "CONVERTED"
                })

                .ToListAsync();

            return View(model);
        }
    }
}