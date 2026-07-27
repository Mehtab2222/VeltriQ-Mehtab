namespace VeltriQ.ViewModels.Recruitment
{
    public class MyPendingAvailabilityViewModel
    {
        public int AvailabilityRequestId { get; set; }
        public string RoundTypeName { get; set; } = string.Empty;
        public DateTime TargetDate { get; set; }
        public DateTime ReplyDeadline { get; set; }
        public List<SlotOptionViewModel> Slots { get; set; } = new();
        public bool AlreadyResponded { get; set; }
    }

    public class SlotOptionViewModel
    {
        public int AvailabilitySlotId { get; set; }
        public DateTime SlotDateTime { get; set; }
        public bool IsSelectedByMe { get; set; }
    }

    public class SubmitAvailabilityResponseDto
    {
        public int AvailabilityRequestId { get; set; }
        public List<int> SelectedSlotIds { get; set; } = new();
    }
}