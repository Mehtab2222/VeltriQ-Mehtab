using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
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
            await LoadDropdowns();

            return View(new ShiftMaster());
        }

        //====================================================
        // LOAD DROPDOWNS
        //====================================================

        private async Task LoadDropdowns()
        {
            ViewBag.Companies = new SelectList(
                await _context.Companies
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.CompanyName)
                    .ToListAsync(),
                "CompanyId",
                "CompanyName");

            ViewBag.Branches = new SelectList(
                await _context.Branches
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.BranchName)
                    .ToListAsync(),
                "BranchId",
                "BranchName");

            ViewBag.AttendancePolicies = new SelectList(
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
        public async Task<IActionResult> Create(ShiftMaster model)
        {
            await LoadDropdowns();

            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                //=========================================
                // DUPLICATE SHIFT CODE CHECK
                //=========================================

                bool exists = await _context.ShiftMasters
                    .AnyAsync(x =>
                        x.CompanyId == model.CompanyId &&
                        x.ShiftCode == model.ShiftCode &&
                        x.IsActive);

                if (exists)
                {
                    ModelState.AddModelError("ShiftCode", "Shift Code already exists.");

                    return View(model);
                }

                //=========================================
                // SET DEFAULT VALUES
                //=========================================

                model.IsActive = true;
                model.CreatedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null && int.TryParse(currentUser.Id, out int userId))
                {
                    model.CreatedBy = userId;
                }

                _context.ShiftMasters.Add(model);

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Shift created successfully.";

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
            var shift = await _context.ShiftMasters
                .FirstOrDefaultAsync(x => x.ShiftMasterId == id);

            if (shift == null)
                return NotFound();

            await LoadDropdowns();

            return View(shift);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShiftMaster model)
        {
            await LoadDropdowns();

            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                //=========================================
                // DUPLICATE SHIFT CODE CHECK
                //=========================================

                bool exists = await _context.ShiftMasters
                    .AnyAsync(x =>
                        x.CompanyId == model.CompanyId &&
                        x.ShiftCode == model.ShiftCode &&
                        x.ShiftMasterId != model.ShiftMasterId &&
                        x.IsActive);

                if (exists)
                {
                    ModelState.AddModelError("ShiftCode", "Shift Code already exists.");

                    return View(model);
                }

                var shift = await _context.ShiftMasters
                    .FirstOrDefaultAsync(x => x.ShiftMasterId == model.ShiftMasterId);

                if (shift == null)
                    return NotFound();

                shift.CompanyId = model.CompanyId;
                shift.BranchId = model.BranchId;
                shift.AttendancePolicyId = model.AttendancePolicyId;
                shift.ShiftCode = model.ShiftCode;
                shift.ShiftName = model.ShiftName;
                shift.StartTime = model.StartTime;
                shift.EndTime = model.EndTime;
                shift.GraceInMinutes = model.GraceInMinutes;
                shift.GraceOutMinutes = model.GraceOutMinutes;
                shift.FullDayHours = model.FullDayHours;
                shift.HalfDayHours = model.HalfDayHours;
                shift.MinimumWorkingHours = model.MinimumWorkingHours;
                shift.IsNightShift = model.IsNightShift;
                shift.IsFlexibleShift = model.IsFlexibleShift;
                shift.IsCrossDayShift = model.IsCrossDayShift;

                shift.ModifiedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null && int.TryParse(currentUser.Id, out int userId))
                {
                    shift.ModifiedBy = userId;
                }

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Shift updated successfully.";

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