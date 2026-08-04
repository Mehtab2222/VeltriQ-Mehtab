using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.ViewModels.Attendance;
using VeltriQ.Models.HR.Attendance;

namespace VeltriQ.Controllers
{
    public class ShiftMasterController : BaseController
    {
        private readonly TenantDbContext _context;

        public ShiftMasterController
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
            var shifts = await _context.ShiftMasters
                .Include(x => x.Company)
                .Include(x => x.Branch)
                .Include(x => x.AttendancePolicy)
                .OrderBy(x => x.ShiftName)
                .AsNoTracking()
                .ToListAsync();

            return View(shifts);
        }

        //====================================================
        // DETAILS
        //====================================================

        public async Task<IActionResult> Details(int id)
        {
            var shift = await _context.ShiftMasters
                .Include(x => x.Company)
                .Include(x => x.Branch)
                .Include(x => x.AttendancePolicy)
                .Include(x => x.ShiftBreaks)
                .FirstOrDefaultAsync(x => x.ShiftMasterId == id);

            if (shift == null)
                return NotFound();

            return View(shift);
        }

        //====================================================
        // CREATE
        //====================================================

        public async Task<IActionResult> Create()
        {
            var vm = new ShiftMasterViewModel();
            await LoadDropdowns(vm);

            if (vm.ShiftBreaks == null)
                vm.ShiftBreaks = new List<ShiftBreakViewModel>();

            if (!vm.ShiftBreaks.Any())
                vm.ShiftBreaks.Add(new ShiftBreakViewModel());

            return View(vm);
        }

        //====================================================
        // LOAD DROPDOWNS
        //====================================================
        private async Task LoadDropdowns(ShiftMasterViewModel vm)
        {
            vm.Companies = new SelectList(
                await _context.Companies
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.CompanyName)
                    .ToListAsync(),
                "CompanyId",
                "CompanyName");

