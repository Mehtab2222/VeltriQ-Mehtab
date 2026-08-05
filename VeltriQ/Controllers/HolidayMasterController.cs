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
    public class HolidayMasterController : BaseController
    {
        private readonly TenantDbContext _context;

        public HolidayMasterController
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
            var holidays = await _context.HolidayMasters
                .Include(x => x.Company)
                .Include(x => x.Branch)
                .OrderByDescending(x => x.HolidayDate)
                .ToListAsync();

            return View(holidays);
        }
        //====================================================
        // CREATE
        //====================================================

        public async Task<IActionResult> Create()
        {
            HolidayMasterViewModel vm = new();

            await LoadDropdowns(vm);

            vm.HolidayMaster.HolidayCode = await GenerateHolidayCode();
            vm.HolidayMaster.IsActive = true;

            return View(vm);
        }
        //====================================================
        // LOAD DROPDOWNS
        //====================================================

        private async Task LoadDropdowns(HolidayMasterViewModel vm)
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

            vm.Branches = await _context.Branches
                .Where(x => x.IsActive)
                .OrderBy(x => x.BranchName)
                .Select(x => new SelectListItem
                {
                    Value = x.BranchId.ToString(),
                    Text = x.BranchName
                })
                .ToListAsync();

            vm.HolidayTypes = new List<SelectListItem>
            {
                new() { Value = "National Holiday", Text = "National Holiday" },
                new() { Value = "Festival Holiday", Text = "Festival Holiday" },
                new() { Value = "Company Holiday", Text = "Company Holiday" },
                new() { Value = "Regional Holiday", Text = "Regional Holiday" },
                new() { Value = "Optional Holiday", Text = "Optional Holiday" }
            };

            vm.HalfDaySessions = new List<SelectListItem>
            {
                new() { Value = "Morning", Text = "Morning" },
                new() { Value = "Afternoon", Text = "Afternoon" }
            };
        }
        //====================================================
        // CREATE
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HolidayMasterViewModel vm)
        {
            await LoadDropdowns(vm);

            try
            {
                if (!ModelState.IsValid)
                    return View(vm);

                //=========================================
                // DUPLICATE HOLIDAY CODE
                //=========================================

                bool codeExists = await _context.HolidayMasters
                    .AnyAsync(x =>
                        x.CompanyId == vm.HolidayMaster.CompanyId &&
                        x.HolidayCode == vm.HolidayMaster.HolidayCode &&
                        x.IsActive);

                if (codeExists)
                {
                    ModelState.AddModelError(
                        "HolidayMaster.HolidayCode",
                        "Holiday Code already exists.");

                    return View(vm);
                }

                //=========================================
                // DUPLICATE HOLIDAY NAME + DATE
                //=========================================

                bool holidayExists = await _context.HolidayMasters
                    .AnyAsync(x =>
                        x.CompanyId == vm.HolidayMaster.CompanyId &&
                        x.HolidayName == vm.HolidayMaster.HolidayName &&
                        x.HolidayDate.Date == vm.HolidayMaster.HolidayDate.Date &&
                        x.IsActive);

                if (holidayExists)
                {
                    ModelState.AddModelError(
                        "HolidayMaster.HolidayName",
                        "Holiday already exists.");

                    return View(vm);
                }

                vm.HolidayMaster.CreatedOn = DateTime.Now;
                vm.HolidayMaster.IsActive = true;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null &&
                    int.TryParse(currentUser.Id, out int userId))
                {
                    vm.HolidayMaster.CreatedBy = userId;
                }

                _context.HolidayMasters.Add(vm.HolidayMaster);

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] =
                    "Holiday created successfully.";

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
            var holiday = await _context.HolidayMasters
                .FirstOrDefaultAsync(x => x.HolidayMasterId == id);

            if (holiday == null)
                return NotFound();

            HolidayMasterViewModel vm = new();

            vm.HolidayMaster = holiday;

            await LoadDropdowns(vm);

            return View(vm);
        }
        //====================================================
        // EDIT
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HolidayMasterViewModel vm)
        {
            await LoadDropdowns(vm);

            try
            {
                if (!ModelState.IsValid)
                    return View(vm);

                bool codeExists = await _context.HolidayMasters
                    .AnyAsync(x =>
                        x.CompanyId == vm.HolidayMaster.CompanyId &&
                        x.HolidayCode == vm.HolidayMaster.HolidayCode &&
                        x.HolidayMasterId != vm.HolidayMaster.HolidayMasterId &&
                        x.IsActive);

                if (codeExists)
                {
                    ModelState.AddModelError(
                        "HolidayMaster.HolidayCode",
                        "Holiday Code already exists.");

                    return View(vm);
                }

                var holiday = await _context.HolidayMasters
                    .FirstOrDefaultAsync(x =>
                        x.HolidayMasterId ==
                        vm.HolidayMaster.HolidayMasterId);

                if (holiday == null)
                    return NotFound();

                holiday.CompanyId = vm.HolidayMaster.CompanyId;
                holiday.BranchId = vm.HolidayMaster.BranchId;
                holiday.HolidayCode = vm.HolidayMaster.HolidayCode;
                holiday.HolidayName = vm.HolidayMaster.HolidayName;
                holiday.HolidayDate = vm.HolidayMaster.HolidayDate;
                holiday.HolidayType = vm.HolidayMaster.HolidayType;
                holiday.Description = vm.HolidayMaster.Description;
                holiday.IsOptional = vm.HolidayMaster.IsOptional;
                holiday.IsRecurring = vm.HolidayMaster.IsRecurring;
                holiday.IsHalfDay = vm.HolidayMaster.IsHalfDay;
                holiday.HalfDaySession = vm.HolidayMaster.HalfDaySession;

                holiday.ModifiedOn = DateTime.Now;

                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser != null &&
                    int.TryParse(currentUser.Id, out int userId))
                {
                    holiday.ModifiedBy = userId;
                }

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] =
                    "Holiday updated successfully.";

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
            var holiday = await _context.HolidayMasters
                .FirstOrDefaultAsync(x => x.HolidayMasterId == id);

            if (holiday == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Holiday not found."
                });
            }

            holiday.IsActive = !holiday.IsActive;
            holiday.ModifiedOn = DateTime.Now;

            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null &&
                int.TryParse(currentUser.Id, out int userId))
            {
                holiday.ModifiedBy = userId;
            }

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true
            });
        }
        //====================================================
        // GENERATE HOLIDAY CODE
        //====================================================

        private async Task<string> GenerateHolidayCode()
        {
            var lastHoliday = await _context.HolidayMasters
                .OrderByDescending(x => x.HolidayMasterId)
                .FirstOrDefaultAsync();

            if (lastHoliday == null)
                return "HOL-0001";

            int nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastHoliday.HolidayCode))
            {
                var numericPart = lastHoliday.HolidayCode.Replace("HOL-", "");

                if (int.TryParse(numericPart, out int currentNumber))
                {
                    nextNumber = currentNumber + 1;
                }
            }

            return $"HOL-{nextNumber:D4}";
        }
        //====================================================
        // GET BRANCHES BY COMPANY
        //====================================================

        [HttpGet]
        public async Task<JsonResult> GetBranchesByCompany(int companyId)
        {
            var branches = await _context.Branches
                .Where(x => x.CompanyId == companyId && x.IsActive)
                .OrderBy(x => x.BranchName)
                .Select(x => new
                {
                    branchId = x.BranchId,
                    branchName = x.BranchName
                })
                .ToListAsync();

            return Json(branches);
        }
        [HttpGet]
        public async Task<JsonResult> GetHolidayById(int id)
        {
            var holiday = await _context.HolidayMasters
                .FirstOrDefaultAsync(x => x.HolidayMasterId == id);

            if (holiday == null)
            {
                return Json(new { success = false, message = "Holiday not found." });
            }

            return Json(new
            {
                success = true,
                holidayMasterId = holiday.HolidayMasterId,
                companyId = holiday.CompanyId,
                branchId = holiday.BranchId,
                holidayCode = holiday.HolidayCode,
                holidayName = holiday.HolidayName,
                holidayDate = holiday.HolidayDate,
                holidayType = holiday.HolidayType,
                description = holiday.Description,
                isOptional = holiday.IsOptional,
                isRecurring = holiday.IsRecurring,
                isHalfDay = holiday.IsHalfDay,
                halfDaySession = holiday.HalfDaySession
            });
        }
    }
}