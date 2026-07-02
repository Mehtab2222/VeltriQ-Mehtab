using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR.Onboarding;
using VeltriQ.ViewModels.OnboardingPolicy;

namespace VeltriQ.Controllers
{
    public class OnboardingPolicyController : BaseController
    {
        private readonly TenantDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public OnboardingPolicyController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment
        )
            : base(context, masterContext, userManager)
        {
            _context = context;
            _environment = environment;
        }

        //====================================================
        // INDEX
        //====================================================

        [HttpGet]
        public async Task<IActionResult> Index(string searchText = "")
        {
            var model = new OnboardingPolicyIndexViewModel
            {
                SearchText = searchText
            };

            var query = _context.OnboardingPolicyMasters

                .Include(x => x.PolicyCategory)

                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.Trim();

                query = query.Where(x =>

                    x.PolicyName.Contains(searchText) ||

                    (x.Description != null &&
                     x.Description.Contains(searchText)) ||

                    (x.PolicyCategory != null &&
                     x.PolicyCategory.CategoryName.Contains(searchText)));
            }

            model.Policies = await query

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new OnboardingPolicyListItemViewModel
                {
                    OnboardingPolicyMasterId = x.OnboardingPolicyMasterId,

                    PolicyName = x.PolicyName,

                    Description = x.Description ?? "",

                    CategoryName = x.PolicyCategory != null
                        ? x.PolicyCategory.CategoryName
                        : "",

                    PolicyVersion = x.PolicyVersion,

                    EffectiveDate = x.EffectiveDate,

                    IsMandatory = x.IsMandatory,

                    RequiresAcceptance = x.RequiresAcceptance,

                    AllowDownload = x.AllowDownload,

                    FileName = x.FileName,

                    DisplayOrder = x.DisplayOrder,

                    IsActive = x.IsActive
                })

                .ToListAsync();

            return View(model);
        }
        //====================================================
        // CREATE
        //====================================================

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new OnboardingPolicyCreateViewModel
            {
                PolicyVersion = "1.0",

                EffectiveDate = DateTime.Today,

                IsMandatory = true,

                RequiresAcceptance = true,

                AllowDownload = true,

                DisplayOrder = await _context.OnboardingPolicyMasters.AnyAsync()
                    ? await _context.OnboardingPolicyMasters.MaxAsync(x => x.DisplayOrder) + 1
                    : 1
            };

            model.Categories = await _context.OnboardingPolicyCategoryMasters

                .Where(x => x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new SelectListItem
                {
                    Value = x.OnboardingPolicyCategoryMasterId.ToString(),
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
            OnboardingPolicyCreateViewModel model)
        {
            // Reload dropdown
            model.Categories = await _context.OnboardingPolicyCategoryMasters

                .Where(x => x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new SelectListItem
                {
                    Value = x.OnboardingPolicyCategoryMasterId.ToString(),
                    Text = x.CategoryName
                })

                .ToListAsync();

            if (!ModelState.IsValid)
                return View(model);

            //====================================================
            // DUPLICATE POLICY NAME
            //====================================================

            var exists = await _context.OnboardingPolicyMasters
                .AnyAsync(x =>
                    x.IsActive &&
                    x.PolicyName.ToLower() ==
                    model.PolicyName.Trim().ToLower());

            if (exists)
            {
                ModelState.AddModelError(
                    nameof(model.PolicyName),
                    "Policy already exists.");

                return View(model);
            }

            //====================================================
            // GENERATE POLICY CODE
            //====================================================

            var policyCode = new string(
                model.PolicyName
                    .Trim()
                    .ToUpper()
                    .Where(char.IsLetterOrDigit)
                    .ToArray());

            string? fileName = null;
            string? filePath = null;

            //====================================================
            // UPLOAD POLICY PDF
            //====================================================

            if (model.PolicyFile != null &&
                model.PolicyFile.Length > 0)
            {
                var extension = Path.GetExtension(model.PolicyFile.FileName)
                    .ToLower();

                if (extension != ".pdf")
                {
                    ModelState.AddModelError(
                        nameof(model.PolicyFile),
                        "Only PDF files are allowed.");

                    return View(model);
                }

                var uploadsFolder = Path.Combine(
                    _environment.WebRootPath,
                    "uploads",
                    "policies");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                fileName =
                    Guid.NewGuid() +
                    extension;

                var fullPath = Path.Combine(
                    uploadsFolder,
                    fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.PolicyFile.CopyToAsync(stream);
                }

                filePath =
                    "/uploads/policies/" +
                    fileName;
            }

            //====================================================
            // SAVE
            //====================================================

            var entity = new OnboardingPolicyMaster
            {
                OnboardingPolicyCategoryMasterId =
                    model.OnboardingPolicyCategoryMasterId,

                PolicyCode = policyCode,

                PolicyName = model.PolicyName.Trim(),

                Description =
                    string.IsNullOrWhiteSpace(model.Description)
                    ? null
                    : model.Description.Trim(),

                PolicyVersion = model.PolicyVersion,

                EffectiveDate = model.EffectiveDate,

                IsMandatory = model.IsMandatory,

                RequiresAcceptance = model.RequiresAcceptance,

                AllowDownload = model.AllowDownload,

                DisplayOrder = model.DisplayOrder,

                FileName = fileName,

                FilePath = filePath,

                IsActive = true,

                CreatedOn = DateTime.Now,

                CreatedBy = User.Identity?.Name
            };

            _context.OnboardingPolicyMasters.Add(entity);

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Policy created successfully.";

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
            var entity = await _context.OnboardingPolicyMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingPolicyMasterId == id);

            if (entity == null)
                return NotFound();

            var model = new OnboardingPolicyEditViewModel
            {
                OnboardingPolicyMasterId = entity.OnboardingPolicyMasterId,

                PolicyName = entity.PolicyName,

                Description = entity.Description,

                OnboardingPolicyCategoryMasterId =
                    entity.OnboardingPolicyCategoryMasterId,

                PolicyVersion = entity.PolicyVersion,

                EffectiveDate = entity.EffectiveDate,

                IsMandatory = entity.IsMandatory,

                RequiresAcceptance = entity.RequiresAcceptance,

                AllowDownload = entity.AllowDownload,

                DisplayOrder = entity.DisplayOrder,

                ExistingFileName = entity.FileName,

                ExistingFilePath = entity.FilePath
            };

            model.Categories = await _context.OnboardingPolicyCategoryMasters

                .Where(x => x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new SelectListItem
                {
                    Value = x.OnboardingPolicyCategoryMasterId.ToString(),
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
            OnboardingPolicyEditViewModel model)
        {
            // Reload dropdown
            model.Categories = await _context.OnboardingPolicyCategoryMasters

                .Where(x => x.IsActive)

                .OrderBy(x => x.DisplayOrder)

                .Select(x => new SelectListItem
                {
                    Value = x.OnboardingPolicyCategoryMasterId.ToString(),
                    Text = x.CategoryName
                })

                .ToListAsync();

            if (!ModelState.IsValid)
                return View(model);

            var entity = await _context.OnboardingPolicyMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingPolicyMasterId ==
                    model.OnboardingPolicyMasterId);

            if (entity == null)
                return NotFound();

            //====================================================
            // DUPLICATE POLICY NAME
            //====================================================

            var exists = await _context.OnboardingPolicyMasters
                .AnyAsync(x =>
                    x.OnboardingPolicyMasterId !=
                    model.OnboardingPolicyMasterId &&
                    x.IsActive &&
                    x.PolicyName.ToLower() ==
                    model.PolicyName.Trim().ToLower());

            if (exists)
            {
                ModelState.AddModelError(
                    nameof(model.PolicyName),
                    "Policy already exists.");

                return View(model);
            }

            //====================================================
            // REPLACE PDF (OPTIONAL)
            //====================================================

            if (model.PolicyFile != null &&
                model.PolicyFile.Length > 0)
            {
                var extension = Path.GetExtension(model.PolicyFile.FileName)
                    .ToLower();

                if (extension != ".pdf")
                {
                    ModelState.AddModelError(
                        nameof(model.PolicyFile),
                        "Only PDF files are allowed.");

                    return View(model);
                }

                var uploadsFolder = Path.Combine(
                    _environment.WebRootPath,
                    "uploads",
                    "policies");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                // Delete existing file
                if (!string.IsNullOrWhiteSpace(entity.FilePath))
                {
                    var existingFile = Path.Combine(
                        _environment.WebRootPath,
                        entity.FilePath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));

                    if (System.IO.File.Exists(existingFile))
                    {
                        System.IO.File.Delete(existingFile);
                    }
                }

                var fileName =
                    Guid.NewGuid() +
                    extension;

                var fullPath = Path.Combine(
                    uploadsFolder,
                    fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.PolicyFile.CopyToAsync(stream);
                }

                entity.FileName = model.PolicyFile.FileName;

                entity.FilePath = "/uploads/policies/" + fileName;
            }

            //====================================================
            // UPDATE
            //====================================================

            entity.PolicyName = model.PolicyName.Trim();

            entity.Description =
                string.IsNullOrWhiteSpace(model.Description)
                ? null
                : model.Description.Trim();

            entity.OnboardingPolicyCategoryMasterId =
                model.OnboardingPolicyCategoryMasterId;

            entity.PolicyVersion = model.PolicyVersion;

            entity.EffectiveDate = model.EffectiveDate;

            entity.IsMandatory = model.IsMandatory;

            entity.RequiresAcceptance = model.RequiresAcceptance;

            entity.AllowDownload = model.AllowDownload;

            entity.DisplayOrder = model.DisplayOrder;

            entity.ModifiedOn = DateTime.Now;

            entity.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Policy updated successfully.";

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
            var policy = await _context.OnboardingPolicyMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingPolicyMasterId == id);

            if (policy == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Policy not found."
                });
            }

            policy.IsActive = true;

            policy.ModifiedOn = DateTime.Now;

            policy.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Policy activated successfully."
            });
        }

        //====================================================
        // DEACTIVATE
        //====================================================

        [HttpPost]
        public async Task<IActionResult> Deactivate([FromBody] int id)
        {
            var policy = await _context.OnboardingPolicyMasters
                .FirstOrDefaultAsync(x =>
                    x.OnboardingPolicyMasterId == id);

            if (policy == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Policy not found."
                });
            }

            //====================================================
            // CHECK IF USED IN ACTIVE TEMPLATES
            //====================================================

            var isUsed = await _context.OnboardingTemplatePolicies
                .AnyAsync(x =>
                    x.OnboardingPolicyMasterId == id &&
                    x.IsActive);

            if (isUsed)
            {
                return Json(new
                {
                    success = false,
                    message = "This policy is currently used in one or more onboarding templates. Remove it from the template(s) before deactivating it."
                });
            }

            policy.IsActive = false;

            policy.ModifiedOn = DateTime.Now;

            policy.ModifiedBy = User.Identity?.Name;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Policy deactivated successfully."
            });
        }
    }
}