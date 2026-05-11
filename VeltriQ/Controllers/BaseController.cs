using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VeltriQ.Models.Master;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly TenantDbContext
            _context;

        protected readonly MasterDbContext
            _masterContext;

        protected readonly UserManager<ApplicationUser>
            _userManager;

        public BaseController
        (
            TenantDbContext context,

            MasterDbContext masterContext,

            UserManager<ApplicationUser> userManager
        )
        {
            _context = context;

            _masterContext = masterContext;

            _userManager = userManager;
        }

        public override void OnActionExecuting
        (
            ActionExecutingContext context
        )
        {
            base.OnActionExecuting(context);

            // =========================
            // ACTIVE COMPANY SESSION
            // =========================

            var activeId =
                HttpContext.Session
                    .GetInt32("ActiveCompanyId");

            var activeName =
                HttpContext.Session
                    .GetString("ActiveCompanyName");

            ViewBag.ActiveCompanyId = activeId;

            ViewBag.ActiveCompanyName =
                string.IsNullOrEmpty(activeName)

                    ? "Select Company"

                    : activeName;

            // =========================
            // CURRENT LOGGED IN USER
            // =========================

            var userId =
                _userManager
                    .GetUserId(User);

            if (!string.IsNullOrEmpty(userId))
            {
                var employee =
                    _context.Employees
                        .FirstOrDefault(x =>
                            x.UserId == userId);
                if (employee == null)
                {
                    var companies =
                        (
                            from access in _masterContext.UserCompanyAccesses

                            join comp in _masterContext.Companies
                            on access.CompanyId equals comp.CompanyId

                            where access.UserId == userId

                            select comp
                        )

                        .ToList();

                    ViewBag.Companies = companies;

                    ViewBag.CurrentCompanyId = activeId;

                    ViewBag.CurrentCompanyName =
                        activeName ?? "Select Company";

                    return;
                }

                else
                {
                    ViewBag.CurrentEmployee =
                        employee;

                    ViewBag.CurrentEmployeeName =
                        employee.FirstName
                        + " "
                        + employee.LastName;

                    ViewBag.CurrentEmployeeCode =
                        employee.EmployeeCode;

                    ViewBag.CurrentCompanyId =
                        activeId ?? employee.CompanyId;

                    // =========================
                    // DESIGNATION
                    // =========================

                    var designation =
                        _context.Designations
                            .FirstOrDefault(x =>
                                x.DesignationId ==
                                employee.DesignationId);

                    if (designation != null)
                    {
                        ViewBag.CurrentDesignation =
                            designation.DesignationName;
                    }

                    // =========================
                    // CURRENT COMPANY
                    // =========================

                    var company =
                        _masterContext.Companies
                            .FirstOrDefault(x =>
                                x.CompanyId ==
                                employee.CompanyId);

                    // SESSION COMPANY HAS PRIORITY
                    if (!string.IsNullOrEmpty(activeName))
                    {
                        ViewBag.CurrentCompanyName = activeName;
                    }
                    else if (company != null)
                    {
                        ViewBag.CurrentCompanyName =
                            company.CompanyName;
                    }

                    // =========================
                    // COMPANY ACCESS DROPDOWN
                    // =========================

                    var companies2 =
                        (
                            from access in _masterContext.UserCompanyAccesses

                            join comp in _masterContext.Companies
                            on access.CompanyId equals comp.CompanyId

                            where access.UserId == userId

                            select comp
                        )

                        .ToList();

                    ViewBag.Companies =
                        companies2;
                }
            }
        }
    }
}