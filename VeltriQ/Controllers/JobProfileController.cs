using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.Recruitment;
using VeltriQ.ViewModels;

namespace VeltriQ.Controllers
{
    public class JobProfileController : BaseController
    {
        public JobProfileController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )
        : base(context, masterContext, userManager)
        {
        }

        // =========================
        // SHARED DROPDOWN LOADERS
        // =========================

        private async Task<List<SelectListItem>> GetJobCategoryListAsync()
        {
            return await _context.JobCategories
                .Where(x => x.IsActive)
                .Select(x => new SelectListItem
                {
                    Value = x.JobCategoryId.ToString(),
                    Text = x.CategoryName
                })
                .ToListAsync();
        }

        private async Task<List<SelectListItem>> GetEmployeeListAsync()
        {
            return await _context.Employees
                .Where(x => x.IsActive)
                .OrderBy(x => x.FirstName)
                .Select(x => new SelectListItem
                {
                    Value = x.EmployeeId.ToString(),
                    Text = (x.FirstName + " " + x.LastName)
                })
                .ToListAsync();
        }

        private async Task LoadDropdownsAsync(JobProfileViewModel vm)
        {
            vm.JobCategoryList = await GetJobCategoryListAsync();
            vm.EmployeeList = await GetEmployeeListAsync();
        }

        // =========================
        // INDEX
        // =========================

        public async Task<IActionResult> Index()
        {
            var profiles = await (
                from p in _context.JobProfiles
                where !p.IsDeleted
                join c in _context.JobCategories
                    on p.JobCategoryId equals c.JobCategoryId into cj
                from c in cj.DefaultIfEmpty()
                orderby p.JobProfileId descending
                select new JobProfileListItemViewModel
                {
                    JobProfileId = p.JobProfileId,
                    JobTitle = p.JobTitle,
                    CategoryName = c != null ? c.CategoryName : "-",
                    IsActive = p.IsActive
                }
            ).ToListAsync();

            return View(profiles);
        }

        // =========================
        // CREATE GET
        // =========================

        public async Task<IActionResult> Create()
        {
            JobProfileViewModel vm = new();
            await LoadDropdownsAsync(vm);
            return View(vm);
        }

        // =========================
        // CREATE POST
        // =========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobProfileViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync(vm);
                return View(vm);
            }

            int createdBy = Convert.ToInt32(HttpContext.Session.GetString("EmployeeId"));

            JobProfile entity = new()
            {
                JobTitle = vm.JobTitle,
                JobCategoryId = vm.JobCategoryId,
                JobDescription = vm.JobDescription,
                ReportingToId = vm.ReportingToId,
                HiringManagerId = vm.HiringManagerId,
                CreatedBy = createdBy,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            _context.JobProfiles.Add(entity);
            await _context.SaveChangesAsync();

            // SAVE SKILLS
            if (vm.SelectedSkillIds != null && vm.SelectedSkillIds.Any())
            {
                foreach (var skillId in vm.SelectedSkillIds)
                {
                    _context.JobProfileSkills.Add(new JobProfileSkill
                    {
                        JobProfileId = entity.JobProfileId,
                        SkillId = skillId
                    });
                }
            }

            // SAVE REVIEWERS
            if (vm.SelectedReviewerIds != null && vm.SelectedReviewerIds.Any())
            {
                foreach (var empId in vm.SelectedReviewerIds)
                {
                    _context.JobProfileReviewers.Add(new JobProfileReviewer
                    {
                        JobProfileId = entity.JobProfileId,
                        EmployeeId = empId
                    });
                }
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Job Profile created successfully.";
            return RedirectToAction("Index");
        }

        // =========================
        // EDIT GET
        // =========================

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var profile = await _context.JobProfiles
                .FirstOrDefaultAsync(x => x.JobProfileId == id);

            if (profile == null)
                return NotFound();

            JobProfileViewModel vm = new()
            {
                JobProfileId = profile.JobProfileId,
                JobTitle = profile.JobTitle,
                JobCategoryId = profile.JobCategoryId,
                JobDescription = profile.JobDescription,
                ReportingToId = profile.ReportingToId,
                HiringManagerId = profile.HiringManagerId,

                SelectedSkillIds = await _context.JobProfileSkills
                    .Where(x => x.JobProfileId == id)
                    .Select(x => x.SkillId)
                    .ToListAsync(),

                SelectedReviewerIds = await _context.JobProfileReviewers
                    .Where(x => x.JobProfileId == id)
                    .Select(x => x.EmployeeId)
                    .ToListAsync(),

                SkillList = await _context.SkillMasters
                    .Where(x => x.JobCategoryId == profile.JobCategoryId && x.IsActive)
                    .Select(x => new SelectListItem
                    {
                        Value = x.SkillId.ToString(),
                        Text = x.SkillName
                    })
                    .ToListAsync()
            };

            await LoadDropdownsAsync(vm);

            return View(vm);
        }

        // =========================
        // EDIT POST
        // =========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JobProfileViewModel vm)
        {
            if (id != vm.JobProfileId)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync(vm);
                return View(vm);
            }

            var profile = await _context.JobProfiles.FindAsync(id);

            if (profile == null)
                return NotFound();

            profile.JobTitle = vm.JobTitle;
            profile.JobCategoryId = vm.JobCategoryId;
            profile.JobDescription = vm.JobDescription;
            profile.ReportingToId = vm.ReportingToId;
            profile.HiringManagerId = vm.HiringManagerId;
            profile.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetString("EmployeeId"));
            profile.ModifiedDate = DateTime.Now;

            _context.Update(profile);

            // UPDATE SKILLS
            var oldSkills = _context.JobProfileSkills.Where(x => x.JobProfileId == id);
            _context.JobProfileSkills.RemoveRange(oldSkills);

            if (vm.SelectedSkillIds != null)
            {
                foreach (var skillId in vm.SelectedSkillIds)
                {
                    _context.JobProfileSkills.Add(new JobProfileSkill
                    {
                        JobProfileId = id,
                        SkillId = skillId
                    });
                }
            }

            // UPDATE REVIEWERS
            var oldReviewers = _context.JobProfileReviewers.Where(x => x.JobProfileId == id);
            _context.JobProfileReviewers.RemoveRange(oldReviewers);

            if (vm.SelectedReviewerIds != null)
            {
                foreach (var empId in vm.SelectedReviewerIds)
                {
                    _context.JobProfileReviewers.Add(new JobProfileReviewer
                    {
                        JobProfileId = id,
                        EmployeeId = empId
                    });
                }
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Job Profile updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        // =========================
        // LOAD SKILLS (AJAX)
        // =========================

        [HttpGet]
        public async Task<JsonResult> GetSkillsByCategory(int categoryId)
        {
            var skills = await _context.SkillMasters
                .Where(x => x.JobCategoryId == categoryId && x.IsActive)
                .Select(x => new { id = x.SkillId, text = x.SkillName })
                .ToListAsync();

            return Json(skills);
        }
    }
}