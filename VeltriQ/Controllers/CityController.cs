using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class CityController : BaseController
    {
        private readonly TenantDbContext _context;

        public CityController
        (
            TenantDbContext context,

            MasterDbContext masterContext,

            UserManager<ApplicationUser> userManager
        )

            : base(context, masterContext, userManager)

        {
            _context = context;
        }
        // INDEX

        public async Task<IActionResult> Index()
        {
            var cities = await _context.Cities
                .Include(x => x.Country)
                .ToListAsync();

            return View(cities);
        }

        // CREATE

        public IActionResult Create()
        {
            LoadDropdowns();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(City model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;

                _context.Cities.Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            LoadDropdowns();

            return View(model);
        }

        // LOAD DROPDOWN

        private void LoadDropdowns()
        {
            ViewBag.CountryList = new SelectList(
                _context.Countries,
                "CountryId",
                "CountryName"
            );
        }
    }
}