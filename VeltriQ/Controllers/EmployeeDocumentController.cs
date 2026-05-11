using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.HR;

namespace VeltriQ.Controllers
{
    public class EmployeeDocumentController : BaseController
    {
        private readonly TenantDbContext _context;

        private readonly IWebHostEnvironment _environment;

        public EmployeeDocumentController
        (
            TenantDbContext context,

            MasterDbContext masterContext,

            IWebHostEnvironment environment,

            UserManager<ApplicationUser> userManager
        )

            : base(context, masterContext, userManager)

        {
            _context = context;

            _environment = environment;
        }

        // DOCUMENT LIST

        public async Task<IActionResult> Index(int employeeId)
        {
            ViewBag.EmployeeId = employeeId;

            var documents = await _context.EmployeeDocuments

                .Include(x => x.DocumentMaster)

                .Where(x => x.EmployeeId == employeeId)

                .ToListAsync();

            return PartialView("_EmployeeDocumentsPartial", documents);
        }
        // CREATE

        public IActionResult Create(int employeeId)
        {
            ViewBag.EmployeeId = employeeId;

            LoadDropdowns();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create
        (
            EmployeeDocument model,
            IFormFile? documentFile
        )
        {
            if (ModelState.IsValid)
            {
                // FILE UPLOAD

                if (documentFile != null)
                {
                    string uploadFolder = Path.Combine
                    (
                        _environment.WebRootPath,
                        "uploads",
                        "employees",
                        "documents"
                    );

                    // CREATE FOLDER IF NOT EXISTS

                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // UNIQUE FILE NAME

                    string uniqueFileName =
                        Guid.NewGuid().ToString()
                        + "_"
                        + documentFile.FileName;

                    string filePath = Path.Combine
                    (
                        uploadFolder,
                        uniqueFileName
                    );

                    // SAVE FILE

                    using (var stream = new FileStream
                    (
                        filePath,
                        FileMode.Create
                    ))
                    {
                        await documentFile.CopyToAsync(stream);
                    }

                    // STORE INFO

                    model.FileName = documentFile.FileName;

                    model.FilePath =
                        "/uploads/employees/documents/"
                        + uniqueFileName;
                }

                model.CreatedOn = DateTime.Now;

                model.IsActive = true;

                _context.EmployeeDocuments.Add(model);

                await _context.SaveChangesAsync();

                return RedirectToAction
                (
                    "Profile",
                    "Employee",
                    new { id = model.EmployeeId }
                );
            }

            LoadDropdowns();

            return View(model);
        }

        // LOAD DROPDOWNS

        private void LoadDropdowns()
        {
            ViewBag.DocumentList = new SelectList
            (
                _context.DocumentMasters,
                "DocumentMasterId",
                "DocumentName"
            );
        }
    }
}