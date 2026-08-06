//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using VeltriQ.Data;
//using VeltriQ.Models.Core;
//using VeltriQ.ViewModels.Attendance;

//namespace VeltriQ.Controllers
//{
//    public class AttendanceProcessingController : BaseController
//    {
//        private readonly TenantDbContext _context;

//        public AttendanceProcessingController
//        (
//            TenantDbContext context,
//            MasterDbContext masterContext,
//            UserManager<ApplicationUser> userManager
//        )
//            : base(context, masterContext, userManager)
//        {
//            _context = context;
//        }
//        //====================================================
//        // INDEX
//        //====================================================

//        public async Task<IActionResult> Index()
//        {
//            AttendanceProcessingViewModel vm = new();

//            vm.ProcessDate = DateTime.Today;

//            await LoadDropdowns(vm);

//            return View(vm);
//        }
//        //====================================================
//        // LOAD DROPDOWNS
//        //====================================================

//        private async Task LoadDropdowns(AttendanceProcessingViewModel vm)
//        {
//            ViewBag.Companies = new SelectList(
//                await _context.Companies
//                    .Where(x => x.IsActive)
//                    .OrderBy(x => x.CompanyName)
//                    .ToListAsync(),
//                "CompanyId",
//                "CompanyName");

//            ViewBag.Branches = new SelectList(
//                new List<SelectListItem>(),
//                "Value",
//                "Text");
//        }
//        //====================================================
//        // GET BRANCHES BY COMPANY
//        //====================================================

//        [HttpGet]
//        public async Task<JsonResult> GetBranchesByCompany(int companyId)
//        {
//            var branches = await _context.Branches
//                .Where(x => x.CompanyId == companyId && x.IsActive)
//                .OrderBy(x => x.BranchName)
//                .Select(x => new
//                {
//                    branchId = x.BranchId,
//                    branchName = x.BranchName
//                })
//                .ToListAsync();

//            return Json(branches);
//        }
//        //====================================================
//        // PROCESS ATTENDANCE
//        //====================================================

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> ProcessAttendance(AttendanceProcessingViewModel vm)
//        {
//            await LoadDropdowns(vm);

//            try
//            {
//                if (!ModelState.IsValid)
//                    return View("Index", vm);

//                TempData["SuccessMessage"] =
//                    "Attendance processing started successfully.";

//                return RedirectToAction(nameof(Index));
//            }
//            catch (Exception ex)
//            {
//                ModelState.AddModelError("", ex.Message);

//                return View("Index", vm);
//            }
//        }
//    }
//}