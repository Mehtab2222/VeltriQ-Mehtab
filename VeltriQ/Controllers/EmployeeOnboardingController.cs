using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.HR.Onboarding;
using VeltriQ.ViewModels.EmployeeOnboarding;

namespace VeltriQ.Controllers
{
    public class EmployeeOnboardingController : Controller
    {
        private readonly TenantDbContext _context;

        public EmployeeOnboardingController(TenantDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var onboardings = await _context.EmployeeOnboardings
                .Include(x => x.OnboardingCandidate)
                .Include(x => x.OnboardingTemplate)
                .Include(x => x.OnboardingStatus)
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();

            return View(onboardings);
        }
        private async Task LoadDropdowns(EmployeeOnboardingViewModel model)
        {
            model.Employees = await _context.Employees
                .Where(x => x.IsActive)
                .OrderBy(x => x.FirstName)
                .Select(x => new SelectListItem
                {
                    Value = x.EmployeeId.ToString(),
                    Text = x.EmployeeCode + " - " + x.FirstName + " " + x.LastName
                })
                .ToListAsync();

            model.Templates = await _context.OnboardingTemplates
                .Where(x => x.IsActive && x.IsPublished)
                .OrderBy(x => x.TemplateName)
                .Select(x => new SelectListItem
                {
                    Value = x.OnboardingTemplateId.ToString(),
                    Text = x.TemplateName
                })
                .ToListAsync();
        }
    }
}