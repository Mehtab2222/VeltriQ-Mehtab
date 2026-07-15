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
                    x.IsConverted);

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
                    EmployeeId = x.EmployeeId,
                    OnboardingCandidateId = x.OnboardingCandidateId,

                    CandidateCode = x.OnboardingCandidate.CandidateCode,

                    CandidateName = x.OnboardingCandidate.FullName,

                    Department = x.OnboardingCandidate.Department.DepartmentName,

                    Designation = x.OnboardingCandidate.Designation.DesignationName,

                    TemplateName = x.OnboardingTemplate.TemplateName,

                    ApprovedOn = x.ApprovedOn,

                    ConversionStatus =
                    x.IsConverted
                        ? "Converted"
                        : "Pending Conversion",

                    IsConverted = x.IsConverted
                })

                .ToListAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Convert([FromBody] ConvertEmployeeRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
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

                var employee = new Employee
                {
                    EmployeeCode = employeeCode,
                    FirstName = personal.FirstName,
                    LastName = personal.LastName,
                    OfficialEmail = personal.Email,
                    PhoneNumber = personal.MobileNumber,
                    BranchId = onboarding.OnboardingCandidate.BranchId.Value,
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

                //====================================================
                // COPY ADDRESSES
                //====================================================

                foreach (var item in addresses)
                {
                    // CURRENT ADDRESS
                    if (!string.IsNullOrWhiteSpace(item.CurrentAddressLine1))
                    {
                        _context.EmployeeAddresses.Add(new EmployeeAddress
                        {
                            EmployeeId = employee.EmployeeId,
                            AddressType = "Current",
                            AddressLine1 = item.CurrentAddressLine1,
                            AddressLine2 = item.CurrentAddressLine2,
                            Landmark = item.CurrentLandmark,
                            PostalCode = item.CurrentPincode,
                            IsPrimary = true,
                            IsSameAsPermanentAddress = item.IsPermanentAddressSame,
                            IsActive = true,
                            CreatedOn = DateTime.Now
                        });
                    }

                    // PERMANENT ADDRESS
                    if (!item.IsPermanentAddressSame &&
                        !string.IsNullOrWhiteSpace(item.PermanentAddressLine1))
                    {
                        _context.EmployeeAddresses.Add(new EmployeeAddress
                        {
                            EmployeeId = employee.EmployeeId,
                            AddressType = "Permanent",
                            AddressLine1 = item.PermanentAddressLine1,
                            AddressLine2 = item.PermanentAddressLine2,
                            Landmark = item.PermanentLandmark,
                            PostalCode = item.PermanentPincode,
                            IsPrimary = false,
                            IsSameAsPermanentAddress = false,
                            IsActive = true,
                            CreatedOn = DateTime.Now
                        });
                    }
                }

                await _context.SaveChangesAsync();

                //====================================================
                // COPY EMERGENCY CONTACTS
                //====================================================

                foreach (var item in emergencyContacts)
                {
                    var emergencyContact = new EmployeeEmergencyContact
                    {
                        EmployeeId = employee.EmployeeId,
                        ContactName = item.ContactPersonName ?? string.Empty,
                        Relationship = item.Relationship ?? string.Empty,
                        MobileNumber = item.MobileNumber ?? string.Empty,
                        AlternateMobileNumber = item.AlternateMobileNumber,
                        AddressLine1 = item.Address,
                        EmailAddress = null,
                        AddressLine2 = null,
                        Landmark = null,
                        CountryId = null,
                        StateId = null,
                        CityId = null,
                        PostalCode = null,
                        Occupation = null,
                        LivesWithEmployee = false,
                        IsPrimaryContact = true,
                        PriorityOrder = 1,
                        IsAuthorizedToReceiveInformation = true,
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        CreatedBy = item.CreatedBy
                    };

                    _context.EmployeeEmergencyContacts.Add(emergencyContact);
                }

                await _context.SaveChangesAsync();

                //====================================================
                // COPY DEPENDENTS
                //====================================================

                foreach (var item in dependents)
                {
                    string firstName = "";
                    string lastName = "";

                    if (!string.IsNullOrWhiteSpace(item.FullName))
                    {
                        var parts = item.FullName.Split(' ', 2);
                        firstName = parts[0];
                        lastName = parts.Length > 1 ? parts[1] : "";
                    }

                    var dependent = new EmployeeDependent
                    {
                        EmployeeId = employee.EmployeeId,
                        FirstName = firstName,
                        LastName = lastName,
                        Relationship = item.Relationship ?? string.Empty,
                        DateOfBirth = item.DateOfBirth,
                        IsNominee = item.IsNominee,
                        MiddleName = null,
                        Gender = null,
                        Occupation = null,
                        IsDependent = true,
                        NomineePercentage = null,
                        IsCoveredByInsurance = false,
                        MobileNumber = null,
                        EmailAddress = null,
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        CreatedBy = item.CreatedBy
                    };

                    _context.EmployeeDependents.Add(dependent);
                }

                await _context.SaveChangesAsync();

                //====================================================
                // COPY QUALIFICATIONS
                //====================================================

                foreach (var item in qualifications)
                {
                    if (!int.TryParse(item.QualificationName, out int qualificationId))
                        continue;

                    var qualification = new EmployeeQualification
                    {
                        EmployeeId = employee.EmployeeId,
                        QualificationMasterId = qualificationId,
                        InstituteName = item.Institute ?? string.Empty,
                        PassingYear = item.PassingYear,
                        Percentage = item.Percentage,
                        QualificationSpecializationMasterId = null,
                        BoardOrUniversity = null,
                        SpecializationDescription = null,
                        CGPA = null,
                        Grade = null,
                        RegistrationNumber = null,
                        CertificateNumber = null,
                        IssueDate = null,
                        ExpiryDate = null,
                        AttachmentFileName = null,
                        AttachmentFilePath = null,
                        IsHighestQualification = false,
                        IsVerified = false,
                        VerifiedOn = null,
                        VerifiedBy = null,
                        Remarks = null,
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        CreatedBy = item.CreatedBy
                    };

                    _context.EmployeeQualifications.Add(qualification);
                }

                await _context.SaveChangesAsync();

                //====================================================
                // COPY DOCUMENTS
                //====================================================

                foreach (var item in documents)
                {
                    var onboardingMaster = await _context.OnboardingDocumentMasters
                        .FirstOrDefaultAsync(x =>
                            x.OnboardingDocumentMasterId == item.OnboardingDocumentMasterId);

                    if (onboardingMaster == null)
                        continue;

                    var employeeMaster = await _context.DocumentMasters
                        .FirstOrDefaultAsync(x =>
                            x.DocumentCode == onboardingMaster.DocumentCode);

                    if (employeeMaster == null)
                        continue;

                    var employeeDocument = new EmployeeDocument
                    {
                        EmployeeId = employee.EmployeeId,
                        DocumentMasterId = employeeMaster.DocumentMasterId,
                        DocumentNumber = null,
                        FileName = item.FileName,
                        FilePath = item.FilePath,
                        IssueDate = null,
                        ExpiryDate = item.ExpiryDate,
                        VerificationStatus = item.IsVerified ? "Verified" : "Pending",
                        Remarks = item.Remarks,
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        CreatedBy = null
                    };

                    _context.EmployeeDocuments.Add(employeeDocument);
                }

                await _context.SaveChangesAsync();

                //====================================================
                // MARK AS CONVERTED
                //====================================================

                onboarding.IsConverted = true;
                onboarding.EmployeeId = employee.EmployeeId;
                onboarding.ConvertedOn = DateTime.Now;
                onboarding.ConvertedBy = HttpContext.Session.GetString("EmployeeId");

                await _context.SaveChangesAsync();

                //====================================================
                // COMMIT TRANSACTION
                //====================================================

                await transaction.CommitAsync();

                return Json(new
                {
                    success = true,
                    message = $"Employee Created Successfully. EmployeeId = {employee.EmployeeId}"
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                return Json(new
                {
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
        
    }
}