using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;
using VeltriQ.Models.Training;
using VeltriQ.ViewModels.Training;

namespace VeltriQ.Controllers
{
    public class TrainingTrainerController : BaseController
    {
        private readonly TenantDbContext _context;

        public TrainingTrainerController(
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager)
            : base(context, masterContext, userManager)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new TrainingTrainerViewModel
            {
                Employees = await _context.Employees
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.FirstName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.EmployeeId.ToString(),
                        Text = x.EmployeeCode + " - " + x.FirstName + " " + x.LastName
                    }).ToListAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetTrainer(int id)
        {
            var trainer = await _context.TrainingTrainers
                .Include(x => x.Employee)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TrainingTrainerId == id);

            if (trainer == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Trainer not found."
                });
            }

            return Json(new
            {
                success = true,
                data = new
                {
                    trainer.TrainingTrainerId,
                    trainer.TrainerCode,
                    trainer.TrainerType,
                    trainer.EmployeeId,
                    trainer.TrainerName,
                    trainer.MobileNo,
                    trainer.Email,
                    trainer.IsActive
                }
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingTrainerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please fill all required fields."
                });
            }

            if (model.TrainerType == 1)
            {
                if (model.EmployeeId == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Please select an employee."
                    });
                }

                bool employeeExists = await _context.TrainingTrainers
                    .AnyAsync(x => x.EmployeeId == model.EmployeeId);

                if (employeeExists)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Selected employee is already added as trainer."
                    });
                }

                string code = await GenerateTrainerCode();

                var entity = new TrainingTrainer
                {
                    TrainerCode = code,
                    TrainerType = model.TrainerType,
                    EmployeeId = model.EmployeeId,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = GetCurrentEmployeeId()
                };

                _context.TrainingTrainers.Add(entity);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Internal trainer created successfully."
                });
            }

            if (string.IsNullOrWhiteSpace(model.TrainerName))
            {
                return Json(new
                {
                    success = false,
                    message = "Trainer name is required."
                });
            }

            if (string.IsNullOrWhiteSpace(model.MobileNo))
            {
                return Json(new
                {
                    success = false,
                    message = "Mobile number is required."
                });
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return Json(new
                {
                    success = false,
                    message = "Email is required."
                });
            }

            bool duplicateExternal = await _context.TrainingTrainers.AnyAsync(x =>
                x.TrainerType == 2 &&
                x.TrainerName!.Trim().ToLower() == model.TrainerName.Trim().ToLower());

            if (duplicateExternal)
            {
                return Json(new
                {
                    success = false,
                    message = "External trainer already exists."
                });
            }

            string trainerCode = await GenerateTrainerCode();

            var externalTrainer = new TrainingTrainer
            {
                TrainerCode = trainerCode,
                TrainerType = 2,
                TrainerName = model.TrainerName.Trim(),
                MobileNo = model.MobileNo.Trim(),
                Email = model.Email.Trim(),
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = GetCurrentEmployeeId()
            };

            _context.TrainingTrainers.Add(externalTrainer);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "External trainer created successfully."
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TrainingTrainerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please fill all required fields."
                });
            }

            var entity = await _context.TrainingTrainers
                .FirstOrDefaultAsync(x => x.TrainingTrainerId == model.TrainingTrainerId);

            if (entity == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Trainer not found."
                });
            }

            if (model.TrainerType == 1)
            {
                if (model.EmployeeId == null)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Please select an employee."
                    });
                }

                bool employeeExists = await _context.TrainingTrainers.AnyAsync(x =>
                    x.TrainingTrainerId != model.TrainingTrainerId &&
                    x.EmployeeId == model.EmployeeId);

                if (employeeExists)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Selected employee is already added as trainer."
                    });
                }

                entity.TrainerType = 1;
                entity.EmployeeId = model.EmployeeId;

                // Clear external trainer fields
                entity.TrainerName = null;
                entity.MobileNo = null;
                entity.Email = null;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(model.TrainerName))
                {
                    return Json(new
                    {
                        success = false,
                        message = "Trainer name is required."
                    });
                }

                if (string.IsNullOrWhiteSpace(model.MobileNo))
                {
                    return Json(new
                    {
                        success = false,
                        message = "Mobile number is required."
                    });
                }

                if (string.IsNullOrWhiteSpace(model.Email))
                {
                    return Json(new
                    {
                        success = false,
                        message = "Email is required."
                    });
                }

                bool duplicateExternal = await _context.TrainingTrainers.AnyAsync(x =>
                    x.TrainingTrainerId != model.TrainingTrainerId &&
                    x.TrainerType == 2 &&
                    x.TrainerName!.Trim().ToLower() == model.TrainerName.Trim().ToLower());

                if (duplicateExternal)
                {
                    return Json(new
                    {
                        success = false,
                        message = "External trainer already exists."
                    });
                }

                entity.TrainerType = 2;
                entity.EmployeeId = null;
                entity.TrainerName = model.TrainerName.Trim();
                entity.MobileNo = model.MobileNo.Trim();
                entity.Email = model.Email.Trim();
            }

            entity.ModifiedOn = DateTime.Now;
            entity.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Trainer updated successfully."
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var entity = await _context.TrainingTrainers
                .FirstOrDefaultAsync(x => x.TrainingTrainerId == id);

            if (entity == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Trainer not found."
                });
            }

            entity.IsActive = !entity.IsActive;
            entity.ModifiedOn = DateTime.Now;
            entity.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = entity.IsActive
                    ? "Trainer activated successfully."
                    : "Trainer deactivated successfully."
            });
        }
        private async Task<string> GenerateTrainerCode()
        {
            var lastCode = await _context.TrainingTrainers
                .OrderByDescending(x => x.TrainingTrainerId)
                .Select(x => x.TrainerCode)
                .FirstOrDefaultAsync();

            int nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastCode) &&
                lastCode.StartsWith("TRR-") &&
                int.TryParse(lastCode.Substring(4), out int number))
            {
                nextNumber = number + 1;
            }

            return $"TRR-{nextNumber:D4}";
        }

        [HttpGet]
        public async Task<IActionResult> GetTrainerList()
        {
            var list = await _context.TrainingTrainers
                .Include(x => x.Employee)
                .OrderBy(x => x.TrainerCode)
                .Select(x => new
                {
                    x.TrainingTrainerId,
                    x.TrainerCode,
                    x.TrainerType,

                    TrainerTypeText = x.TrainerType == 1
                        ? "Internal"
                        : "External",

                    TrainerName = x.TrainerType == 1
                        ? ((x.Employee != null)
                            ? (x.Employee.FirstName ?? "") +
                              ((x.Employee.LastName ?? "") == "" ? "" : " " + x.Employee.LastName)
                            : "-")
                        : x.TrainerName,

                    MobileNo = x.TrainerType == 1
                        ? (x.Employee != null ? x.Employee.PhoneNumber : "")
                        : x.MobileNo,

                    Email = x.TrainerType == 1
                        ? (x.Employee != null ? x.Employee.OfficialEmail : "")
                        : x.Email,

                    EmployeeId = x.EmployeeId,

                    EmployeeCode = x.Employee != null
                        ? x.Employee.EmployeeCode
                        : "",

                    x.IsActive
                })
                .ToListAsync();

            return Json(new
            {
                success = true,
                data = list
            });
        }
    }
}