using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.ViewModels.OnboardingSection;

namespace VeltriQ.Controllers
{
    public class OnboardingSectionController : BaseController
    {
        private readonly TenantDbContext _context;

        public OnboardingSectionController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )
            : base(context, masterContext, userManager)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string searchText = "")
        {
            var model = new OnboardingSectionIndexViewModel
            {
                SearchText = searchText
            };

            var query = _context.OnboardingSectionMasters
                .Where(x => x.IsActive);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.Trim();

                query = query.Where(x =>
                    x.SectionName.Contains(searchText) ||
                    (x.Description != null &&
                     x.Description.Contains(searchText)));
            }

            model.Sections = await query

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new OnboardingSectionListItemViewModel
                {
                    OnboardingSectionMasterId = x.OnboardingSectionMasterId,

                    SectionName = x.SectionName,

                    Description = x.Description ?? "",

                    DisplayOrder = x.DisplayOrder,

                    IsMandatory = x.IsMandatory,

                    IsVisible = x.IsVisible,

                    IsActive = x.IsActive,

                    IconCss = x.IconCss ?? ""
                })

                .ToListAsync();

            return View(model);
        }



        //====================================================
        // ACTIVATE
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Activate([FromBody] int id)
        {
            var section = await _context.OnboardingSectionMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingSectionMasterId == id);

            if (section == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Section not found."
                });
            }

            section.IsActive = true;
            section.ModifiedOn = DateTime.Now;
            section.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Section activated successfully."
            });
        }
        //====================================================
        // DEACTIVATE
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Deactivate([FromBody] int id)
        {
            var section = await _context.OnboardingSectionMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingSectionMasterId == id);

            if (section == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Section not found."
                });
            }

            // Prevent deactivation if used in active templates
            var isUsed = await _context.OnboardingTemplateSections
                .AnyAsync(x =>
                    x.OnboardingSectionMasterId == id &&
                    x.IsActive);

            if (isUsed)
            {
                return Json(new
                {
                    success = false,
                    message = "This section is currently used in one or more onboarding templates. Remove it from the template(s) before deactivating it."
                });
            }

            section.IsActive = false;
            section.ModifiedOn = DateTime.Now;
            section.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Section deactivated successfully."
            });
        }
    }
}