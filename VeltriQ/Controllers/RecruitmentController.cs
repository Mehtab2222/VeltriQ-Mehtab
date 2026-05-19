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
    }
}