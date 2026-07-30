using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Models.Recruitment;

namespace VeltriQ.Helpers
{
    public static class RoundSequenceHelper
    {
        // Returns the next Evaluating RoundTypeId this applicant should go through,
        // or null if they've completed every active Evaluating round (ready for Offer).
        public static async Task<int?> GetNextRequiredRoundTypeIdAsync(TenantDbContext context, int applicantId)
        {
            var sequence = await context.RoundTypes
                .Where(x => x.IsActive && x.StageMapping == "Evaluating")
                .OrderBy(x => x.DisplayOrder)
                .Select(x => x.RoundTypeId)
                .ToListAsync();

            if (!sequence.Any()) return null; // no Evaluating rounds configured at all

            var completedRoundTypeIds = await context.ScheduledInterviews
                .Where(x => x.ApplicantId == applicantId
                         && x.IsActive
                         && x.Status == ScheduledInterviewStatus.Completed)
                .Select(x => x.RoundTypeId)
                .ToListAsync();

            foreach (var roundTypeId in sequence)
            {
                if (!completedRoundTypeIds.Contains(roundTypeId))
                    return roundTypeId;
            }

            return null; // every round in the sequence is done
        }

        // Batched version — for rendering a "Current Round" column across many candidates at once
        public static async Task<Dictionary<int, string?>> GetCurrentRoundLabelsAsync(TenantDbContext context, List<int> applicantIds)
        {
            var sequence = await context.RoundTypes
                .Where(x => x.IsActive && x.StageMapping == "Evaluating")
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            var result = new Dictionary<int, string?>();
            if (!sequence.Any() || !applicantIds.Any()) return result;

            var completedByApplicant = await context.ScheduledInterviews
                .Where(x => applicantIds.Contains(x.ApplicantId) && x.IsActive && x.Status == ScheduledInterviewStatus.Completed)
                .GroupBy(x => x.ApplicantId)
                .Select(g => new { ApplicantId = g.Key, RoundTypeIds = g.Select(x => x.RoundTypeId).ToList() })
                .ToListAsync();

            var completedMap = completedByApplicant.ToDictionary(x => x.ApplicantId, x => x.RoundTypeIds);

            foreach (var applicantId in applicantIds)
            {
                var completed = completedMap.ContainsKey(applicantId) ? completedMap[applicantId] : new List<int>();
                var next = sequence.FirstOrDefault(r => !completed.Contains(r.RoundTypeId));

                result[applicantId] = next != null
                    ? $"{next.RoundTypeName} — Pending"
                    : "All rounds complete — Ready for Offer";
            }

            return result;
        }
    }
}