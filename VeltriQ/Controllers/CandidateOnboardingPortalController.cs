using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.HR.Onboarding;
using VeltriQ.ViewModels.CandidateOnboardingPortal;
using VeltriQ.ViewModels.EmployeeOnboarding;

namespace VeltriQ.Controllers
{
    public class CandidateOnboardingPortalController
        : CandidateOnboardingBaseController
    {
        public CandidateOnboardingPortalController
        (
            TenantDbContext context
        )
            : base(context)
        {
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
        private async Task<CandidateOnboardingIdentityDocumentsViewModel> LoadIdentityDocuments(int employeeOnboardingId)
        {
            var model = new CandidateOnboardingIdentityDocumentsViewModel
            {
                EmployeeOnboardingId = employeeOnboardingId
            };

            model.Documents = await _context.EmployeeOnboardingIdentities
                .Where(x => x.EmployeeOnboardingId == employeeOnboardingId && x.IsActive)
                .OrderBy(x => x.EmployeeOnboardingIdentityId)
                .Select(x => new IdentityDocumentViewModel
                {
                    EmployeeOnboardingIdentityDocumentId = x.EmployeeOnboardingIdentityId,
                    DocumentName = x.DocumentName,
                    DocumentNumber = x.DocumentNumber,
                    Uploaded = x.Uploaded
                })
                .ToListAsync();

            return model;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveIdentityDocument(
    IdentityDocumentViewModel model,
    int employeeOnboardingId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Invalid document details."
                });
            }

            EmployeeOnboardingIdentity entity;

            if (model.EmployeeOnboardingIdentityDocumentId == 0)
            {
                entity = new EmployeeOnboardingIdentity
                {
                    EmployeeOnboardingId = employeeOnboardingId,
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };

                _context.EmployeeOnboardingIdentities.Add(entity);
            }
            else
            {
                entity = await _context.EmployeeOnboardingIdentities
                    .FirstAsync(x =>
                        x.EmployeeOnboardingIdentityId ==
                        model.EmployeeOnboardingIdentityDocumentId);

                entity.ModifiedOn = DateTime.Now;
            }

            entity.DocumentName = model.DocumentName;
            entity.DocumentNumber = model.DocumentNumber;
            entity.Uploaded = model.Uploaded;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Identity document saved successfully."
            });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteIdentityDocument(int id)
        {
            var entity = await _context.EmployeeOnboardingIdentities
                .FirstOrDefaultAsync(x =>
                    x.EmployeeOnboardingIdentityId == id);

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

                case "Identity Documents":
                    return PartialView(
                        "Information/_IdentityDocuments",
                        await LoadIdentityDocuments(employeeOnboardingId.Value));

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

        private async Task LoadDocuments
(
    CandidateOnboardingIndexViewModel model,
    int employeeOnboardingId
)
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

                    IsUploaded = x.IsUploaded
                })

                .ToListAsync();
        }
        private async Task LoadPolicies
(
    CandidateOnboardingIndexViewModel model,
    int employeeOnboardingId
)
        {
            model.PoliciesList = await _context.EmployeeOnboardingPolicies

                .Where(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new EmployeeOnboardingPolicyViewModel
                {
                    EmployeeOnboardingPolicyId = x.EmployeeOnboardingPolicyId,

                    PolicyName = x.Policy.PolicyName,

                    IsMandatory = x.IsMandatory,

                    IsAccepted = x.IsAccepted
                })

                .ToListAsync();
        }
        private async Task LoadOverview
(
    CandidateOnboardingIndexViewModel model,
    int employeeOnboardingId
)
        {
            model.TotalSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.CompletedSections = await _context.EmployeeOnboardingSections
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsCompleted);

            model.TotalDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.UploadedDocuments = await _context.EmployeeOnboardingDocuments
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsUploaded);

            model.TotalPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.AcceptedPolicies = await _context.EmployeeOnboardingPolicies
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsAccepted);

            model.TotalActivities = await _context.EmployeeOnboardingActivities
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive);

            model.CompletedActivities = await _context.EmployeeOnboardingActivities
                .CountAsync(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive &&
                    x.IsCompleted);
        }
        private async Task LoadActivities
 (
     CandidateOnboardingIndexViewModel model,
     int employeeOnboardingId
 )
        {
            model.ActivitiesList = await _context.EmployeeOnboardingActivities

                .Where(x =>
                    x.EmployeeOnboardingId == employeeOnboardingId &&
                    x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new EmployeeOnboardingActivityViewModel
                {
                    EmployeeOnboardingActivityId = x.EmployeeOnboardingActivityId,

                    ActivityName = x.Activity.ActivityName,

                    IsCompleted = x.IsCompleted,

                    CompletedOn = x.CompletedOn
                })

                .ToListAsync();
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

            // We'll enable these later
            // await LoadDocuments(model, employeeOnboardingId.Value);
            // await LoadPolicies(model, employeeOnboardingId.Value);
            // await LoadActivities(model, employeeOnboardingId.Value);

            return View(model);
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

            model.ExpectedJoiningDate = candidate?.ExpectedJoiningDate;

            model.CompletionPercentage = onboarding.CompletionPercentage;
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