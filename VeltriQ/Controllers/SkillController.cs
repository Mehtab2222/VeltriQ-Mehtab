using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.Recruitment;
using VeltriQ.ViewModels;

namespace VeltriQ.Controllers
{
    public class SkillController : BaseController
    {
        public SkillController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )
        : base(context, masterContext, userManager)
        {
        }

        // =========================
        // INDEX — categories + their skills
        // =========================

        public async Task<IActionResult> Index()
        {
            var categories = await _context.JobCategories
                .Where(x => x.IsActive)
                .OrderBy(x => x.CategoryName)
                .ToListAsync();

            var allSkills = await _context.SkillMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.SkillName)
                .ToListAsync();

            var vm = categories.Select(c => new SkillCategoryGroupViewModel
            {
                JobCategoryId = c.JobCategoryId,
                CategoryName = c.CategoryName,
                Skills = allSkills.Where(s => s.JobCategoryId == c.JobCategoryId).ToList()
            }).ToList();

            return View(vm);
        }

        // =========================
        // ADD CATEGORY
        // =========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(string categoryName)
        {
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                _context.JobCategories.Add(new JobCategory
                {
                    CategoryName = categoryName.Trim(),
                    IsActive = true
                });

                await _context.SaveChangesAsync();
                TempData["Success"] = "Category added successfully.";
            }

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // ADD SKILL (under a category)
        // =========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSkill(int jobCategoryId, string skillName)
        {
            if (jobCategoryId > 0 && !string.IsNullOrWhiteSpace(skillName))
            {
                _context.SkillMasters.Add(new SkillMaster
                {
                    JobCategoryId = jobCategoryId,
                    SkillName = skillName.Trim(),
                    IsActive = true
                });

                await _context.SaveChangesAsync();
                TempData["Success"] = "Skill added successfully.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}