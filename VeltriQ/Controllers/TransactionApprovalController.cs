using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.Models.Training;
using VeltriQ.ViewModels.TransactionApproval;

namespace VeltriQ.Controllers
{
    [Authorize]
    public class TransactionApprovalController : BaseController
    {
        private readonly TenantDbContext _context;

        public TransactionApprovalController(
            TenantDbContext context,
            MasterDbContext masterDbContext,
            UserManager<ApplicationUser> userManager)
            : base(context, masterDbContext, userManager)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new TransactionApprovalViewModel();

            model.Modules = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "Training",
                    Text = "Training"
                }
            };

            model.Employees = await _context.Employees
                .Where(x => x.IsActive)
                .OrderBy(x => x.FirstName)
                .Select(x => new SelectListItem
                {
                    Value = x.EmployeeId.ToString(),
                    Text = (x.EmployeeCode ?? "") + " - " + x.FirstName + " " + x.LastName
                })
                .ToListAsync();

            return View(model);
        }
    
    [HttpGet]
        public async Task<IActionResult> GetPendingTransactions(
    int? employeeId,
    string? moduleName,
    string? status)
        {
            try
            {
                var query = from ta in _context.TransactionApprovals
                            join emp in _context.Employees
                                on ta.RequestedBy equals emp.EmployeeId
                            where ta.IsActive
                            select new TransactionApprovalViewModel
                            {
                                TransactionApprovalId = ta.TransactionApprovalId,
                                ModuleName = ta.ModuleName,
                                TransactionId = ta.TransactionId,
                                RequestedBy = ta.RequestedBy,
                                RequestedByName = emp.FirstName + " " + emp.LastName,
                                ApproverId = ta.ApproverId,
                                Status = ta.Status,
                                Remarks = ta.Remarks,
                                ActionDate = ta.ActionDate
                            };

                if (employeeId.HasValue)
                {
                    query = query.Where(x => x.RequestedBy == employeeId.Value);
                }

                if (!string.IsNullOrWhiteSpace(moduleName))
                {
                    query = query.Where(x => x.ModuleName == moduleName);
                }

                if (!string.IsNullOrWhiteSpace(status))
                {
                    query = query.Where(x => x.Status == status);
                }

                var data = await query
                    .OrderByDescending(x => x.TransactionApprovalId)
                    .ToListAsync();

                return Json(new
                {
                    success = true,
                    data
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