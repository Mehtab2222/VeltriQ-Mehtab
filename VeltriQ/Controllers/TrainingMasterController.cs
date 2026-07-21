using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.Models.Training;
using VeltriQ.ViewModels.Training;

namespace VeltriQ.Controllers
{
    public class TrainingMasterController : BaseController
    {
        private readonly TenantDbContext _context;

        public TrainingMasterController(
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager)
            : base(context, masterContext, userManager)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new TrainingMasterViewModel
            {
                TrainingCategories = await _context.TrainingCategories
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.CategoryName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.TrainingCategoryId.ToString(),
                        Text = x.CategoryName
                    }).ToListAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetTrainingMaster(int id)
        {
            var training = await _context.TrainingMasters
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TrainingMasterId == id);

            if (training == null)
                return Json(new { success = false, message = "Training not found." });

            return Json(new
            {
                success = true,
                data = training
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingMasterViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Please fill all required fields." });

            bool exists = await _context.TrainingMasters.AnyAsync(x =>
                x.TrainingCategoryId == model.TrainingCategoryId &&
                x.TrainingName.Trim().ToLower() == model.TrainingName.Trim().ToLower());

            if (exists)
                return Json(new { success = false, message = "Training already exists in this category." });

            string code = await GenerateTrainingCode();

            var entity = new TrainingMaster
            {
                TrainingCode = code,
                TrainingName = model.TrainingName.Trim(),
                TrainingCategoryId = model.TrainingCategoryId,
                Duration = model.Duration,
                DurationType = model.DurationType,
                IsMandatory = model.IsMandatory,
                IsAssessmentRequired = model.IsAssessmentRequired,
                IsCertificateRequired = model.IsCertificateRequired,
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = GetCurrentEmployeeId()
            };

            _context.TrainingMasters.Add(entity);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Training created successfully."
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TrainingMasterViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Please fill all required fields." });

            var entity = await _context.TrainingMasters
                .FirstOrDefaultAsync(x => x.TrainingMasterId == model.TrainingMasterId);

            if (entity == null)
                return Json(new { success = false, message = "Training not found." });

            bool exists = await _context.TrainingMasters.AnyAsync(x =>
                x.TrainingMasterId != model.TrainingMasterId &&
                x.TrainingCategoryId == model.TrainingCategoryId &&
                x.TrainingName.Trim().ToLower() == model.TrainingName.Trim().ToLower());

            if (exists)
                return Json(new { success = false, message = "Training already exists in this category." });

            entity.TrainingName = model.TrainingName.Trim();
            entity.TrainingCategoryId = model.TrainingCategoryId;
            entity.Duration = model.Duration;
            entity.DurationType = model.DurationType;
            entity.IsMandatory = model.IsMandatory;
            entity.IsAssessmentRequired = model.IsAssessmentRequired;
            entity.IsCertificateRequired = model.IsCertificateRequired;
            entity.ModifiedOn = DateTime.Now;
            entity.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Training updated successfully."
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var entity = await _context.TrainingMasters
                .FirstOrDefaultAsync(x => x.TrainingMasterId == id);

            if (entity == null)
                return Json(new { success = false, message = "Training not found." });

            entity.IsActive = !entity.IsActive;
            entity.ModifiedOn = DateTime.Now;
            entity.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = entity.IsActive
                    ? "Training activated successfully."
                    : "Training deactivated successfully."
            });
        }

        private async Task<string> GenerateTrainingCode()
        {
            var lastCode = await _context.TrainingMasters
                .OrderByDescending(x => x.TrainingMasterId)
                .Select(x => x.TrainingCode)
                .FirstOrDefaultAsync();

            int nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastCode) &&
                lastCode.StartsWith("TRN-") &&
                int.TryParse(lastCode.Substring(4), out int number))
            {
                nextNumber = number + 1;
            }

            return $"TRN-{nextNumber:D4}";
        }
        [HttpGet]
        public async Task<IActionResult> GetTrainingList()
        {
            var list = await _context.TrainingMasters
                .Include(x => x.TrainingCategory)
                .OrderBy(x => x.TrainingName)
                .Select(x => new
                {
                    x.TrainingMasterId,
                    x.TrainingCode,
                    x.TrainingName,
                    x.TrainingCategoryId,
                    CategoryName = x.TrainingCategory != null ? x.TrainingCategory.CategoryName : "-",
                    x.Duration,
                    x.DurationType,
                    DurationText = x.DurationType == 1 ? "Minutes" : x.DurationType == 2 ? "Hours" : "Days",
                    x.IsMandatory,
                    x.IsAssessmentRequired,
                    x.IsCertificateRequired,
                    x.IsActive
                }).ToListAsync();

            return Json(new { success = true, data = list });
        }
    }
}