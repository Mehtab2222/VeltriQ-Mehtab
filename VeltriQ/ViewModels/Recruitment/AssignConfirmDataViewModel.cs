namespace VeltriQ.ViewModels.Recruitment
{
    public class CapacitySlotViewModel
    {
        public int AvailabilitySlotId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SlotDateTime { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
    }

    public class CandidateQueueItemViewModel
    {
        public int ApplicantId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string MprTitle { get; set; } = string.Empty;
        public int? MatchPercentage { get; set; }
    }

    public class AssignConfirmDataViewModel   // ← THIS is the one to edit
    {
        public int AvailabilityRequestId { get; set; }   // ← add this line here
        public string RoundTypeName { get; set; } = string.Empty;
        public string StageMapping { get; set; } = string.Empty;
        public List<CapacitySlotViewModel> CapacitySlots { get; set; } = new();
        public List<CandidateQueueItemViewModel> QueuedCandidates { get; set; } = new();
        public int RemainingInQueue { get; set; }
    }

    public class AssignmentPairDto
    {
        public int ApplicantId { get; set; }
        public int AvailabilitySlotId { get; set; }
        public int EmployeeId { get; set; }
    }

    public class ConfirmAssignmentsDto
    {
        public int AvailabilityRequestId { get; set; }
        public List<AssignmentPairDto> Assignments { get; set; } = new();
    }
}