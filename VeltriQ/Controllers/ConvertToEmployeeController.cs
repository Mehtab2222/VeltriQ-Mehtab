using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.ViewModels.ConvertToEmployee;
using VeltriQ.ViewModels.ConvertToEmployee.Requests;

namespace VeltriQ.Controllers
{
    public class ConvertToEmployeeController : BaseController
    {
        private readonly TenantDbContext _context;

        public ConvertToEmployeeController(
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager)
            : base(context, masterContext, userManager)
        {
            _context = context;
        }

        //====================================================
        // INDEX
        //====================================================

        public async Task<IActionResult> Index()
        {
            var model = new ConvertToEmployeeIndexViewModel();

            //====================================================
            // DASHBOARD
            //====================================================

            model.TotalApproved = await _context.EmployeeOnboardings
                .CountAsync(x =>
                    x.IsActive &&
                    x.OnboardingStatus.StatusCode == "APPROVED");

            model.Converted = await _context.EmployeeOnboardings
                .CountAsync(x =>
                    x.IsActive &&
                    x.OnboardingStatus.StatusCode == "CONVERTED");

            model.PendingConversion =
                model.TotalApproved - model.Converted;

            model.ApprovedToday = await _context.EmployeeOnboardings
                .CountAsync(x =>
                    x.IsActive &&
                    x.OnboardingStatus.StatusCode == "APPROVED" &&
                    x.ApprovedOn.HasValue &&
                    x.ApprovedOn.Value.Date == DateTime.Today);

            //====================================================
            // DEPARTMENT DROPDOWN
            //====================================================

            model.Departments = await _context.Departments
                .Where(x => x.IsActive)
                .OrderBy(x => x.DepartmentName)
                .Select(x => new SelectListItem
                {
                    Value = x.DepartmentId.ToString(),
                    Text = x.DepartmentName
                })
                .ToListAsync();

            model.Departments.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "All Departments"
            });

            //====================================================
            // CONVERSION STATUS
            //====================================================

            model.ConversionStatuses.Add(new SelectListItem
            {
                Value = "",
                Text = "All"
            });

            model.ConversionStatuses.Add(new SelectListItem
            {
                Value = "Pending",
                Text = "Pending Conversion"
            });

            model.ConversionStatuses.Add(new SelectListItem
            {
                Value = "Converted",
                Text = "Converted"
            });

            //====================================================
            // MANPOWER REQUEST
            //====================================================

            model.ManpowerRequests.Add(new SelectListItem
            {
                Value = "",
                Text = "All Requests"
            });

            // We'll load actual Manpower Requests later.

            //====================================================
            // GRID
            //====================================================

