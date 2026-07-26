using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Core;
using VeltriQ.Models.Recruitment;
using VeltriQ.ViewModels.Recruitment;

namespace VeltriQ.Controllers
{
    [Authorize]
    public class InterviewPoolController : BaseController
    {
        private readonly TenantDbContext _context;

        public InterviewPoolController(
            TenantDbContext context,
            MasterDbContext masterDbContext,
            UserManager<ApplicationUser> userManager)
            : base(context, masterDbContext, userManager)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetPools()
        {
            try
            {
                var data = await _context.InterviewPools
                    .Where(x => x.IsActive)
                    .Include(x => x.RoundType)
                    .Include(x => x.Department)
                    .Include(x => x.Branch)
                    .Select(x => new InterviewPoolListItemViewModel
                    {
                        InterviewPoolId = x.InterviewPoolId,
                        PoolName = x.PoolName,
                        Description = x.Description,
                        RoundTypeName = x.RoundType != null
                                            ? x.RoundType.RoundTypeName
                                            : "",

                        DepartmentName = x.Department != null
                                            ? x.Department.DepartmentName
                                            : "All Departments",

                        BranchName = x.Branch != null
                                            ? x.Branch.BranchName
                                            : "All Branches",

                        MemberCount = x.Members.Count(m => m.IsActive)
                    })
                    .OrderBy(x => x.PoolName)
                    .ToListAsync();

                return Json(new
                {
                    success = true,
                    data
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRoundTypes()
        {
            var data = await _context.RoundTypes
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new
                {
                    x.RoundTypeId,
                    x.RoundTypeName
                })
                .ToListAsync();

            return Json(new
            {
                success = true,
                data
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var data = await _context.Departments
                .Where(x => x.IsActive)
                .OrderBy(x => x.DepartmentName)
                .Select(x => new
                {
                    x.DepartmentId,
                    x.DepartmentName
                })
                .ToListAsync();

            return Json(new
            {
                success = true,
                data
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePool([FromBody] CreateInterviewPoolDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new
                    {
                        success = false,
                        message = "Invalid request."
                    });
                }

                bool exists = await _context.InterviewPools.AnyAsync(x =>
                    x.IsActive &&
                    x.PoolName == dto.PoolName &&
                    x.RoundTypeId == dto.RoundTypeId &&
                    x.DepartmentId == dto.DepartmentId &&
                    x.BranchId == dto.BranchId);

                if (exists)
                {
                    return Json(new
                    {
                        success = false,
                        message = "A matching interview pool already exists."
                    });
                }

                var pool = new InterviewPool
                {
                    PoolName = dto.PoolName.Trim(),
                    Description = dto.Description,
                    RoundTypeId = dto.RoundTypeId,
                    DepartmentId = dto.DepartmentId,
                    BranchId = dto.BranchId,
                    AllowAutoAssignment = true,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = GetCurrentEmployeeId()
                };

                _context.InterviewPools.Add(pool);

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Interview Pool created successfully."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetBranches()
        {
            var data = await _context.Branches
                .Where(x => x.IsActive)
                .OrderBy(x => x.BranchName)
                .Select(x => new
                {
                    x.BranchId,
                    x.BranchName
                })
                .ToListAsync();

            return Json(new
            {
                success = true,
                data
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetPoolById(int poolId)
        {
            try
            {
                var pool = await _context.InterviewPools
                    .Where(x => x.InterviewPoolId == poolId && x.IsActive)
                    .Select(x => new UpdateInterviewPoolDto
                    {
                        InterviewPoolId = x.InterviewPoolId,
                        PoolName = x.PoolName,
                        Description = x.Description,
                        RoundTypeId = x.RoundTypeId,
                        DepartmentId = x.DepartmentId,
                        BranchId = x.BranchId
                    })
                    .FirstOrDefaultAsync();

                if (pool == null)
                    return Json(new { success = false, message = "Interview Pool not found." });

                return Json(new { success = true, data = pool });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePool([FromBody] UpdateInterviewPoolDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false, message = "Invalid request." });

                var pool = await _context.InterviewPools
                    .FirstOrDefaultAsync(x => x.InterviewPoolId == dto.InterviewPoolId);

                if (pool == null)
                    return Json(new { success = false, message = "Pool not found." });

                bool duplicate = await _context.InterviewPools.AnyAsync(x =>
                    x.InterviewPoolId != dto.InterviewPoolId &&
                    x.IsActive &&
                    x.PoolName == dto.PoolName &&
                    x.RoundTypeId == dto.RoundTypeId &&
                    x.DepartmentId == dto.DepartmentId &&
                    x.BranchId == dto.BranchId);

                if (duplicate)
                    return Json(new
                    {
                        success = false,
                        message = "Another Interview Pool already exists with the same configuration."
                    });

                pool.PoolName = dto.PoolName.Trim();
                pool.Description = dto.Description;
                pool.RoundTypeId = dto.RoundTypeId;
                pool.DepartmentId = dto.DepartmentId;
                pool.BranchId = dto.BranchId;

                pool.ModifiedOn = DateTime.Now;
                pool.ModifiedBy = GetCurrentEmployeeId();

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Interview Pool updated successfully."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePool(int poolId)
        {
            try
            {
                var pool = await _context.InterviewPools
                    .FirstOrDefaultAsync(x => x.InterviewPoolId == poolId);

                if (pool == null)
                    return Json(new
                    {
                        success = false,
                        message = "Interview Pool not found."
                    });

                pool.IsActive = false;
                pool.ModifiedOn = DateTime.Now;
                pool.ModifiedBy = GetCurrentEmployeeId();

                var members = await _context.InterviewPoolMembers
                    .Where(x => x.InterviewPoolId == poolId && x.IsActive)
                    .ToListAsync();

                foreach (var member in members)
                {
                    member.IsActive = false;
                    member.ModifiedOn = DateTime.Now;
                    member.ModifiedBy = GetCurrentEmployeeId();
                }

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Interview Pool deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPoolMembers(int poolId)
        {
            try
            {
                var members = await _context.InterviewPoolMembers
                    .Include(x => x.Employee)
                        .ThenInclude(e => e.Department)
                    .Where(x => x.InterviewPoolId == poolId && x.IsActive)
                    .OrderBy(x => x.Priority)
                    .Select(x => new InterviewPoolMemberViewModel
                    {
                        InterviewPoolMemberId = x.InterviewPoolMemberId,
                        EmployeeId = x.EmployeeId,
                        EmployeeCode = x.Employee.EmployeeCode ?? "",
                        EmployeeName = (x.Employee.FirstName + " " + (x.Employee.LastName ?? "")).Trim(),
                        DepartmentName = x.Employee.Department != null
                            ? x.Employee.Department.DepartmentName
                            : "",
                        Priority = x.Priority,
                        DailyCapacity = x.DailyCapacity
                    })
                    .ToListAsync();

                return Json(new
                {
                    success = true,
                    data = members
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetEligibleEmployees(string? search)
        {
            try
            {
                var query = _context.Employees
                    .Include(x => x.Department)
                    .Where(x => x.IsActive);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.Trim().ToLower();

                    query = query.Where(x =>
                        (x.FirstName ?? "").ToLower().Contains(search) ||
                        (x.LastName ?? "").ToLower().Contains(search) ||
                        (x.EmployeeCode ?? "").ToLower().Contains(search));
                }

                var data = await query
                    .OrderBy(x => x.FirstName)
                    .Take(50)
                    .Select(x => new
                    {
                        x.EmployeeId,
                        x.EmployeeCode,
                        EmployeeName = (x.FirstName + " " + (x.LastName ?? "")).Trim(),
                        Department = x.Department != null
                            ? x.Department.DepartmentName
                            : ""
                    })
                    .ToListAsync();

                return Json(new
                {
                    success = true,
                    data
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        public class AddPoolMemberDto
        {
            public int InterviewPoolId { get; set; }

            public int EmployeeId { get; set; }

            public int Priority { get; set; } = 1;

            public int DailyCapacity { get; set; } = 8;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPoolMember([FromBody] AddPoolMemberDto dto)
        {
            try
            {
                bool exists = await _context.InterviewPoolMembers.AnyAsync(x =>
                    x.InterviewPoolId == dto.InterviewPoolId &&
                    x.EmployeeId == dto.EmployeeId &&
                    x.IsActive);

                if (exists)
                    return Json(new
                    {
                        success = false,
                        message = "Employee already exists in this Interview Pool."
                    });

                var member = new InterviewPoolMember
                {
                    InterviewPoolId = dto.InterviewPoolId,
                    EmployeeId = dto.EmployeeId,
                    Priority = dto.Priority,
                    DailyCapacity = dto.DailyCapacity,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = GetCurrentEmployeeId()
                };

                _context.InterviewPoolMembers.Add(member);

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Member added successfully."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemovePoolMember(int memberId)
        {
            try
            {
                var member = await _context.InterviewPoolMembers
                    .FirstOrDefaultAsync(x => x.InterviewPoolMemberId == memberId);

                if (member == null)
                    return Json(new
                    {
                        success = false,
                        message = "Member not found."
                    });

                member.IsActive = false;
                member.ModifiedOn = DateTime.Now;
                member.ModifiedBy = GetCurrentEmployeeId();

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Member removed successfully."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}