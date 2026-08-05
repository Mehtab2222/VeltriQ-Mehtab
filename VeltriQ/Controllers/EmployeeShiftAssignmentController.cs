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
    public class EmployeeShiftAssignmentController : BaseController
    {
        private readonly TenantDbContext _context;

        public EmployeeShiftAssignmentController
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
            var assignments = await _context.EmployeeShifts
                .Include(x => x.Company)
                .Include(x => x.Employee)
                .Include(x => x.ShiftMaster)
                .Where(x => x.IsCurrent)
                .OrderBy(x => x.Employee!.FirstName)
                .ToListAsync();

            return View(assignments);
        }
        //====================================================
        // CREATE
        //====================================================

        public async Task<IActionResult> Create()
        {
            EmployeeShiftViewModel vm = new();

            await LoadDropdowns(vm);

            vm.EmployeeShift.EffectiveFrom = DateTime.Today;
            vm.EmployeeShift.IsActive = true;
            vm.EmployeeShift.IsCurrent = true;

            return View(vm);
        }
        //====================================================
        // LOAD DROPDOWNS
        //====================================================

        private async Task LoadDropdowns(EmployeeShiftViewModel vm)
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

            vm.Employees = await _context.Employees
                .Where(x => x.IsActive)
               .OrderBy(x => x.FirstName)
                .Select(x => new SelectListItem
                {
                    Value = x.EmployeeId.ToString(),
                    Text = x.EmployeeCode + " - " + x.FirstName + " " + x.LastName
                })
                .ToListAsync();

            vm.Shifts = await _context.ShiftMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.ShiftName)
                .Select(x => new SelectListItem
                {
                    Value = x.ShiftMasterId.ToString(),
                    Text = x.ShiftName
                })
                .ToListAsync();
        }
        //====================================================
        // GET EMPLOYEES BY COMPANY
        //====================================================

        [HttpGet]
        public async Task<JsonResult> GetEmployeesByCompany(int companyId)
        {
            var employees = await _context.Employees
                .Where(x => x.IsActive)
                .OrderBy(x => x.FirstName)
                .Select(x => new
                {
                    employeeId = x.EmployeeId,
                    employeeCode = x.EmployeeCode,
                    employeeName = x.FirstName + " " + x.LastName,
                    companyId = x.CompanyId
                })
                .ToListAsync();

            return Json(employees);
        }
        //====================================================
        // GET ASSIGNMENT
        //====================================================

        [HttpGet]
        public async Task<IActionResult> GetAssignment(int id)
        {
            var assignment = await _context.EmployeeShifts
                .Include(x => x.Employee)
                .Include(x => x.ShiftMaster)
                .FirstOrDefaultAsync(x => x.EmployeeShiftId == id);

            if (assignment == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Shift assignment not found."
                });
            }

            return Json(new
            {
                success = true,

                employeeShiftId = assignment.EmployeeShiftId,

                companyId = assignment.CompanyId,

                employeeId = assignment.EmployeeId,

                employeeName = $"{assignment.Employee?.EmployeeCode} - {assignment.Employee?.FirstName} {assignment.Employee?.LastName}".Trim(),

                shiftMasterId = assignment.ShiftMasterId,

                shiftName = $"{assignment.ShiftMaster?.ShiftCode} - {assignment.ShiftMaster?.ShiftName}".Trim(),

                effectiveFrom = assignment.EffectiveFrom.ToString("yyyy-MM-dd"),

                effectiveTo = assignment.EffectiveTo.HasValue
                    ? assignment.EffectiveTo.Value.ToString("yyyy-MM-dd")
                    : "",

                remarks = assignment.Remarks ?? "",

                isActive = assignment.IsActive
            });
        }
        //====================================================
        // GET SHIFTS BY COMPANY
        //====================================================

        [HttpGet]
        public async Task<JsonResult> GetShiftsByCompany(int companyId)
        {
            var shifts = await _context.ShiftMasters
                .Where(x => x.CompanyId == companyId && x.IsActive)
                .OrderBy(x => x.ShiftName)
                .Select(x => new
                {
                    shiftMasterId = x.ShiftMasterId,
                    shiftName = x.ShiftName
                })
                .ToListAsync();

            return Json(shifts);
        }
        //====================================================
        // GET SHIFT HISTORY
        //====================================================

        [HttpGet]
        public async Task<IActionResult> GetShiftHistory(int employeeId)
        {
            var history = await _context.EmployeeShifts
                .Include(x => x.ShiftMaster)
                .Where(x => x.EmployeeId == employeeId)
                .OrderByDescending(x => x.EffectiveFrom)
                .Select(x => new
                {
                    shiftName = x.ShiftMaster!.ShiftName,
                    effectiveFrom = x.EffectiveFrom.ToString("dd-MMM-yyyy"),
                    effectiveTo = x.EffectiveTo.HasValue
                        ? x.EffectiveTo.Value.ToString("dd-MMM-yyyy")
                        : "Current",
                    isCurrent = x.IsCurrent
                })
                .ToListAsync();

            return Json(history);
        }
        //====================================================
        // CREATE
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeShiftViewModel vm)
        {
            await LoadDropdowns(vm);

            try
            {
                if (!ModelState.IsValid)
                    return View(vm);

                //=========================================
                // CHECK CURRENT SHIFT
                //=========================================

                var currentShift = await _context.EmployeeShifts
                    .FirstOrDefaultAsync(x =>
                        x.EmployeeId == vm.EmployeeShift.EmployeeId &&
                        x.IsCurrent &&
                        x.IsActive);

                if (currentShift != null)
                {
                    // Close previous assignment
                    currentShift.IsCurrent = false;
                    currentShift.EffectiveTo = vm.EmployeeShift.EffectiveFrom.AddDays(-1);
                    currentShift.ModifiedOn = DateTime.Now;

                    var loginUser = await _userManager.GetUserAsync(User);

                    if (loginUser != null &&
                        int.TryParse(loginUser.Id, out int userId))
                    {
                        currentShift.ModifiedBy = userId;
                    }
                }

                //=========================================
                // CREATE NEW SHIFT ASSIGNMENT
                //=========================================

                vm.EmployeeShift.IsCurrent = true;
                vm.EmployeeShift.IsActive = true;
                vm.EmployeeShift.CreatedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null &&
                    int.TryParse(currentUser.Id, out int createdBy))
                {
                    vm.EmployeeShift.CreatedBy = createdBy;
                }

                _context.EmployeeShifts.Add(vm.EmployeeShift);

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] =
                    "Shift assigned successfully.";

                return RedirectToAction(nameof(Index));
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
            var assignment = await _context.EmployeeShifts
                .FirstOrDefaultAsync(x => x.EmployeeShiftId == id);

            if (assignment == null)
                return NotFound();

            EmployeeShiftViewModel vm = new();

            vm.EmployeeShift = assignment;

            await LoadDropdowns(vm);

            return View(vm);
        }
        //====================================================
        // EDIT
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeShiftViewModel vm)
        {
            await LoadDropdowns(vm);

            try
            {
                if (!ModelState.IsValid)
                    return View(vm);

                var assignment = await _context.EmployeeShifts
                    .FirstOrDefaultAsync(x =>
                        x.EmployeeShiftId ==
                        vm.EmployeeShift.EmployeeShiftId);

                if (assignment == null)
                    return NotFound();

                assignment.EffectiveTo = vm.EmployeeShift.EffectiveTo;
                assignment.Remarks = vm.EmployeeShift.Remarks;

                assignment.ModifiedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null &&
                    int.TryParse(currentUser.Id, out int userId))
                {
                    assignment.ModifiedBy = userId;
                }

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] =
                    "Shift assignment updated successfully.";

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
            var assignment = await _context.EmployeeShifts
                .FirstOrDefaultAsync(x => x.EmployeeShiftId == id);

            if (assignment == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Shift assignment not found."
                });
            }

            assignment.IsActive = !assignment.IsActive;
            assignment.ModifiedOn = DateTime.Now;

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null &&
                int.TryParse(currentUser.Id, out int userId))
            {
                assignment.ModifiedBy = userId;
            }

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true
            });
        }
    }
}
