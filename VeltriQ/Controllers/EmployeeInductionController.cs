using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Controllers;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.ViewModels.EmployeeInduction;

public class EmployeeInductionController : BaseController
{
    private readonly TenantDbContext _context;

    public EmployeeInductionController(
        TenantDbContext context,
        MasterDbContext masterDbContext,
        UserManager<ApplicationUser> userManager)
        : base(context, masterDbContext, userManager)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View(new EmployeeInductionIndexViewModel());
    }
    [HttpGet]
    public IActionResult GetEmployeeInductions()
    {
        var inductions = _context.EmployeeInductions
            .Include(x => x.Employee)
            .Include(x => x.InductionProgramMaster)
            .OrderByDescending(x => x.EmployeeInductionId)
            .Select(x => new EmployeeInductionListItemViewModel
            {
                EmployeeInductionId = x.EmployeeInductionId,

                EmployeeCode = x.Employee.EmployeeCode ?? "",

                EmployeeName =
                    (x.Employee.FirstName ?? "") +
                    " " +
                    (x.Employee.LastName ?? ""),

                ProgramName = x.InductionProgramMaster.ProgramName,

                AssignedOn = x.AssignedOn,

                StartDate = x.StartDate,

                Status =
                    x.InductionStatus == 1 ? "Assigned" :
                    x.InductionStatus == 2 ? "In Progress" :
                    x.InductionStatus == 3 ? "Completed" :
                    "Cancelled"
            })
            .ToList();

        return Json(new
        {
            data = inductions
        });
    }
    [HttpGet]
    public IActionResult Create()
    {
        var model = new EmployeeInductionCreateViewModel();

        model.Programs = _context.InductionProgramMasters
            .Where(x => x.IsActive)
            .OrderBy(x => x.ProgramName)
            .Select(x => new SelectListItem
            {
                Value = x.InductionProgramMasterId.ToString(),
                Text = x.ProgramName
            })
            .ToList();

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EmployeeInductionCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Programs = _context.InductionProgramMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.ProgramName)
                .Select(x => new SelectListItem
                {
                    Value = x.InductionProgramMasterId.ToString(),
                    Text = x.ProgramName
                })
                .ToList();

            return View(model);
        }

        if (model.EmployeeIds == null || !model.EmployeeIds.Any())
        {
            TempData["Error"] = "Please select at least one employee.";

            model.Programs = _context.InductionProgramMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.ProgramName)
                .Select(x => new SelectListItem
                {
                    Value = x.InductionProgramMasterId.ToString(),
                    Text = x.ProgramName
                })
                .ToList();

            return View(model);
        }

        using var transaction = _context.Database.BeginTransaction();

        try
        {
            var sessions = _context.InductionSessionMasters
                .Where(x =>
                    x.InductionProgramMasterId == model.InductionProgramMasterId &&
                    x.IsActive)
                .OrderBy(x => x.SessionOrder)
                .ToList();

            foreach (var employeeId in model.EmployeeIds)
            {
                bool exists = _context.EmployeeInductions.Any(x =>
                    x.EmployeeId == employeeId &&
                    x.IsActive &&
                    x.InductionStatus != 3);

                if (exists)
                {
                    continue;
                }

                var induction = new EmployeeInduction
                {
                    EmployeeId = employeeId,
                    InductionProgramMasterId = model.InductionProgramMasterId,
                    AssignedOn = DateTime.Now,
                    AssignedBy = GetCurrentEmployeeId(),
                    StartDate = model.StartDate,
                    ExpectedCompletionDate = model.ExpectedCompletionDate,
                    Remarks = model.Remarks,
                    InductionStatus = 1,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = GetCurrentEmployeeId()
                };

                _context.EmployeeInductions.Add(induction);
                _context.SaveChanges();

                foreach (var session in sessions)
                {
                    _context.EmployeeInductionSessions.Add(new EmployeeInductionSession
                    {
                        EmployeeInductionId = induction.EmployeeInductionId,
                        InductionSessionMasterId = session.InductionSessionMasterId,
                        SessionTitle = session.SessionTitle,
                        SessionOrder = session.SessionOrder,
                        DurationInMinutes = session.DurationInMinutes,
                        IsMandatory = session.IsMandatory,

                        IsCompleted = false,

                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        CreatedBy = GetCurrentEmployeeId()
                    });
                }

                _context.SaveChanges();
            }

            transaction.Commit();

            TempData["Success"] = "Induction assigned successfully.";

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            transaction.Rollback();

            TempData["Error"] = ex.Message;

            model.Programs = _context.InductionProgramMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.ProgramName)
                .Select(x => new SelectListItem
                {
                    Value = x.InductionProgramMasterId.ToString(),
                    Text = x.ProgramName
                })
                .ToList();

            return View(model);
        }
    }
    [HttpGet]
    public IActionResult GetEligibleEmployees()
    {
        var employees = _context.Employees
            .Where(x =>
                x.IsActive &&
                !_context.EmployeeInductions.Any(i =>
                    i.EmployeeId == x.EmployeeId &&
                    i.IsActive &&
                    i.InductionStatus != 3))
            .OrderBy(x => x.EmployeeCode)
            .Select(x => new
            {
                x.EmployeeId,
                x.EmployeeCode,
                EmployeeName = x.FirstName + " " + x.LastName,
                Department = x.Department != null ? x.Department.DepartmentName : "",
                Designation = x.Designation != null ? x.Designation.DesignationName : ""
            })
            .ToList();

        return Json(new { data = employees });
    }
    [HttpGet]
    public IActionResult View(int id)
    {
        var induction = _context.EmployeeInductions
            .Include(x => x.Employee)
            .Include(x => x.InductionProgramMaster)
            .FirstOrDefault(x => x.EmployeeInductionId == id);

        if (induction == null)
        {
            return NotFound();
        }

        ViewBag.EmployeeName =
            $"{induction.Employee?.EmployeeCode} - {induction.Employee?.FirstName} {induction.Employee?.LastName}";

        ViewBag.ProgramName = induction.InductionProgramMaster?.ProgramName;

        ViewBag.StartDate = induction.StartDate;

        ViewBag.Status = induction.InductionStatus;

        return View(induction);
    }
    [HttpGet]
    public IActionResult GetSessions(int employeeInductionId)
    {
        var sessions = _context.EmployeeInductionSessions
            .Where(x => x.EmployeeInductionId == employeeInductionId)
            .OrderBy(x => x.SessionOrder)
            .Select(x => new EmployeeInductionSessionViewModel
            {
                EmployeeInductionSessionId = x.EmployeeInductionSessionId,
                SessionTitle = x.SessionTitle,
                SessionOrder = x.SessionOrder,
                DurationInMinutes = x.DurationInMinutes,
                IsMandatory = x.IsMandatory,

                // Temporary until Attendance module is rebuilt
                AttendanceStatus = "Pending",

                IsCompleted = x.IsCompleted
            })
            .ToList();

        return Json(new
        {
            data = sessions
        });
    }

}