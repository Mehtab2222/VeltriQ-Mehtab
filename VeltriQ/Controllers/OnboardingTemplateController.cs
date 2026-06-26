using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR.Onboarding;
using VeltriQ.ViewModels;
using VeltriQ.Helpers;

namespace VeltriQ.Controllers
{
    public class OnboardingTemplateController : BaseController
    {
        public OnboardingTemplateController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )

            : base(context, masterContext, userManager)

        {

        }

        // =============================
        // INDEX
        // =============================

        // =============================
        // INDEX
        // =============================

        public async Task<IActionResult> Index()
        {
            var model = await _context.OnboardingTemplates

                .Where(x => x.IsActive)

                .OrderBy(x => x.TemplateName)

                .Select(x => new OnboardingTemplateListViewModel
                {
                    OnboardingTemplateId = x.OnboardingTemplateId,

                    TemplateCode = x.TemplateCode,

                    TemplateName = x.TemplateName,

                    EmploymentType = x.EmploymentType != null
                                        ? x.EmploymentType.EmploymentTypeName
                                        : string.Empty,

                    Department = x.Department != null
                                        ? x.Department.DepartmentName
                                        : string.Empty,

                    Designation = x.Designation != null
                                        ? x.Designation.DesignationName
                                        : string.Empty,

                    Version = x.TemplateVersion,

                    IsPublished = x.IsPublished,

                    IsActive = x.IsActive,

                    // Future Dashboard Statistics
                    TotalSections = 0,

                    TotalDocuments = 0,

                    TotalPolicies = 0,

                    TotalActivities = 0
                })

                .ToListAsync();

            return View(model);
        }

        // =============================
        // CREATE
        // =============================

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new OnboardingTemplateViewModel();

            await LoadDropdowns(model);

