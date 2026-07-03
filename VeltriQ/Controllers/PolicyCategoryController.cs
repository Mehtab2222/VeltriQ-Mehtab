using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR.Onboarding;
using VeltriQ.ViewModels.PolicyCategory;

namespace VeltriQ.Controllers
{
    public class PolicyCategoryController : BaseController
    {
        private readonly TenantDbContext _context;

        public PolicyCategoryController
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

        [HttpGet]
        public async Task<IActionResult> Index(string searchText = "")
        {
            var model = new PolicyCategoryIndexViewModel
            {
                SearchText = searchText
            };

            var query = _context.OnboardingPolicyCategoryMasters
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

                .Select(x => new PolicyCategoryListItemViewModel
                {
                    OnboardingPolicyCategoryMasterId =
                        x.OnboardingPolicyCategoryMasterId,

                    CategoryName = x.CategoryName,

                    Description = x.Description ?? "",

                    DisplayOrder = x.DisplayOrder,

                    IsActive = x.IsActive,

                    PolicyCount = _context.OnboardingPolicyMasters
                        .Count(p =>
                            p.OnboardingPolicyCategoryMasterId ==
                            x.OnboardingPolicyCategoryMasterId &&
                            p.IsActive)
                })

                .ToListAsync();

            //====================================================
            // DEFAULT DISPLAY ORDER
            //====================================================

            model.CreateCategory.DisplayOrder =
                await _context.OnboardingPolicyCategoryMasters.AnyAsync()
                    ? await _context.OnboardingPolicyCategoryMasters
                        .MaxAsync(x => x.DisplayOrder) + 1
                    : 1;

            return View(model);
        }

        //====================================================
        // CREATE
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] PolicyCategoryCreateViewModel model)
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

            var exists = await _context.OnboardingPolicyCategoryMasters
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

            var entity = new OnboardingPolicyCategoryMaster
            {
                CategoryCode = categoryCode,

                CategoryName = model.CategoryName,

                Description = model.Description,

                DisplayOrder = model.DisplayOrder,

                IsActive = true,

                CreatedOn = DateTime.Now,

                CreatedBy = User.Identity?.Name
            };

            _context.OnboardingPolicyCategoryMasters.Add(entity);

            await _context.SaveChangesAsync();

            //====================================================
            // SUCCESS
            //====================================================

            return Json(new
            {
                success = true,

                id = entity.OnboardingPolicyCategoryMasterId,

                categoryName = entity.CategoryName,

                description = entity.Description ?? "",

                displayOrder = entity.DisplayOrder,

                policyCount = 0,

                isActive = entity.IsActive,

                message = "Category created successfully."
            });
        }
        //====================================================
        // EDIT
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Edit(
            [FromBody] PolicyCategoryEditViewModel model)
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

            var entity = await _context.OnboardingPolicyCategoryMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingPolicyCategoryMasterId ==
                    model.OnboardingPolicyCategoryMasterId);

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

            var exists = await _context.OnboardingPolicyCategoryMasters
                .AnyAsync(x =>
                    x.OnboardingPolicyCategoryMasterId !=
                        model.OnboardingPolicyCategoryMasterId &&
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

                id = entity.OnboardingPolicyCategoryMasterId,

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
            var category = await _context.OnboardingPolicyCategoryMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingPolicyCategoryMasterId == id);

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
            var category = await _context.OnboardingPolicyCategoryMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingPolicyCategoryMasterId == id);

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

            var policyCount = await _context.OnboardingPolicyMasters
                .CountAsync(x =>
                    x.OnboardingPolicyCategoryMasterId == id &&
                    x.IsActive);

            if (policyCount > 0)
            {
                return Json(new
                {
                    success = false,
                    message = $"This category is currently assigned to {policyCount} active policy(s). Remove it from the policy(s) before deactivating it."
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