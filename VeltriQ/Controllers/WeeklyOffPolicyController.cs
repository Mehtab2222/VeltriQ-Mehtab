using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR.Attendance;
using VeltriQ.ViewModels.Attendance;

namespace VeltriQ.Controllers
{
    public class WeeklyOffPolicyController : BaseController
    {
        private readonly TenantDbContext _context;

        public WeeklyOffPolicyController
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
            var policies = await _context.WeeklyOffPolicies
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
            WeeklyOffPolicyViewModel vm = new();

            await LoadDropdowns(vm);

            vm.WeeklyOffPolicy.PolicyCode = await GeneratePolicyCode();
            vm.WeeklyOffPolicy.IsActive = true;

            return View(vm);
        }
        //====================================================
        // LOAD DROPDOWNS
        //====================================================

        private async Task LoadDropdowns(WeeklyOffPolicyViewModel vm)
        {
            vm.Companies = await _context.Companies
                .Where(x => x.IsActive)
                .OrderBy(x => x.CompanyName)
                .Select(x => new SelectListItem
                {
                    Value = x.CompanyId.ToString(),
                    Text = x.CompanyName
                })
                .ToListAsync();
        }
        //====================================================
        // CREATE
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WeeklyOffPolicyViewModel vm)
        {
            await LoadDropdowns(vm);

            try
            {
                if (!ModelState.IsValid)
                    return View(vm);

                //====================================================
                // DUPLICATE POLICY CODE
                //====================================================

                bool codeExists = await _context.WeeklyOffPolicies
                    .AnyAsync(x =>
                        x.CompanyId == vm.WeeklyOffPolicy.CompanyId &&
                        x.PolicyCode == vm.WeeklyOffPolicy.PolicyCode &&
                        x.IsActive);

                if (codeExists)
                {
                    ModelState.AddModelError("WeeklyOffPolicy.PolicyCode", "Policy Code already exists.");

                    return View(vm);
                }

                //====================================================
                // DUPLICATE POLICY NAME
                //====================================================

                bool nameExists = await _context.WeeklyOffPolicies
                    .AnyAsync(x =>
                        x.CompanyId == vm.WeeklyOffPolicy.CompanyId &&
                        x.PolicyName == vm.WeeklyOffPolicy.PolicyName &&
                        x.IsActive);

                if (nameExists)
                {
                    ModelState.AddModelError("WeeklyOffPolicy.PolicyName", "Policy Name already exists.");

                    return View(vm);
                }

                vm.WeeklyOffPolicy.CreatedOn = DateTime.Now;
                vm.WeeklyOffPolicy.IsActive = true;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null &&
                    int.TryParse(currentUser.Id, out int userId))
                {
                    vm.WeeklyOffPolicy.CreatedBy = userId;
                }

                _context.WeeklyOffPolicies.Add(vm.WeeklyOffPolicy);

                await _context.SaveChangesAsync();

                //====================================================
                // SAVE DETAILS
                //====================================================

                foreach (var item in vm.WeeklyOffDetails)
                {
                    _context.WeeklyOffPolicyDetails.Add(new WeeklyOffPolicyDetail
                    {
                        WeeklyOffPolicyId = vm.WeeklyOffPolicy.WeeklyOffPolicyId,
                        DayOfWeek = item.DayOfWeek,
                        WeekNumber = item.WeekNumber,
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        CreatedBy = vm.WeeklyOffPolicy.CreatedBy
                    });
                }

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Weekly Off Policy created successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(vm);
            }
        }
        //====================================================
        // GENERATE POLICY CODE
        //====================================================

        private async Task<string> GeneratePolicyCode()
        {
            var lastPolicy = await _context.WeeklyOffPolicies
                .OrderByDescending(x => x.WeeklyOffPolicyId)
                .FirstOrDefaultAsync();

            if (lastPolicy == null)
                return "WOP-0001";

            int nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastPolicy.PolicyCode))
            {
                var numericPart = lastPolicy.PolicyCode.Replace("WOP-", "");

                if (int.TryParse(numericPart, out int currentNumber))
                {
                    nextNumber = currentNumber + 1;
                }
            }

            return $"WOP-{nextNumber:D4}";
        }
        //====================================================
        // GET WEEKLY OFF DETAILS (AJAX)
        //====================================================

        [HttpGet]
        public async Task<JsonResult> GetWeeklyOffDetails(int weeklyOffPolicyId)
        {
            var details = await _context.WeeklyOffPolicyDetails
                .Where(x => x.WeeklyOffPolicyId == weeklyOffPolicyId &&
                            x.IsActive)
                .OrderBy(x => x.DayOfWeek)
                .ThenBy(x => x.WeekNumber)
                .Select(x => new
                {
                    weeklyOffPolicyDetailId = x.WeeklyOffPolicyDetailId,
                    dayOfWeek = (int)x.DayOfWeek,
                    weekNumber = x.WeekNumber
                })
                .ToListAsync();

            return Json(details);
        }
        //====================================================
        // SAVE WEEKLY OFF DETAILS (AJAX)
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveWeeklyOffDetails(
            int weeklyOffPolicyId,
            [FromBody] List<WeeklyOffPolicyDetailViewModel> details)
        {
            try
            {
                var policy = await _context.WeeklyOffPolicies
                    .Include(x => x.WeeklyOffDetails)
                    .FirstOrDefaultAsync(x => x.WeeklyOffPolicyId == weeklyOffPolicyId);

                if (policy == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Weekly Off Policy not found."
                    });
                }

                //============================================
                // REMOVE DELETED DETAILS
                //============================================

                var incomingIds = details
                    .Where(x => x.WeeklyOffPolicyDetailId > 0)
                    .Select(x => x.WeeklyOffPolicyDetailId)
                    .ToList();

                var removeItems = policy.WeeklyOffDetails
                    .Where(x => !incomingIds.Contains(x.WeeklyOffPolicyDetailId))
                    .ToList();

                _context.WeeklyOffPolicyDetails.RemoveRange(removeItems);

                //============================================
                // INSERT / UPDATE
                //============================================

                foreach (var item in details)
                {
                    if (item.WeeklyOffPolicyDetailId > 0)
                    {
                        var existing = policy.WeeklyOffDetails
                            .FirstOrDefault(x =>
                                x.WeeklyOffPolicyDetailId ==
                                item.WeeklyOffPolicyDetailId);

                        if (existing != null)
                        {
                            existing.DayOfWeek = item.DayOfWeek;
                            existing.WeekNumber = item.WeekNumber;
                            existing.ModifiedOn = DateTime.Now;
                        }
                    }
                    else
                    {
                        policy.WeeklyOffDetails.Add(new WeeklyOffPolicyDetail
                        {
                            WeeklyOffPolicyId = weeklyOffPolicyId,
                            DayOfWeek = item.DayOfWeek,
                            WeekNumber = item.WeekNumber,
                            IsActive = true,
                            CreatedOn = DateTime.Now
                        });
                    }
                }

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Weekly Off Details saved successfully."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        //====================================================
        // EDIT
        //====================================================

        public async Task<IActionResult> Edit(int id)
        {
            var policy = await _context.WeeklyOffPolicies
                .Include(x => x.WeeklyOffDetails)
                .FirstOrDefaultAsync(x => x.WeeklyOffPolicyId == id);

            if (policy == null)
                return NotFound();

            WeeklyOffPolicyViewModel vm = new();

            vm.WeeklyOffPolicy = policy;

            vm.WeeklyOffDetails = policy.WeeklyOffDetails
                .Where(x => x.IsActive)
                .OrderBy(x => x.DayOfWeek)
                .ThenBy(x => x.WeekNumber)
                .Select(x => new WeeklyOffPolicyDetailViewModel
                {
                    WeeklyOffPolicyDetailId = x.WeeklyOffPolicyDetailId,
                    DayOfWeek = x.DayOfWeek,
                    WeekNumber = x.WeekNumber
                })
                .ToList();

            await LoadDropdowns(vm);

            return View(vm);
        }
        //====================================================
        // EDIT
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WeeklyOffPolicyViewModel vm)
        {
            await LoadDropdowns(vm);

            try
            {
                if (!ModelState.IsValid)
                    return View(vm);

                bool codeExists = await _context.WeeklyOffPolicies
                    .AnyAsync(x =>
                        x.CompanyId == vm.WeeklyOffPolicy.CompanyId &&
                        x.PolicyCode == vm.WeeklyOffPolicy.PolicyCode &&
                        x.WeeklyOffPolicyId != vm.WeeklyOffPolicy.WeeklyOffPolicyId &&
                        x.IsActive);

                if (codeExists)
                {
                    ModelState.AddModelError(
                        "WeeklyOffPolicy.PolicyCode",
                        "Policy Code already exists.");

                    return View(vm);
                }

                bool nameExists = await _context.WeeklyOffPolicies
                    .AnyAsync(x =>
                        x.CompanyId == vm.WeeklyOffPolicy.CompanyId &&
                        x.PolicyName == vm.WeeklyOffPolicy.PolicyName &&
                        x.WeeklyOffPolicyId != vm.WeeklyOffPolicy.WeeklyOffPolicyId &&
                        x.IsActive);

                if (nameExists)
                {
                    ModelState.AddModelError(
                        "WeeklyOffPolicy.PolicyName",
                        "Policy Name already exists.");

                    return View(vm);
                }

                var policy = await _context.WeeklyOffPolicies
                    .FirstOrDefaultAsync(x =>
                        x.WeeklyOffPolicyId ==
                        vm.WeeklyOffPolicy.WeeklyOffPolicyId);

                if (policy == null)
                    return NotFound();

                policy.CompanyId = vm.WeeklyOffPolicy.CompanyId;
                policy.PolicyCode = vm.WeeklyOffPolicy.PolicyCode;
                policy.PolicyName = vm.WeeklyOffPolicy.PolicyName;
                policy.Description = vm.WeeklyOffPolicy.Description;
                policy.IsDefaultPolicy = vm.WeeklyOffPolicy.IsDefaultPolicy;

                policy.ModifiedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null &&
                    int.TryParse(currentUser.Id, out int userId))
                {
                    policy.ModifiedBy = userId;
                }

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] =
                    "Weekly Off Policy updated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(vm);
            }
        }
        //====================================================
        // TOGGLE STATUS
        //====================================================

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var policy = await _context.WeeklyOffPolicies
                .FirstOrDefaultAsync(x =>
                    x.WeeklyOffPolicyId == id);

            if (policy == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Weekly Off Policy not found."
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
        // GET POLICY BY ID (AJAX FOR EDIT MODAL)
        //====================================================
        [HttpGet]
        public async Task<JsonResult> GetPolicyById(int id)
        {
            var policy = await _context.WeeklyOffPolicies
                .FirstOrDefaultAsync(x => x.WeeklyOffPolicyId == id);

            if (policy == null)
                return Json(new { success = false, message = "Policy not found." });

            return Json(new
            {
                success = true,
                weeklyOffPolicyId = policy.WeeklyOffPolicyId,
                companyId = policy.CompanyId,
                policyCode = policy.PolicyCode,
                policyName = policy.PolicyName,
                description = policy.Description,
                isDefaultPolicy = policy.IsDefaultPolicy,
                isActive = policy.IsActive
            });
        }
    }
}