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
    public class TrainingVenueController : BaseController
    {
        private readonly TenantDbContext _context;

        public TrainingVenueController(
            TenantDbContext context,
            MasterDbContext masterContext,
            UserManager<ApplicationUser> userManager)
            : base(context, masterContext, userManager)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new TrainingVenueViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetVenue(int id)
        {
            var venue = await _context.TrainingVenues
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TrainingVenueId == id);

            if (venue == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Venue not found."
                });
            }

            return Json(new
            {
                success = true,
                data = venue
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingVenueViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please fill all required fields."
                });
            }

            if (model.VenueType == 2 && string.IsNullOrWhiteSpace(model.Address))
            {
                return Json(new
                {
                    success = false,
                    message = "Address is required for External Venue."
                });
            }

            bool exists = await _context.TrainingVenues.AnyAsync(x =>
                x.VenueName.Trim().ToLower() == model.VenueName.Trim().ToLower());

            if (exists)
            {
                return Json(new
                {
                    success = false,
                    message = "Venue already exists."
                });
            }

            string venueCode = await GenerateVenueCode();

            var entity = new TrainingVenue
            {
                VenueCode = venueCode,
                VenueName = model.VenueName.Trim(),
                VenueType = model.VenueType,
                Capacity = model.Capacity,
                Address = model.VenueType == 2
                    ? model.Address?.Trim()
                    : null,
                IsActive = true,
                CreatedOn = DateTime.Now,
                CreatedBy = GetCurrentEmployeeId()
            };

            _context.TrainingVenues.Add(entity);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Venue created successfully."
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TrainingVenueViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please fill all required fields."
                });
            }

            var entity = await _context.TrainingVenues
                .FirstOrDefaultAsync(x => x.TrainingVenueId == model.TrainingVenueId);

            if (entity == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Venue not found."
                });
            }

            if (model.VenueType == 2 && string.IsNullOrWhiteSpace(model.Address))
            {
                return Json(new
                {
                    success = false,
                    message = "Address is required for External Venue."
                });
            }

            bool exists = await _context.TrainingVenues.AnyAsync(x =>
                x.TrainingVenueId != model.TrainingVenueId &&
                x.VenueName.Trim().ToLower() == model.VenueName.Trim().ToLower());

            if (exists)
            {
                return Json(new
                {
                    success = false,
                    message = "Venue already exists."
                });
            }

            entity.VenueName = model.VenueName.Trim();
            entity.VenueType = model.VenueType;
            entity.Capacity = model.Capacity;
            entity.Address = model.VenueType == 2
                ? model.Address?.Trim()
                : null;

            entity.ModifiedOn = DateTime.Now;
            entity.ModifiedBy = GetCurrentEmployeeId();

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Venue updated successfully."
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var entity = await _context.TrainingVenues
                .FirstOrDefaultAsync(x => x.TrainingVenueId == id);

            if (entity == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Venue not found."
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
                    ? "Venue activated successfully."
                    : "Venue deactivated successfully."
            });
        }
        private async Task<string> GenerateVenueCode()
        {
            var lastCode = await _context.TrainingVenues
                .OrderByDescending(x => x.TrainingVenueId)
                .Select(x => x.VenueCode)
                .FirstOrDefaultAsync();

            int nextNumber = 1;

            if (!string.IsNullOrWhiteSpace(lastCode) &&
                lastCode.StartsWith("VEN-") &&
                int.TryParse(lastCode.Substring(4), out int number))
            {
                nextNumber = number + 1;
            }

            return $"VEN-{nextNumber:D4}";
        }

        [HttpGet]
        public async Task<IActionResult> GetVenueList()
        {
            var list = await _context.TrainingVenues
                .OrderBy(x => x.VenueName)
                .Select(x => new
                {
                    x.TrainingVenueId,
                    x.VenueCode,
                    x.VenueName,
                    x.VenueType,

                    VenueTypeText = x.VenueType == 1
                        ? "Internal"
                        : x.VenueType == 2
                            ? "External"
                            : "Online",

                    x.Capacity,
                    x.Address,
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