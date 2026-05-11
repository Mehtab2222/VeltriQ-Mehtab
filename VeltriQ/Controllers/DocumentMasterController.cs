using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class DocumentMasterController : BaseController
    {
        private readonly TenantDbContext _context;

        public DocumentMasterController
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
            var documents = await _context.DocumentMasters
                .ToListAsync();

            return View(documents);
        }

        // CREATE

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DocumentMaster model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;

                _context.DocumentMasters.Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}