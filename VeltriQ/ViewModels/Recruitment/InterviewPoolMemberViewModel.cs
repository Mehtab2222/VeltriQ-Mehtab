namespace VeltriQ.ViewModels.Recruitment
{
    public class InterviewPoolMemberViewModel
    {
        public int InterviewPoolMemberId { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; } = "";

        public string EmployeeName { get; set; } = "";

        public string? DepartmentName { get; set; }

        public int Priority { get; set; }

        public int DailyCapacity { get; set; }
    }
}
