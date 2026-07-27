namespace VeltriQ.Models.Recruitment
{
    namespace VeltriQ.ViewModels.Recruitment
    {
        public class CreateAvailabilityRequestDto
        {
            public int RoundTypeId { get; set; }
            public int InterviewPoolId { get; set; }
            public DateTime TargetDate { get; set; }
            public DateTime ReplyDeadline { get; set; }
            public List<string> SlotTimes { get; set; } = new(); // e.g. ["10:00","11:00","14:00"]
        }

        public class StagePollStatusViewModel
        {
            public bool HasOpenRequest { get; set; }
            public int? AvailabilityRequestId { get; set; }
            public string? RoundTypeName { get; set; }
            public DateTime? TargetDate { get; set; }
            public DateTime? ReplyDeadline { get; set; }
            public int PoolMemberCount { get; set; }
            // ResponseCount comes in Phase 4 — omitted for now
        }
    }
}
