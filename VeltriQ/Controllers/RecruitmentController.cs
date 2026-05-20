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

        public async Task<IActionResult> Index()
        {
            var requests = await _context.ManpowerRequests
                .OrderByDescending(x => x.ManpowerRequestId)
                .ToListAsync();

            return View(requests);
        }
        public async Task<IActionResult> Create()
        {
            ManpowerRequestViewModel vm = new();

            vm.RequestDate = DateTime.Now;

            vm.RecruitmentTypes = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = "1",
                        Text = "New"
                    },

                    new SelectListItem
                    {
                        Value = "2",
                        Text = "Resignation"
                    },

                    new SelectListItem
                    {
                        Value = "3",
                        Text = "Termination"
                    }
                };

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

            vm.NationalityList = await _context.Nationalities
                .Select(x => new SelectListItem
                {
                    Value = x.NationalityId.ToString(),
                    Text = x.NationalityName
                })
                .ToListAsync();

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create
(
    ManpowerRequestViewModel vm
)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            string requestCode =
                "REC-" +
                DateTime.Now.Year +
                "-" +
                DateTime.Now.Ticks
                    .ToString()
                    .Substring(10);

            int createdBy =
                Convert.ToInt32(
                    HttpContext.Session.GetString("EmployeeId")
                );

            ManpowerRequest entity = new()
            {
                RequestCode = requestCode,

                RequestDate = vm.RequestDate,

                RecruitmentTypeId = vm.RecruitmentTypeId,

                HODId = vm.HODId,

                DepartmentId = vm.DepartmentId,

                DesignationId = vm.DesignationId,

                ReplacementEmployeeId =
                    vm.ReplacementEmployeeId,

                NumberOfPositions =
                    vm.NumberOfPositions,

                RequiredJoiningDate =
                    vm.RequiredJoiningDate,

                MinExperience =
                    vm.MinExperience,

                MaxExperience =
                    vm.MaxExperience,

                MinAge =
                    vm.MinAge,

                MaxAge =
                    vm.MaxAge,

                EducationId =
                    vm.EducationId,

                NationalityId =
                    vm.NationalityId,

                MinSalary =
                    vm.MinSalary,

                MaxSalary =
                    vm.MaxSalary,

                PriorityId =
                    vm.PriorityId,

                JobDescription =
                    vm.JobDescription,

                RequiredSkills =
                    vm.RequiredSkills,

                Remarks =
                    vm.Remarks,

                StatusId = 1,

                CreatedBy = createdBy,

                CreatedDate = DateTime.Now,

                IsActive = true,

                IsDeleted = false
            };

            _context.ManpowerRequests.Add(entity);

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Recruitment request created successfully.";

            return RedirectToAction("Index");
        }
        // 1. GET: ManpowerRequest/Edit/5
        // GET: Recruitment/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var request = await _context.ManpowerRequests.FindAsync(id);
            if (request == null) return NotFound();

            var viewModel = new ManpowerRequestViewModel
            {
                ManpowerRequestId = request.ManpowerRequestId,
                RequestDate = request.RequestDate,
                RecruitmentTypeId = request.RecruitmentTypeId,
                NumberOfPositions = request.NumberOfPositions,
                DepartmentId = request.DepartmentId,
                DesignationId = request.DesignationId,
                RequiredJoiningDate = request.RequiredJoiningDate,
                ReplacementEmployeeId = request.ReplacementEmployeeId,
                Remarks = request.Remarks,
                MinExperience = request.MinExperience,
                MaxExperience = request.MaxExperience,
                MinAge = request.MinAge,
                MaxAge = request.MaxAge,
                EducationId = request.EducationId,
                NationalityId = request.NationalityId,
                PriorityId = request.PriorityId,
                MinSalary = request.MinSalary,
                MaxSalary = request.MaxSalary,
                RequiredSkills = request.RequiredSkills,
                JobDescription = request.JobDescription,

                // POPULATING DROPDOWNS:
                RecruitmentTypes = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "New" },
            new SelectListItem { Value = "2", Text = "Resignation" },
            new SelectListItem { Value = "3", Text = "Termination" }
        },
                DepartmentList = await _context.Departments
                    .Select(x => new SelectListItem { Value = x.DepartmentId.ToString(), Text = x.DepartmentName })
                    .ToListAsync(),
                DesignationList = await _context.Designations
                    .Select(x => new SelectListItem { Value = x.DesignationId.ToString(), Text = x.DesignationName })
                    .ToListAsync(),
                NationalityList = await _context.Nationalities
                    .Select(x => new SelectListItem { Value = x.NationalityId.ToString(), Text = x.NationalityName })
                    .ToListAsync()
            };

            return View(viewModel);
        }

        // POST: Recruitment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ManpowerRequestViewModel viewModel)
        {
            if (id != viewModel.ManpowerRequestId) return BadRequest();

            if (ModelState.IsValid)
            {
                var request = await _context.ManpowerRequests.FindAsync(id);
                if (request == null) return NotFound();

                request.RequestDate = viewModel.RequestDate;
                request.RecruitmentTypeId = viewModel.RecruitmentTypeId;
                request.NumberOfPositions = viewModel.NumberOfPositions;
                request.DepartmentId = viewModel.DepartmentId;
                request.DesignationId = viewModel.DesignationId;
                request.RequiredJoiningDate = viewModel.RequiredJoiningDate;
                request.ReplacementEmployeeId = viewModel.ReplacementEmployeeId;
                request.Remarks = viewModel.Remarks;
                request.MinExperience = viewModel.MinExperience;
                request.MaxExperience = viewModel.MaxExperience;
                request.MinAge = viewModel.MinAge;
                request.MaxAge = viewModel.MaxAge;
                request.EducationId = viewModel.EducationId;
                request.NationalityId = viewModel.NationalityId;
                request.PriorityId = viewModel.PriorityId;
                request.MinSalary = viewModel.MinSalary;
                request.MaxSalary = viewModel.MaxSalary;
                request.RequiredSkills = viewModel.RequiredSkills;
                request.JobDescription = viewModel.JobDescription;

                request.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetString("EmployeeId"));
                request.ModifiedDate = DateTime.Now;

                _context.Update(request);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Recruitment request updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            // Re-populate dropdown packages here if validation fails so the screen doesn't break
            viewModel.RecruitmentTypes = new List<SelectListItem>
    {
        new SelectListItem { Value = "1", Text = "New" },
        new SelectListItem { Value = "2", Text = "Resignation" },
        new SelectListItem { Value = "3", Text = "Termination" }
    };
            viewModel.DepartmentList = await _context.Departments.Select(x => new SelectListItem { Value = x.DepartmentId.ToString(), Text = x.DepartmentName }).ToListAsync();
            viewModel.DesignationList = await _context.Designations.Select(x => new SelectListItem { Value = x.DesignationId.ToString(), Text = x.DesignationName }).ToListAsync();
            viewModel.NationalityList = await _context.Nationalities.Select(x => new SelectListItem { Value = x.NationalityId.ToString(), Text = x.NationalityName }).ToListAsync();

            return View(viewModel);
        }
    }
}