            vm.Branches = new SelectList(
                await _context.Branches
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.BranchName)
                    .ToListAsync(),
                "BranchId",
                "BranchName");

            vm.AttendancePolicies = new SelectList(
                await _context.AttendancePolicies
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.PolicyName)
                    .ToListAsync(),
                "AttendancePolicyId",
                "PolicyName");
        }

        //====================================================
        // LOAD BRANCHES BY COMPANY (AJAX)
        //====================================================

        [HttpGet]
        public async Task<JsonResult> GetBranches(int companyId)
        {
            var branches = await _context.Branches
                .Where(x => x.CompanyId == companyId && x.IsActive)
                .OrderBy(x => x.BranchName)
                .Select(x => new
                {
                    value = x.BranchId,
                    text = x.BranchName
                })
                .ToListAsync();

            return Json(branches);
        }
        //====================================================
        // CREATE
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShiftMasterViewModel vm)
        {
            await LoadDropdowns(vm);

            try
            {
                if (!ModelState.IsValid)
                    return View(vm);

                //=========================================
                // DUPLICATE SHIFT CODE CHECK
                //=========================================

                bool exists = await _context.ShiftMasters
                    .AnyAsync(x =>
                        x.CompanyId == vm.Shift.CompanyId &&
                        x.ShiftCode == vm.Shift.ShiftCode &&
                        x.IsActive);

                if (exists)
                {
                    ModelState.AddModelError("Shift.ShiftCode", "Shift Code already exists.");

                    return View(vm);
                }

                //=========================================
                // SET DEFAULT VALUES
                //=========================================

                vm.Shift.IsActive = true;
                vm.Shift.CreatedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null && int.TryParse(currentUser.Id, out int userId))
                {
                    vm.Shift.CreatedBy = userId;
                }

                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    _context.ShiftMasters.Add(vm.Shift);

                    await _context.SaveChangesAsync();

                    foreach (var item in vm.ShiftBreaks)
                    {
                        if (string.IsNullOrWhiteSpace(item.BreakName))
                            continue;

                        _context.ShiftBreaks.Add(new ShiftBreak
                        {
                            ShiftMasterId = vm.Shift.ShiftMasterId,
                            BreakName = item.BreakName,
                            StartTime = item.StartTime,
                            EndTime = item.EndTime,
                            IsPaidBreak = item.IsPaidBreak,

                            IsActive = true,
                            CreatedOn = DateTime.Now,
                            CreatedBy = vm.Shift.CreatedBy
                        });
                    }

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    TempData["SuccessMessage"] = "Shift created successfully.";

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(vm);
            }
        }
        //====================================================
        // EDIT
        //====================================================

        public async Task<IActionResult> Edit(int id)
        {
            var shift = await _context.ShiftMasters
                .Include(x => x.ShiftBreaks)
                .FirstOrDefaultAsync(x => x.ShiftMasterId == id);

            if (shift == null)
                return NotFound();

            var vm = new ShiftMasterViewModel
            {
                Shift = shift,
                ShiftBreaks = shift.ShiftBreaks.Select(x => new ShiftBreakViewModel
                {
                    ShiftBreakId = x.ShiftBreakId,
                    BreakName = x.BreakName,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    IsPaidBreak = x.IsPaidBreak
                }).ToList()
            };

            await LoadDropdowns(vm);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShiftMasterViewModel vm)
        {
            await LoadDropdowns(vm);

            try
            {
                if (!ModelState.IsValid)
                    return View(vm);

                //=========================================
                // DUPLICATE SHIFT CODE CHECK
                //=========================================

                bool exists = await _context.ShiftMasters
                    .AnyAsync(x =>
                        x.CompanyId == vm.Shift.CompanyId &&
                        x.ShiftCode == vm.Shift.ShiftCode &&
                        x.ShiftMasterId != vm.Shift.ShiftMasterId &&
                        x.IsActive);

                if (exists)
                {
                    ModelState.AddModelError("Shift.ShiftCode", "Shift Code already exists.");

                    return View(vm);
                }

                var shift = await _context.ShiftMasters
                    .Include(x => x.ShiftBreaks)
                    .FirstOrDefaultAsync(x => x.ShiftMasterId == vm.Shift.ShiftMasterId);

                if (shift == null)
                    return NotFound();

                //=========================================
                // UPDATE SHIFT MASTER
                //=========================================

                shift.CompanyId = vm.Shift.CompanyId;
                shift.BranchId = vm.Shift.BranchId;
                shift.AttendancePolicyId = vm.Shift.AttendancePolicyId;
                shift.ShiftCode = vm.Shift.ShiftCode;
                shift.ShiftName = vm.Shift.ShiftName;
                shift.StartTime = vm.Shift.StartTime;
                shift.EndTime = vm.Shift.EndTime;
                shift.GraceInMinutes = vm.Shift.GraceInMinutes;
                shift.GraceOutMinutes = vm.Shift.GraceOutMinutes;
                shift.FullDayHours = vm.Shift.FullDayHours;
                shift.HalfDayHours = vm.Shift.HalfDayHours;
                shift.MinimumWorkingHours = vm.Shift.MinimumWorkingHours;
                shift.IsNightShift = vm.Shift.IsNightShift;
                shift.IsFlexibleShift = vm.Shift.IsFlexibleShift;
                shift.IsCrossDayShift = vm.Shift.IsCrossDayShift;

                shift.ModifiedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null && int.TryParse(currentUser.Id, out int userId))
                {
                    shift.ModifiedBy = userId;
                }

                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    await _context.SaveChangesAsync();

                    //=========================================
                    // REMOVE OLD BREAKS
                    //=========================================

                    var existingBreaks = await _context.ShiftBreaks
                        .Where(x => x.ShiftMasterId == shift.ShiftMasterId)
                        .ToListAsync();

                    _context.ShiftBreaks.RemoveRange(existingBreaks);

                    await _context.SaveChangesAsync();

                    //=========================================
                    // INSERT NEW BREAKS
                    //=========================================

                    foreach (var item in vm.ShiftBreaks)
                    {
                        if (string.IsNullOrWhiteSpace(item.BreakName))
                            continue;

                        _context.ShiftBreaks.Add(new ShiftBreak
                        {
                            ShiftMasterId = shift.ShiftMasterId,

                            BreakName = item.BreakName,

                            StartTime = item.StartTime,

                            EndTime = item.EndTime,

                            IsPaidBreak = item.IsPaidBreak,

                            IsActive = true,

                            CreatedOn = DateTime.Now,

                            CreatedBy = shift.ModifiedBy
                        });
                    }

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    TempData["SuccessMessage"] = "Shift updated successfully.";

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }

                TempData["SuccessMessage"] = "Shift updated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(vm);
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetCompanies()
        {
            var companies = await _context.Companies
                .Where(x => x.IsActive)
                .OrderBy(x => x.CompanyName)
                .Select(x => new
                {
                    x.CompanyId,
                    x.CompanyName
                })
                .ToListAsync();

            return Json(companies);
        }

        [HttpGet]
        public async Task<JsonResult> GetAttendancePolicies(int companyId)
        {
            var policies = await _context.AttendancePolicies
                .Where(x => x.IsActive && x.CompanyId == companyId)
                .OrderBy(x => x.PolicyName)
                .Select(x => new
                {
                    x.AttendancePolicyId,
                    x.PolicyName
                })
                .ToListAsync();

            return Json(policies);
        }
        //====================================================
        // GET BREAKS FOR SHIFT (AJAX)
        //====================================================
        [HttpGet]
        public async Task<JsonResult> GetBreaks(int shiftMasterId)
        {
            var breaks = await _context.ShiftBreaks
                .Where(x => x.ShiftMasterId == shiftMasterId && x.IsActive)
                .OrderBy(x => x.StartTime)
                .Select(x => new
                {
                    shiftBreakId = x.ShiftBreakId,
                    breakName = x.BreakName,
                    startTime = x.StartTime.ToString(@"hh\:mm"),
                    endTime = x.EndTime.ToString(@"hh\:mm"),
                    isPaidBreak = x.IsPaidBreak
                })
                .ToListAsync();

            return Json(breaks);
        }

        //====================================================
        // SAVE SHIFT BREAKS (AJAX)
        //====================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveBreaks(int shiftMasterId, [FromBody] List<ShiftBreakViewModel> breaks)
        {
            try
            {
                var shift = await _context.ShiftMasters
                    .Include(x => x.ShiftBreaks)
                    .FirstOrDefaultAsync(x => x.ShiftMasterId == shiftMasterId);

                if (shift == null)
                    return Json(new { success = false, message = "Shift record not found." });

                // Remove existing active breaks or sync them
                var incomingIds = breaks.Select(b => b.ShiftBreakId).Where(id => id > 0).ToList();
                var breaksToRemove = shift.ShiftBreaks.Where(b => !incomingIds.Contains(b.ShiftBreakId)).ToList();

                _context.ShiftBreaks.RemoveRange(breaksToRemove);

                foreach (var b in breaks)
                {
                    if (string.IsNullOrWhiteSpace(b.BreakName)) continue;

                    if (b.ShiftBreakId > 0)
                    {
                        var existing = shift.ShiftBreaks.FirstOrDefault(x => x.ShiftBreakId == b.ShiftBreakId);
                        if (existing != null)
                        {
                            existing.BreakName = b.BreakName.Trim();
                            existing.StartTime = b.StartTime;
                            existing.EndTime = b.EndTime;
                            existing.IsPaidBreak = b.IsPaidBreak;
                            existing.ModifiedOn = DateTime.Now;
                        }
                    }
                    else
                    {
                        shift.ShiftBreaks.Add(new ShiftBreak
                        {
                            ShiftMasterId = shiftMasterId,
                            BreakName = b.BreakName.Trim(),
                            StartTime = b.StartTime,
                            EndTime = b.EndTime,
                            IsPaidBreak = b.IsPaidBreak,
                            IsActive = true,
                            CreatedOn = DateTime.Now
                        });
                    }
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Breaks updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        //====================================================
        // TOGGLE STATUS
        //====================================================

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            try
            {
                var shift = await _context.ShiftMasters
                    .FirstOrDefaultAsync(x => x.ShiftMasterId == id);

                if (shift == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Shift not found."
                    });
                }

                //=========================================
                // CHECK WHETHER SHIFT IS ASSIGNED
                //=========================================

                bool isAssigned = await _context.EmployeeShifts
                    .AnyAsync(x => x.ShiftMasterId == id && x.IsActive);

                if (shift.IsActive && isAssigned)
                {
                    return Json(new
                    {
                        success = false,
                        message = "This shift is assigned to employees and cannot be deactivated."
                    });
                }

                shift.IsActive = !shift.IsActive;
                shift.ModifiedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null && int.TryParse(currentUser.Id, out int userId))
                {
                    shift.ModifiedBy = userId;
                }

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    isActive = shift.IsActive,
                    message = shift.IsActive
                        ? "Shift activated successfully."
                        : "Shift deactivated successfully."
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
        // DELETE
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var shift = await _context.ShiftMasters
                    .Include(x => x.ShiftBreaks)
                    .FirstOrDefaultAsync(x => x.ShiftMasterId == id);

                if (shift == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Shift not found."
                    });
                }

                bool isAssigned = await _context.EmployeeShifts
                    .AnyAsync(x => x.ShiftMasterId == id && x.IsActive);

                if (isAssigned)
                {
                    return Json(new
                    {
                        success = false,
                        message = "This shift is assigned to employees and cannot be deleted."
                    });
                }

                // Soft Delete
                shift.IsActive = false;
                shift.ModifiedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null && int.TryParse(currentUser.Id, out int userId))
                {
                    shift.ModifiedBy = userId;
                }

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Shift deleted successfully."
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
    }
}