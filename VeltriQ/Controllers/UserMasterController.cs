using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.Models.Master;
using VeltriQ.ViewModels.Administration;


namespace VeltriQ.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserMasterController : BaseController
    {
        private readonly ApplicationDbContext _identityContext;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserMasterController(
            TenantDbContext tenantContext,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext identityContext,
            RoleManager<IdentityRole> roleManager)
            : base(tenantContext, masterContext, userManager)
        {
            _identityContext = identityContext;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // ------------------------------------------------------------
            // Determine the active company.
            // First use the selected company from session.
            // If it is not available, fall back to the logged-in
            // employee's company.
            // ------------------------------------------------------------

            var companyId = GetCurrentCompanyId();

            if (!companyId.HasValue)
            {
                var currentEmployeeId = GetCurrentEmployeeId();

                if (currentEmployeeId.HasValue)
                {
                    companyId = await _context.Employees
                        .AsNoTracking()
                        .Where(x => x.EmployeeId == currentEmployeeId.Value)
                        .Select(x => (int?)x.CompanyId)
                        .FirstOrDefaultAsync();
                }
            }

            if (!companyId.HasValue)
            {
                TempData["Error"] =
                    "Company information could not be determined for the current user.";

                return View(new UserMasterIndexViewModel());
            }

            // ------------------------------------------------------------
            // Load active employees for the selected/current company
            // ------------------------------------------------------------

            var employees = await _context.Employees
                .AsNoTracking()
                .Include(x => x.Branch)
                .Where(x =>
                    x.IsActive &&
                    x.CompanyId == companyId.Value)
                .OrderBy(x => x.EmployeeCode)
                .ToListAsync();

            // ------------------------------------------------------------
            // Get Employee.UserId values
            // These values alone do NOT determine whether an employee
            // actually has a login account.
            // ------------------------------------------------------------

            var userIds = employees
                .Where(x => !string.IsNullOrWhiteSpace(x.UserId))
                .Select(x => x.UserId!)
                .Distinct()
                .ToList();

            // ------------------------------------------------------------
            // Load actual Identity users
            //
            // IMPORTANT:
            // Only IDs that actually exist in AspNetUsers are considered
            // valid login accounts.
            // ------------------------------------------------------------

            var users = await _identityContext.Users
                .AsNoTracking()
                .Where(x => userIds.Contains(x.Id))
                .ToListAsync();

            // ------------------------------------------------------------
            // Load company access for actual Identity users
            // ------------------------------------------------------------

            var actualUserIds = users
                .Select(x => x.Id)
                .ToList();

            var accessRows = await _masterContext.UserCompanyAccesses
                .AsNoTracking()
                .Where(x => actualUserIds.Contains(x.UserId))
                .ToListAsync();

            // ------------------------------------------------------------
            // Load companies used by those users
            // ------------------------------------------------------------

            var companyIds = accessRows
                .Select(x => x.CompanyId)
                .Distinct()
                .ToList();

            var companies = await _masterContext.Companies
                .AsNoTracking()
                .Where(x => companyIds.Contains(x.CompanyId))
                .ToDictionaryAsync(
                    x => x.CompanyId,
                    x => x.CompanyName
                );

            // ------------------------------------------------------------
            // EXISTING USER ACCOUNTS
            //
            // An employee is considered a user ONLY when:
            //
            // Employee.UserId
            //       ↓
            // Matching AspNetUsers.Id exists
            // ------------------------------------------------------------

            var rows = new List<UserMasterRowViewModel>();

            foreach (var employee in employees)
            {
                var user = users.FirstOrDefault(
                    x => x.Id == employee.UserId
                );

                // Employee has no matching Identity account.
                if (user == null)
                    continue;

                var access = accessRows
                    .Where(x => x.UserId == user.Id)
                    .OrderByDescending(x => x.IsDefault)
                    .FirstOrDefault();

                var roles = await _userManager.GetRolesAsync(user);

                rows.Add(new UserMasterRowViewModel
                {
                    UserId = user.Id,

                    EmployeeCode =
                        employee.EmployeeCode,

                    EmployeeName =
                        $"{employee.FirstName} {employee.LastName}".Trim(),

                    Username =
                        user.UserName,

                    Email =
                        user.Email,

                    Role =
                        roles.FirstOrDefault() ?? "-",

                    CompanyName =
                        access != null &&
                        companies.TryGetValue(
                            access.CompanyId,
                            out var companyName)
                            ? companyName
                            : "-",

                    BranchName =
                        employee.Branch?.BranchName ?? "-",

                    IsActive =
                        user.IsActive
                });
            }

            // ------------------------------------------------------------
            // EMPLOYEES WITHOUT LOGIN
            //
            // An employee belongs here when:
            //
            // 1. UserId is NULL/empty
            // OR
            // 2. UserId exists but there is NO matching AspNetUsers record
            // ------------------------------------------------------------

            var employeeWithoutUsers = employees
                .Where(employee =>
                    !users.Any(user =>
                        user.Id == employee.UserId))
                .Select(employee => new EmployeeWithoutUserViewModel
                {
                    EmployeeId =
                        employee.EmployeeId,

                    EmployeeCode =
                        employee.EmployeeCode ?? "-",

                    EmployeeName =
                        $"{employee.FirstName} {employee.LastName}".Trim(),

                    OfficialEmail =
                        employee.OfficialEmail,

                    BranchName =
                        employee.Branch?.BranchName ?? "-"
                })
                .ToList();

            // ------------------------------------------------------------
            // Send both datasets to the Index view
            // ------------------------------------------------------------

            return View(
                new UserMasterIndexViewModel
                {
                    Users = rows,

                    EmployeesWithoutUsers =
                        employeeWithoutUsers
                }
            );
        }

        private async Task LoadUserMasterCreateDropdowns(
    UserMasterCreateViewModel model)
        {
            // =========================================================
            // EMPLOYEES WITHOUT LOGIN
            // =========================================================

            model.Employees = await _context.Employees
                .AsNoTracking()
                .Where(x =>
                    x.IsActive &&
                    string.IsNullOrWhiteSpace(x.UserId))
                .OrderBy(x => x.EmployeeCode)
                .Select(x => new SelectListItem
                {
                    Value = x.EmployeeId.ToString(),

                    Text =
                        x.EmployeeCode +
                        " - " +
                        x.FirstName +
                        " " +
                        (x.LastName ?? "")
                })
                .ToListAsync();


            // =========================================================
            // ROLES
            // =========================================================

            model.Roles = await _roleManager.Roles
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Value = x.Name!,
                    Text = x.Name!
                })
                .ToListAsync();


            // =========================================================
            // COMPANIES
            // =========================================================

            model.Companies = await _masterContext.Companies
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.CompanyName)
                .Select(x => new SelectListItem
                {
                    Value = x.CompanyId.ToString(),
                    Text = x.CompanyName
                })
                .ToListAsync();


            // =========================================================
            // BRANCHES
            // =========================================================

            model.Branches = new List<SelectListItem>();

            if (model.CompanyId > 0)
            {
                model.Branches =
                    await GetBranches(model.CompanyId);
            }
        }

        private async Task<List<SelectListItem>> GetBranches(
    int companyId)
        {
            return await _context.Branches
                .AsNoTracking()
                .Where(x =>
                    x.IsActive &&
                    x.CompanyId == companyId)
                .OrderBy(x => x.BranchName)
                .Select(x => new SelectListItem
                {
                    Value = x.BranchId.ToString(),
                    Text = x.BranchName
                })
                .ToListAsync();
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeForUserCreation(
    int employeeId)
        {
            var employee = await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.EmployeeId == employeeId &&
                    x.IsActive &&
                    string.IsNullOrWhiteSpace(x.UserId));

            if (employee == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Employee not found or already has a login."
                });
            }

            var branches = await _context.Branches
                .AsNoTracking()
                .Where(x =>
                    x.IsActive &&
                    x.CompanyId == employee.CompanyId)
                .OrderBy(x => x.BranchName)
                .Select(x => new
                {
                    id = x.BranchId,
                    name = x.BranchName
                })
                .ToListAsync();

            return Json(new
            {
                success = true,

                employeeId = employee.EmployeeId,

                employeeCode = employee.EmployeeCode,

                employeeName =
                    $"{employee.FirstName} {employee.LastName}".Trim(),

                officialEmail = employee.OfficialEmail,

                companyId = employee.CompanyId,

                branchId = employee.BranchId,

                branches
            });
        }
        // =========================================================
        // CREATE USER - GET
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> Create(int? employeeId = null)
        {
            var model = new UserMasterCreateViewModel();

            // ---------------------------------------------------------
            // Load dropdown data
            // ---------------------------------------------------------

            await LoadUserMasterCreateDropdowns(model);

            // ---------------------------------------------------------
            // If Create User was opened from
            // Employees Without Login
            // ---------------------------------------------------------

            if (employeeId.HasValue)
            {
                var employee = await _context.Employees
                    .AsNoTracking()
                    .Where(x =>
                        x.EmployeeId == employeeId.Value &&
                        x.IsActive)
                    .Select(x => new
                    {
                        x.EmployeeId,
                        x.EmployeeCode,
                        x.FirstName,
                        x.LastName,
                        x.OfficialEmail,
                        x.BranchId,
                        x.CompanyId,
                        x.UserId
                    })
                    .FirstOrDefaultAsync();

                if (employee == null)
                {
                    TempData["Error"] =
                        "The selected employee could not be found.";

                    return RedirectToAction(nameof(Index));
                }

                // -----------------------------------------------------
                // Check whether the Employee.UserId actually exists
                // in ASP.NET Identity
                // -----------------------------------------------------

                if (!string.IsNullOrWhiteSpace(employee.UserId))
                {
                    var identityUser =
                        await _userManager.FindByIdAsync(employee.UserId);

                    // Only treat the employee as having a login
                    // if the Identity user actually exists.
                    if (identityUser != null)
                    {
                        TempData["Error"] =
                            "The selected employee already has a user account.";

                        return RedirectToAction(nameof(Index));
                    }
                }

                // -----------------------------------------------------
                // Employee details
                // -----------------------------------------------------

                model.EmployeeId =
                    employee.EmployeeId;

                model.EmployeeCode =
                    employee.EmployeeCode;

                model.EmployeeName =
                    $"{employee.FirstName} {employee.LastName}".Trim();

                model.OfficialEmail =
                    employee.OfficialEmail;

                // -----------------------------------------------------
                // Default username = official email
                // -----------------------------------------------------

                model.UserName =
                    employee.OfficialEmail?.Trim() ?? string.Empty;

                // -----------------------------------------------------
                // Preselect company
                // -----------------------------------------------------

                if (employee.CompanyId.HasValue)
                {
                    model.CompanyId =
                        employee.CompanyId.Value;
                }

                // -----------------------------------------------------
                // Preselect branch
                // -----------------------------------------------------

                model.BranchId =
                    employee.BranchId;
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
    UserMasterCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadUserMasterCreateDropdowns(model);

                return View(model);
            }


            // =========================================================
            // EMPLOYEE
            // =========================================================

            var employee = await _context.Employees
                .FirstOrDefaultAsync(x =>
                    x.EmployeeId == model.EmployeeId &&
                    x.IsActive);

            if (employee == null)
            {
                ModelState.AddModelError(
                    nameof(model.EmployeeId),
                    "Selected employee was not found."
                );

                await LoadUserMasterCreateDropdowns(model);

                return View(model);
            }


            // =========================================================
            // PREVENT DUPLICATE USER
            // =========================================================

            if (!string.IsNullOrWhiteSpace(employee.UserId))
            {
                var existingIdentityUser =
                    await _userManager.FindByIdAsync(employee.UserId);

                if (existingIdentityUser != null)
                {
                    ModelState.AddModelError(
                        nameof(model.EmployeeId),
                        "This employee already has a user account."
                    );

                    await LoadUserMasterCreateDropdowns(model);

                    return View(model);
                }
            }


            // =========================================================
            // USERNAME DUPLICATE
            // =========================================================

            var existingUsername =
                await _userManager.FindByNameAsync(
                    model.UserName.Trim()
                );

            if (existingUsername != null)
            {
                ModelState.AddModelError(
                    nameof(model.UserName),
                    "This username is already in use."
                );

                await LoadUserMasterCreateDropdowns(model);

                return View(model);
            }


            // =========================================================
            // EMAIL
            // =========================================================

            var email =
                employee.OfficialEmail?.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError(
                    nameof(model.EmployeeId),
                    "The selected employee does not have an official email."
                );

                await LoadUserMasterCreateDropdowns(model);

                return View(model);
            }


            // =========================================================
            // CREATE IDENTITY USER
            // =========================================================

            var user = new ApplicationUser
            {
                UserName = model.UserName.Trim(),

                Email = email,

                FullName =
                    $"{employee.FirstName} {employee.LastName}".Trim(),

                IsActive = model.IsActive,

                EmailConfirmed = true
            };


            var createResult =
                await _userManager.CreateAsync(
                    user,
                    model.Password
                );


            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError(
                        "",
                        error.Description
                    );
                }

                await LoadUserMasterCreateDropdowns(model);

                return View(model);
            }


            // =========================================================
            // ROLE
            // =========================================================

            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                await _userManager.DeleteAsync(user);

                ModelState.AddModelError(
                    nameof(model.Role),
                    "Selected role does not exist."
                );

                await LoadUserMasterCreateDropdowns(model);

                return View(model);
            }


            var roleResult =
                await _userManager.AddToRoleAsync(
                    user,
                    model.Role
                );


            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);

                foreach (var error in roleResult.Errors)
                {
                    ModelState.AddModelError(
                        "",
                        error.Description
                    );
                }

                await LoadUserMasterCreateDropdowns(model);

                return View(model);
            }


            // =========================================================
            // COMPANY ACCESS
            // =========================================================

            var company =
                await _masterContext.Companies
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.CompanyId == model.CompanyId &&
                        x.IsActive);

            if (company == null)
            {
                await _userManager.RemoveFromRoleAsync(
                    user,
                    model.Role
                );

                await _userManager.DeleteAsync(user);

                ModelState.AddModelError(
                    nameof(model.CompanyId),
                    "Selected company is invalid."
                );

                await LoadUserMasterCreateDropdowns(model);

                return View(model);
            }


            // =========================================================
            // CREATE COMPANY ACCESS
            // =========================================================

            var companyAccess = new UserCompanyAccess
            {
                UserId = user.Id,
                CompanyId = model.CompanyId,
                IsDefault = true
            };

            _masterContext.UserCompanyAccesses.Add(companyAccess);
            // =========================================================
            // LINK EMPLOYEE → IDENTITY USER
            // =========================================================

            employee.UserId = user.Id;


            await _context.SaveChangesAsync();

            await _masterContext.SaveChangesAsync();


            // =========================================================
            // SUCCESS
            // =========================================================

            TempData["Success"] =
                $"User account created successfully for {employee.FirstName} {employee.LastName}.";

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails(int employeeId)
        {
            var companyId = GetCurrentCompanyId();
            if (!companyId.HasValue)
            {
                return Json(new { success = false, message = "Active company is missing." });
            }

            var employee = await _context.Employees
                .AsNoTracking()
                .Include(x => x.Branch)
                .FirstOrDefaultAsync(x =>
                    x.EmployeeId == employeeId &&
                    x.CompanyId == companyId.Value &&
                    x.IsActive &&
                    string.IsNullOrEmpty(x.UserId));

            if (employee == null)
            {
                return Json(new { success = false, message = "Employee not found or already has a user account." });
            }

            return Json(new
            {
                success = true,
                employeeId = employee.EmployeeId,
                employeeCode = employee.EmployeeCode,
                employeeName = $"{employee.FirstName} {employee.LastName}".Trim(),
                email = employee.OfficialEmail,
                branchId = employee.BranchId,
                branchName = employee.Branch?.BranchName
            });
        }

        // =========================================================
        // EDIT USER - GET
        // =========================================================
        // =========================================================
        // EDIT USER - GET
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            // ---------------------------------------------------------
            // Validate User ID
            // ---------------------------------------------------------

            if (string.IsNullOrWhiteSpace(id))
            {
                TempData["Error"] = "Invalid user account.";

                return RedirectToAction(nameof(Index));
            }


            // ---------------------------------------------------------
            // Load Identity User
            // ---------------------------------------------------------

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                TempData["Error"] = "User account could not be found.";

                return RedirectToAction(nameof(Index));
            }


            // ---------------------------------------------------------
            // Load linked Employee
            // ---------------------------------------------------------

            var employee = await _context.Employees
                .AsNoTracking()
                .Where(x =>
                    x.UserId == user.Id &&
                    x.IsActive)
                .Select(x => new
                {
                    x.EmployeeId,
                    x.EmployeeCode,
                    x.FirstName,
                    x.LastName,
                    x.OfficialEmail,
                    x.CompanyId,
                    x.BranchId
                })
                .FirstOrDefaultAsync();


            if (employee == null)
            {
                TempData["Error"] =
                    "The employee linked to this user account could not be found.";

                return RedirectToAction(nameof(Index));
            }


            // ---------------------------------------------------------
            // Get current Identity role
            // ---------------------------------------------------------

            var roles =
                await _userManager.GetRolesAsync(user);

            var currentRole =
                roles.FirstOrDefault() ?? string.Empty;


            // ---------------------------------------------------------
            // Get current company access
            // ---------------------------------------------------------

            var companyAccess =
                await _masterContext.UserCompanyAccesses
                    .AsNoTracking()
                    .Where(x => x.UserId == user.Id)
                    .OrderByDescending(x => x.IsDefault)
                    .FirstOrDefaultAsync();


            // ---------------------------------------------------------
            // Determine Company ID
            //
            // Priority:
            // 1. UserCompanyAccess
            // 2. Employee.CompanyId
            // ---------------------------------------------------------

            int companyId = 0;

            if (companyAccess != null)
            {
                companyId = companyAccess.CompanyId;
            }
            else if (employee.CompanyId.HasValue)
            {
                companyId = employee.CompanyId.Value;
            }


            // ---------------------------------------------------------
            // Create Edit ViewModel
            // ---------------------------------------------------------

            var model = new UserMasterEditViewModel
            {
                UserId =
                    user.Id,

                EmployeeId =
                    employee.EmployeeId,

                EmployeeCode =
                    employee.EmployeeCode,

                EmployeeName =
                    $"{employee.FirstName} {employee.LastName}".Trim(),

                OfficialEmail =
                    employee.OfficialEmail,

                UserName =
                    user.UserName ?? string.Empty,

                Role =
                    currentRole,

                CompanyId =
                    companyId,

                BranchId =
                    employee.BranchId,

                IsActive =
                    user.IsActive
            };


            // =========================================================
            // LOAD ROLES
            // =========================================================

            model.Roles =
                await _roleManager.Roles
                    .AsNoTracking()
                    .OrderBy(x => x.Name)
                    .Select(x => new SelectListItem
                    {
                        Value = x.Name!,
                        Text = x.Name!
                    })
                    .ToListAsync();


            // =========================================================
            // LOAD COMPANIES
            // =========================================================

            model.Companies =
                await _masterContext.Companies
                    .AsNoTracking()
                    .OrderBy(x => x.CompanyName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.CompanyId.ToString(),
                        Text = x.CompanyName
                    })
                    .ToListAsync();


            // =========================================================
            // LOAD BRANCHES
            //
            // Branches belong to TenantDbContext
            // =========================================================

            if (companyId > 0)
            {
                model.Branches =
                    await _context.Branches
                        .AsNoTracking()
                        .Where(x =>
                            x.IsActive &&
                            x.CompanyId == companyId)
                        .OrderBy(x => x.BranchName)
                        .Select(x => new SelectListItem
                        {
                            Value = x.BranchId.ToString(),
                            Text = x.BranchName
                        })
                        .ToListAsync();
            }
            else
            {
                model.Branches =
                    new List<SelectListItem>();
            }


            // ---------------------------------------------------------
            // Return Edit View
            // ---------------------------------------------------------

            return View(model);
        }

        // =========================================================
        // EDIT USER - POST
        // =========================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserMasterEditViewModel model)
        {
            // ---------------------------------------------------------
            // Validate User ID
            // ---------------------------------------------------------

            if (string.IsNullOrWhiteSpace(model.UserId))
            {
                TempData["Error"] = "Invalid user account.";

                return RedirectToAction(nameof(Index));
            }


            // ---------------------------------------------------------
            // Load Identity User
            // ---------------------------------------------------------

            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                TempData["Error"] = "User account could not be found.";

                return RedirectToAction(nameof(Index));
            }


            // ---------------------------------------------------------
            // Remove validation errors for fields that are not
            // actually edited on this page
            // ---------------------------------------------------------

            ModelState.Remove(nameof(model.EmployeeName));
            ModelState.Remove(nameof(model.EmployeeCode));
            ModelState.Remove(nameof(model.OfficialEmail));


            // ---------------------------------------------------------
            // Validate Model
            // ---------------------------------------------------------

            if (!ModelState.IsValid)
            {
                await LoadUserMasterEditDropdowns(model);

                return View(model);
            }


            // ---------------------------------------------------------
            // Load Employee
            // ---------------------------------------------------------

            var employee = await _context.Employees
                .FirstOrDefaultAsync(x =>
                    x.EmployeeId == model.EmployeeId &&
                    x.IsActive);

            if (employee == null)
            {
                ModelState.AddModelError(
                    nameof(model.EmployeeId),
                    "The linked employee could not be found."
                );

                await LoadUserMasterEditDropdowns(model);

                return View(model);
            }


            // ---------------------------------------------------------
            // USERNAME
            // ---------------------------------------------------------

            var newUsername = model.UserName?.Trim();

            if (string.IsNullOrWhiteSpace(newUsername))
            {
                ModelState.AddModelError(
                    nameof(model.UserName),
                    "Username is required."
                );

                await LoadUserMasterEditDropdowns(model);

                return View(model);
            }


            // ---------------------------------------------------------
            // CHECK USERNAME DUPLICATE
            // ---------------------------------------------------------

            var existingUser =
                await _userManager.FindByNameAsync(newUsername);

            if (existingUser != null &&
                existingUser.Id != user.Id)
            {
                ModelState.AddModelError(
                    nameof(model.UserName),
                    "This username is already in use."
                );

                await LoadUserMasterEditDropdowns(model);

                return View(model);
            }


            // ---------------------------------------------------------
            // COMPANY VALIDATION
            // ---------------------------------------------------------

            var company =
                await _masterContext.Companies
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.CompanyId == model.CompanyId);

            if (company == null)
            {
                ModelState.AddModelError(
                    nameof(model.CompanyId),
                    "Selected company is invalid."
                );

                await LoadUserMasterEditDropdowns(model);

                return View(model);
            }


            // ---------------------------------------------------------
            // ROLE VALIDATION
            // ---------------------------------------------------------

            if (string.IsNullOrWhiteSpace(model.Role) ||
                !await _roleManager.RoleExistsAsync(model.Role))
            {
                ModelState.AddModelError(
                    nameof(model.Role),
                    "Selected role does not exist."
                );

                await LoadUserMasterEditDropdowns(model);

                return View(model);
            }


            // =========================================================
            // UPDATE USERNAME
            // =========================================================

            user.UserName = newUsername;


            // =========================================================
            // UPDATE ACTIVE STATUS
            // =========================================================

            user.IsActive = model.IsActive;


            // =========================================================
            // UPDATE EMAIL
            //
            // Keep the employee's official email as the Identity email.
            // =========================================================

            if (!string.IsNullOrWhiteSpace(employee.OfficialEmail))
            {
                user.Email = employee.OfficialEmail.Trim();
            }


            // =========================================================
            // UPDATE ROLE
            // =========================================================

            var currentRoles =
                await _userManager.GetRolesAsync(user);

            if (!currentRoles.Contains(model.Role))
            {
                if (currentRoles.Any())
                {
                    var removeRolesResult =
                        await _userManager.RemoveFromRolesAsync(
                            user,
                            currentRoles
                        );

                    if (!removeRolesResult.Succeeded)
                    {
                        foreach (var error in removeRolesResult.Errors)
                        {
                            ModelState.AddModelError(
                                "",
                                error.Description
                            );
                        }

                        await LoadUserMasterEditDropdowns(model);

                        return View(model);
                    }
                }


                var addRoleResult =
                    await _userManager.AddToRoleAsync(
                        user,
                        model.Role
                    );

                if (!addRoleResult.Succeeded)
                {
                    foreach (var error in addRoleResult.Errors)
                    {
                        ModelState.AddModelError(
                            "",
                            error.Description
                        );
                    }

                    await LoadUserMasterEditDropdowns(model);

                    return View(model);
                }
            }


            // =========================================================
            // UPDATE IDENTITY USER
            // =========================================================

            var updateResult =
                await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError(
                        "",
                        error.Description
                    );
                }

                await LoadUserMasterEditDropdowns(model);

                return View(model);
            }


            // =========================================================
            // CHANGE PASSWORD
            //
            // If NewPassword is blank:
            //     Keep existing password.
            //
            // If NewPassword is entered:
            //     Replace the existing password.
            // =========================================================

            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError(
                        nameof(model.ConfirmPassword),
                        "Password and confirm password do not match."
                    );

                    await LoadUserMasterEditDropdowns(model);

                    return View(model);
                }


                var passwordRemoveResult =
                    await _userManager.RemovePasswordAsync(user);

                if (!passwordRemoveResult.Succeeded)
                {
                    foreach (var error in passwordRemoveResult.Errors)
                    {
                        ModelState.AddModelError(
                            "",
                            error.Description
                        );
                    }

                    await LoadUserMasterEditDropdowns(model);

                    return View(model);
                }


                var passwordAddResult =
                    await _userManager.AddPasswordAsync(
                        user,
                        model.Password
                    );

                if (!passwordAddResult.Succeeded)
                {
                    foreach (var error in passwordAddResult.Errors)
                    {
                        ModelState.AddModelError(
                            "",
                            error.Description
                        );
                    }

                    await LoadUserMasterEditDropdowns(model);

                    return View(model);
                }
            }


            // =========================================================
            // UPDATE COMPANY ACCESS
            // =========================================================

            var companyAccess =
                await _masterContext.UserCompanyAccesses
                    .FirstOrDefaultAsync(x =>
                        x.UserId == user.Id);


            if (companyAccess == null)
            {
                companyAccess = new UserCompanyAccess
                {
                    UserId = user.Id,
                    CompanyId = model.CompanyId,
                    IsDefault = true
                };

                _masterContext.UserCompanyAccesses.Add(
                    companyAccess
                );
            }
            else
            {
                companyAccess.CompanyId =
                    model.CompanyId;

                companyAccess.IsDefault = true;
            }


            // =========================================================
            // UPDATE EMPLOYEE BRANCH
            // =========================================================

            if (model.BranchId.HasValue)
            {
                employee.BranchId = model.BranchId.Value;
            }
            // =========================================================
            // SAVE EMPLOYEE DATABASE
            // =========================================================

            await _context.SaveChangesAsync();




            // =========================================================
            // SAVE MASTER DATABASE
            // =========================================================

            await _masterContext.SaveChangesAsync();


            // =========================================================
            // SUCCESS
            // =========================================================

            TempData["Success"] =
                $"User account for {employee.FirstName} {employee.LastName} was updated successfully.";

            return RedirectToAction(nameof(Index));
        }
        private async Task LoadUserMasterEditDropdowns(
    UserMasterEditViewModel model)
        {
            // =========================================================
            // ROLES
            // =========================================================

            model.Roles =
                await _roleManager.Roles
                    .AsNoTracking()
                    .OrderBy(x => x.Name)
                    .Select(x => new SelectListItem
                    {
                        Value = x.Name!,
                        Text = x.Name!,
                        Selected = x.Name == model.Role
                    })
                    .ToListAsync();


            // =========================================================
            // COMPANIES
            // =========================================================

            model.Companies =
                await _masterContext.Companies
                    .AsNoTracking()
                    .OrderBy(x => x.CompanyName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.CompanyId.ToString(),
                        Text = x.CompanyName,
                        Selected =
                            x.CompanyId == model.CompanyId
                    })
                    .ToListAsync();


            // =========================================================
            // BRANCHES
            // =========================================================

            if (model.CompanyId > 0)
            {
                model.Branches =
                    await _context.Branches
                        .AsNoTracking()
                        .Where(x =>
                            x.IsActive &&
                            x.CompanyId == model.CompanyId)
                        .OrderBy(x => x.BranchName)
                        .Select(x => new SelectListItem
                        {
                            Value = x.BranchId.ToString(),
                            Text = x.BranchName,
                            Selected =
                                x.BranchId == model.BranchId
                        })
                        .ToListAsync();
            }
            else
            {
                model.Branches =
                    new List<SelectListItem>();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            user.IsActive = !user.IsActive;
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                TempData["Error"] = string.Join(" ", result.Errors.Select(x => x.Description));
            }
            else
            {
                TempData["Success"] = user.IsActive ? "User activated." : "User deactivated.";
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task LoadCreateListsAsync(int? selectedCompanyId = null)
        {
            var currentCompanyId = GetCurrentCompanyId();

            var employees = _context.Employees
                .AsNoTracking()
                .Where(x => x.IsActive && x.CompanyId == currentCompanyId && string.IsNullOrEmpty(x.UserId))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new
                {
                    x.EmployeeId,
                    x.EmployeeCode,
                    x.FirstName,
                    x.LastName,
                    x.OfficialEmail
                })
                .ToList();

            ViewBag.EmployeeList = employees.Select(x => new SelectListItem
            {
                Value = x.EmployeeId.ToString(),
                Text = $"{x.EmployeeCode} - {x.FirstName} {x.LastName} ({x.OfficialEmail ?? "No email"})"
            }).ToList();

            var companies = await _masterContext.Companies
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.CompanyName)
                .ToListAsync();

            ViewBag.CompanyList = companies.Select(x => new SelectListItem
            {
                Value = x.CompanyId.ToString(),
                Text = x.CompanyName,
                Selected = selectedCompanyId.HasValue
                    ? selectedCompanyId.Value == x.CompanyId
                    : currentCompanyId.HasValue && currentCompanyId.Value == x.CompanyId
            }).ToList();

            await LoadRolesAsync();
        }

        private async Task LoadEditListsAsync()
        {
            var companies = await _masterContext.Companies
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.CompanyName)
                .ToListAsync();

            ViewBag.CompanyList = companies.Select(x => new SelectListItem
            {
                Value = x.CompanyId.ToString(),
                Text = x.CompanyName
            }).ToList();

            await LoadRolesAsync();
        }

        private async Task LoadRolesAsync()
        {
            ViewBag.RoleList = await _roleManager.Roles
                .Where(x => x.Name != null)
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Value = x.Name!,
                    Text = x.Name!
                })
                .ToListAsync();
        }

        private void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
    }
}
