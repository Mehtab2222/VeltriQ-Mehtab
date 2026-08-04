using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR.Attendance;

namespace VeltriQ.Controllers
{
    public class AttendancePolicyController : BaseController
    {
        private readonly TenantDbContext _context;

        public AttendancePolicyController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )
            : base(context, masterContext, userManager)
        {
            _context = context;
        }

        //====================================================
        // INDEX
        //====================================================

        public async Task<IActionResult> Index()
        {
            var policies = await _context.AttendancePolicies
                .Include(x => x.Company)
                .OrderBy(x => x.PolicyName)
                .ToListAsync();

            return View(policies);
        }
        //====================================================
        // CREATE
        //====================================================

        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();

            AttendancePolicy model = new AttendancePolicy
            {
                PolicyCode = await GeneratePolicyCode(),

                IsActive = true,

                EnableLateMark = true,

                EnableEarlyOut = true,

                EnableOvertime = false


            };

            return View(model);
        }
        //====================================================
        // CREATE
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttendancePolicy model)
        {
            await LoadDropdowns();

            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                //====================================================
                // DUPLICATE POLICY CODE
                //====================================================

                bool codeExists = await _context.AttendancePolicies
                    .AnyAsync(x =>
                        x.CompanyId == model.CompanyId &&
                        x.PolicyCode == model.PolicyCode &&
                        x.IsActive);

                if (codeExists)
                {
                    ModelState.AddModelError("PolicyCode", "Policy Code already exists.");

                    return View(model);
                }

                //====================================================
                // DUPLICATE POLICY NAME
                //====================================================

                bool nameExists = await _context.AttendancePolicies
                    .AnyAsync(x =>
                        x.CompanyId == model.CompanyId &&
                        x.PolicyName == model.PolicyName &&
                        x.IsActive);

                if (nameExists)
                {
                    ModelState.AddModelError("PolicyName", "Policy Name already exists.");

                    return View(model);
                }

                model.IsActive = true;
                model.CreatedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null &&
                    int.TryParse(currentUser.Id, out int userId))
                {
                    model.CreatedBy = userId;
                }

                _context.AttendancePolicies.Add(model);

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Attendance Policy created successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }
        }
        //====================================================
        // EDIT
        //====================================================

        public async Task<IActionResult> Edit(int id)
        {
            var policy = await _context.AttendancePolicies
                .FirstOrDefaultAsync(x => x.AttendancePolicyId == id);

            if (policy == null)
                return NotFound();

            await LoadDropdowns();

            return View(policy);
        }
        //====================================================
        // EDIT
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AttendancePolicy model)
        {
            await LoadDropdowns();

            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                //====================================================
                // DUPLICATE POLICY CODE
                //====================================================

                bool codeExists = await _context.AttendancePolicies
                    .AnyAsync(x =>
                        x.CompanyId == model.CompanyId &&
                        x.PolicyCode.ToUpper() == model.PolicyCode.ToUpper() &&
                        x.AttendancePolicyId != model.AttendancePolicyId &&
                        x.IsActive);

                if (codeExists)
                {
                    ModelState.AddModelError("PolicyCode", "Policy Code already exists.");

                    return View(model);
                }

                //====================================================
                // DUPLICATE POLICY NAME
                //====================================================

                bool nameExists = await _context.AttendancePolicies
                    .AnyAsync(x =>
                        x.CompanyId == model.CompanyId &&
                        x.PolicyName == model.PolicyName &&
                        x.AttendancePolicyId != model.AttendancePolicyId &&
                        x.IsActive);

                if (nameExists)
                {
                    ModelState.AddModelError("PolicyName", "Policy Name already exists.");

                    return View(model);
                }

                var policy = await _context.AttendancePolicies
                    .FirstOrDefaultAsync(x => x.AttendancePolicyId == model.AttendancePolicyId);

                if (policy == null)
                    return NotFound();

                //====================================================
                // BASIC INFORMATION
                //====================================================

                policy.CompanyId = model.CompanyId;
                policy.PolicyCode = model.PolicyCode;
                policy.PolicyName = model.PolicyName;
                policy.Description = model.Description;

                //====================================================
                // WORKING HOURS
                //====================================================

                policy.FullDayHours = model.FullDayHours;
                policy.HalfDayHours = model.HalfDayHours;
                policy.MinimumWorkingHours = model.MinimumWorkingHours;

                //====================================================
                // LATE ARRIVAL
                //====================================================

                policy.LateGraceMinutes = model.LateGraceMinutes;
                policy.EnableLateMark = model.EnableLateMark;
                policy.MaxLateMarksPerMonth = model.MaxLateMarksPerMonth;
                policy.LateMarkDeductionDays = model.LateMarkDeductionDays;

                //====================================================
                // EARLY LEAVING
                //====================================================

                policy.EarlyOutGraceMinutes = model.EarlyOutGraceMinutes;
                policy.EnableEarlyOut = model.EnableEarlyOut;
                policy.MaxEarlyOutPerMonth = model.MaxEarlyOutPerMonth;
                policy.EarlyOutDeductionDays = model.EarlyOutDeductionDays;

                //====================================================
                // OVERTIME
                //====================================================

                policy.EnableOvertime = model.EnableOvertime;
                policy.MinimumOvertimeMinutes = model.MinimumOvertimeMinutes;
                policy.RoundOvertime = model.RoundOvertime;
                policy.MaximumOvertimeHours = model.MaximumOvertimeHours;

                //====================================================
                // PUNCH SETTINGS
                //====================================================

                policy.MinimumPunchesPerDay = model.MinimumPunchesPerDay;
                policy.AllowSinglePunch = model.AllowSinglePunch;
                policy.IgnoreDuplicatePunch = model.IgnoreDuplicatePunch;
                policy.DuplicatePunchIntervalMinutes = model.DuplicatePunchIntervalMinutes;

                //====================================================
                // MISSING PUNCH
                //====================================================

                policy.AutoAbsentForMissingPunch = model.AutoAbsentForMissingPunch;
                policy.AutoHalfDayForMissingPunch = model.AutoHalfDayForMissingPunch;

                //====================================================
                // HOLIDAY RULES
                //====================================================

                policy.EnableSandwichRule = model.EnableSandwichRule;
                policy.IncludeHolidayPrefixSuffix = model.IncludeHolidayPrefixSuffix;
                policy.IncludeWeeklyOffPrefixSuffix = model.IncludeWeeklyOffPrefixSuffix;

                //====================================================
                // GENERAL
                //====================================================

 

                //====================================================
                // AUDIT
                //====================================================

                policy.ModifiedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null &&
                    int.TryParse(currentUser.Id, out int userId))
                {
                    policy.ModifiedBy = userId;
                }

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Attendance Policy updated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }
        }
        //====================================================
        // TOGGLE STATUS
        //====================================================

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var policy = await _context.AttendancePolicies
                .FirstOrDefaultAsync(x => x.AttendancePolicyId == id);

            if (policy == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Attendance Policy not found."
                });
            }

            //====================================================
            // CHECK WHETHER POLICY IS USED IN ANY SHIFT
            //====================================================

            bool isAssigned = await _context.ShiftMasters
                .AnyAsync(x =>
                    x.AttendancePolicyId == id &&
                    x.IsActive);

            if (policy.IsActive && isAssigned)
            {
                return Json(new
                {
                    success = false,
                    message = "This Attendance Policy is assigned to one or more shifts and cannot be deactivated."
                });
            }

            policy.IsActive = !policy.IsActive;
            policy.ModifiedOn = DateTime.Now;

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null &&
                int.TryParse(currentUser.Id, out int userId))
            {
                policy.ModifiedBy = userId;
            }

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true
            });
        }
        //====================================================
        // LOAD DROPDOWNS
        //====================================================

        private async Task LoadDropdowns()
        {
            ViewBag.CompanyDropdown = new SelectList(
                await _context.Companies
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.CompanyName)
                    .ToListAsync(),
                "CompanyId",
                "CompanyName");
        }
        //====================================================
        // GENERATE POLICY CODE
        //====================================================

        private async Task<string> GeneratePolicyCode()
        {
            var lastPolicy = await _context.AttendancePolicies
                .OrderByDescending(x => x.AttendancePolicyId)
                .FirstOrDefaultAsync();

            if (lastPolicy == null)
                return "ATP-001";

            int nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastPolicy.PolicyCode))
            {
                var numericPart = lastPolicy.PolicyCode.Replace("ATP-", "");

                if (int.TryParse(numericPart, out int currentNumber))
                {
                    nextNumber = currentNumber + 1;
                }
            }

            return $"ATP-{nextNumber:D3}";
        }
        //====================================================
        // GET POLICIES BY COMPANY (AJAX)
        //====================================================

        [HttpGet]
        public async Task<JsonResult> GetPoliciesByCompany(int companyId)
        {
            var policies = await _context.AttendancePolicies
                .Where(x => x.CompanyId == companyId && x.IsActive)
                .OrderBy(x => x.PolicyName)
                .Select(x => new
                {
                    attendancePolicyId = x.AttendancePolicyId,
                    policyName = x.PolicyName
                })
                .ToListAsync();

            return Json(policies);
        }
    }
}
