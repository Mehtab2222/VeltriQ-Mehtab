using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.Models.HR.ProbationAssessment;
using VeltriQ.ViewModels.HR;

namespace VeltriQ.Controllers
{
    public class ProbationAssessmentController : BaseController
    {
        private readonly TenantDbContext _context;

        public ProbationAssessmentController(
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager)
            : base(context, masterContext, userManager)
        {
            _context = context;
        }

        // ============================================================
        // SESSION / ROLE HELPERS
        // ============================================================
        private string CurrentCompanyId =>
            GetCurrentCompanyId()?.ToString() ?? "";

        private int? CurrentEmployeeId => GetCurrentEmployeeId();

        private string CurrentEmployeeCode =>
            HttpContext.Session.GetString("EmployeeNo")?.Trim()
            ?? _context.Employees
                .Where(x => x.UserId == GetCurrentUserId())
                .Select(x => x.EmployeeCode)
                .FirstOrDefault()
            ?? "";

        private int CurrentActorId => CurrentEmployeeId ?? 0;

        private bool IsAdminOrHrAdmin()
        {
            return User.IsInRole("Admin")
                || User.IsInRole("HRAdmin")
                || User.IsInRole("HR Admin")
                || User.IsInRole("HR");
        }

        private bool IsManagerOf(Employee employee)
        {
            var currentId = CurrentEmployeeId;
            return currentId.HasValue
                && employee.ReportingManagerId.HasValue
                && employee.ReportingManagerId.Value == currentId.Value;
        }

        private bool CanAccessEmployee(Employee employee)
        {
            return IsAdminOrHrAdmin() || IsManagerOf(employee);
        }

        private async Task<Employee?> GetEmployeeAsync(string employeeNo, bool onlyActive = true)
        {
            employeeNo = employeeNo?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(employeeNo))
                return null;

            int? companyId = int.TryParse(CurrentCompanyId, out var parsedCompany)
                ? parsedCompany
                : null;

            var query = _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Designation)
                .AsQueryable();

            if (onlyActive)
                query = query.Where(x => x.IsActive);

            if (companyId.HasValue)
                query = query.Where(x => x.CompanyId == companyId.Value);

