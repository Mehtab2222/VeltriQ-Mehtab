using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR.Onboarding;
using VeltriQ.ViewModels.OnboardingDocument;

namespace VeltriQ.Controllers
{
    public class OnboardingDocumentController : BaseController
    {
        private readonly TenantDbContext _context;

        public OnboardingDocumentController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )
            : base(context, masterContext, userManager)
        {
            _context = context;
        }

        //====================================================
        // INDEX
        //====================================================

        //====================================================
        // INDEX
        //====================================================

        [HttpGet]
        public async Task<IActionResult> Index(string searchText = "")
        {
            var model = new OnboardingDocumentIndexViewModel
            {
                SearchText = searchText
            };

            var query = _context.OnboardingDocumentMasters
                .Include(x => x.DocumentCategory)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.Trim();

                query = query.Where(x =>
                    x.DocumentName.Contains(searchText) ||
                    (x.Description != null &&
                     x.Description.Contains(searchText)) ||
                    x.DocumentCategory.CategoryName.Contains(searchText));
            }

            model.Documents = await query

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new OnboardingDocumentListItemViewModel
                {
                    OnboardingDocumentMasterId = x.OnboardingDocumentMasterId,

                    DocumentName = x.DocumentName,

                    Description = x.Description ?? "",

                    CategoryName = x.DocumentCategory.CategoryName,

                    AllowedFileTypes = x.AllowedFileTypes,

                    MaxFileSizeMB = x.MaxFileSizeMB,

                    IsMandatory = x.IsMandatory,

                    IsExpiryRequired = x.IsExpiryRequired,

                    IsAllowMultipleFiles = x.AllowMultipleFiles,

                    IsVisibleToCandidate = x.IsVisibleToCandidate,

                    AllowDownloadByCandidate = x.AllowDownloadByCandidate,

                    DisplayOrder = x.DisplayOrder,

                    IsActive = x.IsActive
                })

                .ToListAsync();

            return View(model);
        }

        //====================================================
        // CREATE
        //====================================================

        //====================================================
        // CREATE
        //====================================================

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new OnboardingDocumentCreateViewModel
            {
                IsMandatory = true,
                IsVisibleToCandidate = true,

                DisplayOrder = await _context.OnboardingDocumentMasters.AnyAsync()
                    ? await _context.OnboardingDocumentMasters.MaxAsync(x => x.DisplayOrder) + 1
                    : 1
            };

            model.Categories = await _context.OnboardingDocumentCategoryMasters

                .Where(x => x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new SelectListItem
                {
                    Value = x.OnboardingDocumentCategoryMasterId.ToString(),
                    Text = x.CategoryName
                })

                .ToListAsync();

            return View(model);
        }

        //====================================================
        // CREATE
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            OnboardingDocumentCreateViewModel model)
        {
            // Reload categories when validation fails
            model.Categories = await _context.OnboardingDocumentCategoryMasters
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new SelectListItem
                {
                    Value = x.OnboardingDocumentCategoryMasterId.ToString(),
                    Text = x.CategoryName
                })
                .ToListAsync();

            if (!ModelState.IsValid)
                return View(model);

            //====================================================
            // DUPLICATE DOCUMENT NAME
            //====================================================

            var exists = await _context.OnboardingDocumentMasters
                .AnyAsync(x =>
                    x.IsActive &&
                    x.DocumentName.ToLower() == model.DocumentName.Trim().ToLower());

            if (exists)
            {
                ModelState.AddModelError(
                    nameof(model.DocumentName),
                    "Document already exists.");

                return View(model);
            }

            //====================================================
            // GENERATE DOCUMENT CODE
            //====================================================

            var documentCode = new string(
                model.DocumentName
                    .Trim()
                    .ToUpper()
                    .Where(char.IsLetterOrDigit)
                    .ToArray());

            var entity = new OnboardingDocumentMaster
            {
                DocumentCode = documentCode,

                DocumentName = model.DocumentName.Trim(),

                Description = string.IsNullOrWhiteSpace(model.Description)
                    ? null
                    : model.Description.Trim(),

                OnboardingDocumentCategoryMasterId =
                    model.OnboardingDocumentCategoryMasterId,

                AllowedFileTypes = model.AllowedFileTypes,

                MaxFileSizeMB = model.MaxFileSizeMB,

                AllowMultipleFiles = model.AllowMultipleFiles,

                IsExpiryRequired = model.IsExpiryRequired,

                IsMandatory = model.IsMandatory,

                DisplayOrder = model.DisplayOrder,

                AllowDownloadByCandidate =
                    model.AllowDownloadByCandidate,

                IsVisibleToCandidate =
                    model.IsVisibleToCandidate,

                IsActive = true,

                IsSystemDocument = false,

                CreatedOn = DateTime.Now,

                CreatedBy = User.Identity?.Name
            };

            _context.OnboardingDocumentMasters.Add(entity);

            await _context.SaveChangesAsync();

            TempData["Success"] = "Document created successfully.";

            return RedirectToAction(nameof(Index));
        }

        //====================================================
        // EDIT
        //====================================================

        //====================================================
        // EDIT
        //====================================================

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _context.OnboardingDocumentMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingDocumentMasterId == id);

            if (entity == null)
                return NotFound();

            var model = new OnboardingDocumentEditViewModel
            {
                OnboardingDocumentMasterId = entity.OnboardingDocumentMasterId,

                DocumentName = entity.DocumentName,

                Description = entity.Description,

                OnboardingDocumentCategoryMasterId =
                    entity.OnboardingDocumentCategoryMasterId,

                AllowedFileTypes = entity.AllowedFileTypes,

                MaxFileSizeMB = entity.MaxFileSizeMB,

                AllowMultipleFiles = entity.AllowMultipleFiles,

                IsExpiryRequired = entity.IsExpiryRequired,

                IsMandatory = entity.IsMandatory,

                IsVisibleToCandidate = entity.IsVisibleToCandidate,

                AllowDownloadByCandidate = entity.AllowDownloadByCandidate,

                DisplayOrder = entity.DisplayOrder
            };

            model.Categories = await _context.OnboardingDocumentCategoryMasters

                .Where(x => x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new SelectListItem
                {
                    Value = x.OnboardingDocumentCategoryMasterId.ToString(),
                    Text = x.CategoryName
                })

                .ToListAsync();

            return View(model);
        }
        //====================================================
        // EDIT
        //====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            OnboardingDocumentEditViewModel model)
        {
            model.Categories = await _context.OnboardingDocumentCategoryMasters

                .Where(x => x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new SelectListItem
                {
                    Value = x.OnboardingDocumentCategoryMasterId.ToString(),
                    Text = x.CategoryName
                })

                .ToListAsync();

            if (!ModelState.IsValid)
                return View(model);

            var entity = await _context.OnboardingDocumentMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingDocumentMasterId ==
                    model.OnboardingDocumentMasterId);

            if (entity == null)
                return NotFound();

            //====================================================
            // DUPLICATE NAME
            //====================================================

            var exists = await _context.OnboardingDocumentMasters
                .AnyAsync(x =>
                    x.OnboardingDocumentMasterId != model.OnboardingDocumentMasterId &&
                    x.IsActive &&
                    x.DocumentName.ToLower() == model.DocumentName.Trim().ToLower());

            if (exists)
            {
                ModelState.AddModelError(
                    nameof(model.DocumentName),
                    "Document already exists.");

                return View(model);
            }

            //====================================================
            // UPDATE
            //====================================================

            entity.DocumentName = model.DocumentName.Trim();

            entity.Description =
                string.IsNullOrWhiteSpace(model.Description)
                ? null
                : model.Description.Trim();

            entity.OnboardingDocumentCategoryMasterId =
                model.OnboardingDocumentCategoryMasterId;

            entity.AllowedFileTypes = model.AllowedFileTypes;

            entity.MaxFileSizeMB = model.MaxFileSizeMB;

            entity.AllowMultipleFiles = model.AllowMultipleFiles;

            entity.IsExpiryRequired = model.IsExpiryRequired;

            entity.IsMandatory = model.IsMandatory;

            entity.DisplayOrder = model.DisplayOrder;

            entity.IsVisibleToCandidate =
                model.IsVisibleToCandidate;

            entity.AllowDownloadByCandidate =
                model.AllowDownloadByCandidate;

            entity.ModifiedOn = DateTime.Now;

            entity.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            TempData["Success"] = "Document updated successfully.";

            return RedirectToAction(nameof(Index));
        }
        //====================================================
        // ACTIVATE
        //====================================================

        //====================================================
        // ACTIVATE
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Activate([FromBody] int id)
        {
            var document = await _context.OnboardingDocumentMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingDocumentMasterId == id);

            if (document == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Document not found."
                });
            }

            document.IsActive = true;
            document.ModifiedOn = DateTime.Now;
            document.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Document activated successfully."
            });
        }

        //====================================================
        // DEACTIVATE
        //====================================================

        //====================================================
        // DEACTIVATE
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Deactivate([FromBody] int id)
        {
            var document = await _context.OnboardingDocumentMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingDocumentMasterId == id);

            if (document == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Document not found."
                });
            }

            //====================================================
            // CHECK IF USED IN ACTIVE TEMPLATES
            //====================================================

            var isUsed = await _context.OnboardingTemplateDocuments
                .AnyAsync(x =>
                    x.OnboardingDocumentMasterId == id &&
                    x.IsActive);

            if (isUsed)
            {
                return Json(new
                {
                    success = false,
                    message = "This document is currently used in one or more onboarding templates. Remove it from the template(s) before deactivating it."
                });
            }

            document.IsActive = false;
            document.ModifiedOn = DateTime.Now;
            document.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Document deactivated successfully."
            });
        }
    }
}