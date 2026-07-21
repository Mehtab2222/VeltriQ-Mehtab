using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.Training;
using VeltriQ.ViewModels.TrainingCategory;

namespace VeltriQ.Controllers
{
    public class TrainingCategoryController : BaseController
    {
        private readonly TenantDbContext _context;

        public TrainingCategoryController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        ) : base(context, masterContext, userManager)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.TrainingCategories
                .OrderBy(x => x.CategoryName)
                .ToListAsync();

            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _context.TrainingCategories
                .FirstOrDefaultAsync(x => x.TrainingCategoryId == id);

            if (category == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Training Category not found."
                });
            }

            return Json(new
            {
                success = true,
                data = new
                {
                    category.TrainingCategoryId,
                    category.CategoryCode,
                    category.CategoryName,
                    category.IsActive
                }
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please fill all required fields."
                });
            }

            model.CategoryName = model.CategoryName.Trim();

            bool exists = await _context.TrainingCategories
                .AnyAsync(x => x.IsActive &&
                               x.CategoryName == model.CategoryName);

            if (exists)
            {
                return Json(new
                {
                    success = false,
                    message = "Category already exists."
                });
            }

            var category = new TrainingCategory
            {
                CategoryName = model.CategoryName,
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = GetCurrentEmployeeId()
            };

            _context.TrainingCategories.Add(category);

            await _context.SaveChangesAsync();

            category.CategoryCode = $"TRCAT-{category.TrainingCategoryId:D4}";

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Training Category created successfully."
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TrainingCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please fill all required fields."
                });
            }

            var category = await _context.TrainingCategories
                .FirstOrDefaultAsync(x => x.TrainingCategoryId == model.TrainingCategoryId);

            if (category == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Training Category not found."
                });
            }

            model.CategoryName = model.CategoryName.Trim();

            bool exists = await _context.TrainingCategories
                .AnyAsync(x => x.TrainingCategoryId != model.TrainingCategoryId &&
                               x.IsActive &&
                               x.CategoryName == model.CategoryName);

            if (exists)
            {
                return Json(new
                {
                    success = false,
                    message = "Category already exists."
                });
            }

            category.CategoryName = model.CategoryName;
            category.ModifiedOn = DateTime.Now;
            category.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Training Category updated successfully."
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var category = await _context.TrainingCategories
                .FirstOrDefaultAsync(x => x.TrainingCategoryId == id);

            if (category == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Training Category not found."
                });
            }

            // Later we'll add a check here:
            // if (!category.IsActive && category is referenced by Training)
            // {
            //     return Json(...);
            // }

            category.IsActive = !category.IsActive;
            category.ModifiedOn = DateTime.Now;
            category.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                isActive = category.IsActive,
                message = category.IsActive
                    ? "Training Category activated successfully."
                    : "Training Category deactivated successfully."
            });
        }
    }
}