            return await query.FirstOrDefaultAsync(x =>
                x.EmployeeCode == employeeNo ||
                x.EmployeeId.ToString() == employeeNo);
        }

        private string EmployeeName(Employee? employee)
        {
            if (employee == null)
                return "-";

            return (employee.FirstName + " " + employee.LastName).Trim();
        }

        private async Task<string> GetManagerEmployeeCodeAsync(int? managerId)
        {
            if (!managerId.HasValue)
                return "0";

            return await _context.Employees
                .Where(x => x.EmployeeId == managerId.Value)
                .Select(x => x.EmployeeCode)
                .FirstOrDefaultAsync() ?? "0";
        }

        private static string GetGrade(decimal percentage)
        {
            // No grade-master table exists in the current module.
            // These thresholds are centralized here so they can be changed later.
            if (percentage >= 90m) return "A+";
            if (percentage >= 80m) return "A";
            if (percentage >= 70m) return "B+";
            if (percentage >= 60m) return "B";
            if (percentage >= 50m) return "C";
            return "D";
        }

        private async Task<List<ProbationCriteriaMaster>> GetActiveCriteriaAsync()
        {
            return await _context.ProbationCriteriaMasters
                .Where(x => x.CompanyId == CurrentCompanyId && x.IsActive)
                .OrderBy(x => x.Category)
                .ThenBy(x => x.DisplayOrder)
                .ToListAsync();
        }

        private async Task<List<ProbationAssessmentRatingsModel>> BuildRatingsAsync(
            int detailId,
            List<ProbationCriteriaMaster>? criteria = null)
        {
            criteria ??= await GetActiveCriteriaAsync();

            var existing = await _context.ProbationAssessmentRatings
                .Where(x => x.DetailId == detailId && x.CompanyId == CurrentCompanyId)
                .ToListAsync();

            return criteria.Select(c =>
            {
                var rating = existing.FirstOrDefault(x => x.CriteriaId == c.CriteriaId);

                return new ProbationAssessmentRatingsModel
                {
                    RatingId = rating?.RatingId ?? 0,
                    DetailId = detailId,
                    CriteriaId = c.CriteriaId,
                    CriteriaCode = c.CriteriaCode,
                    CriteriaName = c.CriteriaName,
                    CriteriaDescription = c.CriteriaDescription,
                    Category = c.Category,
                    DisplayOrder = c.DisplayOrder,
                    Rating = rating?.Rating,
                    RatingScore = rating?.RatingScore,
                    CompanyId = CurrentCompanyId
                };
            }).ToList();
        }

        private async Task<ProbationAssessmentDetailsModel?> GetDetailAsync(
            int detailId,
            int assessmentId = 0)
        {
            var query = _context.ProbationAssessmentDetails
                .Where(x => x.DetailId == detailId && x.CompanyId == CurrentCompanyId);

            if (assessmentId > 0)
                query = query.Where(x => x.AssessmentId == assessmentId);

            return await query.FirstOrDefaultAsync();
        }

        private async Task<bool> RecalculateCheckpointStatusAsync(
            ProbationAssessmentDetailsModel detail)
        {
            bool allSignatures = detail.SigManager
                && detail.SigEmployee
                && detail.SigHR;

            bool decisionRequired = detail.CheckpointNo >= 3;

            bool decisionCompleted = !decisionRequired
                || !string.IsNullOrWhiteSpace(detail.CheckpointDecision);

            detail.Status = allSignatures && decisionCompleted
                ? "Completed"
                : "InProgress";

            detail.ModifiedOn = DateTime.Now;
            detail.ModifiedBy = CurrentActorId > 0 ? CurrentActorId : null;

            return detail.Status == "Completed";
        }

        private async Task RecalculateMasterStatusAsync(
            ProbationAssessmentMasterModel master)
        {
            var checkpoints = await _context.ProbationAssessmentDetails
                .Where(x => x.AssessmentId == master.AssessmentId && x.CompanyId == CurrentCompanyId)
                .ToListAsync();

            if (!checkpoints.Any())
            {
                master.OverallStatus = "Pending";
            }
            else if (checkpoints.All(x => x.Status == "Completed"))
            {
                master.OverallStatus = "Completed";
            }
            else
            {
                master.OverallStatus = "InProgress";
            }

            master.ModifiedBy = CurrentActorId > 0 ? CurrentActorId : null;
            master.ModifiedOn = DateTime.Now;
        }

        // ============================================================
        // INDEX
        // ============================================================
        // INDEX
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // =========================================================
                // 1. GET CURRENT LOGGED-IN USER
                // =========================================================

                var userId = _userManager.GetUserId(User);

                if (string.IsNullOrWhiteSpace(userId))
                {
                    TempData["Message"] = "Logged-in user could not be identified.";

                    return View(
                        new List<ProbationAssessmentIndexViewModel>()
                    );
                }


                // =========================================================
                // 2. FIND EMPLOYEE LINKED TO CURRENT USER
                // =========================================================

                var currentEmployee = await _context.Employees
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.UserId == userId &&
                        x.IsActive);

                if (currentEmployee == null)
                {
                    TempData["Message"] =
                        "Your user account is not linked to an active employee.";

                    return View(
                        new List<ProbationAssessmentIndexViewModel>()
                    );
                }


                // =========================================================
                // 3. DETERMINE COMPANY
                // =========================================================

                var companyId = currentEmployee.CompanyId;

                if (!companyId.HasValue)
                {
                    TempData["Message"] =
                        "Your employee is not assigned to a company.";

                    return View(
                        new List<ProbationAssessmentIndexViewModel>()
                    );
                }


                // =========================================================
                // 4. LOAD PROBATION EMPLOYEES
                // =========================================================

                var query = _context.Employees
                    .AsNoTracking()
                    .Include(x => x.Department)
                    .Include(x => x.Designation)
                    .Where(x =>
                        x.IsActive &&
                        x.CompanyId == companyId.Value &&
                        (
                            x.EmployeeStatus == "Probation" ||
                            x.EmploymentStatus == "Probation"
                        ));


                // =========================================================
                // 5. MANAGER ACCESS
                // =========================================================

                if (!IsAdminOrHrAdmin())
                {
                    query = query.Where(x =>
                        x.ReportingManagerId == currentEmployee.EmployeeId);
                }


                // =========================================================
                // 6. LOAD EMPLOYEES
                // =========================================================

                var employees = await query
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToListAsync();


                // =========================================================
                // 7. EMPLOYEE CODES
                // =========================================================

                var employeeCodes = employees
                    .Select(x =>
                        x.EmployeeCode ??
                        x.EmployeeId.ToString())
                    .ToList();


                // =========================================================
                // 8. LOAD EXISTING ASSESSMENTS
                // =========================================================

                var assessments =
                    await _context.ProbationAssessmentMasters
                        .AsNoTracking()
                        .Where(x =>
                            employeeCodes.Contains(x.EmployeeNo) &&
                            x.CompanyId == companyId.Value.ToString())
                        .ToListAsync();


                // =========================================================
                // 9. BUILD INDEX ROWS
                // =========================================================

                var rows = employees
                    .Select(employee =>
                    {
                        var employeeNo =
                            employee.EmployeeCode ??
                            employee.EmployeeId.ToString();

                        var assessment =
                            assessments.FirstOrDefault(x =>
                                x.EmployeeNo == employeeNo);

                        return new ProbationAssessmentIndexViewModel
                        {
                            EmployeeId =
                                employee.EmployeeId,

                            EmployeeNo =
                                employeeNo,

                            EmployeeName =
                                $"{employee.FirstName} {employee.LastName}"
                                    .Trim(),

                            OfficialEmail =
                                employee.OfficialEmail,

                            Department =
                                employee.Department?.DepartmentName ?? "-",

                            Designation =
                                employee.Designation?.DesignationName ?? "-",

                            JoiningDate =
                                employee.JoiningDate,

                            ProbationEndDate =
                                employee.JoiningDate.HasValue
                                    ? employee.JoiningDate.Value.AddMonths(6)
                                    : null,

                            AssessmentId =
                                assessment?.AssessmentId,

                            OverallStatus =
                                assessment?.OverallStatus ?? "Not Started",

                            HasAssessment =
                                assessment != null
                        };
                    })
                    .ToList();


                // =========================================================
                // 10. RETURN VIEW
                // =========================================================

                return View(rows);
            }
            catch (Exception ex)
            {
                TempData["Message"] =
                    ex.InnerException?.Message ??
                    ex.Message;

                return View(
                    new List<ProbationAssessmentIndexViewModel>()
                );
            }
        }
        [HttpGet]
        public async Task<IActionResult> Create(int employeeId)
        {
            try
            {
                // =========================================================
                // CURRENT USER
                // =========================================================

                var userId = _userManager.GetUserId(User);

                if (string.IsNullOrWhiteSpace(userId))
                    return Unauthorized();


                // =========================================================
                // CURRENT EMPLOYEE
                // =========================================================

                var currentEmployee = await _context.Employees
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.UserId == userId &&
                        x.IsActive);

                if (currentEmployee == null)
                    return Forbid();


                // =========================================================
                // COMPANY
                // =========================================================

                var companyId = currentEmployee.CompanyId;

                if (!companyId.HasValue)
                {
                    TempData["Message"] =
                        "Your employee is not assigned to a company.";

                    return RedirectToAction(nameof(Index));
                }

                var companyIdString = companyId.Value.ToString();


                // =========================================================
                // SELECTED PROBATION EMPLOYEE
                // =========================================================

                var employee = await _context.Employees
                    .AsNoTracking()
                    .Include(x => x.Department)
                    .Include(x => x.Designation)
                    .FirstOrDefaultAsync(x =>
                        x.EmployeeId == employeeId &&
                        x.IsActive &&
                        x.CompanyId == companyId.Value &&
                        (
                            x.EmployeeStatus == "Probation" ||
                            x.EmploymentStatus == "Probation"
                        ));

                if (employee == null)
                    return NotFound();


                // =========================================================
                // MANAGER ACCESS
                // =========================================================

                if (!IsAdminOrHrAdmin())
                {
                    if (employee.ReportingManagerId != currentEmployee.EmployeeId)
                        return Forbid();
                }


                // =========================================================
                // EMPLOYEE NUMBER
                // =========================================================

                var employeeNo =
                    employee.EmployeeCode ??
                    employee.EmployeeId.ToString();


                // =========================================================
                // CHECK EXISTING ASSESSMENT
                // =========================================================

                var existingAssessment =
                    await _context.ProbationAssessmentMasters
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x =>
                            x.EmployeeNo == employeeNo &&
                            x.CompanyId == companyIdString);

                if (existingAssessment != null)
                {
                    return RedirectToAction(
                        nameof(Edit),
                        new
                        {
                            id = existingAssessment.AssessmentId
                        });
                }


                // =========================================================
                // JOINING DATE
                // =========================================================

                if (!employee.JoiningDate.HasValue)
                {
                    TempData["Message"] =
                        "Employee joining date is required before creating the probation assessment.";

                    return RedirectToAction(nameof(Index));
                }


                var joiningDate =
                    employee.JoiningDate.Value.Date;

                var probationEndDate =
                    joiningDate.AddMonths(6);


                // =========================================================
                // LOAD ACTIVE CRITERIA
                // =========================================================

                var criteria =
                    await _context.ProbationCriteriaMasters
                        .AsNoTracking()
                        .Where(x =>
                            x.IsActive &&
                            x.CompanyId == companyIdString)
                        .OrderBy(x => x.DisplayOrder)
                        .ToListAsync();


                // =========================================================
                // CREATE CHECKPOINT STRUCTURE
                // =========================================================

                var checkpoints =
                    new List<ProbationAssessmentDetailsModel>
                    {
                new ProbationAssessmentDetailsModel
                {
                    CheckpointNo = 1,
                    CheckpointLabel = "6-Week Evaluation",
                    ScheduledDate = joiningDate.AddDays(42),
                    Status = "Pending",
                    CompanyId = companyIdString
                },

                new ProbationAssessmentDetailsModel
                {
                    CheckpointNo = 2,
                    CheckpointLabel = "10-Week Evaluation",
                    ScheduledDate = joiningDate.AddDays(70),
                    Status = "Pending",
                    CompanyId = companyIdString
                },

                new ProbationAssessmentDetailsModel
                {
                    CheckpointNo = 3,
                    CheckpointLabel = "Final Evaluation",
                    ScheduledDate = probationEndDate,
                    Status = "Pending",
                    CompanyId = companyIdString
                }
                    };


                // =========================================================
                // DETERMINE AVAILABLE CHECKPOINT
                // =========================================================

                var today = DateTime.Today;

                var activeCheckpoint =
                    checkpoints.FirstOrDefault(x =>
                        x.ScheduledDate.HasValue &&
                        x.ScheduledDate.Value.Date <= today);


                var activeIndex =
                    activeCheckpoint == null
                        ? 0
                        : checkpoints.IndexOf(activeCheckpoint);


                // =========================================================
                // BUILD VIEW MODEL
                // =========================================================

                var model =
                    new ProbationAssessmentViewModel
                    {
                        Master = new ProbationAssessmentMasterModel
                        {
                            EmployeeNo = employeeNo,

                            EmployeeName =
                                $"{employee.FirstName} {employee.LastName}"
                                    .Trim(),

                            Department =
                                employee.Department?.DepartmentName ?? "-",

                            Designation =
                                employee.Designation?.DesignationName ?? "-",

                            ProbationStartDate =
                                joiningDate,

                            ProbationEndDate =
                                probationEndDate,

                            OverallStatus =
                                "Pending",

                            CompanyId =
                                companyIdString
                        },

                        Checkpoints =
                            checkpoints,

                        ActiveCheckpoint =
                            activeCheckpoint,

                        ActiveCheckpointIndex =
                            activeIndex,

                        AllCriteria =
                            criteria,

                        ActiveRatings =
                            new List<ProbationAssessmentRatingsModel>(),

                        CompanyId =
                            companyIdString,

                        IsHR =
                            IsAdminOrHrAdmin(),

                        IsManager =
                            !IsAdminOrHrAdmin()
                    };


                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Message"] =
                    ex.InnerException?.Message ??
                    ex.Message;

                return RedirectToAction(nameof(Index));
            }
        }

        // ============================================================
        // CREATE - POST
        // Initializes master + 3 checkpoints + blank rating rows.
        // ============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProbationAssessmentViewModel model)
        {
            try
            {
                var employeeNo = model.Master.EmployeeNo?.Trim();

                var employee = await GetEmployeeAsync(employeeNo ?? "");

                if (employee == null)
                {
                    ModelState.AddModelError(
                        "Master.EmployeeNo",
                        "Probation employee was not found."
                    );

                    return View(model);
                }


                // =========================================================
                // DETERMINE COMPANY
                // =========================================================

                var companyId = CurrentCompanyId;

                if (string.IsNullOrWhiteSpace(companyId))
                {
                    if (!employee.CompanyId.HasValue)
                    {
                        return BadRequest("Company information is missing.");
                    }

                    companyId = employee.CompanyId.Value.ToString();
                }

                if (employee == null)
                {
                    ModelState.AddModelError("Master.EmployeeNo", "Probation employee was not found.");
                    return View(model);
                }

                // =========================================================
                // MANAGER ACCESS SECURITY
                // =========================================================

                var isAdminOrHrAdmin = IsAdminOrHrAdmin();

                var userId = _userManager.GetUserId(User);

                var currentUser =
                    string.IsNullOrWhiteSpace(userId)
                        ? null
                        : await _userManager.FindByIdAsync(userId);

                var isManager =
                    currentUser != null &&
                    await _userManager.IsInRoleAsync(
                        currentUser,
                        "Manager"
                    );


                // ---------------------------------------------------------
                // MANAGER → ONLY THEIR DIRECT EMPLOYEES
                // ---------------------------------------------------------

                if (isManager)
                {
                    var currentEmployeeId = CurrentEmployeeId;

                    if (!currentEmployeeId.HasValue ||
                        employee.ReportingManagerId != currentEmployeeId.Value)
                    {
                        ModelState.AddModelError(
                            "Master.EmployeeNo",
                            "You are not authorized to assess this employee."
                        );

                        return View(model);
                    }
                }
                // ---------------------------------------------------------
                // ADMIN / HR ADMIN → ALLOWED
                // ---------------------------------------------------------
                else if (isAdminOrHrAdmin)
                {
                    // No manager restriction.
                }
                // ---------------------------------------------------------
                // OTHER USERS → USE EXISTING ACCESS CHECK
                // ---------------------------------------------------------
                else if (!CanAccessEmployee(employee))
                {
                    ModelState.AddModelError(
                        "Master.EmployeeNo",
                        "You are not authorized to assess this employee."
                    );

                    return View(model);
                }

                bool alreadyExists = await _context.ProbationAssessmentMasters
                    .AnyAsync(x =>
                        x.EmployeeNo == employee.EmployeeCode &&
                        x.CompanyId == companyId);

                if (alreadyExists)
                {
                    var existing = await _context.ProbationAssessmentMasters
                        .Where(x =>
                            x.EmployeeNo == employee.EmployeeCode &&
                            x.CompanyId == companyId)
                                            .Select(x => x.AssessmentId)
                        .FirstAsync();

                    return RedirectToAction(nameof(Edit), new { id = existing });
                }

                if (!employee.JoiningDate.HasValue)
                {
                    ModelState.AddModelError("Master.EmployeeNo", "Employee joining date is required before creating the probation assessment.");
                    return View(model);
                }

                DateTime joiningDate = employee.JoiningDate.Value.Date;
                DateTime probationEndDate = joiningDate.AddMonths(6);

                var master = new ProbationAssessmentMasterModel
                {
                    EmployeeNo = employee.EmployeeCode ?? employee.EmployeeId.ToString(),
                    AppraiserId = await GetManagerEmployeeCodeAsync(employee.ReportingManagerId),
                    ProbationStartDate = joiningDate,
                    ProbationEndDate = probationEndDate,
                    OverallStatus = "Pending",
                    HRRemarks = model.Master.HRRemarks?.Trim(),
                    CompanyId = companyId,
                    CreatedBy = CurrentActorId > 0 ? CurrentActorId : null,
                    CreatedOn = DateTime.Now
                };

                await using var tx = await _context.Database.BeginTransactionAsync();

                _context.ProbationAssessmentMasters.Add(master);
                await _context.SaveChangesAsync();

                var criteria = await GetActiveCriteriaAsync();

                var checkpoints = new[]
                {
                    new { No = 1, Label = "6-Week Evaluation", Date = joiningDate.AddDays(42) },
                    new { No = 2, Label = "10-Week Evaluation", Date = joiningDate.AddDays(70) },
                    new { No = 3, Label = "Final Evaluation", Date = probationEndDate }
                };

                foreach (var cp in checkpoints)
                {
                    var detail = new ProbationAssessmentDetailsModel
                    {
                        AssessmentId = master.AssessmentId,
                        CheckpointNo = cp.No,
                        CheckpointLabel = cp.Label,
                        ScheduledDate = cp.Date,
                        Status = "Pending",
                        CompanyId = companyId,
                        CreatedBy = CurrentActorId > 0 ? CurrentActorId : null,
                        CreatedOn = DateTime.Now
                    };

                    _context.ProbationAssessmentDetails.Add(detail);
                    await _context.SaveChangesAsync();

                    foreach (var criterion in criteria)
                    {
                        _context.ProbationAssessmentRatings.Add(new ProbationAssessmentRatingsModel
                        {
                            DetailId = detail.DetailId,
                            CriteriaId = criterion.CriteriaId,
                            Rating = null,
                            RatingScore = null,
                            CompanyId = companyId
                        });
                    }

                    await _context.SaveChangesAsync();
                }

                await tx.CommitAsync();

                return RedirectToAction(nameof(Edit), new { id = master.AssessmentId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException?.Message ?? ex.Message);
                return View(model);
            }
        }

        // ============================================================
        // GET PROBATION EMPLOYEES - AJAX
        // ============================================================
        [HttpGet]
        public async Task<JsonResult> GetAllProbationEmployees()
        {
            // =========================================================
            // CURRENT COMPANY
            // =========================================================

            int? companyId =
                int.TryParse(CurrentCompanyId, out var parsedCompany)
                    ? parsedCompany
                    : null;


            // =========================================================
            // BASE QUERY
            // =========================================================

            var query = _context.Employees
                .Where(x => x.IsActive);


            // =========================================================
            // COMPANY FILTER
            // =========================================================

            if (companyId.HasValue)
            {
                query = query.Where(
                    x => x.CompanyId == companyId.Value
                );
            }


            // =========================================================
            // PROBATION FILTER
            // =========================================================

            query = query.Where(x =>
                x.EmployeeStatus == "Probation" ||
                x.EmploymentStatus == "Probation"
            );


            // =========================================================
            // CHECK CURRENT USER
            // =========================================================

            var currentEmployeeId =
                CurrentEmployeeId;


            var isAdminOrHrAdmin =
                IsAdminOrHrAdmin();


            var userId =
             _userManager.GetUserId(User);

            var currentUser =
                string.IsNullOrWhiteSpace(userId)
                    ? null
                    : await _userManager.FindByIdAsync(userId);

            var isManager =
                currentUser != null &&
                await _userManager.IsInRoleAsync(
                    currentUser,
                    "Manager"
                );


            // =========================================================
            // ACCESS FILTERING
            // =========================================================

            if (isManager)
            {
                // -----------------------------------------------------
                // MANAGER
                // Only direct probation employees
                // -----------------------------------------------------

                if (!currentEmployeeId.HasValue)
                {
                    return Json(new List<object>());
                }

                query = query.Where(
                    x =>
                        x.ReportingManagerId ==
                        currentEmployeeId.Value
                );
            }
            else if (isAdminOrHrAdmin)
            {
                // -----------------------------------------------------
                // ADMIN / HR ADMIN
                // See all probation employees
                // -----------------------------------------------------

                // No additional filtering.
            }
            else
            {
                // -----------------------------------------------------
                // OTHER USERS
                // No probation employee access
                // -----------------------------------------------------

                return Json(new List<object>());
            }


            // =========================================================
            // LOAD EMPLOYEES
            // =========================================================

            var employees = await query
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToListAsync();


            // =========================================================
            // RETURN DROPDOWN DATA
            // =========================================================

            return Json(
                employees.Select(x => new
                {
                    employeeNo =
                        x.EmployeeCode ??
                        x.EmployeeId.ToString(),

                    employeeName =
                        EmployeeName(x),

                    employeeDisplay =
                        (x.EmployeeCode ??
                         x.EmployeeId.ToString())
                        + " - " +
                        EmployeeName(x)
                })
            );
        }

        // ============================================================
        // GET EMPLOYEE ASSESSMENT DATA - AJAX
        // Returns employee details even when assessment does not exist.
        // This is required by the Create page.
        // ============================================================
        [HttpGet]
        public async Task<JsonResult> GetEmployeeAssessmentData(string employeeNo)
        {
            try
            {
                var employee = await GetEmployeeAsync(employeeNo ?? "");

                if (employee == null)
                    return Json(new { success = false, message = "Employee record not found." });

                if (!CanAccessEmployee(employee))
                    return Json(new { success = false, message = "You are not authorized to assess this employee." });

                var master = await _context.ProbationAssessmentMasters
                    .FirstOrDefaultAsync(x =>
                        x.EmployeeNo == (employee.EmployeeCode ?? employee.EmployeeId.ToString()) &&
                        x.CompanyId == CurrentCompanyId);

                var checkpoints = master == null
                    ? new List<ProbationAssessmentDetailsModel>()
                    : await _context.ProbationAssessmentDetails
                        .Where(x => x.AssessmentId == master.AssessmentId && x.CompanyId == CurrentCompanyId)
                        .OrderBy(x => x.CheckpointNo)
                        .ToListAsync();

                DateTime? endDate = master?.ProbationEndDate ?? employee.JoiningDate?.AddMonths(6);

                return Json(new
                {
                    success = true,
                    assessmentExists = master != null,
                    assessmentId = master?.AssessmentId ?? 0,
                    employeeName = EmployeeName(employee),
                    employeeNo = employee.EmployeeCode ?? employee.EmployeeId.ToString(),
                    probationStartDate = (master?.ProbationStartDate ?? employee.JoiningDate)?.ToString("dd MMM yyyy"),
                    probationEndDate = endDate?.ToString("dd MMM yyyy"),
                    overallStatus = master?.OverallStatus ?? "Pending",
                    checkpoints
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // ============================================================
        // EDIT - GET
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                // =========================================================
                // LOAD ASSESSMENT
                // =========================================================

                var master = await _context.ProbationAssessmentMasters
                    .FirstOrDefaultAsync(x => x.AssessmentId == id);

                if (master == null)
                    return NotFound();


                // =========================================================
                // DETERMINE COMPANY
                // =========================================================

                var companyId = CurrentCompanyId;

                // If CurrentCompanyId is not available,
                // use the company stored against the assessment.
                if (string.IsNullOrWhiteSpace(companyId))
                {
                    companyId = master.CompanyId;
                }


                if (string.IsNullOrWhiteSpace(companyId))
                    return NotFound();


                // =========================================================
                // COMPANY SECURITY CHECK
                // =========================================================

                // If a current company is available, make sure the
                // assessment belongs to that company.
                if (!string.IsNullOrWhiteSpace(CurrentCompanyId) &&
                    master.CompanyId != CurrentCompanyId)
                {
                    return Forbid();
                }


                // =========================================================
                // LOAD EMPLOYEE
                // =========================================================

                var employee = await GetEmployeeAsync(
                    master.EmployeeNo,
                    false
                );

                if (employee == null)
                    return NotFound();


                // =========================================================
                // EMPLOYEE ACCESS
                // =========================================================

                if (!CanAccessEmployee(employee))
                    return Forbid();


                // =========================================================
                // EMPLOYEE DISPLAY INFORMATION
                // =========================================================

                master.EmployeeName =
                    EmployeeName(employee);

                master.AppraiserName =
                    await _context.Employees
                        .Where(x =>
                            x.EmployeeCode == master.AppraiserId)
                        .Select(x =>
                            (x.FirstName + " " + x.LastName).Trim())
                        .FirstOrDefaultAsync()
                        ?? "-";

                master.Department =
                    employee.Department?.DepartmentName ?? "-";

                master.Designation =
                    employee.Designation?.DesignationName ?? "-";


                // =========================================================
                // LOAD CHECKPOINTS
                // =========================================================

                var checkpoints =
                    await _context.ProbationAssessmentDetails
                        .Where(x =>
                            x.AssessmentId == id &&
                            x.CompanyId == companyId)
                        .OrderBy(x => x.CheckpointNo)
                        .ToListAsync();


                // =========================================================
                // LOAD CRITERIA
                // =========================================================

                var criteria =
                    await GetActiveCriteriaAsync();


                // =========================================================
                // DETERMINE ACTIVE CHECKPOINT
                // =========================================================

                var activeCheckpoint =
                    checkpoints
                        .FirstOrDefault(x =>
                            x.Status != "Completed")
                    ?? checkpoints.LastOrDefault();


                int activeIndex =
                    activeCheckpoint == null
                        ? 0
                        : checkpoints.IndexOf(activeCheckpoint);


                // =========================================================
                // LOAD RATINGS
                // =========================================================

                var activeRatings =
                    activeCheckpoint == null
                        ? new List<ProbationAssessmentRatingsModel>()
                        : await BuildRatingsAsync(
                            activeCheckpoint.DetailId,
                            criteria
                        );


                // =========================================================
                // SET CHECKPOINT STATE
                // =========================================================

                foreach (var checkpoint in checkpoints)
                {
                    checkpoint.IsLocked =
                        checkpoint.Status == "Completed";

                    checkpoint.IsCurrent =
                        activeCheckpoint?.DetailId ==
                        checkpoint.DetailId;
                }


                // =========================================================
                // LOAD EXTENSION HISTORY
                // =========================================================

                var extensions =
                    await _context.ProbationExtensionLogs
                        .Where(x =>
                            x.AssessmentId == id &&
                            x.CompanyId == companyId)
                        .OrderByDescending(x => x.ExtendedOn)
                        .ToListAsync();


                // =========================================================
                // BUILD VIEW MODEL
                // =========================================================

                var vm =
                    new ProbationAssessmentViewModel
                    {
                        Master = master,

                        Checkpoints =
                            checkpoints,

                        ActiveCheckpoint =
                            activeCheckpoint,

                        ActiveCheckpointIndex =
                            activeIndex,

                        AllCriteria =
                            criteria,

                        ActiveRatings =
                            activeRatings,

                        ExtensionHistory =
                            extensions,

                        CompanyId =
                            companyId,

                        IsHR =
                            IsAdminOrHrAdmin(),

                        IsManager =
                            !IsAdminOrHrAdmin()
                    };


                // =========================================================
                // RETURN VIEW
                // =========================================================

                return View(vm);
            }
            catch (Exception ex)
            {
                TempData["Message"] =
                    ex.InnerException?.Message
                    ?? ex.Message;

                return RedirectToAction(nameof(Index));
            }
        }

        // ============================================================
        // EDIT - POST
        // Updates master-level probation date / HR remarks.
        // ============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProbationAssessmentViewModel model)
        {
            try
            {
                var master = await _context.ProbationAssessmentMasters
                    .FirstOrDefaultAsync(x => x.AssessmentId == id && x.CompanyId == CurrentCompanyId);

                if (master == null)
                    return NotFound();

                var employee = await GetEmployeeAsync(master.EmployeeNo, false);
                if (employee == null || !CanAccessEmployee(employee))
                    return Forbid();

                if (model.Master.ProbationEndDate.HasValue)
                {
                    master.ProbationEndDate = model.Master.ProbationEndDate.Value;

                    var finalCheckpoint = await _context.ProbationAssessmentDetails
                        .Where(x => x.AssessmentId == id && x.CompanyId == CurrentCompanyId && x.CheckpointNo == 3)
                        .FirstOrDefaultAsync();

                    if (finalCheckpoint != null && finalCheckpoint.Status != "Completed")
                        finalCheckpoint.ScheduledDate = model.Master.ProbationEndDate.Value;
                }

                master.HRRemarks = model.Master.HRRemarks?.Trim();
                master.ModifiedBy = CurrentActorId > 0 ? CurrentActorId : null;
                master.ModifiedOn = DateTime.Now;

                await _context.SaveChangesAsync();

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return Json(new { success = true, message = "Probation assessment updated successfully." });

                return RedirectToAction(nameof(Edit), new { id });
            }
            catch (Exception ex)
            {
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return Json(new { success = false, message = ex.Message });

                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        // ============================================================
        // GET CHECKPOINT RATINGS - AJAX
        // ============================================================
        [HttpGet]
        public async Task<JsonResult> GetCheckpointRatings(int detailId)
        {
            try
            {
                var detail = await _context.ProbationAssessmentDetails
                    .Join(
                        _context.ProbationAssessmentMasters,
                        d => d.AssessmentId,
                        m => m.AssessmentId,
                        (d, m) => new { d, m })
                    .Where(x =>
                        x.d.DetailId == detailId &&
                        x.d.CompanyId == CurrentCompanyId &&
                        x.m.CompanyId == CurrentCompanyId)
                    .Select(x => new { Detail = x.d, Master = x.m })
                    .FirstOrDefaultAsync();

                if (detail == null)
                    return Json(new { success = false, message = "Checkpoint not found." });

                var employee = await GetEmployeeAsync(detail.Master.EmployeeNo, false);
                if (employee == null || !CanAccessEmployee(employee))
                    return Json(new { success = false, message = "You are not authorized to access this checkpoint." });

                var ratings = await BuildRatingsAsync(detailId);

                return Json(new
                {
                    success = true,
                    assessmentId = detail.Master.AssessmentId,
                    detailId = detail.Detail.DetailId,
                    checkpointNo = detail.Detail.CheckpointNo,
                    checkpointLabel = detail.Detail.CheckpointLabel,
                    scheduledDate = detail.Detail.ScheduledDate?.ToString("dd MMM yyyy"),
                    status = detail.Detail.Status,
                    ratings,
                    strengths = detail.Detail.Strengths,
                    developmentAreas = detail.Detail.DevelopmentAreas,
                    progress = detail.Detail.Progress,
                    employeeComments = detail.Detail.EmployeeComments,
                    hrComments = detail.Detail.HRComments,
                    checkpointDecision = detail.Detail.CheckpointDecision,
                    sigManager = detail.Detail.SigManager,
                    sigEmployee = detail.Detail.SigEmployee,
                    sigHR = detail.Detail.SigHR,
                    overallScore = detail.Detail.OverallScore,
                    grade = detail.Detail.OverallGrade,
                    scorePE = detail.Detail.ScorePersonal,
                    scoreOB = detail.Detail.ScoreOperational
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // ============================================================
        // SAVE ASSESSMENT - POST
        // Supports ratings + comments + manager/HR signature flags.
        // ============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveAssessment([FromBody] SaveProbationAssessmentRequest request)
        {
            try
            {
                if (request == null)
                    return Json(new { success = false, message = "Invalid assessment payload." });

                if (string.IsNullOrWhiteSpace(CurrentCompanyId))
                    return Json(new { success = false, message = "Company information is missing." });

                await using var tx = await _context.Database.BeginTransactionAsync();

                ProbationAssessmentMasterModel? master = null;
                ProbationAssessmentDetailsModel? detail = null;

                // -----------------------------------------------------
                // CREATE ASSESSMENT ON FIRST SAVE
                // -----------------------------------------------------
                if (request.AssessmentId <= 0)
                {
                    var employee = await GetEmployeeAsync(request.EmployeeNo ?? "");

                    if (employee == null)
                        return Json(new { success = false, message = "The selected probation employee could not be found." });

                    if (!CanAccessEmployee(employee))
                        return Json(new { success = false, message = "You are not authorized to assess this employee." });

                    if (!employee.JoiningDate.HasValue)
                        return Json(new { success = false, message = "Employee joining date is missing." });

                    string employeeNo = employee.EmployeeCode ?? employee.EmployeeId.ToString();

                    master = await _context.ProbationAssessmentMasters
                        .FirstOrDefaultAsync(x => x.EmployeeNo == employeeNo && x.CompanyId == CurrentCompanyId);

                    if (master == null)
                    {
                        DateTime joiningDate = employee.JoiningDate.Value.Date;
                        DateTime probationEndDate = joiningDate.AddMonths(6);

                        master = new ProbationAssessmentMasterModel
                        {
                            EmployeeNo = employeeNo,
                            AppraiserId = await GetManagerEmployeeCodeAsync(employee.ReportingManagerId),
                            ProbationStartDate = joiningDate,
                            ProbationEndDate = probationEndDate,
                            OverallStatus = "Pending",
                            CompanyId = CurrentCompanyId,
                            CreatedBy = CurrentActorId > 0 ? CurrentActorId : null,
                            CreatedOn = DateTime.Now
                        };

                        _context.ProbationAssessmentMasters.Add(master);
                        await _context.SaveChangesAsync();

                        var criteria = await GetActiveCriteriaAsync();

                        var checkpoints = new[]
                        {
                            new { No = 1, Label = "6-Week Evaluation", Date = joiningDate.AddDays(42) },
                            new { No = 2, Label = "10-Week Evaluation", Date = joiningDate.AddDays(70) },
                            new { No = 3, Label = "Final Evaluation", Date = probationEndDate }
                        };

                        foreach (var cp in checkpoints)
                        {
                            var newDetail = new ProbationAssessmentDetailsModel
                            {
                                AssessmentId = master.AssessmentId,
                                CheckpointNo = cp.No,
                                CheckpointLabel = cp.Label,
                                ScheduledDate = cp.Date,
                                Status = "Pending",
                                CompanyId = CurrentCompanyId,
                                CreatedBy = CurrentActorId > 0 ? CurrentActorId : null,
                                CreatedOn = DateTime.Now
                            };

                            _context.ProbationAssessmentDetails.Add(newDetail);
                            await _context.SaveChangesAsync();

                            foreach (var criterion in criteria)
                            {
                                _context.ProbationAssessmentRatings.Add(new ProbationAssessmentRatingsModel
                                {
                                    DetailId = newDetail.DetailId,
                                    CriteriaId = criterion.CriteriaId,
                                    CompanyId = CurrentCompanyId
                                });
                            }

                            await _context.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    master = await _context.ProbationAssessmentMasters
                        .FirstOrDefaultAsync(x =>
                            x.AssessmentId == request.AssessmentId &&
                            x.CompanyId == CurrentCompanyId);

                    if (master == null)
                        return Json(new { success = false, message = "Assessment not found." });
                }

                var assessmentEmployee = await GetEmployeeAsync(master.EmployeeNo, false);
                if (assessmentEmployee == null || !CanAccessEmployee(assessmentEmployee))
                    return Json(new { success = false, message = "You are not authorized to update this assessment." });

                int detailId = request.DetailId;

                if (detailId <= 0)
                {
                    detail = await _context.ProbationAssessmentDetails
                        .Where(x => x.AssessmentId == master.AssessmentId
                                 && x.CompanyId == CurrentCompanyId
                                 && x.Status != "Completed")
                        .OrderBy(x => x.CheckpointNo)
                        .FirstOrDefaultAsync();

                    detail ??= await _context.ProbationAssessmentDetails
                        .Where(x => x.AssessmentId == master.AssessmentId && x.CompanyId == CurrentCompanyId)
                        .OrderByDescending(x => x.CheckpointNo)
                        .FirstOrDefaultAsync();
                }
                else
                {
                    detail = await _context.ProbationAssessmentDetails
                        .FirstOrDefaultAsync(x =>
                            x.DetailId == detailId &&
                            x.AssessmentId == master.AssessmentId &&
                            x.CompanyId == CurrentCompanyId);
                }

                if (detail == null)
                    return Json(new { success = false, message = "Checkpoint not found." });

                if (detail.Status == "Completed" && !IsAdminOrHrAdmin())
                    return Json(new { success = false, message = "This checkpoint has already been completed." });

                // -----------------------------------------------------
                // UPDATE COMMENTS
                // -----------------------------------------------------
                detail.Strengths = request.Strengths?.Trim();
                detail.DevelopmentAreas = request.DevelopmentAreas?.Trim();
                detail.Progress = request.Progress?.Trim();
                detail.HRComments = request.HRComments?.Trim();

                // Employee comments are preserved here. The employee
                // acknowledgement endpoint is responsible for final sign-off.
                if (!string.IsNullOrWhiteSpace(request.EmployeeComments))
                    detail.EmployeeComments = request.EmployeeComments.Trim();

                // -----------------------------------------------------
                // UPDATE RATINGS
                // -----------------------------------------------------
                if (request.Ratings != null && request.Ratings.Count > 0)
                {
                    var criteria = await GetActiveCriteriaAsync();
                    var validCriteriaIds = criteria.Select(x => x.CriteriaId).ToHashSet();

                    foreach (var incoming in request.Ratings)
                    {
                        if (!validCriteriaIds.Contains(incoming.CriteriaId))
                            continue;

                        if (incoming.RatingScore.HasValue &&
                            (incoming.RatingScore.Value < 0 || incoming.RatingScore.Value > 100))
                            continue;

                        var existing = await _context.ProbationAssessmentRatings
                            .FirstOrDefaultAsync(x =>
                                x.DetailId == detail.DetailId &&
                                x.CriteriaId == incoming.CriteriaId &&
                                x.CompanyId == CurrentCompanyId);

                        if (existing == null)
                        {
                            _context.ProbationAssessmentRatings.Add(new ProbationAssessmentRatingsModel
                            {
                                DetailId = detail.DetailId,
                                CriteriaId = incoming.CriteriaId,
                                Rating = incoming.Rating?.Trim(),
                                RatingScore = incoming.RatingScore,
                                CompanyId = CurrentCompanyId
                            });
                        }
                        else
                        {
                            existing.Rating = incoming.Rating?.Trim();
                            existing.RatingScore = incoming.RatingScore;
                        }
                    }
                }

                await _context.SaveChangesAsync();

                // -----------------------------------------------------
                // RECALCULATE SCORE
                // RatingScore is percentage (0-100).
                // PE max = 8 * 5 = 40 points.
                // OE max = 7 * 5 = 35 points.
                // Overall max = 75 points.
                // -----------------------------------------------------
                var savedRatings = await _context.ProbationAssessmentRatings
                    .Where(x => x.DetailId == detail.DetailId && x.CompanyId == CurrentCompanyId)
                    .ToListAsync();

                var criteriaForScores = await GetActiveCriteriaAsync();

                var peIds = criteriaForScores
                    .Where(x => string.Equals(x.Category, "PersonalExcellence", StringComparison.OrdinalIgnoreCase))
                    .Select(x => x.CriteriaId)
                    .ToHashSet();

                var obIds = criteriaForScores
                    .Where(x => string.Equals(x.Category, "OperationalExcellence", StringComparison.OrdinalIgnoreCase))
                    .Select(x => x.CriteriaId)
                    .ToHashSet();

                decimal? scorePE = savedRatings.Any(x => peIds.Contains(x.CriteriaId) && x.RatingScore.HasValue)
                    ? Math.Round(savedRatings
                        .Where(x => peIds.Contains(x.CriteriaId) && x.RatingScore.HasValue)
                        .Sum(x => Convert.ToDecimal(x.RatingScore!.Value) / 20m), 2)
                    : null;

                decimal? scoreOB = savedRatings.Any(x => obIds.Contains(x.CriteriaId) && x.RatingScore.HasValue)
                    ? Math.Round(savedRatings
                        .Where(x => obIds.Contains(x.CriteriaId) && x.RatingScore.HasValue)
                        .Sum(x => Convert.ToDecimal(x.RatingScore!.Value) / 20m), 2)
                    : null;

                decimal? overall = scorePE.HasValue || scoreOB.HasValue
                    ? Math.Round((scorePE ?? 0m) + (scoreOB ?? 0m), 2)
                    : null;

                decimal? overallPercentage = overall.HasValue
                    ? Math.Round((overall.Value / 75m) * 100m, 2)
                    : null;

                detail.ScorePersonal = scorePE;
                detail.ScoreOperational = scoreOB;
                detail.OverallScore = overall;
                detail.OverallGrade = overallPercentage.HasValue
                    ? GetGrade(overallPercentage.Value)
                    : null;

                // -----------------------------------------------------
                // MANAGER / HR SIGNATURE FLAGS
                // -----------------------------------------------------
                if (request.SigManager)
                {
                    if (!IsAdminOrHrAdmin() && !IsManagerOf(assessmentEmployee))
                        return Json(new { success = false, message = "You are not authorized to sign as manager." });

                    if (!detail.SigManager)
                    {
                        detail.SigManager = true;
                        detail.SigManagerDate = DateTime.Now;
                    }
                }

                if (request.SigHR)
                {
                    if (!IsAdminOrHrAdmin())
                        return Json(new { success = false, message = "Only HR/Admin can apply the HR signature." });

                    if (!detail.SigHR)
                    {
                        detail.SigHR = true;
                        detail.SigHRDate = DateTime.Now;
                    }
                }

                // -----------------------------------------------------
                // DECISION
                // Checkpoint 1/2 do not require a final decision.
                // Checkpoint 3+ requires Confirm or Extend.
                // -----------------------------------------------------
                string decision = request.CheckpointDecision?.Trim() ?? "";

                if (!string.IsNullOrWhiteSpace(decision))
                {
                    if (!string.Equals(decision, "Confirm", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(decision, "Extend", StringComparison.OrdinalIgnoreCase))
                    {
                        return Json(new { success = false, message = "Invalid checkpoint decision." });
                    }

                    detail.CheckpointDecision =
                        char.ToUpperInvariant(decision[0]) + decision.Substring(1).ToLowerInvariant();
                    detail.CheckpointDecisionDate = DateTime.Now;
                }

                // -----------------------------------------------------
                // EXTENSION
                // -----------------------------------------------------
                if (string.Equals(decision, "Extend", StringComparison.OrdinalIgnoreCase))
                {
                    if (!request.NewProbationEndDate.HasValue)
                        return Json(new { success = false, message = "New probation end date is required for extension." });

                    if (request.NewProbationEndDate.Value.Date <= DateTime.Today)
                        return Json(new { success = false, message = "New probation end date must be in the future." });

                    // Prevent duplicate extension from the same checkpoint.
                    bool alreadyExtended = await _context.ProbationExtensionLogs
                        .AnyAsync(x => x.AssessmentId == master.AssessmentId
                                    && x.DetailId == detail.DetailId
                                    && x.CompanyId == CurrentCompanyId);

                    if (!alreadyExtended)
                    {
                        var lastCheckpoint = await _context.ProbationAssessmentDetails
                            .Where(x => x.AssessmentId == master.AssessmentId && x.CompanyId == CurrentCompanyId)
                            .OrderByDescending(x => x.CheckpointNo)
                            .FirstOrDefaultAsync();

                        int newCheckpointNo = (lastCheckpoint?.CheckpointNo ?? 3) + 1;

                        var newDetail = new ProbationAssessmentDetailsModel
                        {
                            AssessmentId = master.AssessmentId,
                            CheckpointNo = newCheckpointNo,
                            CheckpointLabel = $"Extended Evaluation {newCheckpointNo - 3}",
                            ScheduledDate = request.NewProbationEndDate.Value.Date,
                            Status = "Pending",
                            SigManager = false,
                            SigEmployee = false,
                            SigHR = false,
                            CompanyId = CurrentCompanyId,
                            CreatedBy = CurrentActorId > 0 ? CurrentActorId : null,
                            CreatedOn = DateTime.Now
                        };

                        _context.ProbationAssessmentDetails.Add(newDetail);
                        await _context.SaveChangesAsync();

                        foreach (var criterion in criteriaForScores)
                        {
                            _context.ProbationAssessmentRatings.Add(new ProbationAssessmentRatingsModel
                            {
                                DetailId = newDetail.DetailId,
                                CriteriaId = criterion.CriteriaId,
                                CompanyId = CurrentCompanyId
                            });
                        }

                        _context.ProbationExtensionLogs.Add(new ProbationExtensionLogModel
                        {
                            AssessmentId = master.AssessmentId,
                            EmployeeNo = master.EmployeeNo,
                            DetailId = detail.DetailId,
                            OldProbationEndDate = master.ProbationEndDate,
                            NewProbationEndDate = request.NewProbationEndDate.Value.Date,
                            NewCheckpointNo = newCheckpointNo,
                            NewCheckpointDate = request.NewProbationEndDate.Value.Date,
                            ExtendedBy = CurrentActorId > 0 ? CurrentActorId : null,
                            ExtendedOn = DateTime.Now,
                            Reason = detail.HRComments,
                            CompanyId = CurrentCompanyId
                        });

                        master.ProbationEndDate = request.NewProbationEndDate.Value.Date;
                        master.FinalDecision = "Extend";
                        master.FinalDecisionDate = DateTime.Now;
                        master.HRRemarks = detail.HRComments;
                        master.OverallStatus = "InProgress";
                    }
                }
                else if (string.Equals(decision, "Confirm", StringComparison.OrdinalIgnoreCase)
                         && detail.CheckpointNo >= 3)
                {
                    master.FinalDecision = "Confirm";
                    master.FinalDecisionDate = DateTime.Now;
                    master.HRRemarks = detail.HRComments;

                    // Employee remains active; confirmation date is updated.
                    assessmentEmployee.ConfirmationDate = DateTime.Now.Date;
                }

                await RecalculateCheckpointStatusAsync(detail);
                await RecalculateMasterStatusAsync(master);

                // Extension always keeps the master in progress because a new
                // pending checkpoint was created.
                if (string.Equals(decision, "Extend", StringComparison.OrdinalIgnoreCase))
                    master.OverallStatus = "InProgress";

                master.ModifiedBy = CurrentActorId > 0 ? CurrentActorId : null;
                master.ModifiedOn = DateTime.Now;

                await _context.SaveChangesAsync();
                await tx.CommitAsync();

                return Json(new
                {
                    success = true,
                    message = string.Equals(decision, "Extend", StringComparison.OrdinalIgnoreCase)
                        ? "Probation extended successfully."
                        : string.Equals(decision, "Confirm", StringComparison.OrdinalIgnoreCase)
                            ? "Employee confirmed successfully."
                            : "Assessment saved successfully.",
                    assessmentId = master.AssessmentId,
                    detailId = detail.DetailId,
                    status = detail.Status,
                    overallStatus = master.OverallStatus,
                    overallScore = detail.OverallScore,
                    grade = detail.OverallGrade
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        // ============================================================
        // MY ASSESSMENT - EMPLOYEE GET
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> MyAssessment(string employeeNo = "")
        {
            try
            {
                if (!IsAdminOrHrAdmin())
                    employeeNo = CurrentEmployeeCode;
                else if (string.IsNullOrWhiteSpace(employeeNo))
                    employeeNo = CurrentEmployeeCode;

                if (string.IsNullOrWhiteSpace(employeeNo))
                    return View(new ProbationAssessmentViewModel());

                var master = await _context.ProbationAssessmentMasters
                    .FirstOrDefaultAsync(x =>
                        x.EmployeeNo == employeeNo &&
                        x.CompanyId == CurrentCompanyId);

                if (master == null)
                    return View(new ProbationAssessmentViewModel
                    {
                        CompanyId = CurrentCompanyId,
                        IsHR = IsAdminOrHrAdmin(),
                        IsManager = false
                    });

                var employee = await GetEmployeeAsync(employeeNo, false);
                if (employee != null)
                {
                    master.EmployeeName = EmployeeName(employee);
                    master.Department = employee.Department?.DepartmentName ?? "-";
                    master.Designation = employee.Designation?.DesignationName ?? "-";
                    master.AppraiserName = await _context.Employees
                        .Where(x => x.EmployeeCode == master.AppraiserId)
                        .Select(x => (x.FirstName + " " + x.LastName).Trim())
                        .FirstOrDefaultAsync() ?? "-";
                }

                var checkpoints = await _context.ProbationAssessmentDetails
                    .Where(x => x.AssessmentId == master.AssessmentId && x.CompanyId == CurrentCompanyId)
                    .OrderBy(x => x.CheckpointNo)
                    .ToListAsync();

                foreach (var checkpoint in checkpoints)
                {
                    checkpoint.IsLocked = checkpoint.Status == "Completed";
                    checkpoint.IsCurrent = checkpoint.Status != "Completed";
                }

                return View(new ProbationAssessmentViewModel
                {
                    Master = master,
                    Checkpoints = checkpoints,
                    CompanyId = CurrentCompanyId,
                    IsHR = IsAdminOrHrAdmin(),
                    IsManager = false
                });
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.InnerException?.Message ?? ex.Message;
                return View(new ProbationAssessmentViewModel());
            }
        }

        // ============================================================
        // SAVE EMPLOYEE SIGNATURE - POST
        // Employee can acknowledge only their own checkpoint.
        // ============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveEmployeeSignature(
            int detailId,
            int assessmentId,
            string employeeComments)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CurrentCompanyId))
                    return Json(new { success = false, message = "Company information is missing." });

                var master = await _context.ProbationAssessmentMasters
                    .FirstOrDefaultAsync(x =>
                        x.AssessmentId == assessmentId &&
                        x.CompanyId == CurrentCompanyId);

                if (master == null)
                    return Json(new { success = false, message = "Assessment not found." });

                string currentEmployeeCode = CurrentEmployeeCode;

                if (!IsAdminOrHrAdmin() &&
                    !string.Equals(master.EmployeeNo, currentEmployeeCode, StringComparison.OrdinalIgnoreCase))
                {
                    return Json(new { success = false, message = "You are not authorized to acknowledge this assessment." });
                }

                var detail = await _context.ProbationAssessmentDetails
                    .FirstOrDefaultAsync(x =>
                        x.DetailId == detailId &&
                        x.AssessmentId == assessmentId &&
                        x.CompanyId == CurrentCompanyId);

                if (detail == null)
                    return Json(new { success = false, message = "Checkpoint not found." });

                if (detail.SigEmployee)
                    return Json(new { success = false, message = "This checkpoint is already acknowledged." });

                if (!detail.SigManager)
                    return Json(new { success = false, message = "Manager signature is required before employee acknowledgement." });

                if (detail.ScheduledDate.HasValue && detail.ScheduledDate.Value.Date > DateTime.Today)
                {
                    return Json(new
                    {
                        success = false,
                        message = "This checkpoint can only be acknowledged on or after "
                                  + detail.ScheduledDate.Value.ToString("dd MMM yyyy") + "."
                    });
                }

                employeeComments = employeeComments?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(employeeComments))
                    return Json(new { success = false, message = "Employee comments are required before acknowledgement." });

                detail.EmployeeComments = employeeComments;
                detail.SigEmployee = true;
                detail.SigEmployeeDate = DateTime.Now;
                detail.ModifiedBy = CurrentActorId > 0 ? CurrentActorId : null;
                detail.ModifiedOn = DateTime.Now;

                await RecalculateCheckpointStatusAsync(detail);

                var allDetails = await _context.ProbationAssessmentDetails
                    .Where(x => x.AssessmentId == master.AssessmentId && x.CompanyId == CurrentCompanyId)
                    .ToListAsync();

                master.OverallStatus = allDetails.All(x => x.Status == "Completed")
                    ? "Completed"
                    : "InProgress";
                master.ModifiedBy = CurrentActorId > 0 ? CurrentActorId : null;
                master.ModifiedOn = DateTime.Now;

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Assessment acknowledged successfully.",
                    signedOn = detail.SigEmployeeDate?.ToString("dd MMM yyyy hh:mm tt"),
                    status = detail.Status,
                    overallStatus = master.OverallStatus
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.InnerException?.Message ?? ex.Message });
            }
        }

        // ============================================================
        // DELETE ASSESSMENT
        // ============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteAssessment(int assessmentId)
        {
            try
            {
                var master = await _context.ProbationAssessmentMasters
                    .FirstOrDefaultAsync(x =>
                        x.AssessmentId == assessmentId &&
                        x.CompanyId == CurrentCompanyId);

                if (master == null)
                    return Json(new { success = false, message = "Assessment not found." });

                var employee = await GetEmployeeAsync(master.EmployeeNo, false);
                if (employee == null || !CanAccessEmployee(employee))
                    return Json(new { success = false, message = "You are not authorized to delete this assessment." });

                _context.ProbationAssessmentMasters.Remove(master);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Assessment deleted successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.InnerException?.Message ?? ex.Message });
            }
        }

        // ============================================================
        // TOGGLE STATUS - kept for existing UI compatibility.
        // ============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var master = await _context.ProbationAssessmentMasters
                .FirstOrDefaultAsync(x => x.AssessmentId == id && x.CompanyId == CurrentCompanyId);

            if (master == null)
                return Json(new { success = false, message = "Assessment not found." });

            if (!IsAdminOrHrAdmin())
                return Json(new { success = false, message = "Only Admin/HR can change assessment status." });

            master.OverallStatus = master.OverallStatus == "Completed" ? "InProgress" : "Completed";
            master.ModifiedBy = CurrentActorId > 0 ? CurrentActorId : null;
            master.ModifiedOn = DateTime.Now;

            await _context.SaveChangesAsync();
            return Json(new { success = true, status = master.OverallStatus });
        }
    }

    // ================================================================
    // API REQUEST MODELS
    // ================================================================
    public class SaveProbationAssessmentRequest
    {
        public int AssessmentId { get; set; }
        public int DetailId { get; set; }
        public string? EmployeeNo { get; set; }
        public List<ProbationRatingRequest> Ratings { get; set; } = new();
        public string? Strengths { get; set; }
        public string? DevelopmentAreas { get; set; }
        public string? Progress { get; set; }
        public string? EmployeeComments { get; set; }
        public bool SigManager { get; set; }
        public bool SigEmployee { get; set; }
        public bool SigHR { get; set; }
        public string? CheckpointDecision { get; set; }
        public string? HRComments { get; set; }
        public DateTime? NewProbationEndDate { get; set; }
    }

    public class ProbationRatingRequest
    {
        public int CriteriaId { get; set; }
        public string? Rating { get; set; }
        public int? RatingScore { get; set; }
        public string? Category { get; set; }
    }


}