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
        private async Task LoadDropdowns(
            ManpowerRequestViewModel vm,
            int? selectedBranchId = null,
            int? selectedDepartmentId = null)
        {
            //====================================================
            // RECRUITMENT TYPES
            //====================================================

            vm.RecruitmentTypes = new List<SelectListItem>
    {
        new() { Value = "1", Text = "New" },
        new() { Value = "2", Text = "Resignation" },
        new() { Value = "3", Text = "Termination" }
    };

            //====================================================
            // BRANCH
            //====================================================

            vm.BranchList = await _context.Branches
                .Where(x => x.IsActive)
                .OrderBy(x => x.BranchName)
                .Select(x => new SelectListItem
                {
                    Value = x.BranchId.ToString(),
                    Text = x.BranchName
                })
                .ToListAsync();

            //====================================================
            // DEPARTMENT
            //====================================================

            if (selectedBranchId.HasValue)
            {
                vm.DepartmentList = await _context.Departments
                    .Where(x =>
                        x.IsActive &&
                        x.BranchId == selectedBranchId.Value)
                    .OrderBy(x => x.DepartmentName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.DepartmentId.ToString(),
                        Text = x.DepartmentName
                    })
                    .ToListAsync();
            }
            else
            {
                vm.DepartmentList = new List<SelectListItem>();
            }

            //====================================================
            // DESIGNATION
            //====================================================

            if (selectedDepartmentId.HasValue)
            {
                vm.DesignationList = await _context.Designations
                    .Where(x =>
                        x.IsActive &&
                        x.DepartmentId == selectedDepartmentId.Value)
                    .OrderBy(x => x.DesignationName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.DesignationId.ToString(),
                        Text = x.DesignationName
                    })
                    .ToListAsync();
            }
            else
            {
                vm.DesignationList = new List<SelectListItem>();
            }
            vm.JobProfileList = await _context.JobProfiles
    .Where(x => x.IsActive && !x.IsDeleted)
    .OrderBy(x => x.JobTitle)
    .Select(x => new SelectListItem
    {
        Value = x.JobProfileId.ToString(),
        Text = x.JobTitle
    })
    .ToListAsync();
            //====================================================
            // NATIONALITY
            //====================================================

            vm.NationalityList = await _context.Nationalities
                .OrderBy(x => x.NationalityName)
                .Select(x => new SelectListItem
                {
                    Value = x.NationalityId.ToString(),
                    Text = x.NationalityName
                })
                .ToListAsync();

            // TODO:
            // Education
            // Priority
            // Employee List
        }
        public async Task<IActionResult> Create()
        {
            ManpowerRequestViewModel vm = new();

            vm.RequestDate = DateTime.Now;

            await LoadDropdowns(vm);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ManpowerRequestViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => $"{x.Key}: {string.Join(", ", x.Value.Errors.Select(e => e.ErrorMessage))}")
                    .ToList();

                TempData["Error"] = "Validation failed → " + string.Join(" | ", errors);

                await LoadDropdowns(
                    vm,
                    vm.BranchId,
                    vm.DepartmentId);
                return View(vm);
            }

            string requestCode =
                "REC-" +
                DateTime.Now.Year +
                "-" +
                DateTime.Now.Ticks
                    .ToString()
                    .Substring(10);
            var currentEmployeeId = GetCurrentEmployeeId();

            ManpowerRequest entity = new()
            {
                RequestCode = requestCode,
                RequestDate = vm.RequestDate,
                JobProfileId = vm.JobProfileId,
                RecruitmentTypeId = vm.RecruitmentTypeId,
                HODId = vm.HODId,
                BranchId = vm.BranchId,
                DepartmentId = vm.DepartmentId,
                DesignationId = vm.DesignationId,
                ReplacementEmployeeId = vm.ReplacementEmployeeId,
                NumberOfPositions = vm.NumberOfPositions,
                RequiredJoiningDate = vm.RequiredJoiningDate,
                MinExperience = vm.MinExperience,
                MaxExperience = vm.MaxExperience,
                MinAge = vm.MinAge,
                MaxAge = vm.MaxAge,
                EducationId = vm.EducationId,
                NationalityId = vm.NationalityId,
                MinSalary = vm.MinSalary,
                MaxSalary = vm.MaxSalary,
                PriorityId = vm.PriorityId,
                Remarks = vm.Remarks,
                StatusId = 1,
                CreatedBy = currentEmployeeId.Value,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            _context.ManpowerRequests.Add(entity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Save failed → " + ex.Message +
                    (ex.InnerException != null ? " | Inner: " + ex.InnerException.Message : "");
                await LoadDropdowns(vm, vm.BranchId, vm.DepartmentId);
                return View(vm);
            }

            TempData["Success"] = "Recruitment request created successfully.";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartments(int branchId)
        {
            var departments = await _context.Departments

                .Where(x =>
                    x.IsActive &&
                    x.BranchId == branchId)

                .OrderBy(x => x.DepartmentName)

                .Select(x => new
                {
                    id = x.DepartmentId,
                    text = x.DepartmentName
                })

                .ToListAsync();

            return Json(departments);
        }
        [HttpGet]
        public async Task<IActionResult> GetDesignations(int departmentId)
        {
            var designations = await _context.Designations

                .Where(x =>
                    x.IsActive &&
                    x.DepartmentId == departmentId)

                .OrderBy(x => x.DesignationName)

                .Select(x => new
                {
                    id = x.DesignationId,
                    text = x.DesignationName
                })

                .ToListAsync();

            return Json(designations);
        }
        // 1. GET: ManpowerRequest/Edit/5
        // GET: Recruitment/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var request = await _context.ManpowerRequests.FindAsync(id);

            if (request == null)
                return NotFound();

            var vm = new ManpowerRequestViewModel
            {
                ManpowerRequestId = request.ManpowerRequestId,

                RequestDate = request.RequestDate,

                RecruitmentTypeId = request.RecruitmentTypeId,

                HODId = request.HODId,

                BranchId = request.BranchId,

                DepartmentId = request.DepartmentId,

                DesignationId = request.DesignationId,

                ReplacementEmployeeId = request.ReplacementEmployeeId,

                NumberOfPositions = request.NumberOfPositions,

                RequiredJoiningDate = request.RequiredJoiningDate,

                MinExperience = request.MinExperience,

                MaxExperience = request.MaxExperience,

                MinAge = request.MinAge,

                MaxAge = request.MaxAge,

                EducationId = request.EducationId,

                NationalityId = request.NationalityId,

                MinSalary = request.MinSalary,

                MaxSalary = request.MaxSalary,

                PriorityId = request.PriorityId,


                Remarks = request.Remarks
            };

            await LoadDropdowns(
                vm,
                request.BranchId,
                request.DepartmentId);

            return View(vm);
        }

        // POST: Recruitment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ManpowerRequestViewModel viewModel)
        {
            if (id != viewModel.ManpowerRequestId)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var request = await _context.ManpowerRequests.FindAsync(id);

                if (request == null)
                    return NotFound();

                request.RequestDate = viewModel.RequestDate;

                request.RecruitmentTypeId = viewModel.RecruitmentTypeId;

                request.HODId = viewModel.HODId;

                request.BranchId = viewModel.BranchId;

                request.DepartmentId = viewModel.DepartmentId;

                request.DesignationId = viewModel.DesignationId;

                request.ReplacementEmployeeId = viewModel.ReplacementEmployeeId;

                request.NumberOfPositions = viewModel.NumberOfPositions;

                request.RequiredJoiningDate = viewModel.RequiredJoiningDate;

                request.MinExperience = viewModel.MinExperience;

                request.MaxExperience = viewModel.MaxExperience;

                request.MinAge = viewModel.MinAge;

                request.MaxAge = viewModel.MaxAge;

                request.EducationId = viewModel.EducationId;

                request.NationalityId = viewModel.NationalityId;

                request.MinSalary = viewModel.MinSalary;

                request.MaxSalary = viewModel.MaxSalary;

                request.PriorityId = viewModel.PriorityId;


                request.Remarks = viewModel.Remarks;

                request.ModifiedBy =
                    Convert.ToInt32(HttpContext.Session.GetString("EmployeeId"));

                request.ModifiedDate = DateTime.Now;

                _context.Update(request);

                await _context.SaveChangesAsync();

                TempData["Success"] =
                    "Recruitment request updated successfully.";

                return RedirectToAction(nameof(Index));
            }

            await LoadDropdowns(
                viewModel,
                viewModel.BranchId,
                viewModel.DepartmentId);

            return View(viewModel);
        }
    }
}