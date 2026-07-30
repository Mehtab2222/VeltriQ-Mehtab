using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Helpers;
using VeltriQ.Models.Core;
using VeltriQ.Models.Recruitment;
using VeltriQ.Models.Recruitment.VeltriQ.ViewModels.Recruitment;
using VeltriQ.ViewModels.Recruitment;

namespace VeltriQ.Controllers
{
    [Authorize]
    public class AvailabilityController : BaseController
    {
        private readonly TenantDbContext _context;

        public AvailabilityController(
            TenantDbContext context,
            MasterDbContext masterDbContext,
            UserManager<ApplicationUser> userManager)
            : base(context, masterDbContext, userManager)
        {
            _context = context;
        }

        // stageMapping = "Screening" or "Evaluating" — matches RoundType.StageMapping
        [HttpGet]
        public async Task<IActionResult> GetRoundTypesForStage(string stageMapping)
        {
            try
            {
                var data = await _context.RoundTypes
                    .Where(x => x.IsActive && x.StageMapping == stageMapping)
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x => new { x.RoundTypeId, x.RoundTypeName })
                    .ToListAsync();

                return Json(new { success = true, data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPoolsForRoundType(int roundTypeId)
        {
            try
            {
                var data = await _context.InterviewPools
                    .Where(x => x.IsActive && x.RoundTypeId == roundTypeId)
                    .Select(x => new
                    {
                        x.InterviewPoolId,
                        x.PoolName,
                        MemberCount = _context.InterviewPoolMembers.Count(m => m.InterviewPoolId == x.InterviewPoolId && m.IsActive)
                    })
                    .ToListAsync();

                return Json(new { success = true, data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // Tells the Hiring page dropdown whether to show "Request Availability" or "Poll already sent"
        [HttpGet]
        public async Task<IActionResult> GetStagePollStatus(string stageMapping)
        {
            try
            {
                var openRequest = await _context.AvailabilityRequests
                    .Include(x => x.RoundType)
                    .Include(x => x.InterviewPool)
                    .Where(x => x.IsActive
                             && x.Status == AvailabilityRequestStatus.Open
                             && x.RoundType != null
                             && x.RoundType.StageMapping == stageMapping)
                    .OrderByDescending(x => x.AvailabilityRequestId)
                    .FirstOrDefaultAsync();

                if (openRequest == null)
                    return Json(new { success = true, data = new StagePollStatusViewModel { HasOpenRequest = false } });

                var memberCount = await _context.InterviewPoolMembers
                    .CountAsync(m => m.InterviewPoolId == openRequest.InterviewPoolId && m.IsActive);

                var result = new StagePollStatusViewModel
                {
                    HasOpenRequest = true,
                    AvailabilityRequestId = openRequest.AvailabilityRequestId,
                    RoundTypeName = openRequest.RoundType?.RoundTypeName,
                    TargetDate = openRequest.TargetDate,
                    ReplyDeadline = openRequest.ReplyDeadline,
                    PoolMemberCount = memberCount
                };

                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAvailabilityRequest([FromBody] CreateAvailabilityRequestDto dto)
        {
            try
            {
                if (dto.SlotTimes == null || !dto.SlotTimes.Any())
                    return Json(new { success = false, message = "Please offer at least one time slot." });

                var roundType = await _context.RoundTypes.FirstOrDefaultAsync(x => x.RoundTypeId == dto.RoundTypeId && x.IsActive);
                if (roundType == null)
                    return Json(new { success = false, message = "Round type not found." });

                // Prevent duplicate open polls for the same stage mapping
                var alreadyOpen = await _context.AvailabilityRequests
                    .Include(x => x.RoundType)
                    .AnyAsync(x => x.IsActive && x.Status == AvailabilityRequestStatus.Open
                                && x.RoundType != null && x.RoundType.StageMapping == roundType.StageMapping);

                if (alreadyOpen)
                    return Json(new { success = false, message = "An availability poll is already open for this stage." });

                var currentEmployeeId = GetCurrentEmployeeId();

                var request = new AvailabilityRequest
                {
                    RoundTypeId = dto.RoundTypeId,
                    InterviewPoolId = dto.InterviewPoolId,
                    TargetDate = dto.TargetDate.Date,
                    ReplyDeadline = dto.ReplyDeadline,
                    Status = AvailabilityRequestStatus.Open,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                    CreatedBy = currentEmployeeId
                };

                _context.AvailabilityRequests.Add(request);
                await _context.SaveChangesAsync();

                foreach (var timeStr in dto.SlotTimes)
                {
                    if (!TimeSpan.TryParse(timeStr, out var time)) continue;

                    _context.AvailabilitySlots.Add(new AvailabilitySlot
                    {
                        AvailabilityRequestId = request.AvailabilityRequestId,
                        SlotDateTime = dto.TargetDate.Date.Add(time),
                        IsActive = true,
                        CreatedOn = DateTime.Now
                    });
                }

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Availability poll sent to the pool." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        // Shows on the employee's own dashboard — only open polls where THEY are a pool member
        // and the deadline hasn't passed yet.
        [HttpGet]
        public async Task<IActionResult> GetMyPendingAvailabilityRequests()
        {
            try
            {
                var employeeId = GetCurrentEmployeeId();
                if (employeeId == null)
                    return Json(new { success = false, message = "Unable to identify the current employee." });

                var now = DateTime.Now;

                var myPoolIds = await _context.InterviewPoolMembers
                    .Where(x => x.EmployeeId == employeeId.Value && x.IsActive)
                    .Select(x => x.InterviewPoolId)
                    .ToListAsync();

                var openRequests = await _context.AvailabilityRequests
                    .Include(x => x.RoundType)
                    .Include(x => x.Slots)
                    .Where(x => x.IsActive
                             && x.Status == AvailabilityRequestStatus.Open
                             && myPoolIds.Contains(x.InterviewPoolId)
                             && x.ReplyDeadline >= now)
                    .OrderBy(x => x.ReplyDeadline)
                    .ToListAsync();

                var requestIds = openRequests.Select(x => x.AvailabilityRequestId).ToList();

                var myResponses = await _context.AvailabilitySlotResponses
                    .Include(x => x.AvailabilitySlot)
                    .Where(x => x.EmployeeId == employeeId.Value
                             && x.IsActive
                             && x.AvailabilitySlot != null
                             && requestIds.Contains(x.AvailabilitySlot.AvailabilityRequestId))
                    .ToListAsync();

                var result = openRequests.Select(req =>
                {
                    var respondedSlotIds = myResponses
                        .Where(r => r.AvailabilitySlot!.AvailabilityRequestId == req.AvailabilityRequestId)
                        .Select(r => r.AvailabilitySlotId)
                        .ToHashSet();

                    return new MyPendingAvailabilityViewModel
                    {
                        AvailabilityRequestId = req.AvailabilityRequestId,
                        RoundTypeName = req.RoundType?.RoundTypeName ?? "",
                        TargetDate = req.TargetDate,
                        ReplyDeadline = req.ReplyDeadline,
                        AlreadyResponded = respondedSlotIds.Any(),
                        Slots = req.Slots
                            .Where(s => s.IsActive)
                            .OrderBy(s => s.SlotDateTime)
                            .Select(s => new SlotOptionViewModel
                            {
                                AvailabilitySlotId = s.AvailabilitySlotId,
                                SlotDateTime = s.SlotDateTime,
                                IsSelectedByMe = respondedSlotIds.Contains(s.AvailabilitySlotId)
                            }).ToList()
                    };
                }).ToList();

                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitAvailabilityResponse([FromBody] SubmitAvailabilityResponseDto dto)
        {
            try
            {
                var employeeId = GetCurrentEmployeeId();
                if (employeeId == null)
                    return Json(new { success = false, message = "Unable to identify the current employee." });

                if (dto.SelectedSlotIds == null || !dto.SelectedSlotIds.Any())
                    return Json(new { success = false, message = "Please select at least one slot." });

                var request = await _context.AvailabilityRequests
                    .FirstOrDefaultAsync(x => x.AvailabilityRequestId == dto.AvailabilityRequestId && x.IsActive);

                if (request == null || request.Status != AvailabilityRequestStatus.Open)
                    return Json(new { success = false, message = "This availability request is no longer open." });

                // Remove any previous responses from this employee for this request, then re-add the current selection
                var slotIdsForRequest = await _context.AvailabilitySlots
                    .Where(s => s.AvailabilityRequestId == dto.AvailabilityRequestId)
                    .Select(s => s.AvailabilitySlotId)
                    .ToListAsync();

                var existingResponses = await _context.AvailabilitySlotResponses
                    .Where(r => r.EmployeeId == employeeId.Value && slotIdsForRequest.Contains(r.AvailabilitySlotId))
                    .ToListAsync();

                _context.AvailabilitySlotResponses.RemoveRange(existingResponses);

                foreach (var slotId in dto.SelectedSlotIds)
                {
                    if (!slotIdsForRequest.Contains(slotId)) continue; // ignore slot ids not belonging to this request

                    _context.AvailabilitySlotResponses.Add(new AvailabilitySlotResponse
                    {
                        AvailabilitySlotId = slotId,
                        EmployeeId = employeeId.Value,
                        RespondedOn = DateTime.Now,
                        IsActive = true
                    });
                }

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Availability submitted successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAssignConfirmData(int availabilityRequestId)
        {
            try
            {
                var request = await _context.AvailabilityRequests
                    .Include(x => x.RoundType)
                    .FirstOrDefaultAsync(x => x.AvailabilityRequestId == availabilityRequestId && x.IsActive);

                if (request == null || request.RoundType == null)
                    return Json(new { success = false, message = "Availability request not found." });

                // Capacity = every (slot, employee) response pair, minus ones already used by a scheduled interview
                var usedPairs = await _context.ScheduledInterviews
                    .Where(x => x.AvailabilityRequestId == availabilityRequestId && x.IsActive)
                    .Select(x => new { x.AvailabilitySlotId, x.InterviewerEmployeeId })
                    .ToListAsync();

                var responses = await _context.AvailabilitySlotResponses
                    .Include(x => x.AvailabilitySlot)
                    .Include(x => x.Employee)
                    .Where(x => x.IsActive
                             && x.AvailabilitySlot != null
                             && x.AvailabilitySlot.AvailabilityRequestId == availabilityRequestId)
                    .ToListAsync();

                var capacitySlots = responses
                    .Where(r => !usedPairs.Any(u => u.AvailabilitySlotId == r.AvailabilitySlotId && u.InterviewerEmployeeId == r.EmployeeId))
                    .OrderBy(r => r.AvailabilitySlot!.SlotDateTime)
                    .Select(r => new CapacitySlotViewModel
                    {
                        AvailabilitySlotId = r.AvailabilitySlotId,
                        EmployeeId = r.EmployeeId,
                        SlotDateTime = r.AvailabilitySlot!.SlotDateTime,
                        EmployeeName = r.Employee != null ? (r.Employee.FirstName + " " + (r.Employee.LastName ?? "")).Trim() : ""
                    })
                    .ToList();

                // Queue: candidates eligible for this stage, not already scheduled for this exact round
                var alreadyScheduledApplicantIds = await _context.ScheduledInterviews
                    .Where(x => x.RoundTypeId == request.RoundTypeId && x.IsActive && x.Status != ScheduledInterviewStatus.Cancelled)
                    .Select(x => x.ApplicantId)
                    .ToListAsync();

                var queueQuery = _context.Applicants
                    .Include(x => x.ManpowerRequest)
                    .Where(x => x.IsActive
                             && x.CurrentStage == (request.RoundType.StageMapping == "Screening" ? "Shortlisted" : "Evaluating")
                             && !alreadyScheduledApplicantIds.Contains(x.ApplicantId));

                var candidatePool = await queueQuery
                    .OrderByDescending(x => x.MatchPercentage)
                    .Select(x => new CandidateQueueItemViewModel
                    {
                        ApplicantId = x.ApplicantId,
                        FullName = (x.FirstName + " " + (x.LastName ?? "")).Trim(),
                        MprTitle = x.ManpowerRequest != null ? x.ManpowerRequest.JobTitle : "",
                        MatchPercentage = x.MatchPercentage
                    })
                    .ToListAsync();

                List<CandidateQueueItemViewModel> fullQueue;

                if (request.RoundType.StageMapping == "Evaluating")
                {
                    // Only include candidates whose NEXT required round is this exact round type —
                    // stops offering "Technical Round 2" to someone who hasn't done Round 1 yet.
                    fullQueue = new List<CandidateQueueItemViewModel>();
                    foreach (var candidate in candidatePool)
                    {
                        var nextRoundTypeId = await RoundSequenceHelper.GetNextRequiredRoundTypeIdAsync(_context, candidate.ApplicantId);
                        if (nextRoundTypeId == request.RoundTypeId)
                            fullQueue.Add(candidate);
                    }
                }
                else
                {
                    fullQueue = candidatePool;
                }

                var takeCount = capacitySlots.Count;
                var topQueue = fullQueue.Take(takeCount).ToList();

                var result = new AssignConfirmDataViewModel
                {
                    AvailabilityRequestId = availabilityRequestId,   // ← add this line
                    RoundTypeName = request.RoundType.RoundTypeName,
                    StageMapping = request.RoundType.StageMapping,
                    CapacitySlots = capacitySlots,
                    QueuedCandidates = topQueue,
                    RemainingInQueue = fullQueue.Count - topQueue.Count
                };

                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmAssignments([FromBody] ConfirmAssignmentsDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (dto.Assignments == null || !dto.Assignments.Any())
                    return Json(new { success = false, message = "No assignments to confirm." });

                var request = await _context.AvailabilityRequests
                    .Include(x => x.RoundType)
                    .FirstOrDefaultAsync(x => x.AvailabilityRequestId == dto.AvailabilityRequestId && x.IsActive);

                if (request == null || request.RoundType == null)
                    return Json(new { success = false, message = "Availability request not found." });

                var currentEmployeeId = GetCurrentEmployeeId();

                foreach (var pair in dto.Assignments)
                {
                    var alreadyUsed = await _context.ScheduledInterviews.AnyAsync(x =>
                        x.AvailabilitySlotId == pair.AvailabilitySlotId &&
                        x.InterviewerEmployeeId == pair.EmployeeId &&
                        x.IsActive);

                    if (alreadyUsed) continue; // skip silently — someone else already took this slot

                    _context.ScheduledInterviews.Add(new ScheduledInterview
                    {
                        ApplicantId = pair.ApplicantId,
                        AvailabilityRequestId = dto.AvailabilityRequestId,
                        AvailabilitySlotId = pair.AvailabilitySlotId,
                        InterviewerEmployeeId = pair.EmployeeId,
                        RoundTypeId = request.RoundTypeId,
                        Status = ScheduledInterviewStatus.Scheduled,
                        IsActive = true,
                        CreatedOn = DateTime.Now,
                        CreatedBy = currentEmployeeId
                    });

                    var applicant = await _context.Applicants.FirstOrDefaultAsync(x => x.ApplicantId == pair.ApplicantId);
                    if (applicant != null)
                    {
                        applicant.CurrentStage = request.RoundType.StageMapping;
                        applicant.StageChangedOn = DateTime.Now;
                        applicant.ModifiedOn = DateTime.Now;
                        applicant.ModifiedBy = currentEmployeeId;
                    }
                }

                request.Status = AvailabilityRequestStatus.Closed;
                request.ClosedOn = DateTime.Now;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Json(new { success = true, message = "Candidates scheduled and moved successfully." });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}