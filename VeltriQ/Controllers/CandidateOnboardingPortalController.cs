using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.HR.Onboarding;
using VeltriQ.ViewModels.CandidateOnboardingPortal;
using VeltriQ.ViewModels.EmployeeOnboarding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace VeltriQ.Controllers
{
    public class CandidateOnboardingPortalController
        : CandidateOnboardingBaseController
    {
        private readonly IWebHostEnvironment _environment;

        public CandidateOnboardingPortalController
        (
            TenantDbContext context,
            IWebHostEnvironment environment
        )
            : base(context)
        {
            _environment = environment;
        }
        public IActionResult DevLogin()
        {
            HttpContext.Session.SetInt32("EmployeeOnboardingId", 5);

            return RedirectToAction(nameof(Index));
        }
        private int? GetCurrentEmployeeOnboardingId()
        {
            return HttpContext.Session.GetInt32("EmployeeOnboardingId");
        }
        private async Task<CandidateOnboardingPersonalInformationViewModel> LoadPersonalInformation(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingPersonalInformationViewModel();

            var entity = await _context.EmployeeOnboardingPersonalInformations
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (entity == null)
            {
                model.EmployeeOnboardingId = employeeOnboardingId;
                return model;
            }

            model.EmployeeOnboardingPersonalInformationId = entity.EmployeeOnboardingPersonalInformationId;
            model.EmployeeOnboardingId = entity.EmployeeOnboardingId;

            model.FirstName = entity.FirstName;
            model.MiddleName = entity.MiddleName;
            model.LastName = entity.LastName;

            model.DateOfBirth = entity.DateOfBirth;

            model.Gender = entity.Gender;
            model.MaritalStatus = entity.MaritalStatus;
            model.BloodGroup = entity.BloodGroup;
            model.Nationality = entity.Nationality;
            model.Religion = entity.Religion;

            model.FatherName = entity.FatherName;
            model.MotherName = entity.MotherName;

            model.Email = entity.Email;
            model.MobileNumber = entity.MobileNumber;
            model.AlternateMobileNumber = entity.AlternateMobileNumber;

            model.ProfilePhotoPath = entity.ProfilePhotoPath;

            return model;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavePersonalInformation(CandidateOnboardingPersonalInformationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please correct the validation errors."
                });
            }

            var entity = await _context.EmployeeOnboardingPersonalInformations
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == model.EmployeeOnboardingId &&
                    x.IsActive);

            if (entity == null)
            {
                entity = new EmployeeOnboardingPersonalInformation
                {
                    EmployeeOnboardingId = model.EmployeeOnboardingId,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                _context.EmployeeOnboardingPersonalInformations.Add(entity);
            }

            //====================================================
            // BASIC INFORMATION
            //====================================================

            entity.FirstName = model.FirstName;
            entity.MiddleName = model.MiddleName;
            entity.LastName = model.LastName;
            entity.DateOfBirth = model.DateOfBirth;

            //====================================================
            // PERSONAL DETAILS
            //====================================================

            entity.Gender = model.Gender;
            entity.MaritalStatus = model.MaritalStatus;
            entity.BloodGroup = model.BloodGroup;
            entity.Nationality = model.Nationality;
            entity.Religion = model.Religion;

            //====================================================
            // FAMILY DETAILS
            //====================================================

            entity.FatherName = model.FatherName;
            entity.MotherName = model.MotherName;

            //====================================================
            // CONTACT DETAILS
            //====================================================

            entity.Email = model.Email;
            entity.MobileNumber = model.MobileNumber;
            entity.AlternateMobileNumber = model.AlternateMobileNumber;

            //====================================================
            // PROFILE
            //====================================================

            entity.ProfilePhotoPath = model.ProfilePhotoPath;

            entity.ModifiedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            //====================================================
            // UPDATE COMPLETION PERCENTAGE
            //====================================================

            await UpdateCompletionPercentage(model.EmployeeOnboardingId);

            return Json(new
            {
                success = true,
                message = "Personal Information saved successfully."
            });
        }
        private async Task<CandidateOnboardingAddressViewModel> LoadAddress(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingAddressViewModel
            {
                EmployeeOnboardingId = employeeOnboardingId
            };

            var entity = await _context.EmployeeOnboardingAddresses
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (entity == null)
                return model;

            model.EmployeeOnboardingAddressId = entity.EmployeeOnboardingAddressId;

            //====================================================
            // CURRENT ADDRESS
            //====================================================

            model.CurrentAddressLine1 = entity.CurrentAddressLine1;
            model.CurrentAddressLine2 = entity.CurrentAddressLine2;
            model.CurrentLandmark = entity.CurrentLandmark;
            model.CurrentCity = entity.CurrentCity;
            model.CurrentState = entity.CurrentState;
            model.CurrentCountry = entity.CurrentCountry;
            model.CurrentPostalCode = entity.CurrentPincode;

            //====================================================
            // PERMANENT ADDRESS
            //====================================================

            model.IsPermanentAddressSame = entity.IsPermanentAddressSame;

            model.PermanentAddressLine1 = entity.PermanentAddressLine1;
            model.PermanentAddressLine2 = entity.PermanentAddressLine2;
            model.PermanentLandmark = entity.PermanentLandmark;
            model.PermanentCity = entity.PermanentCity;
            model.PermanentState = entity.PermanentState;
            model.PermanentCountry = entity.PermanentCountry;
            model.PermanentPostalCode = entity.PermanentPincode;

            return model;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAddress(CandidateOnboardingAddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please correct the validation errors."
                });
            }

            var entity = await _context.EmployeeOnboardingAddresses
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == model.EmployeeOnboardingId &&
                    x.IsActive);

            if (entity == null)
            {
                entity = new EmployeeOnboardingAddress
                {
                    EmployeeOnboardingId = model.EmployeeOnboardingId,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                _context.EmployeeOnboardingAddresses.Add(entity);
            }

            //====================================================
            // CURRENT ADDRESS
            //====================================================

            entity.CurrentAddressLine1 = model.CurrentAddressLine1;
            entity.CurrentAddressLine2 = model.CurrentAddressLine2;
            entity.CurrentLandmark = model.CurrentLandmark;
            entity.CurrentCity = model.CurrentCity;
            entity.CurrentState = model.CurrentState;
            entity.CurrentCountry = model.CurrentCountry;
            entity.CurrentPincode = model.CurrentPostalCode;

            //====================================================
            // PERMANENT ADDRESS
            //====================================================

            entity.IsPermanentAddressSame = model.IsPermanentAddressSame;

            if (model.IsPermanentAddressSame)
            {
                entity.PermanentAddressLine1 = model.CurrentAddressLine1;
                entity.PermanentAddressLine2 = model.CurrentAddressLine2;
                entity.PermanentLandmark = model.CurrentLandmark;
                entity.PermanentCity = model.CurrentCity;
                entity.PermanentState = model.CurrentState;
                entity.PermanentCountry = model.CurrentCountry;
                entity.PermanentPincode = model.CurrentPostalCode;
            }
            else
            {
                entity.PermanentAddressLine1 = model.PermanentAddressLine1;
                entity.PermanentAddressLine2 = model.PermanentAddressLine2;
                entity.PermanentLandmark = model.PermanentLandmark;
                entity.PermanentCity = model.PermanentCity;
                entity.PermanentState = model.PermanentState;
                entity.PermanentCountry = model.PermanentCountry;
                entity.PermanentPincode = model.PermanentPostalCode;
            }

            entity.ModifiedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            //====================================================
            // UPDATE COMPLETION PERCENTAGE
            //====================================================

            await UpdateCompletionPercentage(model.EmployeeOnboardingId);

            return Json(new
            {
                success = true,
                message = "Address saved successfully."
            });
        }
        private async Task<CandidateOnboardingEmergencyContactViewModel> LoadEmergencyContact(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingEmergencyContactViewModel
            {
                EmployeeOnboardingId = employeeOnboardingId
            };

            var entity = await _context.EmployeeOnboardingEmergencyContacts
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (entity == null)
                return model;

            model.EmployeeOnboardingEmergencyContactId = entity.EmployeeOnboardingEmergencyContactId;
            model.ContactPersonName = entity.ContactPersonName;
            model.Relationship = entity.Relationship;
            model.MobileNumber = entity.MobileNumber;
            model.AlternateMobileNumber = entity.AlternateMobileNumber;
            model.Address = entity.Address;

            return model;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveEmergencyContact(
              CandidateOnboardingEmergencyContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please correct the validation errors."
                });
            }

            var entity = await _context.EmployeeOnboardingEmergencyContacts
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == model.EmployeeOnboardingId &&
                    x.IsActive);

            if (entity == null)
            {
                entity = new EmployeeOnboardingEmergencyContact
                {
                    EmployeeOnboardingId = model.EmployeeOnboardingId,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                _context.EmployeeOnboardingEmergencyContacts.Add(entity);
            }

            entity.ContactPersonName = model.ContactPersonName;
            entity.Relationship = model.Relationship;
            entity.MobileNumber = model.MobileNumber;
            entity.AlternateMobileNumber = model.AlternateMobileNumber;
            entity.Address = model.Address;
            entity.ModifiedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            //====================================================
            // UPDATE COMPLETION PERCENTAGE
            //====================================================

            await UpdateCompletionPercentage(model.EmployeeOnboardingId);

            return Json(new
            {
                success = true,
                message = "Emergency Contact saved successfully."
            });
        }
        private async Task<CandidateOnboardingDependentsViewModel> LoadDependents(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingDependentsViewModel
            {
                EmployeeOnboardingId = employeeOnboardingId
            };

            model.Dependents = await _context.EmployeeOnboardingDependents
                .Where(x => x.EmployeeOnboardingId == employeeOnboardingId && x.IsActive)
                .OrderBy(x => x.EmployeeOnboardingDependentId)
                .Select(x => new DependentViewModel
                {
                    EmployeeOnboardingDependentId = x.EmployeeOnboardingDependentId,
                    FullName = x.FullName,
                    Relationship = x.Relationship,
                    DateOfBirth = x.DateOfBirth,
                    IsNominee = x.IsNominee
                })
                .ToListAsync();

            return model;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveDependent(CandidateOnboardingDependentsViewModel model)
        {
            if (model.Dependents == null || !model.Dependents.Any())
            {
                return Json(new
                {
                    success = false,
                    message = "No dependent received."
                });
            }

            var item = model.Dependents.First();

            EmployeeOnboardingDependent entity;

            if (item.EmployeeOnboardingDependentId == 0)
            {
                entity = new EmployeeOnboardingDependent
                {
                    EmployeeOnboardingId = model.EmployeeOnboardingId,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                _context.EmployeeOnboardingDependents.Add(entity);
            }
            else
            {
                entity = await _context.EmployeeOnboardingDependents
                    .FirstAsync(x => x.EmployeeOnboardingDependentId == item.EmployeeOnboardingDependentId);

                entity.ModifiedOn = DateTime.Now;
            }

            entity.FullName = item.FullName;
            entity.Relationship = item.Relationship;
            entity.DateOfBirth = item.DateOfBirth;
            entity.IsNominee = item.IsNominee;

            await _context.SaveChangesAsync();

            //====================================================
            // UPDATE COMPLETION PERCENTAGE
            //====================================================

            await UpdateCompletionPercentage(model.EmployeeOnboardingId);

            return Json(new
            {
                success = true,
                message = "Dependent saved successfully."
            });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDependent(int id)
        {
            var entity = await _context.EmployeeOnboardingDependents
                .FirstOrDefaultAsync(x => x.EmployeeOnboardingDependentId == id);

            if (entity == null)
            {
                return Json(new
                {
                    success = false
                });
            }

            entity.IsActive = false;
            entity.ModifiedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true
            });
        }
        private async Task<CandidateOnboardingQualificationsViewModel> LoadQualifications(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingQualificationsViewModel
            {
                EmployeeOnboardingId = employeeOnboardingId
            };

            model.Qualifications = await _context.EmployeeOnboardingQualifications
                .Where(x => x.EmployeeOnboardingId == employeeOnboardingId && x.IsActive)
                .OrderBy(x => x.EmployeeOnboardingQualificationId)
                .Select(x => new QualificationViewModel
                {
                    EmployeeOnboardingQualificationId = x.EmployeeOnboardingQualificationId,
                    QualificationName = x.QualificationName,
                    Institute = x.Institute,
                    PassingYear = x.PassingYear,
                    Percentage = x.Percentage
                })
                .ToListAsync();

            return model;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveQualifications(CandidateOnboardingQualificationsViewModel model)
        {
            if (model.Qualifications == null || !model.Qualifications.Any())
            {
                return Json(new
                {
                    success = false,
                    message = "No qualification received."
                });
            }

            var item = model.Qualifications.First();

            EmployeeOnboardingQualification entity;

            if (item.EmployeeOnboardingQualificationId == 0)
            {
                entity = new EmployeeOnboardingQualification
                {
                    EmployeeOnboardingId = model.EmployeeOnboardingId,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                _context.EmployeeOnboardingQualifications.Add(entity);
            }
            else
            {
                entity = await _context.EmployeeOnboardingQualifications
                    .FirstAsync(x => x.EmployeeOnboardingQualificationId == item.EmployeeOnboardingQualificationId);

                entity.ModifiedOn = DateTime.Now;
            }

            entity.QualificationName = item.QualificationName;
            entity.Institute = item.Institute;
            entity.PassingYear = item.PassingYear;
            entity.Percentage = item.Percentage;

            await _context.SaveChangesAsync();

            //====================================================
            // UPDATE COMPLETION PERCENTAGE
            //====================================================

            await UpdateCompletionPercentage(model.EmployeeOnboardingId);

            return Json(new
            {
                success = true,
                message = "Qualification saved successfully."
            });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteQualification(int id)
        {
            var entity = await _context.EmployeeOnboardingQualifications
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingQualificationId == id);

            if (entity == null)
            {
                return Json(new
                {
                    success = false
                });
            }

            entity.IsActive = false;
            entity.ModifiedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true
            });
        }
        
        [HttpGet]
        public async Task<IActionResult> LoadInformationSection(string section)
        {
            var employeeOnboardingId =
                HttpContext.Session.GetInt32("EmployeeOnboardingId");

            if (employeeOnboardingId == null)
                return Content("Session expired.");

            switch (section)
            {
                case "Personal Information":
                    return PartialView(
                        "Information/_PersonalInformation",
                        await LoadPersonalInformation(employeeOnboardingId.Value));

                case "Address":
                    return PartialView(
                        "Information/_Address",
                        await LoadAddress(employeeOnboardingId.Value));

                case "Emergency Contact":
                    return PartialView(
                        "Information/_EmergencyContact",
                        await LoadEmergencyContact(employeeOnboardingId.Value));

                case "Dependents":
                    return PartialView(
                        "Information/_Dependents",
                        await LoadDependents(employeeOnboardingId.Value));

                case "Qualifications":
                    return PartialView(
                        "Information/_Qualifications",
                        await LoadQualifications(employeeOnboardingId.Value));


                default:
                    return Content("Section not found.");
            }
        }
        private void MapPersonalInformationToEntity(
    CandidateOnboardingPersonalInformationViewModel model,
    EmployeeOnboardingPersonalInformation entity)
        {
            entity.FirstName = model.FirstName;
            entity.MiddleName = model.MiddleName;
            entity.LastName = model.LastName;

            entity.DateOfBirth = model.DateOfBirth;

            entity.Gender = model.Gender;
            entity.MaritalStatus = model.MaritalStatus;
            entity.BloodGroup = model.BloodGroup;
            entity.Nationality = model.Nationality;
            entity.Religion = model.Religion;

            entity.FatherName = model.FatherName;
            entity.MotherName = model.MotherName;

            entity.Email = model.Email;
            entity.MobileNumber = model.MobileNumber;
            entity.AlternateMobileNumber = model.AlternateMobileNumber;
        }
        private async Task UpdateSectionCompletion(
    int employeeOnboardingId,
    string sectionName)
        {
            var section = await _context.EmployeeOnboardingSections

                .Include(x => x.Section)

                .FirstOrDefaultAsync(x =>

                    x.EmployeeOnboardingId == employeeOnboardingId &&

                    x.Section.SectionName == sectionName &&

                    x.IsActive);

            if (section == null)
                return;

            section.IsCompleted = true;

            section.CompletedOn = DateTime.Now;
        }
        private async Task UpdateOverallProgress(int employeeOnboardingId)
        {
            var onboarding = await _context.EmployeeOnboardings
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId);

            if (onboarding == null)
                return;

            var totalSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (totalSections == 0)
            {
                onboarding.CompletionPercentage = 0;
                return;
            }

            var completedSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsCompleted &&
                    x.IsActive);

            onboarding.CompletionPercentage =
                Math.Round((decimal)completedSections * 100 / totalSections, 2);
        }

        //============================================================
        // LOGIN
        //============================================================

        [HttpGet]
        public async Task<IActionResult> Login(string? token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return View("InvalidInvitation");
            }

            var invitation = await _context.OnboardingCandidateInvitations

                .Include(x => x.OnboardingCandidate)

                .Include(x => x.EmployeeOnboarding)

                .FirstOrDefaultAsync(x =>
                    x.InvitationToken == token);

            if (invitation == null)
            {
                return View("InvalidInvitation");
            }

            if (!invitation.IsActive)
            {
                return View("InvitationExpired");
            }

            if (!invitation.IsPortalAccessEnabled)
            {
                return View("InvitationExpired");
            }

            if (DateTime.Now > invitation.ExpiryDate)
            {
                return View("InvitationExpired");
            }

            //----------------------------------------------------
            // Create Candidate Session
            //----------------------------------------------------

            HttpContext.Session.SetInt32
            (
                "EmployeeOnboardingId",
                invitation.EmployeeOnboardingId
            );

            HttpContext.Session.SetInt32
            (
                "OnboardingCandidateId",
                invitation.OnboardingCandidateId
            );

            HttpContext.Session.SetInt32
            (
                "OnboardingCandidateInvitationId",
                invitation.OnboardingCandidateInvitationId
            );

            HttpContext.Session.SetString
            (
                "CandidateName",
                invitation.OnboardingCandidate?.FullName ?? ""
            );

            //----------------------------------------------------
            // First Login
            //----------------------------------------------------

            if (!invitation.IsInvitationAccepted)
            {
                invitation.IsInvitationAccepted = true;

                invitation.AcceptedOn = DateTime.Now;
            }

            invitation.LastLoginOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadDocument(
     int employeeOnboardingDocumentId,
     IFormFile documentFile)
        {
            if (documentFile == null || documentFile.Length == 0)
            {
                return Json(new
                {
                    success = false,
                    message = "Please select a document."
                });
            }

            var document = await _context.EmployeeOnboardingDocuments
                .Include(x => x.Document)
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingDocumentId == employeeOnboardingDocumentId &&
                    x.IsActive);

            if (document == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Document not found."
                });
            }

            // Validate file extension
            var extension = Path.GetExtension(documentFile.FileName)
                .TrimStart('.')
                .ToLower();

            var allowedExtensions = document.Document.AllowedFileTypes
                .Split(',')
                .Select(x => x.Trim().ToLower());

            if (!allowedExtensions.Contains(extension))
            {
                return Json(new
                {
                    success = false,
                    message = $"Allowed file types: {document.Document.AllowedFileTypes}"
                });
            }

            // Validate file size
            var maxBytes = document.Document.MaxFileSizeMB * 1024 * 1024;

            if (documentFile.Length > maxBytes)
            {
                return Json(new
                {
                    success = false,
                    message = $"Maximum file size is {document.Document.MaxFileSizeMB} MB."
                });
            }

            // Create Folder
            var folder = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                "onboarding",
                document.EmployeeOnboardingId.ToString());

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            // Generate unique filename
            var fileName =
                Guid.NewGuid().ToString() +
                Path.GetExtension(documentFile.FileName);

            var fullPath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await documentFile.CopyToAsync(stream);
            }

            // Update Database
            document.FileName = documentFile.FileName;

            document.FilePath =
                "/uploads/onboarding/" +
                document.EmployeeOnboardingId +
                "/" +
                fileName;

            document.IsUploaded = true;
            document.UploadedOn = DateTime.Now;
            document.ModifiedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            //====================================================
            // UPDATE COMPLETION PERCENTAGE
            //====================================================

            await UpdateCompletionPercentage(document.EmployeeOnboardingId);

            return Json(new
            {
                success = true,
                message = "Document uploaded successfully."
            });
        }
        [HttpGet]
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var document = await _context.EmployeeOnboardingDocuments
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingDocumentId == id &&
                    x.IsActive);

            if (document == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(document.FilePath))
            {
                return NotFound();
            }

            var fullPath = Path.Combine(
                _environment.WebRootPath,
                document.FilePath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));

            if (!System.IO.File.Exists(fullPath))
            {
                return NotFound();
            }

            var contentType = "application/octet-stream";

            return PhysicalFile(
                fullPath,
                contentType,
                document.FileName);
        }
        private async Task LoadInformationSidebar
