using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.ViewModels.InductionProgram;

namespace VeltriQ.Controllers
{
    public class InductionProgramController : BaseController
    {
        public InductionProgramController
        (
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager
        )
            : base(context, masterContext, userManager)
        {
        }

        public IActionResult Index()
        {
            var model = new InductionProgramIndexViewModel();

            return View(model);
        }
        [HttpGet]
        public IActionResult GetPrograms()
        {
            var programs = _context.InductionProgramMasters
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new InductionProgramListItemViewModel
                {
                    InductionProgramMasterId = x.InductionProgramMasterId,
                    ProgramCode = x.ProgramCode,
                    ProgramName = x.ProgramName,
                    Description = x.Description,
                    DurationInDays = x.DurationInDays,
                    IsActive = x.IsActive,
                    CreatedOn = x.CreatedOn
                })
                .ToList();

            return Json(new
            {
                success = true,
                data = programs
            });
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new InductionProgramCreateViewModel();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InductionProgramCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Please correct the validation errors."
                    });
                }

                bool exists = _context.InductionProgramMasters.Any(x =>
                    x.ProgramName.Trim().ToLower() == model.ProgramName.Trim().ToLower());

                if (exists)
                {
                    return Json(new
                    {
                        success = false,
                        message = "An induction program with the same name already exists."
                    });
                }

                string nextCode = GenerateProgramCode();

                var program = new InductionProgramMaster
                {
                    ProgramCode = nextCode,
                    ProgramName = model.ProgramName.Trim(),
                    Description = model.Description?.Trim(),
                    DurationInDays = model.DurationInDays,
                    IsActive = model.IsActive,
                    CreatedOn = DateTime.Now,
                    CreatedBy = User.Identity?.Name
                };

                _context.InductionProgramMasters.Add(program);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Induction program created successfully."
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    success = false,
                    message = "An error occurred while saving the induction program."
                });
            }
        }
        private string GenerateProgramCode()
        {
            var lastProgram = _context.InductionProgramMasters
                .OrderByDescending(x => x.InductionProgramMasterId)
                .FirstOrDefault();

            if (lastProgram == null)
            {
                return "IND-0001";
            }

            var lastNumber = 0;

            if (!string.IsNullOrWhiteSpace(lastProgram.ProgramCode))
            {
                int.TryParse(lastProgram.ProgramCode.Replace("IND-", ""), out lastNumber);
            }

            return $"IND-{(lastNumber + 1):D4}";
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var program = _context.InductionProgramMasters
                .FirstOrDefault(x => x.InductionProgramMasterId == id);

            if (program == null)
            {
                return NotFound();
            }

            var model = new InductionProgramEditViewModel
            {
                InductionProgramMasterId = program.InductionProgramMasterId,
                ProgramName = program.ProgramName,
                Description = program.Description,
                DurationInDays = program.DurationInDays,
                IsActive = program.IsActive
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InductionProgramEditViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Please correct the validation errors."
                    });
                }

                var program = _context.InductionProgramMasters
                    .FirstOrDefault(x => x.InductionProgramMasterId == model.InductionProgramMasterId);

                if (program == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Induction program not found."
                    });
                }

                bool exists = _context.InductionProgramMasters.Any(x =>
                    x.InductionProgramMasterId != model.InductionProgramMasterId &&
                    x.ProgramName.Trim().ToLower() == model.ProgramName.Trim().ToLower());

                if (exists)
                {
                    return Json(new
                    {
                        success = false,
                        message = "An induction program with the same name already exists."
                    });
                }

                program.ProgramName = model.ProgramName.Trim();
                program.Description = model.Description?.Trim();
                program.DurationInDays = model.DurationInDays;
                program.IsActive = model.IsActive;
                program.ModifiedOn = DateTime.Now;
                program.ModifiedBy = User.Identity?.Name;

                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Induction program updated successfully."
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    success = false,
                    message = "An error occurred while updating the induction program."
                });
            }
        }
        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            try
            {
                var program = _context.InductionProgramMasters
                    .FirstOrDefault(x => x.InductionProgramMasterId == id);

                if (program == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Induction program not found."
                    });
                }

                program.IsActive = !program.IsActive;
                program.ModifiedOn = DateTime.Now;
                program.ModifiedBy = User.Identity?.Name;

                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    isActive = program.IsActive,
                    message = program.IsActive
                        ? "Induction program activated successfully."
                        : "Induction program deactivated successfully."
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    success = false,
                    message = "An error occurred while updating the program status."
                });
            }
        }
    }
}