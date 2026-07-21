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
    public class TrainingScheduleController : BaseController
    {
        private readonly TenantDbContext _context;

        public TrainingScheduleController
        (
            TenantDbContext context,
            MasterDbContext masterDbContext,
            UserManager<ApplicationUser> userManager
        ) : base(context, masterDbContext, userManager)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new TrainingScheduleViewModel
            {
                Trainings = await _context.TrainingMasters
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.TrainingName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.TrainingMasterId.ToString(),
                        Text = x.TrainingName
                    }).ToListAsync(),

                Trainers = await _context.TrainingTrainers
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.TrainerType)
                    .ThenBy(x => x.TrainerType == 1
                        ? x.Employee!.FirstName
                        : x.TrainerName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.TrainingTrainerId.ToString(),
                        Text = x.TrainerType == 1
                            ? x.Employee!.FirstName + " " + x.Employee.LastName
                            : x.TrainerName!
                    }).ToListAsync(),

                Venues = await _context.TrainingVenues
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.VenueName)
                    .Select(x => new SelectListItem
                    {
                        Value = x.TrainingVenueId.ToString(),
                        Text = x.VenueName
                    }).ToListAsync(),

                Departments = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = "0",
                        Text = "All Departments"
                    }
                }
            };

            var departments = await _context.Departments
                .Where(x => x.IsActive)
                .OrderBy(x => x.DepartmentName)
                .Select(x => new SelectListItem
                {
                    Value = x.DepartmentId.ToString(),
                    Text = x.DepartmentName
                })
                .ToListAsync();

            model.Departments.AddRange(departments);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedule(int id)
        {
            var schedule = await _context.TrainingSchedules
                .FirstOrDefaultAsync(x => x.TrainingScheduleId == id);

            if (schedule == null)
                return Json(new { success = false });

            var model = new TrainingScheduleViewModel
            {
                TrainingScheduleId = schedule.TrainingScheduleId,
                ScheduleCode = schedule.ScheduleCode,
                TrainingMasterId = schedule.TrainingMasterId,
                TrainingTrainerId = schedule.TrainingTrainerId,
                TrainingVenueId = schedule.TrainingVenueId,
                DepartmentId = schedule.DepartmentId,
                StartDate = schedule.StartDate,
                EndDate = schedule.EndDate,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                EnrollmentLastDate = schedule.EnrollmentLastDate,
                Capacity = schedule.Capacity,
                Remarks = schedule.Remarks,
                IsCancelled = schedule.IsCancelled,
                IsActive = schedule.IsActive
            };

            return Json(new
            {
                success = true,
                data = model
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingScheduleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please fill all required fields."
                });
            }

            if (model.EndDate < model.StartDate)
            {
                return Json(new
                {
                    success = false,
                    message = "End Date cannot be earlier than Start Date."
                });
            }

            if (model.EnrollmentLastDate.HasValue &&
                model.EnrollmentLastDate.Value > model.StartDate)
            {
                return Json(new
                {
                    success = false,
                    message = "Enrollment Last Date cannot be after the Start Date."
                });
            }

            if (model.EndDate == model.StartDate &&
                model.EndTime <= model.StartTime)
            {
                return Json(new
                {
                    success = false,
                    message = "End Time must be greater than Start Time."
                });
            }

            var schedule = new TrainingSchedule
            {
                ScheduleCode = await GenerateScheduleCode(),
                TrainingMasterId = model.TrainingMasterId,
                TrainingTrainerId = model.TrainingTrainerId,
                TrainingVenueId = model.TrainingVenueId,
                DepartmentId = model.DepartmentId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                EnrollmentLastDate = model.EnrollmentLastDate,
                Capacity = model.Capacity,
                Remarks = model.Remarks,
                IsCancelled = false,
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = GetCurrentEmployeeId()
            };

            _context.TrainingSchedules.Add(schedule);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Training Schedule created successfully."
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TrainingScheduleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please fill all required fields."
                });
            }

            var schedule = await _context.TrainingSchedules
                .FirstOrDefaultAsync(x => x.TrainingScheduleId == model.TrainingScheduleId);

            if (schedule == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Training Schedule not found."
                });
            }

            if (model.EndDate < model.StartDate)
            {
                return Json(new
                {
                    success = false,
                    message = "End Date cannot be earlier than Start Date."
                });
            }

            if (model.EnrollmentLastDate.HasValue &&
                model.EnrollmentLastDate.Value > model.StartDate)
            {
                return Json(new
                {
                    success = false,
                    message = "Enrollment Last Date cannot be after the Start Date."
                });
            }

            if (model.EndDate == model.StartDate &&
                model.EndTime <= model.StartTime)
            {
                return Json(new
                {
                    success = false,
                    message = "End Time must be greater than Start Time."
                });
            }

            schedule.TrainingMasterId = model.TrainingMasterId;
            schedule.TrainingTrainerId = model.TrainingTrainerId;
            schedule.TrainingVenueId = model.TrainingVenueId;
            schedule.DepartmentId = model.DepartmentId;
            schedule.StartDate = model.StartDate;
            schedule.EndDate = model.EndDate;
            schedule.StartTime = model.StartTime;
            schedule.EndTime = model.EndTime;
            schedule.EnrollmentLastDate = model.EnrollmentLastDate;
            schedule.Capacity = model.Capacity;
            schedule.Remarks = model.Remarks;
            schedule.IsCancelled = model.IsCancelled;

            schedule.ModifiedOn = DateTime.Now;
            schedule.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Training Schedule updated successfully."
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var schedule = await _context.TrainingSchedules
                .FirstOrDefaultAsync(x => x.TrainingScheduleId == id);

            if (schedule == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Training Schedule not found."
                });
            }

            schedule.IsActive = !schedule.IsActive;
            schedule.ModifiedOn = DateTime.Now;
            schedule.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = schedule.IsActive
                    ? "Training Schedule activated successfully."
                    : "Training Schedule deactivated successfully."
            });
        }
        private async Task<string> GenerateScheduleCode()
        {
            var lastCode = await _context.TrainingSchedules
                .OrderByDescending(x => x.TrainingScheduleId)
                .Select(x => x.ScheduleCode)
                .FirstOrDefaultAsync();

            int nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastCode) &&
                lastCode.StartsWith("SCH-") &&
                int.TryParse(lastCode.Substring(4), out int number))
            {
                nextNumber = number + 1;
            }

            return $"SCH-{nextNumber:D4}";
        }

        
        [HttpGet]
        public async Task<IActionResult> GetScheduleList()
        {
            var list = await _context.TrainingSchedules
                .Include(x => x.TrainingMaster)
                .Include(x => x.TrainingTrainer)
                .Include(x => x.TrainingVenue)
                .Include(x => x.Department)
                .OrderByDescending(x => x.StartDate)
                .Select(x => new
                {
                    x.TrainingScheduleId,
                    x.ScheduleCode,
                    x.TrainingMasterId,
                    TrainingName = x.TrainingMaster != null ? x.TrainingMaster.TrainingName : "-",
                    x.TrainingTrainerId,
                    TrainerName = x.TrainingTrainer != null ? (x.TrainingTrainer.TrainerType == 1 && x.TrainingTrainer.Employee != null ? x.TrainingTrainer.Employee.FirstName + " " + x.TrainingTrainer.Employee.LastName : x.TrainingTrainer.TrainerName) : "-",
                    x.TrainingVenueId,
                    VenueName = x.TrainingVenue != null ? x.TrainingVenue.VenueName : "-",
                    x.DepartmentId,
                    DepartmentName = x.DepartmentId == 0 ? "All Departments" : (x.Department != null ? x.Department.DepartmentName : "-"),
                    StartDateStr = x.StartDate.ToString("yyyy-MM-dd"),
                    EndDateStr = x.EndDate.ToString("yyyy-MM-dd"),
                    StartTimeStr = x.StartTime.ToString(@"hh\:mm"),
                    EndTimeStr = x.EndTime.ToString(@"hh\:mm"),
                    EnrollmentLastDateStr = x.EnrollmentLastDate.HasValue ? x.EnrollmentLastDate.Value.ToString("yyyy-MM-dd") : "",
                    x.Capacity,
                    x.Remarks,
                    x.IsCancelled,
                    x.IsActive
                }).ToListAsync();

            return Json(new { success = true, data = list });
        }
    }
}