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
        // ADD CATEGORY (HTML Form Post)
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
        // ADD SKILL (HTML Form Post)
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

        // =========================
        // AJAX ENDPOINTS FOR SKILLS DIRECTORY
        // =========================

        [HttpGet]
        public async Task<IActionResult> GetSkillsList()
        {
            try
            {
                var categories = await _context.JobCategories
                    .Where(c => c.IsActive)
                    .OrderBy(c => c.CategoryName)
                    .ToListAsync();

                var skills = await _context.SkillMasters
                    .Where(s => s.IsActive)
                    .OrderBy(s => s.SkillName)
                    .ToListAsync();

                var categoryLookup = categories.ToDictionary(c => c.JobCategoryId, c => c.CategoryName);

                var skillsFlatList = skills.Select(s => new
                {
                    skillId = s.SkillId,
                    skillName = s.SkillName,
                    categoryId = s.JobCategoryId,
                    categoryName = categoryLookup.ContainsKey(s.JobCategoryId) ? categoryLookup[s.JobCategoryId] : "General",
                    addedOn = (DateTime?)null,
                    addedBy = "Admin"
                }).ToList();

                var categoryList = categories.Select(c => new
                {
                    categoryId = c.JobCategoryId,
                    categoryName = c.CategoryName
                }).ToList();

                return Json(new
                {
                    success = true,
                    data = skillsFlatList,
                    categories = categoryList
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryCreateModel model)
        {
            try
            {
                if (model == null || string.IsNullOrWhiteSpace(model.CategoryName))
                    return Json(new { success = false, message = "Category name is required." });

                var category = new JobCategory
                {
                    CategoryName = model.CategoryName.Trim(),
                    IsActive = true
                };
                _context.JobCategories.Add(category);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSkillsBatch([FromBody] SkillBatchCreateModel model)
        {
            try
            {
                if (model == null || model.CategoryId <= 0 || model.SkillNames == null || !model.SkillNames.Any())
                    return Json(new { success = false, message = "Invalid category or skill list." });

                foreach (var name in model.SkillNames)
                {
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        var skill = new SkillMaster
                        {
                            JobCategoryId = model.CategoryId,
                            SkillName = name.Trim(),
                            IsActive = true
                        };
                        _context.SkillMasters.Add(skill);
                    }
                }
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSkill([FromBody] SkillUpdateModel model)
        {
            try
            {
                var skill = await _context.SkillMasters.FindAsync(model.SkillId);
                if (skill == null) return Json(new { success = false, message = "Skill not found." });

                skill.SkillName = model.SkillName.Trim();
                skill.JobCategoryId = model.CategoryId;

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSkillRecord(int id)
        {
            try
            {
                var skill = await _context.SkillMasters.FindAsync(id);
                if (skill == null) return Json(new { success = false, message = "Skill not found." });

                skill.IsActive = false;
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public class CategoryCreateModel { public string CategoryName { get; set; } = ""; }
        public class SkillBatchCreateModel { public int CategoryId { get; set; } public List<string> SkillNames { get; set; } = new(); }
        public class SkillUpdateModel { public int SkillId { get; set; } public string SkillName { get; set; } = ""; public int CategoryId { get; set; } }
    }
}