(
    CandidateOnboardingIndexViewModel model,
    int employeeOnboardingId
)
        {
            model.Sections = await _context.EmployeeOnboardingSections

                .Where(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new CandidateOnboardingSectionViewModel
                {
                    EmployeeOnboardingSectionId = x.EmployeeOnboardingSectionId,

                    OnboardingSectionMasterId = x.OnboardingSectionMasterId,

                    SectionName = x.Section.SectionName,

                    IsMandatory = x.IsMandatory,

                    IsCompleted = x.IsCompleted,

                    DisplayOrder = x.DisplayOrder,

                    Icon = ""
                })

                .ToListAsync();
        }

        private async Task LoadDocuments(
            CandidateOnboardingIndexViewModel model,
            int employeeOnboardingId)
        {
            model.DocumentsList = await _context.EmployeeOnboardingDocuments
                .Where(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new EmployeeOnboardingDocumentViewModel
                {
                    EmployeeOnboardingDocumentId = x.EmployeeOnboardingDocumentId,

                    DocumentName = x.Document.DocumentName,

                    IsMandatory = x.IsMandatory,

                    IsUploaded = x.IsUploaded,

                    IsVerified = x.IsVerified,

                    UploadedOn = x.UploadedOn
                })
                .ToListAsync();
        }
        private async Task<CandidateOnboardingPoliciesViewModel> LoadPolicies(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingPoliciesViewModel
            {
                EmployeeOnboardingId = employeeOnboardingId
            };

            model.Policies = await _context.EmployeeOnboardingPolicies
                .Where(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new PolicyViewModel
                {
                    EmployeeOnboardingPolicyId = x.EmployeeOnboardingPolicyId,

                    PolicyName = x.Policy.PolicyName,

                    IsMandatory = x.IsMandatory,

                    IsAccepted = x.IsAccepted,

                    AcceptedOn = x.AcceptedOn,

                    AllowDownload = x.Policy.AllowDownload
                })
                .ToListAsync();

            return model;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptPolicy(int id)
        {
            var policy = await _context.EmployeeOnboardingPolicies
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingPolicyId == id &&
                    x.IsActive);

            if (policy == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Policy not found."
                });
            }

            policy.IsAccepted = true;
            policy.AcceptedOn = DateTime.Now;
            policy.ModifiedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            //====================================================
            // UPDATE COMPLETION PERCENTAGE
            //====================================================

            await UpdateCompletionPercentage(policy.EmployeeOnboardingId);

            return Json(new
            {
                success = true,
                message = "Policy accepted successfully."
            });
        }
        private async Task LoadOverview(
     CandidateOnboardingIndexViewModel model,
     int employeeOnboardingId)
        {
            //====================================================
            // UPDATE COMPLETION PERCENTAGE
            //====================================================

            await UpdateCompletionPercentage(employeeOnboardingId);

            //====================================================
            // LOAD COMPLETION PERCENTAGE
            //====================================================

            var onboarding = await _context.EmployeeOnboardings
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId);

            if (onboarding != null)
            {
                model.CompletionPercentage = onboarding.CompletionPercentage;
            }

            //====================================================
            // INFORMATION SECTIONS
            //====================================================

            model.TotalSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.CompletedSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsCompleted);

            //====================================================
            // DOCUMENTS
            //====================================================

            model.TotalDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.UploadedDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsUploaded);

            //====================================================
            // POLICIES
            //====================================================

            model.TotalPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.AcceptedPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsAccepted);
        }
        private async Task<decimal> CalculateCompletionPercentage(int employeeOnboardingId)
        {
            decimal completed = 0;

            //====================================================
            // PERSONAL INFORMATION (30%)
            //====================================================

            var personal = await _context.EmployeeOnboardingPersonalInformations
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (personal != null &&
                !string.IsNullOrWhiteSpace(personal.FirstName) &&
                !string.IsNullOrWhiteSpace(personal.LastName) &&
                personal.DateOfBirth != null &&
                !string.IsNullOrWhiteSpace(personal.Email) &&
                !string.IsNullOrWhiteSpace(personal.MobileNumber))
            {
                completed += 30;
            }

            //====================================================
            // ADDRESS (20%)
            //====================================================

            var address = await _context.EmployeeOnboardingAddresses
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (address != null &&
                !string.IsNullOrWhiteSpace(address.CurrentAddressLine1) &&
                !string.IsNullOrWhiteSpace(address.CurrentCity) &&
                !string.IsNullOrWhiteSpace(address.CurrentState) &&
                !string.IsNullOrWhiteSpace(address.CurrentCountry) &&
                !string.IsNullOrWhiteSpace(address.CurrentPincode))
            {
                completed += 20;
            }

            //====================================================
            // EMERGENCY CONTACT (10%)
            //====================================================

            var emergency = await _context.EmployeeOnboardingEmergencyContacts
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            if (emergency != null &&
                !string.IsNullOrWhiteSpace(emergency.ContactPersonName) &&
                !string.IsNullOrWhiteSpace(emergency.Relationship) &&
                !string.IsNullOrWhiteSpace(emergency.MobileNumber))
            {
                completed += 10;
            }

            //====================================================
            // MANDATORY DOCUMENTS (30%)
            //====================================================

            var totalDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsMandatory);

            var uploadedDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsMandatory &&
                    x.IsUploaded);

            if (totalDocuments > 0 &&
                totalDocuments == uploadedDocuments)
            {
                completed += 30;
            }

            //====================================================
            // MANDATORY POLICIES (10%)
            //====================================================

            var totalPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsMandatory);

            var acceptedPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsMandatory &&
                    x.IsAccepted);

            if (totalPolicies > 0 &&
                totalPolicies == acceptedPolicies)
            {
                completed += 10;
            }

            return completed;
        }
        private async Task UpdateCompletionPercentage(int employeeOnboardingId)
        {
            var percentage = await CalculateCompletionPercentage(employeeOnboardingId);

            var onboarding = await _context.EmployeeOnboardings
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId);

            if (onboarding != null)
            {
                onboarding.CompletionPercentage = percentage;
                onboarding.ModifiedOn = DateTime.Now;

                await _context.SaveChangesAsync();
            }
        }
       
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employeeOnboardingId =
                HttpContext.Session.GetInt32("EmployeeOnboardingId");

            if (employeeOnboardingId == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var model = new CandidateOnboardingIndexViewModel();

            await LoadHeader(model, employeeOnboardingId.Value);

            await LoadOverview(model, employeeOnboardingId.Value);

            await LoadInformationSidebar(model, employeeOnboardingId.Value);

            await LoadDocuments(model, employeeOnboardingId.Value);
            model.Policies = await LoadPolicies(employeeOnboardingId.Value);
 

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DownloadPolicy(int id)
        {
            var policy = await _context.EmployeeOnboardingPolicies
                .Include(x => x.Policy)
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingPolicyId == id &&
                    x.IsActive);

            if (policy == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(policy.Policy.FilePath))
            {
                return NotFound();
            }

            var fullPath = Path.Combine(
                _environment.WebRootPath,
                policy.Policy.FilePath
                    .TrimStart('/')
                    .Replace("/", Path.DirectorySeparatorChar.ToString()));

            if (!System.IO.File.Exists(fullPath))
            {
                return NotFound();
            }

            return PhysicalFile(
                fullPath,
                "application/octet-stream",
                policy.Policy.FileName);
        }
        private async Task LoadHeader
        (
            CandidateOnboardingIndexViewModel model,
            int employeeOnboardingId
        )
        {
            var onboarding = await _context.EmployeeOnboardings

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.Department)

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.Designation)

                .Include(x => x.OnboardingCandidate)
                    .ThenInclude(x => x.EmploymentType)

                .Include(x => x.OnboardingTemplate)

                .Include(x => x.OnboardingStatus)

                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId);

            if (onboarding == null)
                return;

            var candidate = onboarding.OnboardingCandidate;

            model.EmployeeOnboardingId = onboarding.EmployeeOnboardingId;

            model.OnboardingCandidateId = onboarding.OnboardingCandidateId;

            model.CandidateName = candidate?.FullName ?? "";

            model.CandidateCode = candidate?.CandidateCode ?? "";

            model.Email = candidate?.Email ?? "";

            model.MobileNumber = candidate?.MobileNumber ?? "";

            model.Department = candidate?.Department?.DepartmentName ?? "";

            model.Designation = candidate?.Designation?.DesignationName ?? "";

            model.EmploymentType = candidate?.EmploymentType?.EmploymentTypeName ?? "";

            model.TemplateName = onboarding.OnboardingTemplate?.TemplateName ?? "";

            model.Status = onboarding.OnboardingStatus?.StatusName ?? "";

            model.StatusName = onboarding.OnboardingStatus?.StatusName ?? "";

            model.StatusCode = onboarding.OnboardingStatus?.StatusCode ?? "";

            model.ExpectedJoiningDate = candidate?.ExpectedJoiningDate;

            model.CompletionPercentage = onboarding.CompletionPercentage;

            model.IsPortalLocked = onboarding.IsPortalLocked;

            // Candidate can submit only if:
            // 1. Progress is 100%
            // 2. Portal is not locked
            // 3. Status is In Progress or Corrections Required

            model.CanSubmit =
                onboarding.CompletionPercentage == 100 &&
                !onboarding.IsPortalLocked &&
                (
                    onboarding.OnboardingStatus?.StatusCode == "INPROGRESS" ||
                    onboarding.OnboardingStatus?.StatusCode == "CORRECTION"
                );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitOnboarding()
        {
            var employeeOnboardingId =
                HttpContext.Session.GetInt32("EmployeeOnboardingId");

            if (employeeOnboardingId == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Session expired."
                });
            }

            await UpdateCompletionPercentage(employeeOnboardingId.Value);

            var onboarding = await _context.EmployeeOnboardings
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId.Value);

            if (onboarding == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Onboarding not found."
                });
            }

            if (onboarding.CompletionPercentage < 100)
            {
                return Json(new
                {
                    success = false,
                    message = "Please complete all mandatory onboarding requirements before submitting."
                });
            }

            onboarding.OnboardingStatusMasterId = 4; // SUBMITTED

            onboarding.SubmittedOn = DateTime.Now;

            onboarding.IsPortalLocked = true;

            onboarding.ModifiedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Onboarding submitted successfully."
            });
        }
        //============================================================
        // LOGOUT
        //============================================================

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("EmployeeOnboardingId");
            HttpContext.Session.Remove("OnboardingCandidateId");
            HttpContext.Session.Remove("OnboardingCandidateInvitationId");
            HttpContext.Session.Remove("CandidateName");

            return RedirectToAction(nameof(Login));
        }
    }
}