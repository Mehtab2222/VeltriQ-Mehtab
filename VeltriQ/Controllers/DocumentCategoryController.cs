using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR.Onboarding;
using VeltriQ.ViewModels.OnboardingDocumentCategory;

namespace VeltriQ.Controllers
{
    public class DocumentCategoryController : BaseController
    {
        private readonly TenantDbContext _context;

        public DocumentCategoryController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )
            : base(context, masterContext, userManager)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchText = "")
        {
            var model = new DocumentCategoryIndexViewModel
            {
                SearchText = searchText
            };

            var query = _context.OnboardingDocumentCategoryMasters
                .AsQueryable();

            //====================================================
            // SEARCH
            //====================================================

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.Trim();

                query = query.Where(x =>
                    x.CategoryName.Contains(searchText) ||
                    (x.Description != null &&
                     x.Description.Contains(searchText)));
            }

            //====================================================
            // LOAD CATEGORIES
            //====================================================

            model.Categories = await query

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new DocumentCategoryListItemViewModel
                {
                    OnboardingDocumentCategoryMasterId =
                        x.OnboardingDocumentCategoryMasterId,

                    CategoryName = x.CategoryName,

                    Description = x.Description ?? "",

                    DisplayOrder = x.DisplayOrder,

                    IsActive = x.IsActive,

                    DocumentCount = _context.OnboardingDocumentMasters
                        .Count(d =>
                            d.OnboardingDocumentCategoryMasterId ==
                            x.OnboardingDocumentCategoryMasterId &&
                            d.IsActive)
                })

                .ToListAsync();

            //====================================================
            // DEFAULT DISPLAY ORDER
            //====================================================

            model.CreateCategory.DisplayOrder =
                await _context.OnboardingDocumentCategoryMasters.AnyAsync()
                    ? await _context.OnboardingDocumentCategoryMasters
                        .MaxAsync(x => x.DisplayOrder) + 1
                    : 1;

            return View(model);
        }
        //====================================================
        // CREATE
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] DocumentCategoryCreateViewModel model)
        {
            //====================================================
            // VALIDATION
            //====================================================

            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please enter all required fields."
                });
            }

            model.CategoryName = model.CategoryName.Trim();

            model.Description = string.IsNullOrWhiteSpace(model.Description)
                ? null
                : model.Description.Trim();

            //====================================================
            // DUPLICATE CATEGORY
            //====================================================

            var exists = await _context.OnboardingDocumentCategoryMasters
                .AnyAsync(x =>
                    x.CategoryName.ToLower() ==
                    model.CategoryName.ToLower());

            if (exists)
            {
                return Json(new
                {
                    success = false,
                    message = "Category already exists."
                });
            }

            //====================================================
            // GENERATE CATEGORY CODE
            //====================================================

            var categoryCode = new string(
                model.CategoryName
                    .ToUpper()
                    .Where(char.IsLetterOrDigit)
                    .ToArray());

            //====================================================
            // CREATE ENTITY
            //====================================================

            var entity = new OnboardingDocumentCategoryMaster
            {
                CategoryCode = categoryCode,

                CategoryName = model.CategoryName,

                Description = model.Description,

                DisplayOrder = model.DisplayOrder,

                IsActive = true,

                CreatedOn = DateTime.Now,

                CreatedBy = User.Identity?.Name
            };

            _context.OnboardingDocumentCategoryMasters.Add(entity);

            await _context.SaveChangesAsync();

            //====================================================
            // SUCCESS
            //====================================================

            return Json(new
            {
                success = true,

                id = entity.OnboardingDocumentCategoryMasterId,

                categoryName = entity.CategoryName,

                description = entity.Description ?? "",

                displayOrder = entity.DisplayOrder,

                documentCount = 0,

                isActive = entity.IsActive,

                message = "Category created successfully."
            });
        }
        //====================================================
        // EDIT
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Edit(
            [FromBody] DocumentCategoryEditViewModel model)
        {
            //====================================================
            // VALIDATION
            //====================================================

            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please enter all required fields."
                });
            }

            var entity = await _context.OnboardingDocumentCategoryMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingDocumentCategoryMasterId ==
                    model.OnboardingDocumentCategoryMasterId);

            if (entity == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Category not found."
                });
            }

            model.CategoryName = model.CategoryName.Trim();

            model.Description = string.IsNullOrWhiteSpace(model.Description)
                ? null
                : model.Description.Trim();

            //====================================================
            // DUPLICATE CATEGORY
            //====================================================

            var exists = await _context.OnboardingDocumentCategoryMasters
                .AnyAsync(x =>
                    x.OnboardingDocumentCategoryMasterId !=
                        model.OnboardingDocumentCategoryMasterId &&
                    x.CategoryName.ToLower() ==
                        model.CategoryName.ToLower());

            if (exists)
            {
                return Json(new
                {
                    success = false,
                    message = "Category already exists."
                });
            }

            //====================================================
            // UPDATE
            //====================================================

            entity.CategoryName = model.CategoryName;

            entity.Description = model.Description;

            entity.DisplayOrder = model.DisplayOrder;

            entity.ModifiedOn = DateTime.Now;

            entity.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            //====================================================
            // SUCCESS
            //====================================================

            return Json(new
            {
                success = true,

                id = entity.OnboardingDocumentCategoryMasterId,

                categoryName = entity.CategoryName,

                description = entity.Description ?? "",

                displayOrder = entity.DisplayOrder,

                message = "Category updated successfully."
            });
        }
        //====================================================
        // ACTIVATE
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Activate([FromBody] int id)
        {
            var category = await _context.OnboardingDocumentCategoryMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingDocumentCategoryMasterId == id);

            if (category == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Category not found."
                });
            }

            category.IsActive = true;

            category.ModifiedOn = DateTime.Now;

            category.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Category activated successfully."
            });
        }
        //====================================================
        // DEACTIVATE
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Deactivate([FromBody] int id)
        {
            var category = await _context.OnboardingDocumentCategoryMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingDocumentCategoryMasterId == id);

            if (category == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Category not found."
                });
            }

            //====================================================
            // CHECK IF CATEGORY IS USED
            //====================================================

            var documentCount = await _context.OnboardingDocumentMasters
                .CountAsync(x =>
                    x.OnboardingDocumentCategoryMasterId == id &&
                    x.IsActive);

            if (documentCount > 0)
            {
                return Json(new
                {
                    success = false,
                    message = $"This category is currently assigned to {documentCount} active document(s). Remove it from the document(s) before deactivating it."
                });
            }

            category.IsActive = false;

            category.ModifiedOn = DateTime.Now;

            category.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Category deactivated successfully."
            });
        }

    }
}