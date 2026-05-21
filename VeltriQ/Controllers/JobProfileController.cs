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
        // INDEX
        // =========================

        public async Task<IActionResult> Index()
        {
            var profiles = await _context.JobProfiles
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.JobProfileId)
                .ToListAsync();

            return View(profiles);
        }

        // =========================
        // CREATE GET
        // =========================

        public async Task<IActionResult> Create()
        {
            JobProfileViewModel vm = new();

            vm.DepartmentList = await _context.Departments
                .Select(x => new SelectListItem
                {
                    Value = x.DepartmentId.ToString(),
                    Text = x.DepartmentName
                })
                .ToListAsync();

            vm.DesignationList = await _context.Designations
                .Select(x => new SelectListItem
                {
                    Value = x.DesignationId.ToString(),
                    Text = x.DesignationName
                })
                .ToListAsync();

            vm.JobCategoryList = await _context.JobCategories
                .Where(x => x.IsActive)
                .Select(x => new SelectListItem
                {
                    Value = x.JobCategoryId.ToString(),
                    Text = x.CategoryName
                })
                .ToListAsync();

            return View(vm);
        }

        // =========================
        // CREATE POST
        // =========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create
        (
            JobProfileViewModel vm
        )
        {
            if (!ModelState.IsValid)
            {
                vm.DepartmentList = await _context.Departments
                    .Select(x => new SelectListItem
                    {
                        Value = x.DepartmentId.ToString(),
                        Text = x.DepartmentName
                    })
                    .ToListAsync();

                vm.DesignationList = await _context.Designations
                    .Select(x => new SelectListItem
                    {
                        Value = x.DesignationId.ToString(),
                        Text = x.DesignationName
                    })
                    .ToListAsync();

                vm.JobCategoryList = await _context.JobCategories
                    .Where(x => x.IsActive)
                    .Select(x => new SelectListItem
                    {
                        Value = x.JobCategoryId.ToString(),
                        Text = x.CategoryName
                    })
                    .ToListAsync();

                return View(vm);
            }

            int createdBy =
                Convert.ToInt32(
                    HttpContext.Session.GetString("EmployeeId")
                );

            JobProfile entity = new()
            {
                JobTitle = vm.JobTitle,

                DepartmentId = vm.DepartmentId,

                DesignationId = vm.DesignationId,

                JobCategoryId = vm.JobCategoryId,

                JobDescription = vm.JobDescription,

                MinSalary = vm.MinSalary,

                MaxSalary = vm.MaxSalary,

                MinExperience = vm.MinExperience,

                MaxExperience = vm.MaxExperience,

                CreatedBy = createdBy,

                CreatedDate = DateTime.Now,

                IsActive = true,

                IsDeleted = false
            };

            _context.JobProfiles.Add(entity);

            await _context.SaveChangesAsync();

            // =========================
            // SAVE SKILLS
            // =========================

            if (vm.SelectedSkillIds != null
                && vm.SelectedSkillIds.Any())
            {
                foreach (var skillId in vm.SelectedSkillIds)
                {
                    JobProfileSkill skill = new()
                    {
                        JobProfileId = entity.JobProfileId,
                        SkillId = skillId
                    };

                    _context.JobProfileSkills.Add(skill);
                }

                await _context.SaveChangesAsync();
            }

            TempData["Success"] =
                "Job Profile created successfully.";

            return RedirectToAction("Index");
        }

        // =========================
        // EDIT GET
        // =========================

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var profile = await _context.JobProfiles
                .FirstOrDefaultAsync(x =>
                    x.JobProfileId == id);

            if (profile == null)
                return NotFound();

            JobProfileViewModel vm = new()
            {
                JobProfileId = profile.JobProfileId,

                JobTitle = profile.JobTitle,

                DepartmentId = profile.DepartmentId,

                DesignationId = profile.DesignationId,

                JobCategoryId = profile.JobCategoryId,

                JobDescription = profile.JobDescription,

                MinSalary = profile.MinSalary,

                MaxSalary = profile.MaxSalary,

                MinExperience = profile.MinExperience,

                MaxExperience = profile.MaxExperience,

                SelectedSkillIds = await _context.JobProfileSkills
                    .Where(x => x.JobProfileId == id)
                    .Select(x => x.SkillId)
                    .ToListAsync(),

                DepartmentList = await _context.Departments
                    .Select(x => new SelectListItem
                    {
                        Value = x.DepartmentId.ToString(),
                        Text = x.DepartmentName
                    })
                    .ToListAsync(),

                DesignationList = await _context.Designations
                    .Select(x => new SelectListItem
                    {
                        Value = x.DesignationId.ToString(),
                        Text = x.DesignationName
                    })
                    .ToListAsync(),

                JobCategoryList = await _context.JobCategories
                    .Where(x => x.IsActive)
                    .Select(x => new SelectListItem
                    {
                        Value = x.JobCategoryId.ToString(),
                        Text = x.CategoryName
                    })
                    .ToListAsync(),

                SkillList = await _context.SkillMasters
                    .Where(x =>
                        x.JobCategoryId ==
                        profile.JobCategoryId)
                    .Select(x => new SelectListItem
                    {
                        Value = x.SkillId.ToString(),
                        Text = x.SkillName
                    })
                    .ToListAsync()
            };

            return View(vm);
        }

        // =========================
        // EDIT POST
        // =========================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit
        (
            int id,
            JobProfileViewModel vm
        )
        {
            if (id != vm.JobProfileId)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var profile =
                    await _context.JobProfiles
                        .FindAsync(id);

                if (profile == null)
                    return NotFound();

                profile.JobTitle = vm.JobTitle;

                profile.DepartmentId = vm.DepartmentId;

                profile.DesignationId = vm.DesignationId;

                profile.JobCategoryId = vm.JobCategoryId;

                profile.JobDescription = vm.JobDescription;

                profile.MinSalary = vm.MinSalary;

                profile.MaxSalary = vm.MaxSalary;

                profile.MinExperience = vm.MinExperience;

                profile.MaxExperience = vm.MaxExperience;

                profile.ModifiedBy =
                    Convert.ToInt32(
                        HttpContext.Session.GetString("EmployeeId")
                    );

                profile.ModifiedDate =
                    DateTime.Now;

                _context.Update(profile);

                // =========================
                // UPDATE SKILLS
                // =========================

                var oldSkills =
                    _context.JobProfileSkills
                        .Where(x =>
                            x.JobProfileId == id);

                _context.JobProfileSkills
                    .RemoveRange(oldSkills);

                if (vm.SelectedSkillIds != null)
                {
                    foreach (var skillId
                        in vm.SelectedSkillIds)
                    {
                        JobProfileSkill skill = new()
                        {
                            JobProfileId = id,
                            SkillId = skillId
                        };

                        _context.JobProfileSkills
                            .Add(skill);
                    }
                }

                await _context.SaveChangesAsync();

                TempData["Success"] =
                    "Job Profile updated successfully.";

                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        // =========================
        // LOAD SKILLS
        // =========================

        [HttpGet]
        public async Task<JsonResult>
            GetSkillsByCategory(int categoryId)
        {
            var skills = await _context.SkillMasters
                .Where(x =>
                    x.JobCategoryId == categoryId
                    && x.IsActive)
                .Select(x => new
                {
                    id = x.SkillId,
                    text = x.SkillName
                })
                .ToListAsync();

            return Json(skills);
        }
    }
}