            return View(model);
        }

        // =============================
        // LOAD DROPDOWNS
        // =============================

        private async Task LoadDropdowns(OnboardingTemplateViewModel model)
        {
            model.EmploymentTypes = await _context
                .EmploymentTypeMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new SelectListItem
                {
                    Value = x.EmploymentTypeMasterId.ToString(),
                    Text = x.EmploymentTypeName
                })
                .ToListAsync();

            model.Departments = await _context
                .Departments
                .Where(x => x.IsActive)
                .OrderBy(x => x.DepartmentName)
                .Select(x => new SelectListItem
                {
                    Value = x.DepartmentId.ToString(),
                    Text = x.DepartmentName
                })
                .ToListAsync();

            model.Designations = await _context
                .Designations
                .Where(x => x.IsActive)
                .OrderBy(x => x.DesignationName)
                .Select(x => new SelectListItem
                {
                    Value = x.DesignationId.ToString(),
                    Text = x.DesignationName
                })
                .ToListAsync();

            // Template Name Suggestions
            model.TemplateSuggestions = TemplateSuggestions.GetSuggestions();
        }
        // =============================
        // GENERATE TEMPLATE CODE
        // =============================

        private async Task<string> GenerateTemplateCode()
        {
            const string prefix = "ONTEMP";

            var lastTemplate = await _context.OnboardingTemplates

                .OrderByDescending(x => x.OnboardingTemplateId)

                .FirstOrDefaultAsync();

            if (lastTemplate == null)
            {
                return $"{prefix}0001";
            }

            var lastCode = lastTemplate.TemplateCode;

            if (string.IsNullOrWhiteSpace(lastCode) ||
                !lastCode.StartsWith(prefix))
            {
                return $"{prefix}0001";
            }

            var numberPart = lastCode.Substring(prefix.Length);

            if (!int.TryParse(numberPart, out int number))
            {
                return $"{prefix}0001";
            }

            number++;

            return $"{prefix}{number:D4}";
        }
        // =============================
        // CREATE
        // =============================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create
        (
            OnboardingTemplateViewModel model
        )
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model);

                return View(model);
            }

            // =============================
            // CHECK DUPLICATE TEMPLATE
            // =============================

            var exists = await _context.OnboardingTemplates

                .AnyAsync(x =>

                    x.TemplateName == model.TemplateName

                    && x.EmploymentTypeMasterId == model.EmploymentTypeMasterId

                    && x.DepartmentId == model.DepartmentId

                    && x.DesignationId == model.DesignationId

                    && x.IsActive);

            if (exists)
            {
                ModelState.AddModelError
                (
                    "",
                    "An onboarding template already exists for the selected Employment Type, Department and Designation."
                );

                await LoadDropdowns(model);

                return View(model);
            }

            // =============================
            // CREATE TEMPLATE
            // =============================

            var template = new OnboardingTemplate
            {
                TemplateCode = await GenerateTemplateCode(),

                TemplateName = model.TemplateName,

                Description = model.Description,

                EmploymentTypeMasterId = model.EmploymentTypeMasterId,

                DepartmentId = model.DepartmentId,

                DesignationId = model.DesignationId,

                TemplateVersion = model.TemplateVersion,

                IsDefault = model.IsDefault,

                IsPublished = false,

                IsActive = true,

                CreatedOn = DateTime.Now,

                CreatedBy = _userManager.GetUserId(User)
            };

            _context.OnboardingTemplates.Add(template);

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Onboarding Template created successfully.";

            return RedirectToAction
            (
                "Edit",

                new
                {
                    id = template.OnboardingTemplateId
                }
            );
        }
        // =============================
        // EDIT
        // =============================

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var template = await _context.OnboardingTemplates

                .FirstOrDefaultAsync(x =>
                    x.OnboardingTemplateId == id);

            if (template == null)
            {
                return NotFound();
            }

            var model = new OnboardingTemplateViewModel
            {
                OnboardingTemplateId = template.OnboardingTemplateId,

                TemplateCode = template.TemplateCode,

                TemplateName = template.TemplateName,

                Description = template.Description,

                EmploymentTypeMasterId = template.EmploymentTypeMasterId,

                DepartmentId = template.DepartmentId,

                DesignationId = template.DesignationId,

                TemplateVersion = template.TemplateVersion,

                IsDefault = template.IsDefault,

                IsPublished = template.IsPublished,

                IsActive = template.IsActive
            };

            await LoadDropdowns(model);

            return View(model);
        }
        // =============================
        // EDIT
        // =============================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit
        (
            OnboardingTemplateViewModel model
        )
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model);

                return View(model);
            }

            // =============================
            // GET TEMPLATE
            // =============================

            var template = await _context.OnboardingTemplates

                .FirstOrDefaultAsync(x =>
                    x.OnboardingTemplateId == model.OnboardingTemplateId);

            if (template == null)
            {
                return NotFound();
            }

            // =============================
            // DO NOT ALLOW EDIT IF PUBLISHED
            // =============================

            if (template.IsPublished)
            {
                TempData["Error"] =
                    "Published templates cannot be modified.";

                return RedirectToAction
                (
                    "Edit",
                    new
                    {
                        id = template.OnboardingTemplateId
                    }
                );
            }

            // =============================
            // CHECK DUPLICATE
            // =============================

            var exists = await _context.OnboardingTemplates

                .AnyAsync(x =>

                    x.OnboardingTemplateId != model.OnboardingTemplateId

                    && x.TemplateName == model.TemplateName

                    && x.EmploymentTypeMasterId == model.EmploymentTypeMasterId

                    && x.DepartmentId == model.DepartmentId

                    && x.DesignationId == model.DesignationId

                    && x.IsActive);

            if (exists)
            {
                ModelState.AddModelError
                (
                    "",
                    "An onboarding template already exists for the selected Employment Type, Department and Designation."
                );

                await LoadDropdowns(model);

                return View(model);
            }

            // =============================
            // UPDATE
            // =============================

            template.TemplateName = model.TemplateName;

            template.Description = model.Description;

            template.EmploymentTypeMasterId = model.EmploymentTypeMasterId;

            template.DepartmentId = model.DepartmentId;

            template.DesignationId = model.DesignationId;

            template.TemplateVersion = model.TemplateVersion;

            template.IsDefault = model.IsDefault;

            template.IsActive = model.IsActive;

            template.ModifiedOn = DateTime.Now;

            template.ModifiedBy = _userManager.GetUserId(User);

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Onboarding Template updated successfully.";

            return RedirectToAction
            (
                "Edit",

                new
                {
                    id = template.OnboardingTemplateId
                }
            );
        }
        // =============================
        // PUBLISH
        // =============================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Publish(int id)
        {
            var template = await _context.OnboardingTemplates
                .FirstOrDefaultAsync(x => x.OnboardingTemplateId == id);

            if (template == null)
            {
                return NotFound();
            }

            // =====================================
            // UNPUBLISH OTHER TEMPLATES
            // =====================================

            var publishedTemplates = await _context.OnboardingTemplates

                .Where(x =>

                    x.OnboardingTemplateId != id

                    && x.EmploymentTypeMasterId == template.EmploymentTypeMasterId

                    && x.DepartmentId == template.DepartmentId

                    && x.DesignationId == template.DesignationId

                    && x.IsPublished)

                .ToListAsync();

            foreach (var item in publishedTemplates)
            {
                item.IsPublished = false;

                item.ModifiedOn = DateTime.Now;

                item.ModifiedBy = _userManager.GetUserId(User);
            }

            // =====================================
            // PUBLISH CURRENT TEMPLATE
            // =====================================

            template.IsPublished = true;

            template.ModifiedOn = DateTime.Now;

            template.ModifiedBy = _userManager.GetUserId(User);

            await _context.SaveChangesAsync();

            TempData["Success"] = "Template published successfully.";

            return RedirectToAction(nameof(Index));
        }
        // =============================
        // UNPUBLISH
        // =============================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnPublish(int id)
        {
            var template = await _context.OnboardingTemplates
                .FirstOrDefaultAsync(x => x.OnboardingTemplateId == id);

            if (template == null)
            {
                return NotFound();
            }

            template.IsPublished = false;

            template.ModifiedOn = DateTime.Now;

            template.ModifiedBy = _userManager.GetUserId(User);

            await _context.SaveChangesAsync();

            TempData["Success"] = "Template unpublished successfully.";

            return RedirectToAction(nameof(Index));
        }
        // =============================
        // DELETE (SOFT DELETE)
        // =============================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var template = await _context.OnboardingTemplates
                .FirstOrDefaultAsync(x => x.OnboardingTemplateId == id);

            if (template == null)
            {
                TempData["Error"] = "Onboarding Template not found.";

                return RedirectToAction(nameof(Index));
            }

            // =====================================
            // ALREADY DELETED
            // =====================================

            if (!template.IsActive)
            {
                TempData["Warning"] = "Onboarding Template is already inactive.";

                return RedirectToAction(nameof(Index));
            }

            // =====================================
            // DO NOT ALLOW DELETE OF PUBLISHED TEMPLATE
            // =====================================

            if (template.IsPublished)
            {
                TempData["Error"] =
                    "Published templates cannot be deleted. Please unpublish the template first.";

                return RedirectToAction(nameof(Index));
            }

            // =====================================
            // SOFT DELETE
            // =====================================

            template.IsActive = false;

            template.ModifiedOn = DateTime.Now;

            template.ModifiedBy = _userManager.GetUserId(User);

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Onboarding Template deleted successfully.";

            return RedirectToAction(nameof(Index));
        }
        // ==========================================
        // CONFIGURE TEMPLATE
        // ==========================================

        [HttpGet]
        public async Task<IActionResult> Configure(int id)
        {
            var template = await _context.OnboardingTemplates
                .FirstOrDefaultAsync(x => x.OnboardingTemplateId == id);

            if (template == null)
            {
                return NotFound();
            }

            var model = new OnboardingTemplateSectionDesignerViewModel
            {
                OnboardingTemplateId = template.OnboardingTemplateId,
                TemplateCode = template.TemplateCode,
                TemplateName = template.TemplateName
            };

            // =====================================================
            // LOAD SECTIONS
            // =====================================================

            var templateSections = await _context.OnboardingTemplateSections
                .Where(x => x.OnboardingTemplateId == id && x.IsActive)
                .ToListAsync();

            var masterSections = await _context.OnboardingSectionMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            foreach (var section in masterSections)
            {
                var mapping = templateSections.FirstOrDefault(x =>
                    x.OnboardingSectionMasterId == section.OnboardingSectionMasterId);

                model.Sections.Add(new OnboardingTemplateSectionViewModel
                {
                    OnboardingTemplateSectionId = mapping?.OnboardingTemplateSectionId ?? 0,
                    OnboardingTemplateId = template.OnboardingTemplateId,
                    OnboardingSectionMasterId = section.OnboardingSectionMasterId,
                    SectionName = section.SectionName,
                    IsSelected = mapping != null,
                    IsMandatory = mapping?.IsMandatory ?? true,
                    DisplayOrder = mapping?.DisplayOrder ?? section.DisplayOrder,
                    IsActive = mapping?.IsActive ?? true
                });
            }
            // =====================================================
            // LOAD POLICIES
            // =====================================================

            var templatePolicies = await _context.OnboardingTemplatePolicies
                .Where(x => x.OnboardingTemplateId == id && x.IsActive)
                .ToListAsync();

            var masterPolicies = await _context.OnboardingPolicyMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            foreach (var policy in masterPolicies)
            {
                var mapping = templatePolicies.FirstOrDefault(x =>
                    x.OnboardingPolicyMasterId == policy.OnboardingPolicyMasterId);

                model.Policies.Add(new OnboardingTemplatePolicyViewModel
                {
                    OnboardingTemplatePolicyId = mapping?.OnboardingTemplatePolicyId ?? 0,
                    OnboardingPolicyMasterId = policy.OnboardingPolicyMasterId,
                    PolicyName = policy.PolicyName,
                    IsSelected = mapping != null,
                    IsMandatory = mapping?.IsMandatory ?? true,
                    DisplayOrder = mapping?.DisplayOrder ?? policy.DisplayOrder
                });
            }
            // =====================================================
            // LOAD ACTIVITIES
            // =====================================================

            var templateActivities = await _context.OnboardingTemplateActivities
                .Where(x => x.OnboardingTemplateId == id && x.IsActive)
                .ToListAsync();

            var masterActivities = await _context.OnboardingActivityMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            foreach (var activity in masterActivities)
            {
                var mapping = templateActivities.FirstOrDefault(x =>
                    x.OnboardingActivityMasterId == activity.OnboardingActivityMasterId);

                model.Activities.Add(new OnboardingTemplateActivityViewModel
                {
                    OnboardingTemplateActivityId = mapping?.OnboardingTemplateActivityId ?? 0,
                    OnboardingActivityMasterId = activity.OnboardingActivityMasterId,
                    ActivityName = activity.ActivityName,
                    IsSelected = mapping != null,
                    IsMandatory = mapping?.IsMandatory ?? true,
                    DisplayOrder = mapping?.DisplayOrder ?? activity.DisplayOrder
                });
            }
            // =====================================================
            // LOAD DOCUMENTS
            // =====================================================

            var templateDocuments = await _context.OnboardingTemplateDocuments
                .Where(x => x.OnboardingTemplateId == id && x.IsActive)
                .ToListAsync();

            var masterDocuments = await _context.OnboardingDocumentMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            foreach (var document in masterDocuments)
            {
                var mapping = templateDocuments.FirstOrDefault(x =>
                    x.OnboardingDocumentMasterId == document.OnboardingDocumentMasterId);

                model.Documents.Add(new OnboardingTemplateDocumentViewModel
                {
                    OnboardingTemplateDocumentId = mapping?.OnboardingTemplateDocumentId ?? 0,
                    OnboardingDocumentMasterId = document.OnboardingDocumentMasterId,
                    DocumentName = document.DocumentName,
                    IsSelected = mapping != null,
                    IsMandatory = mapping?.IsMandatory ?? true,
                    DisplayOrder = mapping?.DisplayOrder ?? document.DisplayOrder
                });
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSections(OnboardingTemplateSectionDesignerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Configure", model);
            }

            var existingSections = await _context.OnboardingTemplateSections
                .Where(x => x.OnboardingTemplateId == model.OnboardingTemplateId)
                .ToListAsync();

            foreach (var section in model.Sections)
            {
                var existing = existingSections.FirstOrDefault(x =>
                    x.OnboardingSectionMasterId == section.OnboardingSectionMasterId);

                if (section.IsSelected)
                {
                    if (existing != null)
                    {
                        // Update existing mapping
                        existing.IsMandatory = section.IsMandatory;
                        existing.DisplayOrder = section.DisplayOrder;
                        existing.IsActive = true;
                        existing.ModifiedOn = DateTime.Now;
                        // existing.ModifiedBy = User.Identity?.Name;
                    }
                    else
                    {
                        // Insert new mapping
                        _context.OnboardingTemplateSections.Add(new OnboardingTemplateSection
                        {
                            OnboardingTemplateId = model.OnboardingTemplateId,
                            OnboardingSectionMasterId = section.OnboardingSectionMasterId,
                            IsMandatory = section.IsMandatory,
                            DisplayOrder = section.DisplayOrder,
                            IsActive = true,
                            CreatedOn = DateTime.Now,
                            // CreatedBy = User.Identity?.Name
                        });
                    }
                }
                else
                {
                    if (existing != null)
                    {
                        // Soft delete
                        existing.IsActive = false;
                        existing.ModifiedOn = DateTime.Now;
                        // existing.ModifiedBy = User.Identity?.Name;
                    }
                }
            }


            await _context.SaveChangesAsync();

            TempData["Success"] = "Sections configured successfully.";

            return RedirectToAction(nameof(Configure), new { id = model.OnboardingTemplateId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveDocuments(OnboardingTemplateSectionDesignerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Configure), new { id = model.OnboardingTemplateId });
            }

            var existingDocuments = await _context.OnboardingTemplateDocuments
                .Where(x => x.OnboardingTemplateId == model.OnboardingTemplateId)
                .ToListAsync();

            foreach (var document in model.Documents)
            {
                var existing = existingDocuments.FirstOrDefault(x =>
                    x.OnboardingDocumentMasterId == document.OnboardingDocumentMasterId);

                if (document.IsSelected)
                {
                    if (existing != null)
                    {
                        // Update existing mapping
                        existing.IsMandatory = document.IsMandatory;
                        existing.DisplayOrder = document.DisplayOrder;
                        existing.IsActive = true;
                        existing.ModifiedOn = DateTime.Now;
                        // existing.ModifiedBy = User.Identity?.Name;
                    }
                    else
                    {
                        // Create new mapping
                        _context.OnboardingTemplateDocuments.Add(new OnboardingTemplateDocument
                        {
                            OnboardingTemplateId = model.OnboardingTemplateId,
                            OnboardingDocumentMasterId = document.OnboardingDocumentMasterId,
                            IsMandatory = document.IsMandatory,
                            DisplayOrder = document.DisplayOrder,
                            IsActive = true,
                            CreatedOn = DateTime.Now,
                            // CreatedBy = User.Identity?.Name;
                        });
                    }
                }
                else
                {
                    if (existing != null)
                    {
                        // Soft delete
                        existing.IsActive = false;
                        existing.ModifiedOn = DateTime.Now;
                        // existing.ModifiedBy = User.Identity?.Name;
                    }
                }
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Documents configured successfully.";

            return RedirectToAction(nameof(Configure), new { id = model.OnboardingTemplateId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavePolicies(OnboardingTemplateSectionDesignerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Configure), new { id = model.OnboardingTemplateId });
            }

            var existingPolicies = await _context.OnboardingTemplatePolicies
                .Where(x => x.OnboardingTemplateId == model.OnboardingTemplateId)
                .ToListAsync();

            foreach (var policy in model.Policies)
            {
                var existing = existingPolicies.FirstOrDefault(x =>
                    x.OnboardingPolicyMasterId == policy.OnboardingPolicyMasterId);

                if (policy.IsSelected)
                {
                    if (existing != null)
                    {
                        // Update existing mapping
                        existing.IsMandatory = policy.IsMandatory;
                        existing.DisplayOrder = policy.DisplayOrder;
                        existing.IsActive = true;
                        existing.ModifiedOn = DateTime.Now;
                        // existing.ModifiedBy = User.Identity?.Name;
                    }
                    else
                    {
                        // Insert new mapping
                        _context.OnboardingTemplatePolicies.Add(new OnboardingTemplatePolicy
                        {
                            OnboardingTemplateId = model.OnboardingTemplateId,
                            OnboardingPolicyMasterId = policy.OnboardingPolicyMasterId,
                            IsMandatory = policy.IsMandatory,
                            DisplayOrder = policy.DisplayOrder,
                            IsActive = true,
                            CreatedOn = DateTime.Now,
                            // CreatedBy = User.Identity?.Name;
                        });
                    }
                }
                else
                {
                    if (existing != null)
                    {
                        // Soft delete
                        existing.IsActive = false;
                        existing.ModifiedOn = DateTime.Now;
                        // existing.ModifiedBy = User.Identity?.Name;
                    }
                }
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Policies configured successfully.";

            return RedirectToAction(nameof(Configure), new { id = model.OnboardingTemplateId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveActivities(OnboardingTemplateSectionDesignerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Configure), new { id = model.OnboardingTemplateId });
            }

            var existingActivities = await _context.OnboardingTemplateActivities
                .Where(x => x.OnboardingTemplateId == model.OnboardingTemplateId)
                .ToListAsync();

            foreach (var activity in model.Activities)
            {
                var existing = existingActivities.FirstOrDefault(x =>
                    x.OnboardingActivityMasterId == activity.OnboardingActivityMasterId);

                if (activity.IsSelected)
                {
                    if (existing != null)
                    {
                        // Update existing mapping
                        existing.IsMandatory = activity.IsMandatory;
                        existing.DisplayOrder = activity.DisplayOrder;
                        existing.IsActive = true;
                        existing.ModifiedOn = DateTime.Now;
                        // existing.ModifiedBy = User.Identity?.Name;
                    }
                    else
                    {
                        // Insert new mapping
                        _context.OnboardingTemplateActivities.Add(new OnboardingTemplateActivity
                        {
                            OnboardingTemplateId = model.OnboardingTemplateId,
                            OnboardingActivityMasterId = activity.OnboardingActivityMasterId,
                            IsMandatory = activity.IsMandatory,
                            DisplayOrder = activity.DisplayOrder,
                            IsActive = true,
                            CreatedOn = DateTime.Now,
                            // CreatedBy = User.Identity?.Name;
                        });
                    }
                }
                else
                {
                    if (existing != null)
                    {
                        // Soft delete
                        existing.IsActive = false;
                        existing.ModifiedOn = DateTime.Now;
                        // existing.ModifiedBy = User.Identity?.Name;
                    }
                }
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Activities configured successfully.";

            return RedirectToAction(nameof(Configure), new { id = model.OnboardingTemplateId });
        }
    }

}