            model.Items = await _context.EmployeeOnboardings

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.Department)

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.Designation)

                .Include(x => x.OnboardingTemplate)

                .Include(x => x.OnboardingStatus)

                .Where(x =>
                    x.IsActive &&
                    (
                        x.OnboardingStatus.StatusCode == "APPROVED" ||
                        x.OnboardingStatus.StatusCode == "CONVERTED"
                    ))

                .OrderByDescending(x => x.ApprovedOn)

                .Select(x => new ConvertToEmployeeListItemViewModel
                {
                    EmployeeOnboardingId = x.EmployeeOnboardingId,

                    OnboardingCandidateId = x.OnboardingCandidateId,

                    CandidateCode = x.OnboardingCandidate.CandidateCode,

                    CandidateName = x.OnboardingCandidate.FullName,

                    Department = x.OnboardingCandidate.Department.DepartmentName,

                    Designation = x.OnboardingCandidate.Designation.DesignationName,

                    TemplateName = x.OnboardingTemplate.TemplateName,

                    ApprovedOn = x.ApprovedOn,

                    ConversionStatus =
                        x.OnboardingStatus.StatusCode == "CONVERTED"
                        ? "Converted"
                        : "Pending Conversion",

                    IsConverted =
                        x.OnboardingStatus.StatusCode == "CONVERTED"
                })

                .ToListAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Convert(
     [FromBody] ConvertEmployeeRequest request)
        {
            //====================================================
            // LOAD ONBOARDING
            //====================================================

            var onboarding = await _context.EmployeeOnboardings

                .Include(x => x.OnboardingCandidate)

                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == request.EmployeeOnboardingId);

            if (onboarding == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Onboarding record not found."
                });
            }

            //====================================================
            // LOAD PERSONAL INFORMATION
            //====================================================

            var personal = await _context.EmployeeOnboardingPersonalInformations

                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == onboarding.EmployeeOnboardingId &&
                    x.IsActive);

            if (personal == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Personal Information not found."
                });
            }
            //====================================================
            // LOAD ADDRESS
            //====================================================

            var addresses = await _context.EmployeeOnboardingAddresses

                .Where(x =>
                    x.EmployeeOnboardingId == onboarding.EmployeeOnboardingId &&
                    x.IsActive)

                .ToListAsync();
            //====================================================
            // LOAD EMERGENCY CONTACTS
            //====================================================

            var emergencyContacts = await _context.EmployeeOnboardingEmergencyContacts

                .Where(x =>
                    x.EmployeeOnboardingId == onboarding.EmployeeOnboardingId &&
                    x.IsActive)

                .ToListAsync();
            //====================================================
            // LOAD DEPENDENTS
            //====================================================

            var dependents = await _context.EmployeeOnboardingDependents

                .Where(x =>
                    x.EmployeeOnboardingId == onboarding.EmployeeOnboardingId &&
                    x.IsActive)

                .ToListAsync();
            //====================================================
            // LOAD QUALIFICATIONS
            //====================================================

            var qualifications = await _context.EmployeeOnboardingQualifications

                .Where(x =>
                    x.EmployeeOnboardingId == onboarding.EmployeeOnboardingId &&
                    x.IsActive)

                .ToListAsync();
            //====================================================
            // LOAD VERIFIED DOCUMENTS
            //====================================================

            var documents = await _context.EmployeeOnboardingDocuments

                .Where(x =>
                    x.EmployeeOnboardingId == onboarding.EmployeeOnboardingId &&
                    x.IsActive &&
                    x.IsVerified)

                .ToListAsync();
            //====================================================
            // GENERATE EMPLOYEE CODE
            //====================================================

            var lastEmployee = await _context.Employees
                .OrderByDescending(x => x.EmployeeId)
                .FirstOrDefaultAsync();

            string employeeCode;

            if (lastEmployee == null)
            {
                employeeCode = "EMP001";
            }
            else
            {
                int number = int.Parse(
                    lastEmployee.EmployeeCode.Replace("EMP", ""));

                employeeCode = $"EMP{(number + 1):D3}";
            }
            //====================================================
            // CREATE EMPLOYEE
            //====================================================

            //====================================================
            // CREATE EMPLOYEE
            //====================================================

            var employee = new Employee
            {
                EmployeeCode = employeeCode,

                FirstName = personal.FirstName,

                LastName = personal.LastName,

                OfficialEmail = personal.Email,

                PhoneNumber = personal.MobileNumber,

                DepartmentId = onboarding.OnboardingCandidate.DepartmentId,

                DesignationId = onboarding.OnboardingCandidate.DesignationId,

                JoiningDate = onboarding.OnboardingCandidate.ExpectedJoiningDate,

                EmploymentType = onboarding.OnboardingCandidate.EmploymentTypeMasterId.ToString(),

                EmployeeStatus = "Active",

                IsActive = true,

                Gender = personal.Gender,

                DateOfBirth = personal.DateOfBirth,

                MaritalStatus = personal.MaritalStatus,

                BloodGroup = personal.BloodGroup,

                ProfilePhotoPath = personal.ProfilePhotoPath,

                CreatedOn = DateTime.Now
            };

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();
            return Json(new
            {
                success = true,
                message = $"Employee Created Successfully. EmployeeId = {employee.EmployeeId}"
            });
        }
    }
}